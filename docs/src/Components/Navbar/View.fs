module Components.Navbar.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Components
open Elmish.Bulma.Elements

let basic =
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

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
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
