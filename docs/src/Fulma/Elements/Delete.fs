module Elements.Delete

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

let demoInteractive () =
    div [ ClassName "block" ]
        [ Delete.delete
            [ Delete.Size IsSmall ] [ ]
          Delete.delete
            [ ] [ ]
          Delete.delete
            [ Delete.Size IsMedium ] [ ]
          Delete.delete
            [ Delete.Size IsLarge ] [ ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Delete

The **delete** element can have different sizes.

*[Bulma documentation](http://bulma.io/documentation/elements/delete/)*
                        """
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view demoInteractive (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
