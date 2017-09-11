module Layouts.Section.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Layout
open Fulma.Elements.Form
open Fulma.Elements
open Fulma.Components
open Fulma.BulmaClasses

let basic =
    Section.section [ ]
        [ Container.container [ Container.isFluid ]
            [ Heading.h1 [ ]
                [ str "Section" ]
              Heading.h2 [ Heading.isSubtitle ]
                [ str "A simple container to divide your page into sections" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.contentFromMarkdown
                        """
### Properties

Spacing:

- `Section.isMedium`
- `Section.isLarge`
                        """
                        ]
