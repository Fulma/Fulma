module Components.Tabs

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Elements
open Fulma.Components
open Fulma.Layouts
open Fulma.Elements.Form

let basic () =
    Tabs.tabs [ ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]

let alignment () =
    Tabs.tabs [ Tabs.IsCentered ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]

let size () =
    Tabs.tabs [ Tabs.Size IsLarge ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]

let styles () =
    Tabs.tabs [ Tabs.IsFullwidth
                Tabs.IsBoxed ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Tabs

Simple responsive horizontal navigation **tabs**, with different styles

*[Bulma documentation](http://bulma.io/documentation/components/tabs/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        "### Alignment"
                        (Widgets.Showcase.view alignment (Render.getViewSource alignment))
                     Render.docSection
                        "### Size"
                        (Widgets.Showcase.view size (Render.getViewSource size))
                     Render.docSection
                        "### Styles"
                        (Widgets.Showcase.view styles (Render.getViewSource styles)) ]
