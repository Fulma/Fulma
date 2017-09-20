module FulmaExtensions.PageLoader.State

open Elmish
open Types
open Fable.Import.Browser
open Fulma.Common


let normalCode =
    """
```fsharp
PageLoader.pageLoader
    [ yield PageLoader.isDanger // Set the color of the page loader
      if model.IsLoading then // If we are in loading state, make the loader active
        yield PageLoader.isActive ]
            [ ]
```
    """

let intro =
        """
# Page-loader

Display a **page-loader** to inform user that content is loading, in different colors.

*[Documentation](https://wikiki.github.io/bulma-extensions/pageloader)*

## Npm packages

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Version</th>
            <th>CLI</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>`yarn add bulma bulma-pageloader`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-pageloader@0.0.2`</td>
        </tr>
    </tbody>
<table>
        """

let init() =
    { Viewer = Viewer.State.init normalCode
      Intro = intro
      IsLoading = false
      Color = IsPrimary }

let fakeNetworkRequest _ =
    async {
        do! Async.Sleep 3000
    }

let update msg model =
    match msg with
    | ViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.Viewer
        { model with Viewer = viewer }, Cmd.map ViewerMsg viewerMsg

    | IsLoadingMsg color ->
        { model with IsLoading = true
                     Color = color }, Cmd.ofAsync fakeNetworkRequest () FakeRequestSuccess FakeRequestError

    | FakeRequestSuccess _ | FakeRequestError _ ->
        { model with IsLoading = false }, Cmd.none
