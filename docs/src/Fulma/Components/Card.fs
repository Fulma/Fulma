module Components.Card

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

let basic () =
    Card.card [ ]
        [ Card.header [ ]
            [ Card.Header.title [ ]
                [ str "Component" ]
              Card.Header.icon [ ]
                [ i [ ClassName "fa fa-angle-down" ] [ ] ] ]
          Card.content [ ]
            [ Content.content [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris." ] ]
          Card.footer [ ]
            [ Card.Footer.a [ ]
                [ str "Save" ]
              Card.Footer.a [ ]
                [ str "Edit" ]
              Card.Footer.a [ ]
                [ str "Delete" ] ] ]

let centered () =
    Card.card [ ]
        [ Card.header [ ]
            [ Card.Header.title [ Card.Header.Title.IsCentered ]
                [ str "Component" ]
              Card.Header.icon [ ]
                [ i [ ClassName "fa fa-angle-down" ] [ ] ] ]
          Card.content [ ]
            [ Content.content [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris." ] ]
          Card.footer [ ]
            [ Card.Footer.a [ ]
                [ str "Save" ]
              Card.Footer.a [ ]
                [ str "Edit" ]
              Card.Footer.a [ ]
                [ str "Delete" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Card

*[Bulma documentation](http://bulma.io/documentation/components/card/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        "### Title can be centered"
                        (Widgets.Showcase.view centered (Render.getViewSource centered)) ]
