module Layouts.Footer.State

open Elmish
open Types

let iconCode =
    """
```fsharp
    Footer.footer [ ]
        [ Content.content [ Content.customClass Bulma.Properties.Alignment.HasTextCentered ]
            [ h1 [ ]
                 [ str "Fulma" ]
              p [ ]
                [ str "A wrapper around Bulma to help you create application quicker" ] ] ]
```
    """

let init() =
    { Intro =
        """
# Level

*[Bulma documentation](http://bulma.io/documentation/layout/level/)*
        """
      BasicViewer = Viewer.State.init iconCode }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
