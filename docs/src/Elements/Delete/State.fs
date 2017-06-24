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

let init() =
    { Intro =
        """
# Delete

The **delete** element can have different sizes.

*[Bulma documentation](http://bulma.io/documentation/elements/delete/)*
        """
      DemoViewer = Viewer.State.init demoCode }

let update msg model =
    match msg with
    | DemoViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.DemoViewer
        { model with DemoViewer = viewer }, Cmd.map DemoViewerMsg viewerMsg
