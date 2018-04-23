#r "paket: groupref netcorebuild //"
#load ".fake/build.fsx/intellisense.fsx"

#nowarn "52"

open System
open System.IO
open System.Text.RegularExpressions
open Fake.Core
open Fake.Core.TargetOperators
open Fake.DotNet
open Fake.IO
open Fake.IO.Globbing.Operators
open Fake.IO.FileSystemOperators
open Fake.Tools.Git
open Fake.Core.Environment

module Util =

    let visitFile (visitor: string->string) (fileName : string) =
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

let platformTool tool =
    Process.tryFindFileOnPath tool
    |> function Some t -> t | _ -> failwithf "%s not found" tool

let run (cmd:string) dir args  =
    if Process.execSimple (fun info ->
        { info with
            FileName = cmd
            WorkingDirectory =
                if not (String.IsNullOrWhiteSpace dir) then dir else info.WorkingDirectory
            Arguments = args
        }
    ) TimeSpan.MaxValue <> 0 then
        failwithf "Error while running '%s' with args: %s " cmd args

let yarnTool = platformTool "yarn"

let yarn = run yarnTool "./"

Target.create "Clean" (fun _ ->
    !! "docs/**/bin"
    ++ "docs/**/obj"
    ++ "src/**/bin"
    ++ "src/**/obj"
    ++ "templates/**/bin"
    ++ "templates/**/obj"
    |> Seq.iter Shell.CleanDir
)

Target.create "Install" (fun _ ->
    !! "src/**/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        DotNet.restore id dir)
)

Target.create "Build" (fun _ ->
    !! "src/**/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        DotNet.build id dir)
)

Target.create "QuickBuild" (fun _ ->
    !! "src/**/*.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        DotNet.build id dir)
)

Target.create "YarnInstall" (fun _ ->
    yarn "install"
)

// --------------------------------------------------------------------------------------
// Docs targets

Target.create "InstallDocs" (fun _ ->
    !! "docs/**.fsproj"
    |> Seq.iter(fun s ->
        let dir = IO.Path.GetDirectoryName s
        DotNet.restore id dir)
)

let watchDocs _ =
    let result =
        DotNet.exec
            (DotNet.Options.withWorkingDirectory "docs")
            "fable"
            "webpack-dev-server --port free"

    if not result.OK then failwithf "dotnet fable failed with code %i" result.ExitCode


Target.create "WatchDocs" watchDocs

Target.create "QuickWatchDocs" watchDocs

Target.create "BuildDocs" (fun _ ->
    DotNet.exec
        (DotNet.Options.withWorkingDirectory "docs")
        "fable"
        "webpack --port free -- -p"
    |> ignore
)

Target.create "BuildPlugin" (fun _ ->
    DotNet.build
        (fun p ->
            { p with Configuration = DotNet.BuildConfiguration.Release } )
        "docs/Plugins"
)

// --------------------------------------------------------------------------------------
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
    "* " + String.Join("\n * ", notes)
    |> (fun txt -> txt.Replace("\"", "\\\""))

let pushNuget (releaseNotes: ReleaseNotes.ReleaseNotes) (projFile: string) =
    let versionRegex = Regex("<Version>(.*?)</Version>", RegexOptions.IgnoreCase)

    if needsPublishing versionRegex releaseNotes projFile then
        let projDir = Path.GetDirectoryName(projFile)
        let nugetKey =
            match environVarOrNone "NUGET_KEY" with
            | Some nugetKey -> nugetKey
            | None -> failwith "The Nuget API key must be set in a NUGET_KEY environmental variable"
        (versionRegex, projFile)
        ||> Util.replaceLines (fun line _ ->
                                    versionRegex.Replace(line, "<Version>"+releaseNotes.NugetVersion+"</Version>") |> Some)

        let result =
            DotNet.exec
                (DotNet.Options.withWorkingDirectory projDir)
                "pack"
                (sprintf "-c Release /p:PackageReleaseNotes=\"%s\"" (toPackageReleaseNotes releaseNotes.Notes))

        if not result.OK then failwithf "dotnet fable failed with code %i" result.ExitCode

        Directory.GetFiles(projDir </> "bin" </> "Release", "*.nupkg")
        |> Array.find (fun nupkg -> nupkg.Contains(releaseNotes.NugetVersion))
        |> (fun nupkg ->
            Paket.push (fun p -> { p with ApiKey = nugetKey
                                          WorkingDir = Path.getDirectory nupkg }))


Target.create "PublishNugets" (fun _ ->
    !! "src/Fulma/Fulma.fsproj"
    ++ "src/Fulma.Extensions/Fulma.Extensions.fsproj"
    ++ "src/Fulma.Elmish/Fulma.Elmish.fsproj"
    ++ "templates/Fable.Template.Fulma.Minimal.proj"
    |> Seq.iter(fun s ->
        let projFile = s
        let projDir = IO.Path.GetDirectoryName(projFile)
        let release = projDir </> "RELEASE_NOTES.md" |> ReleaseNotes.load
        pushNuget release projFile
    )
)

// Where to push generated documentation
let githubLink = "git@github.com:MangelMaxime/Fulma.git"
let publishBranch = "gh-pages"
let fableRoot   = __SOURCE_DIRECTORY__
let temp        = fableRoot </> "temp"
let docsOuput = fableRoot </> "docs" </> "public"

// --------------------------------------------------------------------------------------
// Release Scripts

Target.create "PublishDocs" (fun _ ->
  Shell.CleanDir temp
  Repository.cloneSingleBranch "" githubLink publishBranch temp

  Shell.CopyRecursive docsOuput temp true |> Trace.tracefn "%A"
  Staging.stageAll temp
  Commit.exec temp (sprintf "Update site (%s)" (DateTime.Now.ToShortDateString()))
  Branches.push temp
)

// Build order
"Clean"
    ==> "Install"
    ==> "Build"
    ==> "PublishNugets"

"Build"
    ==> "YarnInstall"
    ==> "InstallDocs"
    ==> "BuildPlugin"
    ==> "WatchDocs"

"Build"
    ==> "YarnInstall"
    ==> "InstallDocs"
    ==> "BuildPlugin"
    ==> "BuildDocs"
    ==> "PublishDocs"

// start build
Target.runOrDefault "Build"
