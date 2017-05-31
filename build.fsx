// include Fake libs
#r "./packages/build/FAKE/tools/FakeLib.dll"
#r "System.IO.Compression.FileSystem"

open System
open System.IO
open Fake
open Fake.NpmHelper
open Fake.ReleaseNotesHelper
open Fake.Git


// Filesets
let projects  =
      !! "src/**.fsproj"

let dotnetcliVersion = "1.0.1"
let mutable dotnetExePath = "./dotnetsdk/dotnet"

let runDotnet workingDir args =
    printfn "CWD: %s" workingDir
    // printfn "dotnet %s" args
    let result =
        ExecProcess (fun info ->
            info.FileName <- dotnetExePath
            info.WorkingDirectory <- workingDir
            info.Arguments <- args) TimeSpan.MaxValue
    if result <> 0 then failwithf "Command failed: dotnet %s" args


Target "InstallDotNetCore" (fun _ ->
    let dotnetSDKPath = FullName "./dotnetsdk"
    let correctVersionInstalled =
        try
            let processResult =
                ExecProcessAndReturnMessages (fun info ->
                info.FileName <- dotnetExePath
                info.WorkingDirectory <- Environment.CurrentDirectory
                info.Arguments <- "--version") (TimeSpan.FromMinutes 30.)

            processResult.Messages |> separated "" = dotnetcliVersion
        with
        | _ -> false

    if correctVersionInstalled then
        tracefn "dotnetcli %s already installed" dotnetcliVersion
    else
        CleanDir dotnetSDKPath
        let archiveFileName =
            if isWindows then
                sprintf "dotnet-dev-win-x64.%s.zip" dotnetcliVersion
            elif isLinux then
                sprintf "dotnet-dev-ubuntu-x64.%s.tar.gz" dotnetcliVersion
            else
                sprintf "dotnet-dev-osx-x64.%s.tar.gz" dotnetcliVersion
        let downloadPath =
                sprintf "https://dotnetcli.azureedge.net/dotnet/Sdk/%s/%s" dotnetcliVersion archiveFileName
        let localPath = Path.Combine(dotnetSDKPath, archiveFileName)

        tracefn "Installing '%s' to '%s'" downloadPath localPath

        use webclient = new Net.WebClient()
        webclient.DownloadFile(downloadPath, localPath)

        if not isWindows then
            let assertExitCodeZero x =
                if x = 0 then () else
                failwithf "Command failed with exit code %i" x

            Shell.Exec("tar", sprintf """-xvf "%s" -C "%s" """ localPath dotnetSDKPath)
            |> assertExitCodeZero
        else
            Compression.ZipFile.ExtractToDirectory(localPath, dotnetSDKPath)

        tracefn "dotnet cli path - %s" dotnetSDKPath
        System.IO.Directory.EnumerateFiles dotnetSDKPath
        |> Seq.iter (fun path -> tracefn " - %s" path)
        System.IO.Directory.EnumerateDirectories dotnetSDKPath
        |> Seq.iter (fun path -> tracefn " - %s%c" path System.IO.Path.DirectorySeparatorChar)

        dotnetExePath <- dotnetSDKPath </> (if isWindows then "dotnet.exe" else "dotnet")
)


Target "Install" (fun _ ->
    projects
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "restore"
    )
)

Target "Build" (fun _ ->
    projects
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "build")
)

Target "Clean" (fun _ ->
  seq [
    "src/bin"
    "src/obj"
  ] |> CleanDirs
)

Target "QuickBuild" (fun _ ->
    projects
    |> Seq.iter (fun s ->
        let dir = IO.Path.GetDirectoryName s
        runDotnet dir "build")
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

let fakePath = "packages" </> "build" </> "FAKE" </> "tools" </> "FAKE.exe"
let fakeStartInfo script workingDirectory args fsiargs environmentVars =
    (fun (info: System.Diagnostics.ProcessStartInfo) ->
        info.FileName <- System.IO.Path.GetFullPath fakePath
        info.Arguments <- sprintf "%s --fsiargs -d:FAKE %s \"%s\"" args fsiargs script
        info.WorkingDirectory <- workingDirectory
        let setVar k v =
            info.EnvironmentVariables.[k] <- v
        for (k, v) in environmentVars do
            setVar k v
        setVar "MSBuild" msBuildExe
        setVar "GIT" Git.CommandHelper.gitPath
        setVar "FSI" fsiPath)

/// Run the given buildscript with FAKE.exe
let executeFAKEWithOutput workingDirectory script fsiargs envArgs =
    let exitCode =
        ExecProcessWithLambdas
            (fakeStartInfo script workingDirectory "" fsiargs envArgs)
            TimeSpan.MaxValue false ignore ignore
    System.Threading.Thread.Sleep 1000
    exitCode

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
  ==> "InstallDotNetCore"
  ==> "Clean"
  ==> "Install"
  ==> "Build"
  ==> "Package"

"Publish"
  <== [ "Build"
        "PublishNuget" ]


// start build
RunTargetOrDefault "Build"
