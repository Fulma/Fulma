module Layouts.Footer

open Fable.Helpers.React
open Fulma.Layouts
open Fulma.Elements
open Fulma.BulmaClasses

let basic () =
    Footer.footer [ ]
        [ Content.content [ Content.CustomClass Bulma.Properties.Alignment.HasTextCentered ]
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
                        (Widgets.Showcase.view basic (Render.getViewSource basic)) ]
