module Components.Navbar.State

open Elmish
open Types

let basic =
    """
```fsharp
    Navbar.navbar [ ]
        [ Navbar.brand_div [ ]
            [ Navbar.item_a[ Navbar.Item.props [ Href "#" ] ]
                [ img [ Src "/logo.png" ] ] ]
          Navbar.item_a [ Navbar.Item.hasDropdown
                          Navbar.Item.isHoverable ]

            [ Navbar.link_a [ ]
                [ str "Docs" ]
              Navbar.dropdown_div [ ]
                [ Navbar.item_a [ ]
                    [ str "Overwiew" ]
                  Navbar.item_a [ ]
                    [ str "Elements" ]
                  Navbar.divider [ ] [ ]
                  Navbar.item_a [ ]
                    [ str "Components" ] ] ]
          Navbar.end_div [ ]
            [ Navbar.item_div [ ]
                [ Button.button [ Button.isSuccess ]
                    [ str "Demo" ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Navbar

*[Bulma documentation](http://bulma.io/documentation/components/navbar/)*
        """
      BasicViewer = Viewer.State.init basic }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
