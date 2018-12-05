module Elements.Icon

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fable.FontAwesome

let iconDemo () =
    div [ ClassName "block" ]
        [ Icon.icon [ Icon.Size IsSmall ]
            [ i [ ClassName "fas fa-home" ] [ ] ]
          Icon.icon [ ]
            [ i [ ClassName "fas fa-lg fa-home" ] [ ] ]
          Icon.icon [ Icon.Size IsMedium ]
            [ i [ ClassName "fas fa-2x fa-home" ] [ ] ]
          Icon.icon [ Icon.Size IsLarge ]
            [ i [ ClassName "fas fa-3x fa-home" ] [ ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Icons

The **icons** can have different sizes and is also compatible with *[Font Awesome](http://fontawesome.io/)* icons.

*[Bulma documentation](http://bulma.io/documentation/elements/icon/)*
                        """
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view iconDemo (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
