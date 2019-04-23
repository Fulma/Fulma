module Elements.Image

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Fulma

let fixedInteractive () =
    div [ ClassName "block" ]
        [ Image.image [ Image.Is64x64 ]
            [ img [ Src "https://dummyimage.com/64x64/7a7a7a/fff" ] ]
          br [ ]
          Image.image [ Image.Is128x128 ]
            [ img [ Src "https://dummyimage.com/128x128/7a7a7a/fff" ] ] ]

let responsiveInteractive () =
    div [ ClassName "block" ]
        [ Image.image [ Image.Is2by1 ]
            [ img [ Src "https://dummyimage.com/640x320/7a7a7a/fff" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Images

The **images** can have different sizes (fixed or ratio).

*[Bulma documentation](http://bulma.io/documentation/elements/image/)*
                        """
                     Render.docSection
                        "### Fixed square images"
                        (Widgets.Showcase.view fixedInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Responsive images with ratio"
                        (Widgets.Showcase.view responsiveInteractive (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
