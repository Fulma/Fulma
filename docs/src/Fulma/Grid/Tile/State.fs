module Grid.Tile.State

open Elmish
open Types

let iconCode =
    """
```fsharp
Box.box' [ ]
    [ str "Lorem ipsum dolor sit amet, consectetur adipisicing elit
           , sed do eiusmod tempor incididunt ut labore et dolore magna aliqua." ]
```
    """

let init() =
    { Intro =
        """
# Box

A white **box** to contain other elements .

*[Bulma documentation](http://bulma.io/documentation/elements/box/)*
        """
      BoxViewer = Viewer.State.init iconCode }

let update msg model =
    match msg with
    | BoxViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BoxViewer
        { model with BoxViewer = viewer }, Cmd.map BoxViewerMsg viewerMsg
