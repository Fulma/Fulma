module Elements.Icon.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Extra.FontAwesome

let icon =
    div [ ClassName "block" ]
        [ Icon.icon [ Icon.isSmall ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon [ ]
            [ i [ ClassName "fa fa-lg fa-home" ] [ ] ]
          Icon.icon [ Icon.isMedium ]
            [ i [ ClassName "fa fa-2x fa-home" ] [ ] ]
          Icon.icon [ Icon.isLarge ]
            [ i [ ClassName "fa fa-3x fa-home" ] [ ] ] ]

//Display modification of container size with Bulma options
let containerSizes =
    div [ ClassName "block" ]
        [ //faIcon creates one Fulma icon element containing one Font Awesome icon
          Icon.faIcon [ // First group of Options: Usual fulma properties available: size, class
                        // Icon container size set to small in Fulma
                        Icon.isSmall;
                        // Custom class to set background color to yellow to display container
                        Icon.customClass "icon-size" ]
                        //Second group of Options: Font Awesome options
                        [ //Display one Font Awesome Icon available in the Fa.I namespace
                          Fa.icon Fa.I.Home ]

          Icon.faIcon [ //No setting for Icon container size = Normal size
                        //...
                        Icon.customClass "icon-size" ]
                      [ Fa.icon Fa.I.Home ]

          Icon.faIcon [ Icon.isMedium
                        Icon.customClass "icon-size" ]
                      [ Fa.icon Fa.I.Home
                        //Makes the Icon 33% larger
                        Fa.faLg ]
          Icon.faIcon [ Icon.isLarge
                        Icon.customClass "icon-size" ]
                      [ Fa.icon Fa.I.Home
                        //Makes the Icon 2x times larger
                        Fa.fa2x ] ]

//Diplay Font Awesome Rotation & Flip
let iconRotationFlip =
    div [ ClassName "block" ]
        [ ul [ ]
             [ li [ ]
                  [ Icon.faIcon [ Icon.isMedium ]
                                [ Fa.icon Fa.I.Shield
                                  Fa.faLg  ]
                    str "No Rotation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.isMedium ]
                                [ Fa.icon Fa.I.Shield
                                  //Rotate 90 degrees
                                  Fa.rotate90
                                  //Large icon
                                  Fa.faLg  ]
                    str "90 degrees rotation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.isMedium ]
                                [ Fa.icon Fa.I.Shield
                                  //Rotation 180 degrees
                                  Fa.rotate180
                                  Fa.faLg ]
                    str "180 degrees rotation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.isMedium ]
                                [ Fa.icon Fa.I.Shield
                                  //Flip Horizontal
                                  Fa.flipHorizontal
                                  Fa.faLg ]
                    str "Horizontal flip" ]
               li [ ]
                  [ Icon.faIcon [ Icon.isMedium ]
                                [ Fa.icon Fa.I.Shield
                                  //Flip Vertical
                                  Fa.flipVertical
                                  Fa.faLg ]
                    str "Vertical flip" ] ] ]

//Display Font Awesome Animations
let iconAnimations =
    div [ ClassName "block" ]
        [ ul [ ]
             [ li [ ]
                  [ Icon.faIcon [ Icon.isLarge ]
                                [ //Animations work well on Spinner
                                  Fa.icon Fa.I.Spinner
                                  //Pulse Animation
                                  Fa.pulse
                                  //Icon 2x times larger
                                  Fa.fa2x ]
                    str "Pulse animation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.isLarge ]
                                [ //Animations work well wit Cog
                                  Fa.icon Fa.I.Cog
                                  //Spin animation
                                  Fa.spin
                                  //Icon 2x times larger
                                  Fa.fa2x ]
                    str "Spin animation" ] ] ]

//Stacked Icons
let stackedIcons =
    div [ ClassName "block" ]
        [ ul [ ]
             [ li [ ]
                  [ Icon.stackParent [ Fa.Parent.faLg ]
                                     [ Icon.stackChild [ Fa.Child.faStack2x; Fa.Child.icon Fa.I.SquareO ]
                                       Icon.stackChild [ Fa.Child.faStack1x; Fa.Child.icon Fa.I.Twitter ] ]
                    str "Twitter logo over a square with round corners" ]
               li [ ]
                  [ Icon.stackParent [ Fa.Parent.faLg ]
                                     [ Icon.stackChild [ Fa.Child.faStack2x; Fa.Child.icon Fa.I.Circle ]
                                       Icon.stackChild [ Fa.Child.faStack1x; Fa.Child.icon Fa.I.Flag; Fa.Child.colorInverse ] ]
                    str "One flag with inversed color over a circle" ] ] ]

//Display Font Awesome Icon List
let iconList =
    div [ ClassName "block" ]
        [ // fa_ul creates an unordered list with icons instead of the classic bullet points
          Icon.fa_ul [ ]
            [ li [ ]
                [ Icon.faIcon [ ]
                              [ Fa.icon Fa.I.CheckSquare
                                Fa.isLi ]
                  str "Item done" ]
              li [ ]
                [ Icon.faIcon [ ]
                              [ Fa.icon Fa.I.Spinner
                                Fa.spin
                                Fa.isLi ]
                  str "Item processing" ] ] ]

let borderPulledIcons =
    div [ ClassName "block" ]
        [ span [ ]
               [ Icon.faIcon [ ]
                             [ Fa.icon Fa.I.QuoteLeft
                               Fa.pullLeft
                               Fa.border ]
                 str "...Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus.\
                     Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor.\
                     Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi.\
                     Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat.." ] ]

let fontAwesomeIcons =
    div [ ClassName "block" ]
        [ Icon.faIcon [ Icon.isSmall ] [ Fa.icon Fa.I.Home ]
          Icon.faIcon [ ] [ Fa.icon Fa.I.Tags; Fa.faLg ]
          Icon.faIcon [ Icon.isMedium ] [ Fa.icon Fa.I.``500px``; Fa.fa2x ]
          Icon.faIcon [ Icon.isLarge ] [ Fa.icon Fa.I.Android; Fa.fa3x ] ]

let composeButtons =
    div [ ClassName "block" ]
        [ Button.button [ Button.isDanger ]
                        [ Icon.faIcon [ ]
                                      [ Fa.icon Fa.I.Trash; Fa.faLg ]
                          span [] [ str "  Delete" ] ]
          Button.button [ Button.isInfo ]
                        [ Icon.faIcon [ ]
                                      [ Fa.icon Fa.I.User; Fa.fw ]
                          span [] [ str "User" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root icon model.IconViewer (IconViewerMsg >> dispatch))
                     Render.docSection
                        """
### Convenience functions

We provide convenience functions for **[Font Awesome](http://fontawesome.io/)**.

You need the next `open` statement to access the FontAwesome convenience functions.

```fsharp
    open Fulma.Elements
    open Fulma.Extra.FontAwesome
```

All the examples below use Font Awesome.
                        """
                        (Viewer.View.root containerSizes model.IconViewer (IconViewerMsg >> dispatch))
                     Render.docSection
                        """
### Available Font Awesome icons

If the icon you want to use isn't accessible via `Fa.I.*` please *[open an issue here](https://github.com/MangelMaxime/Fulma/issues)*.
You can also use `Fa.I.Custom "fa-my-icon"` as a fix.

```fsharp
    // If the "fa-thumbs-up" icon was missing, you could use Fa.I.Custom to get it:
    Icon.faIcon [ Icon.isLarge ] [ Fa.I.Custom "fa-thumbs-up" ]
```
                        """
                        (Viewer.View.root fontAwesomeIcons model.ConvenienceViewer (ConvenienceViewerMsg >> dispatch))
                     Render.docSection
                        """
### Rotations and Flip

Font Awesome options to rotate or flip icons are available as options in the library.
                        """
                        (Viewer.View.root iconRotationFlip model.RotationFlipViewer (RotationFlipViewerMsg >> dispatch))
                     Render.docSection
                        """
### Animated Icons

Font Awesome spin and pulse animations are available as options in the library.
                        """
                        (Viewer.View.root iconAnimations model.AnimationViewer (AnimationViewerMsg >> dispatch))
                     Render.docSection
                        """
### Icons as Bullet Points

You can use icons instead of bullet points in unordered lists.
                        """
                        (Viewer.View.root iconList model.IconListViewer (IconListViewerMsg >> dispatch))
                     Render.docSection
                        """
### Icons inside text paragraphs

You can embed icons inside text paragraphs.
                        """
                        (Viewer.View.root borderPulledIcons model.BorderPulledViewer (BorderPulledViewerMsg >> dispatch))
                     Render.docSection
                        """
### Stacked icons

You can build complex icons by combining several simple icons
                        """
                        (Viewer.View.root stackedIcons model.StackedIconViewer (StackedIconViewerMsg >> dispatch))
                     Render.docSection
                        """
### Compose Buttons

You can add Font Awesome icons to buttons.
                        """
                        (Viewer.View.root composeButtons model.ComposeButtonViewer (ComposeButtonViewerMsg >> dispatch))
                ]
