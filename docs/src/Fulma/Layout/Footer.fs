module Layouts.Footer

open Fable.React
open Fulma

let basic () =
    Footer.footer [ ]
        [ Content.content [ Content.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
            [ h1 [ ]
                 [ str "Fulma" ]
              p [ ]
                [ str "A wrapper around Bulma to help you create application quicker" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Footer

*[Bulma documentation](http://bulma.io/documentation/layout/footer/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
