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

    runDotnetNoTimeout "docs" """fable shell-run "..\node_modules\.bin\rollup -c rollup-config.js -w" """

Target "WatchDocs" watchDocs

Target "QuickWatchDocs" watchDocs

Target "BuildDocs" (fun _ ->
    runDotnet "docs" """fable shell-run "..\node_modules\.bin\rollup -c rollup-config.js" """
)

// --------------------------------------------------------------------------------------
// Build a NuGet package

Target "Package" (fun _ ->
    runDotnet "src" "pack"
)

Target "PublishNuget" (fun _ ->
    runDotnet "src" "push"
)

// --------------------------------------------------------------------------------------
// Generate the documentation
let gitName = "elmish"
let gitOwner = "fable-elmish"
let gitHome = sprintf "https://github.com/%s" gitOwner

// --------------------------------------------------------------------------------------
// Release Scripts

#load "paket-files/build/fsharp/FAKE/modules/Octokit/Octokit.fsx"
open Octokit

Target "Release" (fun _ ->
    let user =
        match getBuildParam "github-user" with
        | s when not (String.IsNullOrWhiteSpace s) -> s
        | _ -> getUserInput "Username: "
    let pw =
        match getBuildParam "github-pw" with
        | s when not (String.IsNullOrWhiteSpace s) -> s
        | _ -> getUserPassword "Password: "
    let remote =
        Git.CommandHelper.getGitResult "" "remote -v"
        |> Seq.filter (fun (s: string) -> s.EndsWith("(push)"))
        |> Seq.tryFind (fun (s: string) -> s.Contains(gitOwner + "/" + gitName))
        |> function None -> gitHome + "/" + gitName | Some (s: string) -> s.Split().[0]

    StageAll ""
    Git.Commit.Commit "" (sprintf "Bump version to %s" release.NugetVersion)
    Branches.pushBranch "" remote (Information.getBranchName "")

    Branches.tag "" release.NugetVersion
    Branches.pushTag "" remote release.NugetVersion

    // release on github
    createClient user pw
    |> createDraft gitOwner gitName release.NugetVersion (release.SemVer.PreRelease <> None) release.Notes
    |> releaseDraft
    |> Async.RunSynchronously
)

Target "Publish" DoNothing

// Build order
"Meta"
    // ==> "InstallDotNetCore"
    ==> "Clean"
    ==> "Install"
    ==> "Build"
    ==> "Package"

"Publish"
    <== [ "Build"
          "PublishNuget" ]
"Build"
    ==> "YarnInstall"
    ==> "InstallDocs"
    ==> "WatchDocs"

"Build"
    ==> "YarnInstall"
    ==> "InstallDocs"
    ==> "BuildDocs"

// start build
RunTargetOrDefault "Build"
