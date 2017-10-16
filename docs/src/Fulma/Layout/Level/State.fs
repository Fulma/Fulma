module Layouts.Level.State

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
                [ Field.field_div [ Field.hasAddons ]
                    [ Control.control_div [ ]
                        [ Input.input [ Input.typeIsText
                                        Input.placeholder "Find a post" ] ]
                      Control.control_div [ ]
                        [ Button.button_div [ ]
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
                [ Button.button_div [ Button.isSuccess ] [ str "New" ] ] ] ]
```
    """

let centered =
    """
```fsharp
    Level.level [ ]
        [ Level.item [ Level.Item.hasTextCentered ]
            [ div [ ]
                [ Level.heading [ ] [ str "Stars" ]
                  Level.title [ ] [ str "1,010" ] ] ]
          Level.item [ Level.Item.hasTextCentered ]
            [ div [ ]
                [ Level.heading [ ] [ str "Forks" ]
                  Level.title [ ] [ str "127" ] ] ]
          Level.item [ Level.Item.hasTextCentered ]
            [ div [ ]
                [ Level.heading [ ] [ str "Watchers" ]
                  Level.title [ ] [ str "66" ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Level

*[Bulma documentation](http://bulma.io/documentation/layout/level/)*
        """
      BoxViewer = Viewer.State.init iconCode
      CenteredViewer = Viewer.State.init centered }

let update msg model =
    match msg with
    | BoxViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BoxViewer
        { model with BoxViewer = viewer }, Cmd.map BoxViewerMsg viewerMsg

    | CenteredViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.CenteredViewer
        { model with CenteredViewer = viewer }, Cmd.map CenteredViewerMsg viewerMsg
