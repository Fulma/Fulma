module Components.Breadcrumb.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components

let iconInteractive =
        Breadcrumb.breadcrumb [ ]
            [ Breadcrumb.item [ ]
                [ a [ ] [ str "Fable" ] ]
              Breadcrumb.item [ ]
                [ a [ ] [ str "Fable" ] ]
              Breadcrumb.item [ ]
                [ a [ ] [ str "Fable" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.BoxViewer (BoxViewerMsg >> dispatch)) ]
