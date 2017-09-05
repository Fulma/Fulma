module Elements.Notification.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Grids


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
                        (Viewer.View.root delete model.DeleteViewer (DeleteViewerMsg >> dispatch)) ]
