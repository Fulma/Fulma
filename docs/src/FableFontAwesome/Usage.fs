module FableFontAwesome.Usage

open Fable.Core
open Fable.Import
open Fable.React
open Fable.React.Props
open System
open Fable.FontAwesome

let simpleDemo () =
    div [ ClassName "block" ]
        [ Fa.i [ Fa.Solid.Home ]
            [ ]
          Fa.i [ Fa.Solid.Home
                 Fa.Size Fa.Fa2x ]
            [ ]
          Fa.span [ Fa.Solid.Home ]
            [ ]
          Fa.span [ Fa.Solid.Home
                    Fa.Size Fa.Fa2x ]
            [ ] ]

let iconSize () =
    div [ ClassName "block" ]
        [ Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.FaExtraSmall ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.FaSmall ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.FaLarge ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.Fa2x ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.Fa4x ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.Fa6x ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.Fa8x ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Size Fa.Fa10 ]
            [ ] ]

let iconFixedWidth () =
    let mistyRoseBg =
        Fa.Props [ Style [ BackgroundColor "mistyrose" ] ]
    // Demo view
    div [ ClassName "block"
          Style [ FontSize "2rem" ] ]
        [ div [ ]
            [ Fa.span [ Fa.Solid.Home
                        Fa.FixedWidth
                        mistyRoseBg ]
                [ ]
              str " Home" ]
          div [ ]
            [ Fa.span [ Fa.Solid.Info
                        Fa.FixedWidth
                        mistyRoseBg ]
                [ ]
              str " Info" ]
          div [ ]
            [ Fa.span [ Fa.Solid.Book
                        Fa.FixedWidth
                        mistyRoseBg ]
                [ ]
              str " Library" ]
          div [ ]
            [ Fa.span [ Fa.Solid.PencilAlt
                        Fa.FixedWidth
                        mistyRoseBg ]
                [ ]
              str " Applications" ]
          div [ ]
            [ Fa.span [ Fa.Solid.Cog
                        Fa.FixedWidth
                        mistyRoseBg ]
                [ ]
              str " Settings" ] ]

let iconInList () =
    div [ ClassName "block" ]
        [ Fa.ul [ ]
            [ li [ ]
                [ Fa.i [ Fa.Solid.CheckSquare
                         Fa.IsLi ]
                        [ ]
                  str "List icons can" ]
              li [ ]
                [ Fa.i [ Fa.Solid.CheckSquare
                         Fa.IsLi ]
                        [ ]
                  str "be used to" ]
              li [ ]
                [ Fa.i [ Fa.Solid.Spinner
                         Fa.Pulse
                         Fa.IsLi ]
                        [ ]
                  str "replace bullets icons can" ]
              li [ ]
                [ Fa.i [ Fa.Regular.Square
                         Fa.IsLi ]
                        [ ]
                  str "in lists" ] ] ]

let iconRotation () =
    div [ Class ("block " + Fa.Classes.Size.Fa4x) ]
        [ Fa.i [ Fa.Brand.FontAwesome ]
            [ ]
          Fa.i [ Fa.Brand.FontAwesome
                 Fa.Rotate90 ]
            [ ]
          Fa.i [ Fa.Brand.FontAwesome
                 Fa.Rotate180 ]
            [ ]
          Fa.i [ Fa.Brand.FontAwesome
                 Fa.Rotate270 ]
            [ ]
          Fa.i [ Fa.Brand.FontAwesome
                 Fa.FlipHorizontal ]
            [ ]
          Fa.i [ Fa.Brand.FontAwesome
                 Fa.FlipVertical ]
            [ ] ]

let iconAnimation () =
    div [ Class ("block " + Fa.Classes.Size.Fa3x) ]
        [ Fa.i [ Fa.Solid.Spinner
                 Fa.Spin ]
            [ ]
          Fa.i [ Fa.Solid.CircleNotch
                 Fa.Spin ]
            [ ]
          Fa.i [ Fa.Solid.Sync
                 Fa.Spin ]
            [ ]
          Fa.i [ Fa.Solid.Cog
                 Fa.Spin ]
            [ ]
          Fa.i [ Fa.Solid.Spinner
                 Fa.Pulse ]
            [ ]
          Fa.i [ Fa.Solid.Stroopwafel
                 Fa.Spin ]
            [ ] ]

let iconBorderedAndPulled () =
    div [ Class "block" ]
        [ div [ ]
            [ Fa.i [ Fa.Solid.QuoteLeft
                     Fa.Size Fa.Fa2x
                     Fa.PullLeft ]
                [ ]
              str """Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dapibus eros sit amet molestie
                 vestibulum. Nullam non feugiat massa, et feugiat ante. Pellentesque vestibulum ante felis, in
                 accumsan magna molestie eu. Suspendisse elementum eu metus vel volutpat. Praesent id sem sem.
                 Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.
                 Vivamus massa ante, dignissim non tincidunt ac, imperdiet quis arcu.""" ]
          hr [ ]
          div [ ]
            [ Fa.i [ Fa.Solid.ArrowRight
                     Fa.Size Fa.Fa2x
                     Fa.PullRight
                     Fa.Border ]
                [ ]
              str """Lorem ipsum dolor sit amet, consectetur adipiscing elit. In dapibus eros sit amet molestie
                 vestibulum. Nullam non feugiat massa, et feugiat ante. Pellentesque vestibulum ante felis, in
                 accumsan magna molestie eu. Suspendisse elementum eu metus vel volutpat. Praesent id sem sem.
                 Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos.
                 Vivamus massa ante, dignissim non tincidunt ac, imperdiet quis arcu.""" ] ]

let iconStacked () =
    div [ Class "block" ]
        [ Fa.stack [ Fa.Stack.Size Fa.Fa2x ]
            [ Fa.i [ Fa.Solid.Square
                     Fa.Stack2x ]
                [ ]
              Fa.i [ Fa.Brand.Twitter
                     Fa.Stack1x
                     Fa.Inverse ]
                [ ] ]
          Fa.stack [ Fa.Stack.Size Fa.Fa2x ]
            [ Fa.i [ Fa.Solid.Circle
                     Fa.Stack2x ]
                [ ]
              Fa.i [ Fa.Solid.Flag
                     Fa.Stack1x
                     Fa.Inverse ]
                [ ] ]
          Fa.stack [ Fa.Stack.Size Fa.Fa2x ]
            [ Fa.i [ Fa.Solid.Square
                     Fa.Stack2x ]
                [ ]
              Fa.i [ Fa.Solid.Terminal
                     Fa.Stack1x
                     Fa.Inverse ]
                [ ] ]
          Fa.stack [ Fa.Stack.Size Fa.Fa4x ]
            [ Fa.i [ Fa.Solid.Square
                     Fa.Stack2x ]
                [ ]
              Fa.i [ Fa.Solid.Terminal
                     Fa.Stack1x
                     Fa.Inverse ]
                [ ] ]
          Fa.stack [ Fa.Stack.Size Fa.Fa2x ]
            [ Fa.i [ Fa.Solid.Camera
                     Fa.Stack1x ]
                [ ]
              Fa.i [ Fa.Solid.Ban
                     Fa.Stack2x
                     Fa.Props [ Style [ Color "tomato" ] ] ]
                [ ] ] ]


let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Fable.FontAwesome

<div class="message is-info">
    <div class="message-header">Information</div>
    <div class="message-body">
        The package is **Fable**.FontAwesome but we are hosting the package under **Fulma** repo for historical reason.
        In a future, we will probably move it to its own repo.
    </div>
</div>

*[Font Awesome documentation](https://fontawesome.com/how-to-use/on-the-web/referencing-icons/basic-use)*
                        """
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/referencing-icons/basic-use" target="_blank" class="fas fa-book"></a> - Basic use

Font Awesome 5 comes with different categories of icons. They are located under:

- `Fa.Solid.XXX` - `fas fa-xxxx`
- `Fa.Regular.XXX` - `far fa-xxxx`
- `Fa.Brand.XXX` - `fab fa-xxxx`
- `Fa.Light.XXX` - `fal fa-xxxx` - Only if you use `Fable.FontAwesome.Pro` and Font Awesome Pro

You can choose which element hosts your icon:

- `Fa.i`
- `Fa.span`
                        """
                        (Widgets.Showcase.view simpleDemo (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/styling/sizing-icons" target="_blank" class="fas fa-book"></a> - Sizing

Supported size:


- `Fa.Size Fa.FaExtraSmall`
- `Fa.Size Fa.FaSmall`
- `Fa.Size Fa.FaLarge`
- `Fa.Size Fa.Fa2x`
- `Fa.Size Fa.Fa3x`
- `Fa.Size Fa.Fa4x`
- `Fa.Size Fa.Fa5x`
- `Fa.Size Fa.Fa6x`
- `Fa.Size Fa.Fa7x`
- `Fa.Size Fa.Fa8x`
- `Fa.Size Fa.Fa9x`
- `Fa.Size Fa.Fa10`
                        """
                        (Widgets.Showcase.view iconSize (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/styling/fixed-width-icons" target="_blank" class="fas fa-book"></a> - Fixed width icons

Font Awesome options to set one or more icons to the same fixed width.
                        """
                        (Widgets.Showcase.view iconFixedWidth (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/styling/fixed-width-icons" target="_blank" class="fas fa-book"></a> - Icons in a list
                        """
                        (Widgets.Showcase.view iconInList (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/styling/rotating-icons" target="_blank" class="fas fa-book"></a> - Rotating icons
                        """
                        (Widgets.Showcase.view iconRotation (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/styling/animating-icons" target="_blank" class="fas fa-book"></a> - Animating icons
                        """
                        (Widgets.Showcase.view iconAnimation (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/styling/bordered-pulled-icons" target="_blank" class="fas fa-book"></a> - Bordered + Pulled Icons
                        """
                        (Widgets.Showcase.view iconBorderedAndPulled (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### <a href="https://fontawesome.com/how-to-use/on-the-web/styling/stacking-icons" target="_blank" class="fas fa-book"></a> - Stacked icons
                        """
                        (Widgets.Showcase.view iconStacked (Render.includeCode __LINE__ __SOURCE_FILE__))
                        ]
