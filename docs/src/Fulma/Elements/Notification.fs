module Elements.Notification

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Fulma

let basic () =
    Notification.notification [ ]
        [ str "I am a notification" ]

let color () =
    div [ ] [
        Notification.notification [ Notification.Color IsSuccess ]
            [ str "I am a notification with some color" ]
        Notification.notification [ Notification.Color IsSuccess; Notification.IsLight ]
            [ str "I am a notification with some light color" ]
    ]

let withCross () =
    Notification.notification [ Notification.Color IsDanger ]
        [ Notification.delete [ ] [ ]
          str "I am a notification with some color and a delete button" ]

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
