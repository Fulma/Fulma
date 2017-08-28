module Elements.Delete.State

open Elmish
open Types

let demoCode =
    """
```fsharp
    Delete.delete
        [ Delete.isSmall ] [ ]
    Delete.delete
        [ ] [ ]
    Delete.delete
        [ Delete.isMedium ] [ ]
    Delete.delete
        [ Delete.isLarge ] [ ]
```
    """

let extraCode =
    """
```fsharp
    // Using Button.onClick helper
    Delete.delete
        [ Delete.onClick (fun _ -> Click |> dispatch) ] [ ]
    // Is equivalent to:
    Delete.delete
        [ Delete.props [ OnClick (fun _ -> Click |> dispatch) ] ] [ ]
```
    """

let init() =
    { Intro =
        """
# Delete

The **delete** element can have different sizes.

*[Bulma documentation](http://bulma.io/documentation/elements/delete/)*
        """
      DemoViewer = Viewer.State.init demoCode
      ExtraViewer = Viewer.State.init extraCode
      Clicked = false }

let update msg model =
    match msg with
    | DemoViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.DemoViewer
        { model with DemoViewer = viewer }, Cmd.map DemoViewerMsg viewerMsg

    | ExtraViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ExtraViewer
        { model with ExtraViewer = viewer }, Cmd.map ExtraViewerMsg viewerMsg

    | Click ->
        { model with Clicked = true }, Cmd.none
