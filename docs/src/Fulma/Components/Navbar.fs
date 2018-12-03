module Components.Navbar

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

let basic () =
    Navbar.navbar [ ]
        [ Navbar.Brand.div [ ]
            [ Navbar.Item.a [ Navbar.Item.Props [ Href "#" ] ]
                [ img [ Style [ Width "2.5em" ] // Force svg display
                        Src "assets/logo_transparent.svg" ] ] ]
          Navbar.Item.a [ Navbar.Item.HasDropdown
                          Navbar.Item.IsHoverable ]
            [ Navbar.Link.a [ ]
                [ str "Docs" ]
              Navbar.Dropdown.div [ ]
                [ Navbar.Item.a [ ]
                    [ str "Overwiew" ]
                  Navbar.Item.a [ ]
                    [ str "Elements" ]
                  Navbar.divider [ ] [ ]
                  Navbar.Item.a [ ]
                    [ str "Components" ] ] ]
          Navbar.Item.a [ Navbar.Item.HasDropdown
                          Navbar.Item.IsHoverable ]
            [ Navbar.Link.a [ Navbar.Link.IsArrowless ]
                [ str "Link without arrow" ]
              Navbar.Dropdown.div [ ]
                [ Navbar.Item.a [ ]
                    [ str "Overwiew" ] ] ]
          Navbar.End.div [ ]
            [ Navbar.Item.div [ ]
                [ Button.button [ Button.Color IsSuccess ]
                    [ str "Demo" ] ] ] ]

let colors () =
    Navbar.navbar [ Navbar.Color IsInfo ]
        [ Navbar.Brand.div [ ]
            [ Navbar.Item.a [ Navbar.Item.Props [ Href "#" ] ]
                [ img [ Style [ Width "2.5em" ] // Force svg display
                        Src "assets/logo_transparent.svg" ] ] ]
          Navbar.Item.a [ Navbar.Item.HasDropdown
                          Navbar.Item.IsHoverable ]
            [ Navbar.Link.a [ ]
                [ str "Docs" ]
              Navbar.Dropdown.div [ ]
                [ Navbar.Item.a [ ]
                    [ str "Overwiew" ]
                  Navbar.Item.a [ ]
                    [ str "Elements" ]
                  Navbar.divider [ ] [ ]
                  Navbar.Item.a [ ]
                    [ str "Components" ] ] ]
          Navbar.End.div [ ]
            [ Navbar.Item.div [ ]
                [ Button.button [ Button.Color IsSuccess ]
                    [ str "Demo" ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Navbar

*[Bulma documentation](http://bulma.io/documentation/components/navbar/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Colors

You can see the default looks [here](https://bulma.io/documentation/components/navbar/#colors).
                        """
                        (Widgets.Showcase.view colors (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.contentFromMarkdown
                        """
### Important

In bulma framework, some components of the navbar can either be rooted by `a` or a `div` element. In order, to provide you this choice we added suffix to some of the helpers:

- item
- brand
- link
- dropdown
- end
- start
                        """ ]
