module Components.Tabs

open Fable.React
open Fulma

let basic () =
    Tabs.tabs [ ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ]
                [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Hink" ] ] ]

let alignment () =
    Tabs.tabs [ Tabs.IsCentered ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ]
                [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Hink" ] ] ]

let size () =
    Tabs.tabs [ Tabs.Size IsLarge ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ]
                [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Hink" ] ] ]

let styles () =
    Tabs.tabs [ Tabs.IsFullWidth
                Tabs.IsBoxed ]
        [ Tabs.tab [ Tabs.Tab.IsActive true ]
            [ a [ ]
                [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ]
                [ str "Hink" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Tabs

Simple responsive horizontal navigation **tabs**, with different styles

*[Bulma documentation](http://bulma.io/documentation/components/tabs/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Alignment"
                        (Widgets.Showcase.view alignment (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Size"
                        (Widgets.Showcase.view size (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Styles"
                        (Widgets.Showcase.view styles (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
