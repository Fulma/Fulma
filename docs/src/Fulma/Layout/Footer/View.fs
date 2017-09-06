module Layouts.Footer.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Layout
open Fulma.Elements.Form
open Fulma.Elements
open Fulma.BulmaClasses

let basic =
    Footer.footer [ ]
        [ Content.content [ Content.customClass Bulma.Properties.Alignment.HasTextCentered ]
            [ h1 [ ]
                 [ str "Fulma" ]
              p [ ]
                [ str "A wrapper around Bulma to help you create application quicker" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch)) ]
