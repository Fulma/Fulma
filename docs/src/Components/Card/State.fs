module Components.Card.State

open Elmish
open Types

let basic =
    """
```fsharp
    Card.card [ ]
        [ Card.header [ ]
            [ Card.Header.title [ ]
                [ str "Component" ]
              Card.Header.icon [ ]
                [ i [ ClassName "fa fa-angle-down" ] [ ] ] ]
          Card.content [ ]
            [ Content.content [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris." ] ]
          Card.footer [ ]
            [ Card.Footer.item [ ]
                [ str "Save" ]
              Card.Footer.item [ ]
                [ str "Edit" ]
              Card.Footer.item [ ]
                [ str "Delete" ] ] ]
```
    """

let init() =
    { Intro =
        """
# Card

*[Bulma documentation](http://bulma.io/documentation/components/card/)*
        """
      BasicViewer = Viewer.State.init basic }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
