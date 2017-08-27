module Components.Message.State

open Elmish
open Types

let basic =
    """
```fsharp
    Message.message [ ]
        [ Message.header [ ]
            [ str "Nunc finibus ligula et semper suscipit"
              Delete.delete [ ]
                [ ] ]
          Message.body [ ]
            [ str loremText ] ]
```
    """

let color =
    """
```fsharp
    div [ ]
        [ Message.message [ Message.isInfo ]
            [ Message.header [ ]
                [ str "Nunc finibus ligula et semper suscipit"
                  Delete.delete [ ]
                    [ ] ]
              Message.body [ ]
                [ str loremText ] ]
          Message.message [ Message.isDanger ]
            [ Message.header [ ]
                [ str "Nunc finibus ligula et semper suscipit"
                  Delete.delete [ ]
                    [ ] ]
              Message.body [ ]
                [ str loremText ] ] ]
```
    """

let sizes =
    """
```fsharp
    Message.message [ Message.isSmall ]
        [ Message.header [ ]
            [ str "Nunc finibus ligula et semper suscipit"
              Delete.delete [ ]
                [ ] ]
          Message.body [ ]
            [ str loremText ] ]
```
    """

let bodyOnly =
    """
```fsharp
    Message.message [ ]
        [ Message.body [ ]
            [ str loremText ] ]
```
    """

let init() =
    { Intro =
        """
# Message

*[Bulma documentation](http://bulma.io/documentation/components/message/)*
        """
      BasicViewer = Viewer.State.init basic
      ColorViewer = Viewer.State.init color
      SizeViewer = Viewer.State.init sizes
      BodyOnlyViewer = Viewer.State.init bodyOnly }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg

    | ColorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ColorViewer
        { model with ColorViewer = viewer }, Cmd.map ColorViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg

    | BodyOnlyViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BodyOnlyViewer
        { model with BodyOnlyViewer = viewer }, Cmd.map BodyOnlyViewerMsg viewerMsg
