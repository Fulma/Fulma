module Components.Tabs.State

open Elmish
open Types

let iconCode =
    """
```fsharp
    Tabs.tabs [ ]
        [ Tabs.tab [ Tabs.Tab.isActive ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]
```
    """

let alignment =
    """
```fsharp
    Tabs.tabs [ Tabs.isCentered ]
        [ Tabs.tab [ Tabs.Tab.isActive ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]
```
    """

let size =
    """
```fsharp
    Tabs.tabs [ Tabs.isLarge ]
        [ Tabs.tab [ Tabs.Tab.isActive ]
            [ a [ ] [ str "Fable" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Elmish" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Bulma" ] ]
          Tabs.tab [ ]
            [ a [ ] [ str "Hink" ] ] ]
```
    """

let styles =
    """
```fsharp
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
```
    """

let init() =
    { Intro =
        """
# Tabs

Simple responsive horizontal navigation **tabs**, with different styles

*[Bulma documentation](http://bulma.io/documentation/components/tabs/)*
        """
      BasicViewer = Viewer.State.init iconCode
      AlignmentViewer = Viewer.State.init alignment
      SizeViewer = Viewer.State.init size
      StylesViewer = Viewer.State.init styles }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg

    | AlignmentViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.AlignmentViewer
        { model with AlignmentViewer = viewer }, Cmd.map AlignmentViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg

    | StylesViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.StylesViewer
        { model with StylesViewer = viewer }, Cmd.map StylesViewerMsg viewerMsg
