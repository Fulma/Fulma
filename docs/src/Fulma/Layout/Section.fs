module Layouts.Section

open Fable.React
open Fulma

let basic () =
    Section.section [ ]
        [ Container.container [ Container.IsFluid ]
            [ Heading.h1 [ ]
                [ str "Section" ]
              Heading.h2 [ Heading.IsSubtitle ]
                [ str "A simple container to divide your page into sections" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Section

*[Bulma documentation](http://bulma.io/documentation/layout/section/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.contentFromMarkdown
                        """
### Properties

Spacing:

- `Section.Size IsMedium`
- `Section.Size IsLarge`
                        """ ]
