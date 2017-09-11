module FulmaExtensions.Divider.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Extensions
open Fulma.Elements
open Fulma.Layouts
open Fulma.Extra.FontAwesome
open Fulma.BulmaClasses

let basicInteractive =
    div [ ]
        [ div [ ClassName Bulma.Properties.Alignment.HasTextCentered ]
              [ Heading.h1 [ ] [ str "Top" ] ]
          Divider.divider [ ] [ ]
          div [ ClassName Bulma.Properties.Alignment.HasTextCentered ]
              [ Heading.h1 [ ] [ str "Middle" ] ]
          Divider.divider [ Divider.label "OR" ] [ ]
          div [ ClassName Bulma.Properties.Alignment.HasTextCentered ]
              [ Heading.h1 [ ] [ str "Bottom" ] ] ]

let verticalInteractive =
     Columns.columns [ ]
        [ Column.column [ Column.customClass Bulma.Properties.Alignment.HasTextCentered ]
              [ Heading.h1 [ ] [str "Left"] ]
          Column.column [ ]
              [ Divider.divider [ Divider.label "OR"
                                  Divider.IsVertical ] [ ] ]
          Column.column [ Column.customClass Bulma.Properties.Alignment.HasTextCentered ]
              [ Heading.h1 [ ] [ str "Right" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                         "### Default divider"
                         (Viewer.View.root basicInteractive model.NormalViewer (NormalViewerMsg >> dispatch))
                     Render.docSection
                         "### Vertical divider"
                         (Viewer.View.root verticalInteractive model.VerticalViewer (VerticalViewerMsg >> dispatch)) ]
