module Elements.Button.State

open Elmish
open Types

let colorCode =
    """
```fsharp
    Button.button [ ] [ str "Button" ]
    Button.button [ Button.isWhite ] [ str "White" ]
    Button.button [ Button.isLight ] [ str "Light" ]
    Button.button [ Button.isLight ] [ str "Light" ]
    Button.button [ Button.isDark ] [ str "Dark" ]
    Button.button [ Button.isBlack ] [ str "Black" ]
    Button.button [ Button.isLink ] [ str "Link" ]
    Button.button [ Button.isPrimary ] [ str "Primary" ]
    Button.button [ Button.isInfo ] [ str "Info" ]
    Button.button [ Button.isSuccess ] [ str "Success" ]
    Button.button [ Button.isWarning ] [ str "Warning" ]
    Button.button [ Button.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
    Button.button [ Button.isSmall ] [ str "Small" ]
    Button.button [ ] [ str "Normal" ]
    Button.button [ Button.isMedium ] [ str "Medium" ]
    Button.button [ Button.isLarge ] [ str "Large" ]
```
    """


let outlinedCode =
    """
```fsharp
    Button.button [ Button.isOutlined ] [ str "Outlined" ]
    Button.button [ Button.isSuccess; Button.isOutlined ] [ str "Outlined" ]
    Button.button [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
    Button.button [ Button.isInfo; Button.isOutlined ] [ str "Outlined" ]
    Button.button [ Button.isDanger;  Button.isOutlined ] [ str "Outlined" ]
```
    """

let mixedStyleCode =
    """
```fsharp
    Button.button [ Button.isInverted ] [ str "Inverted" ]
    Button.button [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
    Button.button [ Button.isDanger; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
    Button.button [ Button.isInfo; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
```
    """

let stateCode =
    """
```fsharp
    Button.button [ ] [ str "Normal" ]
    Button.button [ Button.isSuccess; Button.isHovered ] [ str "Hover" ]
    Button.button [ Button.isWarning; Button.isFocused ] [ str "Focus" ]
    Button.button [ Button.isInfo; Button.isActive ] [ str "Active" ]
    Button.button [ Button.isBlack; Button.isLoading ] [ str "Loading" ]
```
    """

let extraCode =
    """
```fsharp
    // For registering a click event, we can use the Button.onClick helper
    Button.button [ Button.onClick (fun _ -> dispatch Click) ]
                  [ str buttonTxt ]
    // Or we can pass any IProps via Button.props
    // Equivalent of the Button.onClick
    Button.button [ Button.props [ OnClick (fun _ -> dispatch Click) ] ]
                  [ str buttonTxt ]
    // Disabled button
    Button.button [ Button.props [ Disabled true ] ]
                  [ str "Fixed width" ]
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
