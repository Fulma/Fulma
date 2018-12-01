module Elements.Icon

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome5

let icon () =
    div [ ClassName "block" ]
        [ Icon.icon [ Icon.Size IsSmall ]
            [ i [ ClassName "fas fa-home" ] [ ] ]
          Icon.icon [ ]
            [ i [ ClassName "fas fa-lg fa-home" ] [ ] ]
          Icon.icon [ Icon.Size IsMedium ]
            [ i [ ClassName "fas fa-2x fa-home" ] [ ] ]
          Icon.icon [ Icon.Size IsLarge ]
            [ i [ ClassName "fas fa-3x fa-home" ] [ ] ] ]

//Display modification of container size with Bulma options
let containerSizes () =
    div [ ClassName "block" ]
        [ //faIcon creates one Fulma icon element containing one Font Awesome icon
          Icon.faIcon [ // First group of Options: Usual fulma properties available: size, class
                        // Icon container size set to small in Fulma
                        Icon.Size IsSmall;
                        // Custom class to set background color to yellow to display container
                        Icon.CustomClass "icon-size" ]
                        //Second group of Options: Font Awesome options
                        [ //Display one Font Awesome Icon available in the Fa5.I namespace
                          Fa5.icon(Fa5.I.Home, Fa5.Solid) ]
          Icon.faIcon [ //No setting for Icon container size = Normal size
                        //...
                        Icon.CustomClass "icon-size" ]
                      [ Fa5.icon(Fa5.I.Home, Fa5.Solid) ]
          Icon.faIcon [ Icon.Size IsMedium
                        Icon.CustomClass "icon-size" ]
                      [ Fa5.icon(Fa5.I.Home, Fa5.Solid)
                        //Makes the Icon 33% larger
                        Fa5.faLg ]
          Icon.faIcon [ Icon.Size IsLarge
                        Icon.CustomClass "icon-size" ]
                      [ Fa5.icon(Fa5.I.Home, Fa5.Solid)
                        //Makes the Icon 2x times larger
                        Fa5.fa2x ] ]

let iconStyles () =
    div [ ClassName "block" ]
        [ Icon.faIcon [ Icon.Size IsLarge ]
                      [ Fa5.icon(Fa5.I.GrinTongue, Fa5.Solid); Fa5.fa3x ]

          Icon.faIcon [ Icon.Size IsLarge ]
                      [ Fa5.icon(Fa5.I.GrinTongue, Fa5.Regular); Fa5.fa3x ]

          Icon.faIcon [ Icon.Size IsLarge ]
                      [ Fa5.icon(Fa5.I.GrinTongue, Fa5.Light); Fa5.fa3x ] ]

let brands () =
    div [ ClassName "block" ]
        [ Icon.faIcon [ Icon.Size IsLarge ]
                      [ Fa5.brand Fa5.B.Bluetooth; Fa5.fa2x ]
          Icon.faIcon [ Icon.Size IsLarge ]
                      [ Fa5.brand Fa5.B.Paypal; Fa5.fa3x ] ]

//Diplay Font Awesome Rotation & Flip
let iconRotationFlip () =
    div [ ClassName "block" ]
        [ ul [ ]
             [ li [ ]
                  [ Icon.faIcon [ Icon.Size IsMedium ]
                                [ Fa5.icon(Fa5.I.ShieldAlt, Fa5.Solid)
                                  Fa5.faLg  ]
                    str "No Rotation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.Size IsMedium ]
                                [ Fa5.icon(Fa5.I.ShieldAlt, Fa5.Solid)
                                  //Rotate 90 degrees
                                  Fa5.rotate90
                                  //Large icon
                                  Fa5.faLg  ]
                    str "90 degrees rotation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.Size IsMedium ]
                                [ Fa5.icon(Fa5.I.ShieldAlt, Fa5.Solid)
                                  //Rotation 180 degrees
                                  Fa5.rotate180
                                  Fa5.faLg ]
                    str "180 degrees rotation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.Size IsMedium ]
                                [ Fa5.icon(Fa5.I.ShieldAlt, Fa5.Solid)
                                  //Flip Horizontal
                                  Fa5.flipHorizontal
                                  Fa5.faLg ]
                    str "Horizontal flip" ]
               li [ ]
                  [ Icon.faIcon [ Icon.Size IsMedium ]
                                [ Fa5.icon(Fa5.I.ShieldAlt, Fa5.Solid)
                                  //Flip Vertical
                                  Fa5.flipVertical
                                  Fa5.faLg ]
                    str "Vertical flip" ] ] ]

//Display Font Awesome Animations
let iconAnimations () =
    div [ ClassName "block" ]
        [ ul [ ]
             [ li [ ]
                  [ Icon.faIcon [ Icon.Size IsLarge ]
                                [ //Animations work well on Spinner
                                  Fa5.icon(Fa5.I.Spinner, Fa5.Solid)
                                  //Pulse Animation
                                  Fa5.pulse
                                  //Icon 2x times larger
                                  Fa5.fa2x ]
                    str "Pulse animation" ]
               li [ ]
                  [ Icon.faIcon [ Icon.Size IsLarge ]
                                [ //Animations work well wit Cog
                                  Fa5.icon(Fa5.I.Cog, Fa5.Solid)
                                  //Spin animation
                                  Fa5.spin
                                  //Icon 2x times larger
                                  Fa5.fa2x ]
                    str "Spin animation" ] ] ]

//Stacked Icons
let stackedIcons () =
    div [ ClassName "block" ]
        [ ul [ ]
             [ li [ ]
                  [ Icon.stackParent [ Fa5.Parent.faLg ]
                                     [ Icon.stackChild [ Fa5.Child.faStack2x; Fa5.Child.icon(Fa5.I.Square, Fa5.Regular) ]
                                       Icon.stackChild [ Fa5.Child.faStack1x; Fa5.Child.brand Fa5.B.Twitter ] ]
                    str "Twitter logo over a square with round corners" ]
               li [ ]
                  [ Icon.stackParent [ Fa5.Parent.faLg ]
                                     [ Icon.stackChild [ Fa5.Child.faStack2x; Fa5.Child.icon(Fa5.I.Circle, Fa5.Solid) ]
                                       Icon.stackChild [ Fa5.Child.faStack1x; Fa5.Child.icon(Fa5.I.Flag, Fa5.Regular); Fa5.Child.colorInverse ] ]
                    str "One flag with inversed color over a circle" ] ] ]

//Display Font Awesome Icon List
let iconList () =
    div [ ClassName "block" ]
        [ // fa_ul creates an unordered list with icons instead of the classic bullet points
          Icon.fa_ul [ ]
            [ li [ ]
                [ Icon.faIcon [ ]
                              [ Fa5.icon(Fa5.I.CheckSquare, Fa5.Regular)
                                Fa5.isLi ]
                  str "Item done" ]
              li [ ]
                [ Icon.faIcon [ ]
                              [ Fa5.icon(Fa5.I.Spinner, Fa5.Solid)
                                Fa5.spin
                                Fa5.isLi ]
                  str "Item processing" ] ] ]

let borderPulledIcons () =
    div [ ClassName "block" ]
        [ span [ ]
               [ Icon.faIcon [ ]
                             [ Fa5.icon(Fa5.I.QuoteLeft, Fa5.Solid)
                               Fa5.pullLeft
                               Fa5.border ]
                 str "...Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed non risus.\
                     Suspendisse lectus tortor, dignissim sit amet, adipiscing nec, ultricies sed, dolor.\
                     Cras elementum ultrices diam. Maecenas ligula massa, varius a, semper congue, euismod non, mi.\
                     Proin porttitor, orci nec nonummy molestie, enim est eleifend mi, non fermentum diam nisl sit amet erat.." ] ]

let fontAwesomeIcons () =
    div [ ClassName "block" ]
        [ Icon.faIcon [ Icon.Size IsSmall ] [ Fa5.icon(Fa5.I.Home, Fa5.Solid) ]
          Icon.faIcon [ ] [ Fa5.icon(Fa5.I.Tags, Fa5.Solid); Fa5.faLg ]
          Icon.faIcon [ Icon.Size IsMedium ] [ Fa5.brand Fa5.B.``500px``; Fa5.fa2x ]
          Icon.faIcon [ Icon.Size IsLarge ] [ Fa5.brand Fa5.B.Android; Fa5.fa3x ] ]

let composeButtons () =
    div [ ClassName "block" ]
        [ Button.button [ Button.Color IsDanger ]
                        [ Icon.faIcon [ ]
                                      [ Fa5.icon(Fa5.I.Trash, Fa5.Solid); Fa5.faLg ]
                          span [] [ str "  Delete" ] ]
          Button.button [ Button.Color IsInfo ]
                        [ Icon.faIcon [ ]
                                      [ Fa5.icon(Fa5.I.User, Fa5.Solid); Fa5.fw ]
                          span [] [ str "User" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Icons

The **icons** can have different sizes and is also compatible with *[Font Awesome](http://fontawesome.io/)* icons.

*[Bulma documentation](http://bulma.io/documentation/elements/icon/)*
                        """
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view icon (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Convenience functions

We provide convenience functions for **[Font Awesome 5](http://fontawesome.io/)**.

*if you are looking for information on Font Awesome 4, please visit **[this page](https://mangelmaxime.github.io/Fulma/#fulma/elements/iconobsolete)** *

You need the next `open` statement to access the FontAwesome convenience functions.

```fsharp
    open Fulma
    open Fulma.FontAwesome5
```

All the examples below use Font Awesome.
                        """
                        (Widgets.Showcase.view containerSizes (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Icons

Supported styles:

* `Solid`
* `Regular`
* `Light`

```fsharp
    Icon.faIcon [ ] [ Fa5.icon(Fa5.I.Trash, Fa5.Solid) ]
```

We offer icon support for all styles, including those only available in the pro.
If the style of the icon is not available in the free edition, it will simply not show.
                        """
                        (Widgets.Showcase.view iconStyles (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Brands

```fsharp
    Icon.faIcon [ ] [ Fa5.brand Fa5.B.Bluetooth ]
```

If the brand you want to use isn't accessible via `Fa5.B.*` please *[open an issue here](https://github.com/MangelMaxime/Fulma/issues)*.
You can also use `Fa5.B.Custom "fa-my-icon"` as a fix.

                        """
                        (Widgets.Showcase.view brands (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Available Font Awesome icons

If the icon you want to use isn't accessible via `Fa5.I.*` please *[open an issue here](https://github.com/MangelMaxime/Fulma/issues)*.
You can also use `Fa5.I.Custom "fas fa-my-icon"` as a fix.

```fsharp
    // If the "fa-thumbs-up" icon was missing, you could use Fa5.I.Custom to get it:
    Icon.faIcon [ Icon.isLarge ] [ Fa5.I.Custom "fas fa-thumbs-up" ]
```
                        """
                        (Widgets.Showcase.view fontAwesomeIcons (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Rotations and Flip

Font Awesome options to rotate or flip icons are available as options in the library.
                        """
                        (Widgets.Showcase.view iconRotationFlip (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Animated Icons

Font Awesome spin and pulse animations are available as options in the library.
                        """
                        (Widgets.Showcase.view iconAnimations (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Icons as Bullet Points

You can use icons instead of bullet points in unordered lists.
                        """
                        (Widgets.Showcase.view iconList (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Icons inside text paragraphs

You can embed icons inside text paragraphs.
                        """
                        (Widgets.Showcase.view borderPulledIcons (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Stacked icons

You can build complex icons by combining several simple icons
                        """
                        (Widgets.Showcase.view stackedIcons (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Compose Buttons

You can add Font Awesome icons to buttons.
                        """
                        (Widgets.Showcase.view composeButtons (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
