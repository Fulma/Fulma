module Elements.Button.State

open Elmish
open Types

let colorCode =
    """
```fsharp
    Button.button_div [ ] [ str "Button" ]
    Button.button_div [ Button.isWhite ] [ str "White" ]
    Button.button_div [ Button.isLight ] [ str "Light" ]
    Button.button_div [ Button.isDark ] [ str "Dark" ]
    Button.button_div [ Button.isBlack ] [ str "Black" ]
    Button.button_div [ Button.isLink ] [ str "Link" ]
    Button.button_div [ Button.isPrimary ] [ str "Primary" ]
    Button.button_div [ Button.isInfo ] [ str "Info" ]
    Button.button_div [ Button.isSuccess ] [ str "Success" ]
    Button.button_div [ Button.isWarning ] [ str "Warning" ]
    Button.button_div [ Button.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
    Button.button_div [ Button.isSmall ] [ str "Small" ]
    Button.button_div [ ] [ str "Normal" ]
    Button.button_div [ Button.isMedium ] [ str "Medium" ]
    Button.button_div [ Button.isLarge ] [ str "Large" ]
```
    """


let outlinedCode =
    """
```fsharp
    Button.button_div [ Button.isOutlined ] [ str "Outlined" ]
    Button.button_div [ Button.isSuccess; Button.isOutlined ] [ str "Outlined" ]
    Button.button_div [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
    Button.button_div [ Button.isInfo; Button.isOutlined ] [ str "Outlined" ]
    Button.button_div [ Button.isDanger;  Button.isOutlined ] [ str "Outlined" ]
```
    """

let mixedStyleCode =
    """
```fsharp
    Button.button_div [ Button.isInverted ] [ str "Inverted" ]
    Button.button_div [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
    Button.button_div [ Button.isDanger; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
    Button.button_div [ Button.isInfo; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
```
    """

let stateCode =
    """
```fsharp
    Button.button_div [ ] [ str "Normal" ]
    Button.button_div [ Button.isSuccess; Button.isHovered ] [ str "Hover" ]
    Button.button_div [ Button.isWarning; Button.isFocused ] [ str "Focus" ]
    Button.button_div [ Button.isInfo; Button.isActive ] [ str "Active" ]
    Button.button_div [ Button.isBlack; Button.isLoading ] [ str "Loading" ]
```
    """

let extraCode =
    """
```fsharp
    // For registering a click event, we can use the Button.onClick helper
    Button.button_div [ Button.onClick (fun _ -> dispatch Click) ]
                      [ str buttonTxt ]
    // Or we can pass any IProps via Button.props
    // Equivalent of the Button.onClick
    Button.button_div [ Button.props [ OnClick (fun _ -> dispatch Click) ] ]
                      [ str buttonTxt ]
    // Disabled button
    Button.button_div [ Button.props [ Disabled true ] ]
                      [ str "Fixed width" ]
```
    """

let staticView =
    """
```fsharp
    Button.button_div [ Button.isStatic ]
        [ str "Static" ]
```
    """

let disabled =
    """
```fsharp
    Button.button_div [ Button.isDisabled
                        Button.isLink ] [ str "Link" ]
    Button.button_div [ Button.isDisabled
                        Button.isPrimary ] [ str "Primary" ]
    Button.button_div [ Button.isDisabled
                        Button.isInfo ] [ str "Info" ]
    Button.button_div [ Button.isDisabled
                        Button.isSuccess ] [ str "Success" ]
    Button.button_div [ Button.isDisabled
                        Button.isWarning ] [ str "Warning" ]
    Button.button_div [ Button.isDisabled
                        Button.isDanger ] [ str "Danger" ]
```
    """

let icons =
    """
```fsharp
    Button.button_div [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Bold ] ]
    Button.button_div [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Italic ] ]
    Button.button_div [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Underline ] ]
    Button.button_div [ Button.isDanger
                        Button.isOutlined ] [ str "Danger" ]
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
