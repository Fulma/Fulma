module Layouts.Footer

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma.Layouts
open Fulma.Elements.Form
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
# Level

*[Bulma documentation](http://bulma.io/documentation/layout/level/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.getViewSource basic)) ]
