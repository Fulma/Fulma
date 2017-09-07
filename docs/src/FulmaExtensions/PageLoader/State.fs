module FulmaExtensions.PageLoader.State

open Elmish
open Types
open Fable.Import.Browser
open Fulma.Common


let normalCode =
    """
```fsharp
    // Timeout to close the loader, dispatch IsLoaded
    if isloading then 
        window.setTimeout(  (fun _ -> dispatch IsLoadedMsg) , 3000 , [] ) |> ignore

    // On click dispatch IsLoading with the specified color
    Button.button [ Button.isPrimary; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsPrimary))] [str "Show loader"]

    // PageLoader will be active only then is loading 
    PageLoader.pageLoader [ if isloading then 
                                    yield PageLoader.isActive 
                            yield match color with
                                    | IsBlack ->  PageLoader.isBlack
                                    | IsDanger -> PageLoader.isDanger
                                    | IsDark ->   PageLoader.isDark
                                    | IsInfo ->   PageLoader.isInfo
                                    | IsLight ->  PageLoader.isLight
                                    | IsPrimary ->PageLoader.isPrimary
                                    | IsSuccess ->PageLoader.isSuccess
                                    | IsWarning ->PageLoader.isWarning
                                    | IsWhite ->  PageLoader.isWhite
                          ]
                          []
```
    """

let intro =
        """
# Page-Loader

Display a **page-loader** to inform user that content is loading, in different colors.

*[documentation](https://wikiki.github.io/bulma-extensions/pageloader)*
        """

let init() =
    { Viewer = Viewer.State.init normalCode
      Intro = intro
      IsLoading = false, IsPrimary
    }

let update msg model =
    match msg with
    | ViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.Viewer
        { model with Viewer = viewer }, Cmd.map ViewerMsg viewerMsg
    | IsLoadingMsg color ->
        { model with IsLoading = true, color }, Cmd.none
    | IsLoadedMsg ->
        let (_, color) = model.IsLoading
        { model with IsLoading = (false, color) }, Cmd.none