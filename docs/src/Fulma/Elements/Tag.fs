module Elements.Tag

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

let colorInteractive () =
    div [ ClassName "block" ]
        [ Tag.tag [ ] [ str "Default" ]
          Tag.tag [ Tag.Color IsWhite ] [ str "White" ]
          Tag.tag [ Tag.Color IsLight ] [ str "Light" ]
          Tag.tag [ Tag.Color IsDark ] [ str "Dark" ]
          Tag.tag [ Tag.Color IsBlack ] [ str "Black" ]
          Tag.tag [ Tag.Color IsPrimary ] [ str "Primary" ]
          Tag.tag [ Tag.Color IsInfo ] [ str "Info" ]
          Tag.tag [ Tag.Color IsSuccess ] [ str "Success" ]
          Tag.tag [ Tag.Color IsWarning ] [ str "Warning" ]
          Tag.tag [ Tag.Color IsDanger ] [ str "Danger" ] ]

let sizeInteractive () =
    div [ ClassName "block" ]
        [ Tag.tag [ ] [ str "Normal" ]
          Tag.tag [ Tag.Color IsPrimary; Tag.Size IsMedium ] [ str "Medium" ]
          Tag.tag [ Tag.Color IsInfo; Tag.Size IsLarge ] [ str "Large" ] ]

let nestedDeleteStyleInteractive () =
    div [ ClassName "block" ]
        [ Tag.tag [ Tag.Color IsDark ]
            [ str "With delete"
              Delete.delete [ Delete.Size IsSmall ] [ ] ]
          Tag.tag [ Tag.Size IsMedium ]
            [ str "With delete"
              Delete.delete [ ] [ ] ]
          Tag.tag [ Tag.Color IsWarning; Tag.Size IsLarge ]
            [ str "With delete"
              Delete.delete [ Delete.Size IsLarge ] [ ] ] ]

let list () =
    Tag.list [ Tag.List.HasAddons ]
        [ Tag.tag [ Tag.Color IsDanger ] [ str "Maxime Mangel" ]
          Tag.delete [ ] [ ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Tags

The **tags** can have different colors and sizes. You can also nest a *[Delete element](#elements/delete)* in it.

*[Bulma documentation](http://bulma.io/documentation/elements/tag/)*
                        """
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Nested delete"
                        (Widgets.Showcase.view nestedDeleteStyleInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Tag List"
                        (Widgets.Showcase.view list (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
