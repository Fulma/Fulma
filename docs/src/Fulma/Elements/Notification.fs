module Elements.Notification

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Elements

let basic () =
    Notification.notification [ ]
        [ str "I am a notification" ]

let color () =
    Notification.notification [ Notification.Color IsSuccess ]
        [ str "I am a notification with some colors" ]

let withCross () =
    Notification.notification [ Notification.Color IsDanger ]
        [ Notification.delete [ ] [ ]
          str "I am a notification with some colors and a delete button" ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Notification

*[Bulma documentation](http://bulma.io/documentation/elements/notification/)*
                        """
                     Render.docSection
                        ""
                        (Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        "### Colors"
                        (Showcase.view color (Render.getViewSource color))
                     Render.docSection
                        "### Delete button"
                        (Showcase.view withCross (Render.getViewSource withCross)) ]
