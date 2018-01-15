module Components.Dropdown.View

open Fable.Helpers.React
open Types
open Fulma
open Fulma.Elements
open Fulma.Components
open Fulma.Extra.FontAwesome

let basic =
    Dropdown.dropdown [ Dropdown.IsHoverable ]
        [ div [ ]
            [ Button.button [ ]
                [ span [ ]
                    [ str "Dropdown" ]
                  Icon.faIcon [ Icon.Size IsSmall ] [ Fa.icon Fa.I.AngleDown ] ] ]
          Dropdown.menu [ ]
            [ Dropdown.content [ ]
                [ Dropdown.Item.a [ ] [ str "Item n°1" ]
                  Dropdown.Item.a [ ] [ str "Item n°2" ]
                  Dropdown.Item.a [ Dropdown.Item.IsActive true ] [ str "Item n°3" ]
                  Dropdown.Item.a [ ] [ str "Item n°4" ]
                  Dropdown.divider [ ]
                  Dropdown.Item.a [ ] [ str "Item n°5" ] ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.contentFromMarkdown
                        """
### Properties

#### Dropdown
State:

- `Dropdown.isActive`
- `Dropdown.isHoverable`

Alignment:

- `Dropdown.isRight`

#### Dropdown item

State:

- `Dropdown.Item.isActive`
                        """ ]
