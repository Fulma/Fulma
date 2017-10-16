module Elements.Table.State

open Elmish
open Types

let simpleCode =
    """
```fsharp
    Table.table [ ]
        [ thead [ ]
            [ tr
            [ ]
            [ th [ ] [ str "Firstname" ]
              th [ ] [ str "Surname" ]
              th [ ] [ str "Birthday" ] ] ]
          tbody [ ]
            [ tr [ ]
                 [ td [ ] [ str "Maxime" ]
                   td [ ] [ str "Mangel" ]
                   td [ ] [ str "28/02/1992" ] ]
              tr [ Table.Row.isSelected ]
                 [ td [ ] [ str "Jane" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "21/07/1987" ] ]
              tr [  ]
                 [ td [ ] [ str "John" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "11/07/1978" ] ] ] ]
```
    """

let modifierCode =
    """
```fsharp
    Table.table [ Table.isBordered
                  Table.isNarrow
                  Table.isStripped ]
        [ thead [ ]
            [ tr [ ]
                 [ th [ ] [ str "Firstname" ]
                   th [ ] [ str "Surname" ]
                   th [ ] [ str "Birthday" ] ] ]
          tbody [ ]
            [ tr [ ]
                [ td [ ] [ str "Maxime" ]
                  td [ ] [ str "Mangel" ]
                  td [ ] [ str "28/02/1992" ] ]
              tr [ Table.Row.isSelected ]
                 [ td [ ] [ str "Jane" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "21/07/1987" ] ]
              tr [  ]
                 [ td [ ] [ str "John" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "11/07/1978" ] ] ] ]
```
    """
let modifierFullWidthCode =
    """
```fsharp
    Table.table [ Table.isBordered
                  Table.isFullWidth
                  Table.isStripped ]
        [ thead [ ]
            [ tr [ ]
                 [ th [ ] [ str "Firstname" ]
                   th [ ] [ str "Surname" ]
                   th [ ] [ str "Birthday" ] ] ]
          tbody [ ]
            [ tr [ ]
                [ td [ ] [ str "Maxime" ]
                  td [ ] [ str "Mangel" ]
                  td [ ] [ str "28/02/1992" ] ]
              tr [ Table.Row.isSelected ]
                 [ td [ ] [ str "Jane" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "21/07/1987" ] ]
              tr [  ]
                 [ td [ ] [ str "John" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "11/07/1978" ] ] ] ]
```
    """


let init() =
    { Intro =
        """
# Table

*[Bulma documentation](http://bulma.io/documentation/elements/table/)*
        """
      SimpleViewer = Viewer.State.init simpleCode
      ModifierViewer = Viewer.State.init modifierCode
      ModifierFullWidth = Viewer.State.init modifierFullWidthCode }

let update msg model =
    match msg with
    | SimpleViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SimpleViewer
        { model with SimpleViewer = viewer }, Cmd.map SimpleViewerMsg viewerMsg

    | ModifierViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ModifierViewer
        { model with ModifierViewer = viewer }, Cmd.map ModifierViewerMsg viewerMsg

    | ModifierFullWidthMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ModifierFullWidth
        { model with ModifierFullWidth = viewer }, Cmd.map ModifierFullWidthMsg viewerMsg
