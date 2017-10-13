module FulmaExtensions.Slider.State

open Elmish
open Types

let colorCode =
    """
```fsharp
Slider.slider [ ] [ ]
Slider.slider [ Slider.isPrimary ] [ ]
Slider.slider [ Slider.isInfo ] [ ]
Slider.slider [ Slider.isSuccess ] [ ]
Slider.slider [ Slider.isWarning ] [ ]
Slider.slider [ Slider.isDanger ] [ ]
```
    """

let sizeCode =
    """
```fsharp
Slider.slider [ Slider.isSmall ] [ ]
Slider.slider [ ] [ ]
Slider.slider [ Slider.isMedium ] [ ]
Slider.slider [ Slider.isLarge ] [ ]
Slider.slider [ Slider.isFullWidth ] [ ]
```
    """


let circleCode =
    """
```fsharp
Slider.slider [ Slider.isCircle; Slider.isDisabled ] [ ]
Slider.slider [ Slider.isCircle; Slider.isPrimary ] [ ]
Slider.slider [ Slider.isCircle; Slider.isSuccess ] [ ]
Slider.slider [ Slider.isCircle; Slider.isWarning ] [ ]
Slider.slider [ Slider.isCircle; Slider.isDanger ] [ ]
Slider.slider [ Slider.isCircle; Slider.isInfo ] [ ]
```
    """


let stateCode =
    """
```fsharp
Slider.slider [  Slider.isDisabled ] [ ]
```
    """

let eventCode =
    """
```fsharp
    // For registering a change event, we can use the Slider.onChange helper
    Slider.slider [ Slider.onChange (fun x -> dispatch (Change (x.currentTarget?value |> sprintf "%O" |> int)))  ] [ ]
    div [] [ str (sprintf "%i" model.Value) ]

```
    """

let intro =
        """
# Slider

The **Slider** can have different colors, sizes and states.

*[Documentation](https://wikiki.github.io/bulma-extensions/slider)*
        """



let init() =
    { ColorViewer = Viewer.State.init colorCode
      SizeViewer = Viewer.State.init sizeCode
      CircleViewer = Viewer.State.init circleCode
      StateViewer = Viewer.State.init stateCode
      EventViewer = Viewer.State.init eventCode
      Intro = intro
      Value = 50
    }

let update msg model =
    match msg with
    | ColorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ColorViewer
        { model with ColorViewer = viewer }, Cmd.map ColorViewerMsg viewerMsg
    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg
    | CircleViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.CircleViewer
        { model with CircleViewer = viewer }, Cmd.map CircleViewerMsg viewerMsg
    | StateViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.StateViewer
        { model with StateViewer = viewer }, Cmd.map StateViewerMsg viewerMsg
    | EventViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.EventViewer
        { model with EventViewer = viewer }, Cmd.map EventViewerMsg viewerMsg
    | Change value ->
        { model with Value = value }, Cmd.none
