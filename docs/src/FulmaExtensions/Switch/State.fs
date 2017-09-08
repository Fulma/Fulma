module FulmaExtensions.Switch.State

open Elmish
open Types

let inlineBlockCode =
       """
```fsharp
    // Block
    Switch.switch [ ] [ str "One" ]
    Switch.switch [ ] [ str "Two" ]
    
    // Inline
    div [ ClassName "field"] [
        yield! Switch.switchInline [ ] [ str "One " ]
        yield! Switch.switchInline [ ] [ str "Two " ]
    ]
```
    """ 
let colorCode =
    """
```fsharp
    Switch.switch [ Switch.isChecked;  ] [ str "Default" ]
    Switch.switch [ Switch.isChecked; Switch.isWhite ] [ str "White" ]
    Switch.switch [ Switch.isChecked; Switch.isLight ] [ str "Light" ]
    Switch.switch [ Switch.isChecked; Switch.isDark ] [ str "Dark" ]
    Switch.switch [ Switch.isChecked; Switch.isBlack ] [ str "Black" ]
    Switch.switch [ Switch.isChecked; Switch.isPrimary ] [ str "Primary" ]
    Switch.switch [ Switch.isChecked; Switch.isInfo ] [ str "Info" ]
    Switch.switch [ Switch.isChecked; Switch.isSuccess ] [ str "Success" ]
    Switch.switch [ Switch.isChecked; Switch.isWarning ] [ str "Warning" ]
    Switch.switch [ Switch.isChecked; Switch.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
Switch.switch [ Switch.isSmall ] [ str "Small" ]
Switch.switch [ ] [ str "Normal" ]
Switch.switch [ Switch.isMedium ] [ str "Medium" ]
Switch.switch [ Switch.isLarge ] [ str "Large" ]
```
    """


let circleCode =
    """
```fsharp

Switch.switch [ Switch.isChecked; Switch.isRounded ] [ str "Rounded" ]
Switch.switch [ Switch.isChecked; Switch.isOutlined ] [ str "Outline" ]
Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isOutlined ] [ str "Both" ]
                          
```
    """

let mixedStyleCode =
    """
```fsharp
    Switch.switch [ Button.isInverted ] [ str "Inverted" ]
    Switch.switch [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
    Switch.switch [ Button.isDanger; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
    Switch.switch [ Button.isInfo; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
```
    """

let stateCode =
    """
```fsharp
    Switch.switch [  Switch.isDisabled ] [ str "Disabled" ]
    Switch.switch [  Switch.isDisabled; Checkradio.isChecked ] [ str "Disabled & Checked" ]
    Switch.switch [ ] [ str "Unchecked" ]
    Switch.switch [ Switch.isChecked;] [ str "checked" ]
```
    """

let eventCode =
    """
```fsharp
    // For registering a change event, we can use the Switch.onChange helper
    Switch.switch 
            [
                if model.IsChecked then yield Switch.isChecked;  
                yield Switch.onChange (fun x -> dispatch (Change state))
            ] 
            [ str  (sprintf "%A" model.IsChecked) ]

```
    """

let intro =
        """
# Switch

The **Switch** can have different colors, sizes and states.

*[Documentation](https://wikiki.github.io/bulma-extensions/switch)*
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