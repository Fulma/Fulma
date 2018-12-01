module Elements.Notification

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

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
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view color (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Delete button"
                        (Widgets.Showcase.view withCross (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
