module Components.Navbar.State

open Elmish
open Types

let basic =
    """
```fsharp
    Navbar.navbar [ ]
        [ Navbar.brand_div [ ]
            [ Navbar.item_a[ Navbar.Item.props [ Href "#" ] ]
                [ img [ Src "/assets/logo.png" ] ] ]
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
                [ Button.button_div [ Button.isSuccess ]
                    [ str "Demo" ] ] ] ]
```
    """

let colors =
    """
```fsharp
    let navbarWithColor color =
        Navbar.navbar [ color ]
            [ Navbar.brand_div [ ]
                [ Navbar.item_a[ Navbar.Item.props [ Href "#" ] ]
                    [ img [ Style [ Width "2.5em" ] // Force svg display
                            Src "/assets/logo_transparent.svg" ] ] ]
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
                    [ Button.button_div [ Button.isSuccess ]
                        [ str "Demo" ] ] ] ]

    navbarWithColor Navbar.isDanger

    navbarWithColor Navbar.isInfo
```
    """

let init() =
    { Intro =
        """
# Navbar

*[Bulma documentation](http://bulma.io/documentation/components/navbar/)*
        """
      BasicViewer = Viewer.State.init basic
      ColorViewer = Viewer.State.init colors }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg

    | ColorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ColorViewer
        { model with ColorViewer = viewer }, Cmd.map ColorViewerMsg viewerMsg
