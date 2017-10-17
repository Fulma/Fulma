module Components.Dropdown.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Components
open Fulma.Extra.FontAwesome

let basic =
    Dropdown.dropdown [ Dropdown.isHoverable ]
        [ div [ ]
            [ Button.button_a [ ]
                [ span [ ]
                    [ str "Dropdown" ]
                  Icon.faIcon [ Icon.isSmall ] [ Fa.icon Fa.I.AngleDown ] ] ]
          Dropdown.menu [ ]
            [ Dropdown.content [ ]
                [ Dropdown.item [ ] [ str "Item n°1" ]
                  Dropdown.item [ ] [ str "Item n°2" ]
                  Dropdown.item [ Dropdown.Item.isActive ] [ str "Item n°3" ]
                  Dropdown.item [ ] [ str "Item n°4" ]
                  Dropdown.divider [ ]
                  Dropdown.item [ ] [ str "Item n°5" ] ] ] ]

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
