#r "nuget: Fun.Build, 0.3.7"
#r "nuget: Fake.IO.FileSystem, 6.0.0"
#r "nuget: BlackFox.CommandLine, 1.0.0"
#r "nuget: Fake.Core.ReleaseNotes, 6.0.0"
#r "nuget: FsToolkit.ErrorHandling, 4.3.0"

open Fun.Build
open System
open System.IO
open System.Text.RegularExpressions
open Fake.Core
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open BlackFox.CommandLine
open FsToolkit.ErrorHandling


module Util =

    let visitFile (visitor: string->string) (fileName: string) =
        File.ReadAllLines(fileName)
        |> Array.map (visitor)
        |> fun lines -> File.WriteAllLines(fileName, lines)

    let replaceLines (replacer: string->Match->string option) (reg: Regex) (fileName: string) =
        fileName |> visitFile (fun line ->
            let m = reg.Match(line)
            if not m.Success
            then line
            else
                match replacer line m with
                | None -> line
                | Some newLine -> newLine)

// Build a NuGet package
let needsPublishing (versionRegex: Regex) (releaseNotes: ReleaseNotes.ReleaseNotes) projFile =
    printfn "Project: %s" projFile
    if releaseNotes.NugetVersion.ToUpper().EndsWith("NEXT")
    then
        printfn "Version in Release Notes ends with NEXT, don't publish yet."
        false
    else
        File.ReadLines(projFile)
        |> Seq.tryPick (fun line ->
            let m = versionRegex.Match(line)
            if m.Success then Some m else None)
        |> function
            | None -> failwith "Couldn't find version in project file"
            | Some m ->
                let sameVersion = m.Groups.[1].Value = releaseNotes.NugetVersion
                if sameVersion then
                    printfn "Already version %s, no need to publish." releaseNotes.NugetVersion
                not sameVersion

let toPackageReleaseNotes (notes: string list) =
    String.Join("\n * ", notes)
    |> (fun txt -> txt.Replace("\"", "\\\""))

let createPublishNugetStageForProject (projectFile : string) =
    let projectDir = IO.Path.GetDirectoryName(projectFile)

    stage $"Publish NuGet for {projectFile}" {
        workingDir projectDir

        run (fun ctx -> asyncResult {
            let nugetKey = ctx.GetEnvVar "NUGET_KEY"
            let releaseNotes = projectDir </> "RELEASE_NOTES.md" |> ReleaseNotes.load
            let versionRegex = Regex("<Version>(.*?)</Version>", RegexOptions.IgnoreCase)

            do! ctx.RunCommand "pwd"

            if needsPublishing versionRegex releaseNotes projectFile then
                (versionRegex, projectFile)
                ||> Util.replaceLines (fun line _ ->
                    versionRegex.Replace(line, "<Version>"+releaseNotes.NugetVersion+"</Version>")
                    |> Some
                )

                let! dotnetPackOutput =
                    CmdLine.empty
                    |> CmdLine.appendRaw "dotnet"
                    |> CmdLine.appendRaw "pack"
                    |> CmdLine.appendPrefix "-c" "Release"
                    |> CmdLine.appendRaw $"""/p:PackageReleaseNotes="{toPackageReleaseNotes releaseNotes.Notes}" """
                    |> CmdLine.toString
                    |> ctx.RunCommandCaptureOutput

                let m = Regex.Match(dotnetPackOutput, ".*'(?<nupkg_path>.*\.(?<version>.*\..*\..*)\.nupkg)'")

                if not m.Success then
                    failwithf "Couldn't find NuGet package in output: %s" dotnetPackOutput

                let nupkgPath = m.Groups.["nupkg_path"].Value

                do! CmdLine.empty
                    |> CmdLine.appendRaw "dotnet"
                    |> CmdLine.appendRaw "nuget"
                    |> CmdLine.appendRaw "push"
                    |> CmdLine.appendRaw nupkgPath
                    |> CmdLine.appendPrefix "--api-key" nugetKey
                    |> CmdLine.appendPrefix "--source" "nuget.org"
                    |> CmdLine.toString
                    |> ctx.RunCommand
        }
        )
    }

pipeline "Docs" {

    stage "Install dependencies" {
        run "npx yarn install"
    }

    stage "Watch" {
        whenCmd {
            name "--watch"
            alias "-w"
            description "Watch for changes and rebuild"
        }

        workingDir "docs"

        run (
            CmdLine.empty
            |> CmdLine.appendRaw "npx"
            |> CmdLine.appendRaw "webpack-dev-server"
            |> CmdLine.toString
        )
    }

    stage "Build" {
        whenNot {
            whenCmd {
                name "--watch"
                alias "-w"
                description "Watch for changes and rebuild"
            }
        }

        workingDir "docs"

        run (
            CmdLine.empty
            |> CmdLine.appendRaw "npx"
            |> CmdLine.appendRaw "webpack"
            |> CmdLine.toString
        )
    }

    runIfOnlySpecified

}

pipeline "Publish" {

    whenEnvVar "NUGET_KEY"

    stage "Clean" {
        run (fun _ ->
            !! "docs/**/bin"
            ++ "docs/**/obj"
            ++ "src/**/bin"
            ++ "src/**/obj"
            |> Seq.iter Shell.cleanDir
        )
    }

    stage "Install dependencies" {
        run "npx yarn install"
    }

    // stage "Build documentation" {
    //     workingDir "docs"

    //     run (
    //         CmdLine.empty
    //         |> CmdLine.appendRaw "npx"
    //         |> CmdLine.appendRaw "webpack"
    //         |> CmdLine.toString
    //     )
    // }

    // stage "Publis documentation" {
    //     workingDir "docs"

    //     run (
    //         CmdLine.empty
    //         |> CmdLine.appendRaw "npx"
    //         |> CmdLine.appendRaw "gh-pages"
    //         |> CmdLine.appendPrefix "-d" "docs/public/"
    //         |> CmdLine.toString
    //     )
    // }

    stage "Publish packages" {

        createPublishNugetStageForProject "src/Fable.FontAwesome/Fable.FontAwesome.fsproj"
        createPublishNugetStageForProject "src/Fable.FontAwesome.Free/Fable.FontAwesome.Free.fsproj"
        createPublishNugetStageForProject "src/Fable.FontAwesome.Pro/Fable.FontAwesome.Pro.fsproj"
        createPublishNugetStageForProject "src/Fulma/Fulma.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Calendar/Fulma.Extensions.Wikiki.Calendar.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Checkradio/Fulma.Extensions.Wikiki.Checkradio.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Divider/Fulma.Extensions.Wikiki.Divider.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.PageLoader/Fulma.Extensions.Wikiki.PageLoader.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Quickview/Fulma.Extensions.Wikiki.Quickview.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Slider/Fulma.Extensions.Wikiki.Slider.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Switch/Fulma.Extensions.Wikiki.Switch.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Tooltip/Fulma.Extensions.Wikiki.Tooltip.fsproj"
        createPublishNugetStageForProject "src/Fulma.Extensions.Wikiki.Timeline/Fulma.Extensions.Wikiki.Timeline.fsproj"
        createPublishNugetStageForProject "src/Fulma.Elmish/Fulma.Elmish.fsproj"

    }


    runIfOnlySpecified

}

tryPrintPipelineCommandHelp ()
