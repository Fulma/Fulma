module Elements.Button.State

open Elmish
open Types

let colorCode =
    """
```fsharp
    Button.button_a [ ] [ str "Button" ]
    Button.button_a [ Button.isWhite ] [ str "White" ]
    Button.button_a [ Button.isLight ] [ str "Light" ]
    Button.button_a [ Button.isDark ] [ str "Dark" ]
    Button.button_a [ Button.isBlack ] [ str "Black" ]
    Button.button_a [ Button.isLink ] [ str "Link" ]
    Button.button_a [ Button.isPrimary ] [ str "Primary" ]
    Button.button_a [ Button.isInfo ] [ str "Info" ]
    Button.button_a [ Button.isSuccess ] [ str "Success" ]
    Button.button_a [ Button.isWarning ] [ str "Warning" ]
    Button.button_a [ Button.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
    Button.button_a [ Button.isSmall ] [ str "Small" ]
    Button.button_a [ ] [ str "Normal" ]
    Button.button_a [ Button.isMedium ] [ str "Medium" ]
    Button.button_a [ Button.isLarge ] [ str "Large" ]
```
    """


let outlinedCode =
    """
```fsharp
    Button.button_a [ Button.isOutlined ] [ str "Outlined" ]
    Button.button_a [ Button.isSuccess; Button.isOutlined ] [ str "Outlined" ]
    Button.button_a [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
    Button.button_a [ Button.isInfo; Button.isOutlined ] [ str "Outlined" ]
    Button.button_a [ Button.isDanger;  Button.isOutlined ] [ str "Outlined" ]
```
    """

let mixedStyleCode =
    """
```fsharp
    Button.button_a [ Button.isInverted ] [ str "Inverted" ]
    Button.button_a [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
    Button.button_a [ Button.isDanger; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
    Button.button_a [ Button.isInfo; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
```
    """

let stateCode =
    """
```fsharp
    Button.button_a [ ] [ str "Normal" ]
    Button.button_a [ Button.isSuccess; Button.isHovered ] [ str "Hover" ]
    Button.button_a [ Button.isWarning; Button.isFocused ] [ str "Focus" ]
    Button.button_a [ Button.isInfo; Button.isActive ] [ str "Active" ]
    Button.button_a [ Button.isBlack; Button.isLoading ] [ str "Loading" ]
```
    """

let extraCode =
    """
```fsharp
    // For registering a click event, we can use the Button.onClick helper
    Button.button_a [ Button.onClick (fun _ -> dispatch Click) ]
                    [ str buttonTxt ]
    // Or we can pass any IProps via Button.props
    // Equivalent of the Button.onClick
    Button.button_a [ Button.props [ OnClick (fun _ -> dispatch Click) ] ]
                    [ str buttonTxt ]
    // Disabled button
    Button.button_a [ Button.props [ Disabled true ] ]
                    [ str "Fixed width" ]
```
    """

let staticView =
    """
```fsharp
    Button.button_a [ Button.isStatic ]
        [ str "Static" ]
```
    """

let disabled =
    """
```fsharp
    Button.button_a [ Button.isDisabled
                      Button.isLink ] [ str "Link" ]
    Button.button_a [ Button.isDisabled
                      Button.isPrimary ] [ str "Primary" ]
    Button.button_a [ Button.isDisabled
                      Button.isInfo ] [ str "Info" ]
    Button.button_a [ Button.isDisabled
                      Button.isSuccess ] [ str "Success" ]
    Button.button_a [ Button.isDisabled
                      Button.isWarning ] [ str "Warning" ]
    Button.button_a [ Button.isDisabled
                      Button.isDanger ] [ str "Danger" ]
```
    """

let icons =
    """
```fsharp
    Button.button_a [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Bold ] ]
    Button.button_a [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Italic ] ]
    Button.button_a [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Underline ] ]
    Button.button_a [ Button.isDanger
                      Button.isOutlined ] [ str "Danger" ]
```
    """

let demoHelpers =
    """
```fsharp
    Button.button_a [ ]
      [ str "I am an anchor button"]
    Button.button_btn [ ]
      [ str "I am a form button"]
    Button.button_input [ Button.value "I am an input button"
                          Button.typeIsReset ]
```
    """

let init() =
    { Intro =
        """
# Buttons

The **buttons** can have different colors, sizes and states.

*[Bulma documentation](http://bulma.io/documentation/elements/button/)*
        """
      ColorViewer = Viewer.State.init colorCode
      DemoHelpersViewer = Viewer.State.init demoHelpers
      SizeViewer = Viewer.State.init sizeCode
      OutlinedViewer = Viewer.State.init outlinedCode
      MixedStyleViewer = Viewer.State.init mixedStyleCode
      StateViewer = Viewer.State.init stateCode
      ExtraViewer = Viewer.State.init extraCode
      StaticViewer = Viewer.State.init staticView
      DisabledViewer = Viewer.State.init disabled
      IconsViewer = Viewer.State.init icons
      ClickCount = 0 }

let update msg model =
    match msg with
    | ColorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ColorViewer
        { model with ColorViewer = viewer }, Cmd.map ColorViewerMsg viewerMsg

    | DemoHelpersViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.DemoHelpersViewer
        { model with DemoHelpersViewer = viewer }, Cmd.map DemoHelpersViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg

    | OutlinedViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.OutlinedViewer
        { model with OutlinedViewer = viewer }, Cmd.map OutlinedViewerMsg viewerMsg

    | MixedStyleViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.MixedStyleViewer
        { model with MixedStyleViewer = viewer }, Cmd.map MixedStyleViewerMsg viewerMsg

    | StateViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.StateViewer
        { model with StateViewer = viewer }, Cmd.map StateViewerMsg viewerMsg

    | ExtraViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ExtraViewer
        { model with ExtraViewer = viewer }, Cmd.map ExtraViewerMsg viewerMsg

    | Click -> { model with ClickCount = model.ClickCount + 1 }, Cmd.none

    | StaticViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.StaticViewer
        { model with StaticViewer = viewer }, Cmd.map StaticViewerMsg viewerMsg

    | DisabledViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.DisabledViewer
        { model with DisabledViewer = viewer }, Cmd.map DisabledViewerMsg viewerMsg

    | IconsViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.IconsViewer
        { model with IconsViewer = viewer }, Cmd.map IconsViewerMsg viewerMsg
