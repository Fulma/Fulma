module Components.Navbar.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.BulmaClasses
open Fulma.Components
open Fulma.Elements

let basic =
    Navbar.navbar [ ]
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
                [ Button.button_a [ Button.isSuccess ]
                    [ str "Demo" ] ] ] ]

let colors =
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
                    [ Button.button_a [ Button.isSuccess ]
                        [ str "Demo" ] ] ] ]

    div [ ]
        [ navbarWithColor Navbar.isDanger
          br [ ]
          navbarWithColor Navbar.isInfo ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.docSection
                        """
### Colors

Please note the display on the next sample isn't perfact because we customize Bulma to work with Fulma colors for the docs site.

You can see the default looks [here](https://bulma.io/documentation/components/navbar/#colors).
                        """
                        (Viewer.View.root colors model.ColorViewer (ColorViewerMsg >> dispatch))
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
