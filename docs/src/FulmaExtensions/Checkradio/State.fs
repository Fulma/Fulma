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
    Field.field_div [ ]
        [ yield! Checkradio.checkboxInline [ ] [ str "One " ]
          yield! Checkradio.checkboxInline [ ] [ str "Two " ] ]
```
    """

let rtlCode =
       """
```fsharp
    Checkradio.checkbox [ Checkradio.isRtl ] [ str "Label is on the left" ]

    Checkradio.radio [ Checkradio.isRtl ] [ str "Label is on the left" ]
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

    // Works for the radio too
    Checkbox.radio [ Checkbox.isPrimary ] [ str "Primary" ]
    Checkbox.radio [ Checkbox.isInfo ] [ str "Info" ]
    Checkbox.radio [ Checkbox.isSuccess ] [ str "Success" ]
    Checkbox.radio [ Checkbox.isWarning ] [ str "Warning" ]
    Checkbox.radio [ Checkbox.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
    Checkbox.checkbox [ Checkbox.isSmall ] [ str "Small" ]
    Checkbox.checkbox [ ] [ str "Normal" ]

    // Works for the radio too
    Checkbox.radio [ Checkbox.isMedium ] [ str "Medium" ]
    Checkbox.radio [ Checkbox.isLarge ] [ str "Large" ]
```
    """


let circleCode =
    """
```fsharp
    // Checkbox with a circle design
    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isCircle; Checkradio.isPrimary ] [ str "Primary" ]

    // No border
    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasNoBorder; Checkradio.isPrimary ] [ str "Primary" ]

    // With background color
    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isPrimary ] [ str "Primary" ]
    // Works for radio too
    Checkradio.radio [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isPrimary ] [ str "Primary" ]
```
    """


let stateCode =
    """
```fsharp
    Checkradio.checkbox [ Checkradio.isDisabled true ] [ str "Disabled" ]
    Checkradio.checkbox [ Checkradio.isDisabled true; Checkradio.isChecked true] [ str "Disabled & Checked" ]
    Checkradio.checkbox [ ] [ str "Unchecked" ]
    Checkradio.checkbox [ Checkradio.isChecked true] [ str "checked" ]
```
    """

let eventCode =
    """
```fsharp
    let newState = not model.IsChecked

    // For registering a change event, we can use the Checkradio.onChange helper
    Checkradio.checkbox
      [ Checkradio.isChecked model.IsChecked
        Checkradio.onChange (fun x -> dispatch (Change newState)) ]
      [ str  (string model.IsChecked) ]
    Checkradio.checkbox
          [ Checkradio.isChecked model.IsChecked
            Checkradio.onChange (fun x -> dispatch (Change newState)) ]
          [ if model.IsChecked then
              yield Icon.faIcon [ ] [ Fa.icon Fa.I.Plane ]
            else
              yield Icon.faIcon [ ] [ Fa.icon Fa.I.Rocket] ]
```
    """

let intro =
        """
# Checkradio

Make classic **checkbox** and **radio** more sexy in different colors, sizes, and states.

*[Documentation](https://github.com/Wikiki/bulma-checkradio)*

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
            <td>`yarn add bulma bulma-checkradio`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-checkradio@0.0.8`</td>
        </tr>
    </tbody>
<table>
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
      IsChecked = false }

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
