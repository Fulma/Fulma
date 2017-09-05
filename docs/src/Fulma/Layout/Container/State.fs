module Layouts.Container.State

open Elmish
open Types

let basic =
    """
```fsharp
    Container.container [ Container.isFluid ]
        [ Content.content [ ]
            [ h1 [ ] [str "Hello World"]
              p [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                      , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                      , sollicitudin vel erat vel, interdum mattis neque." ] ] ]
```
    """

let init() =
    { Intro =
        """
# Container

*[Bulma documentation](http://bulma.io/documentation/layout/container/)*
        """
      BasicViewer = Viewer.State.init basic }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
