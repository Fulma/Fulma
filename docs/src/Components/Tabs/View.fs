module Components.Tabs.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components
open Elmish.Bulma.Grids
open Elmish.Bulma.Elements.Form


let basic =
    Tabs.tabs [ ]
        [ Tabs.tab [ Tabs.Tab.isActive ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]

let alignment =
    Tabs.tabs [ Tabs.isCentered ]
        [ Tabs.tab [ Tabs.Tab.isActive ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]

let size =
    Tabs.tabs [ Tabs.isLarge ]
        [ Tabs.tab [ Tabs.Tab.isActive ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]

let styles =
    Tabs.tabs [ Tabs.isFullwidth
                Tabs.isBoxed ]
        [ Tabs.tab [ Tabs.Tab.isActive ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]


let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.docSection
                        "### Alignment"
                        (Viewer.View.root alignment model.AlignmentViewer (AlignmentViewerMsg >> dispatch))
                     Render.docSection
                        "### Size"
                        (Viewer.View.root size model.SizeViewer (SizeViewerMsg >> dispatch))
                     Render.docSection
                        "### Styles"
                        (Viewer.View.root styles model.StylesViewer (StylesViewerMsg >> dispatch)) ]
