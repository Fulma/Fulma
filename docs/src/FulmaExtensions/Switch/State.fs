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
    Field.field_div [ ]
    [ yield! Switch.switchInline [ ] [ str "One" ]
      yield! Switch.switchInline [ ] [ str "Two" ] ]
```
    """
let colorCode =
    """
```fsharp
    Switch.switch [ Switch.isChecked true ] [ str "Default" ]
    Switch.switch [ Switch.isChecked true; Switch.isWhite ] [ str "White" ]
    Switch.switch [ Switch.isChecked true; Switch.isLight ] [ str "Light" ]
    Switch.switch [ Switch.isChecked true; Switch.isDark ] [ str "Dark" ]
    Switch.switch [ Switch.isChecked true; Switch.isBlack ] [ str "Black" ]
    Switch.switch [ Switch.isChecked true; Switch.isPrimary ] [ str "Primary" ]
    Switch.switch [ Switch.isChecked true; Switch.isInfo ] [ str "Info" ]
    Switch.switch [ Switch.isChecked true; Switch.isSuccess ] [ str "Success" ]
    Switch.switch [ Switch.isChecked true; Switch.isWarning ] [ str "Warning" ]
    Switch.switch [ Switch.isChecked true; Switch.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
    Switch.switch [ Switch.isChecked true; Switch.isSmall ] [ str "Small" ]
    Switch.switch [ Switch.isChecked true ] [ str "Normal" ]
    Switch.switch [ Switch.isChecked true; Switch.isMedium ] [ str "Medium" ]
    Switch.switch [ Switch.isChecked true; Switch.isLarge ] [ str "Large" ]
```
    """


let circleCode =
    """
```fsharp
    // Rounded
    Switch.switch [ Switch.isChecked true
                    Switch.isRounded
                    Switch.isPrimary ] [ str "Checkbox" ]

// Thin
    Switch.switch [ Switch.isChecked true
                    Switch.isThin
                    Switch.isPrimary ] [ str "Checkbox" ]

// Outlined
    Switch.switch [ Switch.isChecked true
                    Switch.isOutlined
                    Switch.isPrimary ] [ str "Checkbox" ]

// Mixed
    Switch.switch [ Switch.isChecked true
                    Switch.isRounded
                    Switch.isOutlined
                    Switch.isPrimary ] [ str "Checkbox" ]

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
    Switch.switch [ Switch.isDisabled ] [ str "Disabled" ]
    Switch.switch [ Switch.isDisabled; Switch.isChecked true ] [ str "Disabled & Checked" ]
    Switch.switch [ ] [ str "Unchecked" ]
    Switch.switch [ Switch.isChecked true ] [ str "checked" ]
```
    """

let eventCode =
    """
```fsharp
    let newState = not model.IsChecked

    // For registering a change event, we can use the Switch.onChange helper
    Switch.switch
        [ Switch.isChecked model.IsChecked
          Switch.onChange (fun x -> dispatch (Change newState)) ]
        [ str (sprintf "%A" model.IsChecked) ]
    Switch.switch
        [ Switch.isChecked model.IsChecked
          Switch.onChange (fun x -> dispatch (Change newState)) ]
        [ if model.IsChecked then
            yield Icon.faIcon [ ] [ Fa.icon Fa.I.Check ]
          else
            yield Icon.faIcon [ ] [ Fa.icon Fa.I.Times ] ]
```
    """

let intro =
        """
# Switch

The **Switch** can have different colors, sizes and states.

*[Documentation](https://wikiki.github.io/bulma-extensions/switch)*

## Npm packages

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Version</th>
            <th>CLI</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>`yarn add bulma bulma-switch`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-switch@0.0.3`</td>
        </tr>
    </tbody>
<table>
        """

let rtlCode =
    """
```fsharp
    Switch.switch [ Switch.isRtl ] "Label is on the left"
```
    """

let init() =
    { InlineBlockViewer = Viewer.State.init inlineBlockCode
      ColorViewer = Viewer.State.init colorCode
      SizeViewer = Viewer.State.init sizeCode
      CircleViewer = Viewer.State.init circleCode
      StateViewer = Viewer.State.init stateCode
      EventViewer = Viewer.State.init eventCode
      RtlViewer = Viewer.State.init rtlCode
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
    | RtlViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.RtlViewer
        { model with RtlViewer = viewer }, Cmd.map RtlViewerMsg viewerMsg
    | Change state ->
        { model with IsChecked = state }, Cmd.none
