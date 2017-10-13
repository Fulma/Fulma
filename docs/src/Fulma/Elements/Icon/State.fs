module Elements.Icon.State

open Elmish
open Types

let containerSizesCode =
    """
```fsharp
            //faIcon creates one Fulma icon element containing one Font Awesome icon
            Icon.faIcon
                        //First group of Options: Usual fulma properties available: size, class
                        [   //Icon container size set to small in Fulma
                            Icon.isSmall;
                            //Custom class to set background color to yellow to display container
                            Icon.customClass "icon-size"
                        ]
                        //Second group of Options: Font Awesome options
                        [
                            //Display one Font Awesome Icon available in the Fa.I namespace
                            Fa.icon Fa.I.Home
                          ]

            Icon.faIcon [
                            //No setting for Icon container sier : Normal assumed
                            //...
                            Icon.customClass "icon-size"
                        ] [ Fa.icon Fa.I.Home ]

            Icon.faIcon [
                            Icon.isMedium;
                            Icon.customClass "icon-size"
                        ] [
                            Fa.icon Fa.I.Home
                            //Makes the Icon 33% larger
                            Fa.faLg
                        ]

            Icon.faIcon [
                            Icon.isLarge;
                            Icon.customClass "icon-size"
                        ] [
                            Fa.icon Fa.I.Home
                            //Makes the Icon 2x times larger
                            Fa.fa2x
                        ]
```
    """

let borderPulledIconsCode =
    """
```fsharp
    span [] [
                    Icon.faIcon [] [
                            Fa.icon Fa.I.QuoteLeft
                            Fa.pullLeft
                            Fa.border
                        ]
                    str "...Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus.\
                     Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor.\
                     Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi.\
                     Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat.."
            ]
```
    """

let fontAwesomeIconsCode =
    """
```fsharp
    Icon.faIcon [ Icon.isSmall ] [ Fa.icon Fa.I.Home; Fa.faLg ]
    Icon.faIcon [ ] [ Fa.icon Fa.I.Tags]
    Icon.faIcon [ Icon.isMedium ] [ Fa.icon Fa.I.``500px``; Fa.fa4x ]
    Icon.faIcon [ Icon.isLarge ] [ Fa.icon Fa.I.Android; Fa.fa3x ]  ]

```
    """

let rotationFlipCode =
    """
```fsharp
    //No Rotation
    Icon.faIcon [ Icon.isMedium ] [
        Fa.icon Fa.I.Shield;
        //Large icon
        Fa.faLg  ]
    //Rotation
    Icon.faIcon [ Icon.isMedium ] [
        Fa.icon Fa.I.Shield;
        //Rotate 90 degrees
        Fa.rotate90;
        //Large icon
        Fa.faLg  ]
    Icon.faIcon [ Icon.isMedium ] [
        Fa.icon Fa.I.Shield;
        //Rotation 180 degrees
        Fa.rotate180;
        Fa.faLg ]

    //Flip
    Icon.faIcon [ Icon.isMedium ] [
        Fa.icon Fa.I.Shield
        //Flip Horizontal
        Fa.flipHorizontal
        Fa.faLg ]

    Icon.faIcon [ Icon.isMedium ] [
        Fa.icon Fa.I.Shield
        //Flip Vertical
        Fa.flipVertical
        Fa.faLg ]
```
    """

let animationCode =
    """
```fsharp
    //Animations
    Icon.faIcon [ Icon.isLarge ] [
        //Animations work well on Spinner
        Fa.icon Fa.I.Spinner;
        //Pulse Animation
        Fa.pulse;
        //Icon 2x times larger
        Fa.fa2x  ]
    Icon.faIcon [ Icon.isLarge ] [
        //Animations work well wit Cog
        Fa.icon Fa.I.Cog;
        //Spin animation
        Fa.spin;
        //Icon 2x times larger
        Fa.fa2x  ]
```
    """
let iconListCode =
    """
```fsharp
    // faUl creates an unordered list with icons instead of the classic bullet points
    Icon.faUl [
        // faLi creates one list item. It has the same options as faIcon
        Icon.faLi [ Fa.icon Fa.I.CheckSquare ]       [ str "Item done"]
        Icon.faLi [ Fa.icon Fa.I.Spinner; Fa.spin ]  [ str "Item processing"]
    ]
```
    """
let stackedIconsCode =
    """
```fsharp
    Icon.stackParent [ Fa.Parent.faLg ] [
                Icon.stackChild [ Fa.Child.faStack2x; Fa.Child.icon Fa.I.SquareO ]
                Icon.stackChild [ Fa.Child.faStack1x; Fa.Child.icon Fa.I.Twitter ]
            ]
    Icon.stackParent [ Fa.Parent.faLg ] [
        Icon.stackChild [ Fa.Child.faStack2x; Fa.Child.icon Fa.I.Circle ]
        Icon.stackChild [ Fa.Child.faStack1x; Fa.Child.icon Fa.I.Flag; Fa.Child.colorInverse ]
    ]
```
    """
let composeButtonsCode =
    """
```fsharp
    Button.button [ Button.isDanger ]
            [
                Icon.faIcon [ Icon.customClass "icopn-size" ] [ Fa.icon Fa.I.Trash; Fa.faLg ]
                span [] [ str "  Delete" ]
            ]
    Button.button [ Button.isInfo ]
            [
                Icon.faIcon [ ] [ Fa.icon Fa.I.User; Fa.fw ]
                span [] [ str "User" ]
            ]
```
    """


let init() =
    { Intro =
        """
# Icons

The **icons** can have different sizes and is also compatible with *[Font Awesome](http://fontawesome.io/)* icons.

*[Bulma documentation](http://bulma.io/documentation/elements/icon/)*
        """
      IconViewer            = Viewer.State.init containerSizesCode
      ConvenienceViewer     = Viewer.State.init fontAwesomeIconsCode
      BorderPulledViewer    = Viewer.State.init borderPulledIconsCode
      RotationFlipViewer    = Viewer.State.init rotationFlipCode
      AnimationViewer       = Viewer.State.init animationCode
      IconListViewer        = Viewer.State.init iconListCode
      StackedIconViewer     = Viewer.State.init stackedIconsCode
      ComposeButtonViewer   = Viewer.State.init composeButtonsCode
     }

let update msg model =
    match msg with
    | IconViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.IconViewer
        { model with IconViewer = viewer }, Cmd.map IconViewerMsg viewerMsg

    | ConvenienceViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ConvenienceViewer
        { model with ConvenienceViewer = viewer }, Cmd.map ConvenienceViewerMsg viewerMsg

    | BorderPulledViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BorderPulledViewer
        { model with BorderPulledViewer = viewer }, Cmd.map BorderPulledViewerMsg viewerMsg

    | RotationFlipViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.RotationFlipViewer
        { model with RotationFlipViewer = viewer }, Cmd.map RotationFlipViewerMsg viewerMsg

    | AnimationViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.AnimationViewer
        { model with AnimationViewer = viewer }, Cmd.map AnimationViewerMsg viewerMsg

    | IconListViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.IconListViewer
        { model with IconListViewer = viewer }, Cmd.map IconListViewerMsg viewerMsg

    | StackedIconViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.StackedIconViewer
        { model with StackedIconViewer = viewer }, Cmd.map StackedIconViewerMsg viewerMsg

    | ComposeButtonViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ComposeButtonViewer
        { model with ComposeButtonViewer = viewer }, Cmd.map ComposeButtonViewerMsg viewerMsg
