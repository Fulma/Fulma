module Components.Media.State

open Elmish
open Types

let basic =
    """
```fsharp
    Media.media [ ]
        [ Media.left [ ]
            [ Image.image [ Image.is64x64 ]
                [ img [ Src "https://dummyimage.com/64x64/7a7a7a/fff" ] ] ]
          Media.content [ ]
            [ Field.field_div [ ]
                [ Control.control_div [ ]
                    [ textarea [ ClassName "textarea"
                                 Placeholder "Add a message ..." ]
                               [ ] ] ]
              Level.level [ ]
                [ Level.left [ ]
                    [ Level.item [ ]
                        [ Button.button [ Button.isInfo ]
                            [ str "Submit" ] ] ]
                  Level.right [ ]
                    [ Level.item [ ]
                        [ str "Press Ctrl + Enter to submit" ] ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Media

*[Bulma documentation](http://bulma.io/documentation/components/media-object/)*
        """
      BasicViewer = Viewer.State.init basic }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
