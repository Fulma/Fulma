module Components.Level.State

open Elmish
open Types

let iconCode =
    """
```fsharp
    Level.level [ ]
        [ Level.left [ ]
            [ Level.item [ ]
                [ Heading.h5 [ Heading.isSubtitle ]
                    [ strong [ ] [ str "123"]
                      str " posts" ] ]
              Level.item [ ]
                [ Field.field [ Field.hasAddonsLeft ]
                    [ Control.control [ ]
                        [ Input.input [ Input.typeIsText
                                        Input.placeholder "Find a post" ] ]
                      Control.control [ ]
                        [ Button.button [ ]
                            [ str "Search" ] ] ] ] ]
          Level.right [ ]
            [ Level.item [ ]
                [ a [ ] [ str "All" ] ]
              Level.item [ ]
                [ a [ ] [ str "Published" ] ]
              Level.item [ ]
                [ a [ ] [ str "Drafts" ] ]
              Level.item [ ]
                [ a [ ] [ str "Deleted" ] ]
              Level.item [ ]
                [ Button.button [ Button.isSuccess ] [ str "New" ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Level

*[Bulma documentation](http://bulma.io/documentation/components/level/)*
        """
      BoxViewer = Viewer.State.init iconCode }

let update msg model =
    match msg with
    | BoxViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BoxViewer
        { model with BoxViewer = viewer }, Cmd.map BoxViewerMsg viewerMsg
