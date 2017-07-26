// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"

open System
open System.IO
open Fake
open Fake.NpmHelper
open Fake.ReleaseNotesHelper
open Fake.Git
open Fake.YarnHelper


let dotnetcliVersion = "1.0.1"
let mutable dotnetExePath = "dotnet"


let runDotnet dir =
    DotNetCli.RunCommand (fun p -> { p with ToolPath = dotnetExePath
                                            WorkingDir = dir
                                            TimeOut =  TimeSpan.FromHours 12. } )
                                            // Extra timeout allow us to run watch mode
                                            // Otherwise, the process is stopped every 30 minutes by default

Target "InstallDotNetCore" (fun _ ->
   dotnetExePath <- DotNetCli.InstallDotNetSDK dotnetcliVersion
)

Target "Clean" (fun _ ->
  seq [
    "src/bin"
    "src/obj"
    "docs/bin"
    "docs/obj"
  ] |> CleanDirs
)

Target "Install" (fun _ ->
    !! "src/**.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "restore")
)

Target "Build" (fun _ ->
    !! "src/**.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "build")
)

Target "QuickBuild" (fun _ ->
    !! "src/**.fsproj"
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "build")
)

Target "YarnInstall" (fun _ ->
    Yarn (fun p ->
    { p with
        Command = Install Standard
    })
)

let release = LoadReleaseNotes "RELEASE_NOTES.md"

Target "Meta" (fun _ ->
    [ "<Project xmlns=\"http://schemas.microsoft.com/developer/msbuild/2003\">"
      "<PropertyGroup>"
      "<Description>Helpers around Bulma for Elmish apps</Description>"
      "<PackageProjectUrl>https://github.com/MangelMaxime/Fable.Elmish.Bulma</PackageProjectUrl>"
      "<PackageLicenseUrl>https://github.com/MangelMaxime/Fable.Elmish.Bulma/blob/master/LICENSE.md</PackageLicenseUrl>"
      "<PackageIconUrl></PackageIconUrl>"
      "<RepositoryUrl>https://github.com/MangelMaxime/Fable.Elmish.Bulma</RepositoryUrl>"
      "<PackageTags>fable;elm;fsharp;bulma</PackageTags>"
      "<Authors>Maxime Mangel</Authors>"
      sprintf "<Version>%s</Version>" (string release.SemVer)
      "</PropertyGroup>"
      "</Project>"]
    |> WriteToFile false "Meta.props"
)

// --------------------------------------------------------------------------------------
// Docs targets

Target "InstallDocs" (fun _ ->
    !! "docs/**.fsproj"
    |> Seq.iter(fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "restore")
)

let watchDocs _ =
    let runDotnetNoTimeout workingDir =
        DotNetCli.RunCommand (fun p -> { p with ToolPath = dotnetExePath
                                                WorkingDir = workingDir
                                                TimeOut =  TimeSpan.FromDays 1. } ) // Really big timeout as we use a watcher

    runDotnetNoTimeout "docs" "fable node-run ../node_modules/rollup/bin/rollup --port free -- -c rollup-config.js -w"

Target "WatchDocs" watchDocs

Target "QuickWatchDocs" watchDocs

Target "BuildDocs" (fun _ ->
    runDotnet "docs" "fable node-run ../node_modules/rollup/bin/rollup --port free -- -c rollup-config.js"
)

// --------------------------------------------------------------------------------------
// Build a NuGet package

Target "Package" (fun _ ->
    runDotnet "src" "restore"
    runDotnet "src" "pack -c Release"
)

Target "PublishNuget" (fun _ ->
    let nugetKey =
        match environVarOrNone "NUGET_KEY" with
        | Some nugetKey -> nugetKey
        | None -> failwith "The Nuget API key must be set in a NUGET_KEY environmental variable"

    Directory.GetFiles("src" </> "bin" </> "Release", "*.nupkg")
    |> Array.find(fun nupkg -> nupkg.Contains(release.NugetVersion))
    |> (fun nupkg ->
            (Path.GetFullPath nupkg, nugetKey)
            ||> sprintf "nuget push %s -s nuget.org -k %s"
            |> runDotnet "src"
    )
)


// --------------------------------------------------------------------------------------
// Generate the documentation
let gitName = "Fable.Elmish.Bulma"
let gitOwner = "MangelMaxime"
let gitHome = sprintf "https://github.com/%s" gitOwner


// Where to push generated documentation
let githubLink = "git@github.com:MangelMaxime/Fable.Elmish.Bulma.git"
let publishBranch = "gh-pages"
let fableRoot   = __SOURCE_DIRECTORY__
let temp        = fableRoot </> "temp"
let docsOuput = fableRoot </> "docs" </> "public"
// --------------------------------------------------------------------------------------
// Release Scripts

#load "paket-files/build/fsharp/FAKE/modules/Octokit/Octokit.fsx"
open Octokit


Target "PublishDocs" (fun _ ->
  CleanDir temp
  Repository.cloneSingleBranch "" githubLink publishBranch temp

  CopyRecursive docsOuput temp true |> tracefn "%A"
  StageAll temp
  Git.Commit.Commit temp (sprintf "Update site (%s)" (DateTime.Now.ToShortDateString()))
  Branches.push temp
)

// Build order
"Meta"
    // ==> "InstallDotNetCore"
    ==> "Clean"
    ==> "Install"
    ==> "Build"
    ==> "Package"
    ==> "PublishNuget"

"Build"
    ==> "YarnInstall"
    ==> "InstallDocs"
    ==> "WatchDocs"

"Build"
    ==> "YarnInstall"
    ==> "InstallDocs"
    ==> "BuildDocs"
    ==> "PublishDocs"

// start build
RunTargetOrDefault "Build"
