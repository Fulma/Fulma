module Layouts.Section.State

open Elmish
open Types

let basic =
    """
```fsharp
    Section.section [ ]
        [ Container.container [ Container.isFluid ]
            [ Heading.h1 [ ]
                [ str "Section" ]
              Heading.h2 [ Heading.isSubtitle ]
                [ str "A simple container to divide your page into sections" ] ] ]
```
    """

let init() =
    { Intro =
        """
# Section

*[Bulma documentation](http://bulma.io/documentation/layout/section/)*
        """
      BasicViewer = Viewer.State.init basic }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
