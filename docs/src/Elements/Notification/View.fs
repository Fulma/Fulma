module Elements.Notification.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Grids


let basic =
    Notification.notification [ ]
        [ str "I am a notification" ]

let color =
    Notification.notification [ Notification.isSuccess ]
        [ str "I am a notification with some colors" ]

let delete =
    Notification.notification [ Notification.isDanger ]
        [ Notification.delete [ ] [ ]
          str "I am a notification with some colors and a delete button" ]

let convenience dispatch =
    Button.button [ Button.onClick (fun _ -> dispatch NewGlobalNotification) ]
        [ str "Click me and generate a global notification" ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.docSection
                        "### Colors"
                        (Viewer.View.root color model.ColorViewer (ColorViewerMsg >> dispatch))
                     Render.docSection
                        "### Delete button"
                        (Viewer.View.root delete model.DeleteViewer (DeleteViewerMsg >> dispatch))
                     Render.docSection
                        """
### Convenience functions


                        """
                        (Viewer.View.root (convenience dispatch) model.DeleteViewer (DeleteViewerMsg >> dispatch))
                      ]
