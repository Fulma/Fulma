module Layouts.Section.View

open Fable.Helpers.React
open Types
open Fulma.Layouts
open Fulma.Elements

let basic =
    Section.section [ ]
        [ Container.container [ Container.IsFluid ]
            [ Heading.h1 [ ]
                [ str "Section" ]
              Heading.h2 [ Heading.IsSubtitle ]
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
