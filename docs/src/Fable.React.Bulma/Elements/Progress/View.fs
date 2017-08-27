module Elements.Progress.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fable.React.Bulma.Elements

let colorInteractive =
    div [ ClassName "block" ]
        [ Progress.progress
            [ Progress.value 15
              Progress.max 100 ] [ str "15%" ]
          Progress.progress
            [ Progress.isSuccess
              Progress.value 30
              Progress.max 100 ] [ str "30%" ]
          Progress.progress
            [ Progress.isInfo
              Progress.value 45
              Progress.max 100 ] [ str "45%" ]
          Progress.progress
            [ Progress.isWarning
              Progress.value 60
              Progress.max 100 ] [ str "60%" ]
          Progress.progress
            [ Progress.isPrimary
              Progress.value 75
              Progress.max 100 ] [ str "75%" ]
          Progress.progress
            [ Progress.isDanger
              Progress.value 90
              Progress.max 100 ] [ str "90%" ] ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Progress.progress
            [ Progress.isSmall
              Progress.value 15
              Progress.max 100 ] [ str "15%" ]
          Progress.progress
            [ Progress.value 30
              Progress.max 100 ] [ str "30%" ]
          Progress.progress
            [ Progress.isMedium
              Progress.value 45
              Progress.max 100 ] [ str "45%" ]
          Progress.progress
            [ Progress.isLarge
              Progress.value 60
              Progress.max 100 ] [ str "60%" ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Colors"
                        (Viewer.View.root colorInteractive model.ColorViewer (ColorViewerMsg >> dispatch))
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root sizeInteractive model.SizeViewer (SizeViewerMsg >> dispatch)) ]
