module Components.Dropdown.State

open Elmish
open Types

let basic =
    """
```fsharp
    Dropdown.dropdown [ Dropdown.isHoverable ]
        [ div [ ]
            [ Button.button_a [ ]
                [ span [ ]
                    [ str "Dropdown" ]
                  Icon.faIcon [ Icon.isSmall ] Fa.I.AngleDown ] ]
          Dropdown.menu [ ]
            [ Dropdown.content [ ]
                [ Dropdown.item [ ] [ str "Item n°1" ]
                  Dropdown.item [ ] [ str "Item n°2" ]
                  Dropdown.item [ Dropdown.Item.isActive ] [ str "Item n°3" ]
                  Dropdown.item [ ] [ str "Item n°4" ]
                  Dropdown.divider [ ]
                  Dropdown.item [ ] [ str "Item n°5" ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Dropdown

*[Bulma documentation](http://bulma.io/documentation/components/dropdown/)*
        """
      BasicViewer = Viewer.State.init basic }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
