module Components.Navbar

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Components
open Fulma.Elements

let basic () =
    Navbar.navbar [ ]
        [ Navbar.Brand.div [ ]
            [ Navbar.Item.a [ Navbar.Item.Props [ Href "#" ] ]
                [ img [ Style [ Width "2.5em" ] // Force svg display
                        Src "assets/logo_transparent.svg" ] ] ]
          Navbar.Item.a  [ Navbar.Item.HasDropdown
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

let colors () =
    let navbarWithColor color =
        Navbar.navbar [ Navbar.Color color ]
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
    div [ ]
        [ navbarWithColor IsDanger
          br [ ]
          navbarWithColor IsInfo ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Navbar

*[Bulma documentation](http://bulma.io/documentation/components/navbar/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        """
### Colors

Please note the display on the next sample isn't perfact because we customize Bulma to work with Fulma colors for the docs site.

You can see the default looks [here](https://bulma.io/documentation/components/navbar/#colors).
                        """
                        (Widgets.Showcase.view colors (Render.getViewSource colors))
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
