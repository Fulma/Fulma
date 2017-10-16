module FulmaExtensions.Checkradio.State


open Elmish
open Types

let inlineBlockCode =
       """
```fsharp
    // Block
    Checkradio.checkbox [ Checkradio.text "One" ] [ ]
    Checkradio.checkbox [ Checkradio.text "Two" ] [ ]
                       
    // Inline
    div [ ClassName "field"] [
        yield! Checkradio.checkboxInline [ ] [ str "One " ]
        yield! Checkradio.checkboxInline [ ] [ str "Two " ]
    ]
```
    """ 
let colorCode =
    """
```fsharp
    Checkbox.checkbox [ ] [ str "Button" ]
    Checkbox.checkbox [ Checkbox.isWhite ] [ str "White" ]
    Checkbox.checkbox [ Checkbox.isLight ] [ str "Light" ]
    Checkbox.checkbox [ Checkbox.isDark ] [ str "Dark" ]
    Checkbox.checkbox [ Checkbox.isBlack ] [ str "Black" ]
    Checkbox.checkbox [ Checkbox.isPrimary ] [ str "Primary" ]
    Checkbox.checkbox [ Checkbox.isInfo ] [ str "Info" ]
    Checkbox.checkbox [ Checkbox.isSuccess ] [ str "Success" ]
    Checkbox.checkbox [ Checkbox.isWarning ] [ str "Warning" ]
    Checkbox.checkbox [ Checkbox.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
    Checkbox.checkbox [ Checkbox.isSmall ] [ str "Small" ]
    Checkbox.checkbox [ ] [ str "Normal" ]
    Checkbox.checkbox [ Checkbox.isMedium ] [ str "Medium" ]
    Checkbox.checkbox [ Checkbox.isLarge ] [ str "Large" ]
```
    """


let circleCode =
    """
```fsharp
    Checkbox.checkbox [ Checkbox.isChecked; Checkbox.isCircle ] [ str "Checkbox" ]
    Checkbox.checkbox [ Checkbox.isChecked; Checkbox.isCircle; Checkbox.isPrimary ] [ str "Checkbox" ]
    Checkbox.checkbox [ Checkbox.isChecked; Checkbox.isCircle; Checkbox.isSuccess ] [ str "Checkbox - success" ]
    Checkbox.checkbox [ Checkbox.isChecked; Checkbox.isCircle; Checkbox.isWarning ] [ str "Checkbox - warning" ]
    Checkbox.checkbox [ Checkbox.isChecked; Checkbox.isCircle; Checkbox.isDanger ] [ str "Checkbox - danger" ]
    Checkbox.checkbox [ Checkbox.isChecked; Checkbox.isCircle; Checkbox.isInfo ] [ str "Checkbox - info" ]
```
    """


let stateCode =
    """
```fsharp
    Checkradio.checkbox [ Checkradio.isDisabled ] [ str "Disabled" ]
    Checkradio.checkbox [ Checkradio.isDisabled; Checkradio.isChecked ] [ str "Disabled & Checked" ]
    Checkradio.checkbox [ ] [ str "Unchecked" ]
    Checkradio.checkbox [ Checkradio.isChecked;] [ str "checked" ]
```
    """

let eventCode =
    """
```fsharp
    // For registering a change event, we can use the Checkradio.onChange helper
    Checkradio.checkbox 
        [
            if model.IsChecked then yield Checkradio.isChecked;  
            yield Checkradio.onChange (fun x -> dispatch (Change state))
        ] 
        [ str  (sprintf "%A" model.IsChecked) ]
```
    """

let intro =
        """
# Checkradio

Make classic **checkbox** and **radio** more sexy in different colors, sizes, and states.

*[documentation](https://github.com/Wikiki/bulma-checkradio)*
        """



let init() =
    { InlineBlockViewer = Viewer.State.init inlineBlockCode
      ColorViewer = Viewer.State.init colorCode
      SizeViewer = Viewer.State.init sizeCode
      CircleViewer = Viewer.State.init circleCode
      StateViewer = Viewer.State.init stateCode
      EventViewer = Viewer.State.init eventCode
      Intro = intro
      IsChecked = false
    }

let update msg model =
    match msg with
    | InlineBlockViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.InlineBlockViewer
        { model with InlineBlockViewer = viewer }, Cmd.map InlineBlockViewerMsg viewerMsg
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
    | Change state -> 
        { model with IsChecked = state }, Cmd.none