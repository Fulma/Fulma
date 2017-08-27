module Elements.Progress.State

open Elmish
open Types

let colorCode =
    """
```fsharp
Progress.progress
    [ Progress.value 15
      Progress.max 100 ] [ str "15%" ]
Progress.progress
    [ Progress.isSuccess
      Progress.value 30
      Progress.max 100 ] [ str "30%" ]
Progress.progress
    [ Progress.isInfo
      Progress.value 45
      Progress.max 100 ] [ str "45%" ]
Progress.progress
    [ Progress.isWarning
      Progress.value 60
      Progress.max 100 ] [ str "60%" ]
Progress.progress
    [ Progress.isPrimary
      Progress.value 75
      Progress.max 100 ] [ str "75%" ]
Progress.progress
    [ Progress.isDanger
      Progress.value 90
      Progress.max 100 ] [ str "90%" ]
```
    """

let extraCode =
    """
```fsharp
Progress.progress
    [ Progress.isSmall
      Progress.value 15
      Progress.max 100 ] [ str "15%" ]
Progress.progress
    [ Progress.value 30
      Progress.max 100 ] [ str "30%" ]
Progress.progress
    [ Progress.isMedium
      Progress.value 45
      Progress.max 100 ] [ str "45%" ]
Progress.progress
    [ Progress.isLarge
      Progress.value 60
      Progress.max 100 ] [ str "60%" ]
```
    """

let init() =
    { Intro =
        """
# Progress

The **progress** element can have different colors and sizes.

*[Bulma documentation](http://bulma.io/documentation/elements/progress/)*
        """
      ColorViewer = Viewer.State.init colorCode
      SizeViewer = Viewer.State.init extraCode
      Clicked = false }

let update msg model =
    match msg with
    | ColorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ColorViewer
        { model with ColorViewer = viewer }, Cmd.map ColorViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg

    | Click ->
        { model with Clicked = true }, Cmd.none
