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

let init() =
    { Intro =
        """
# Content

A single class to handle WYSIWYG generated content, where only **HTML tags** are available. Content also support size attributes.

*[Bulma documentation](http://bulma.io/documentation/elements/content/)*
        """
      SimpleViewer = Viewer.State.init simpleCode
      ModifierViewer = Viewer.State.init modifierCode }

let update msg model =
    match msg with
    | SimpleViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SimpleViewer
        { model with SimpleViewer = viewer }, Cmd.map SimpleViewerMsg viewerMsg

    | ModifierViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ModifierViewer
        { model with ModifierViewer = viewer }, Cmd.map ModifierViewerMsg viewerMsg
