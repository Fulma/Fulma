module Elements.Tag.State

open Elmish
open Types

let colorCode =
    """
```fsharp
    Tag.tag [ ] [ str "Default" ]
    Tag.tag [ Tag.isWhite ] [ str "White" ]
    Tag.tag [ Tag.isLight ] [ str "Light" ]
    Tag.tag [ Tag.isDark ] [ str "Dark" ]
    Tag.tag [ Tag.isBlack ] [ str "Black" ]
    Tag.tag [ Tag.isPrimary ] [ str "Primary" ]
    Tag.tag [ Tag.isInfo ] [ str "Info" ]
    Tag.tag [ Tag.isSuccess ] [ str "Success" ]
    Tag.tag [ Tag.isWarning ] [ str "Warning" ]
    Tag.tag [ Tag.isDanger ] [ str "Danger" ]
```
    """

let sizeCode =
    """
```fsharp
    Tag.tag [ ] [ str "Normal" ]
    Tag.tag [ Tag.isPrimary; Tag.isMedium ] [ str "Medium" ]
    Tag.tag [ Tag.isInfo; Tag.isLarge ] [ str "Large" ]
```
    """


let nestedDeletedCode =
    """
```fsharp
    Tag.tag [ Tag.isDark ]
        [ str "With delete"
          Delete.delete [ Delete.isSmall ] [ ] ]
    Tag.tag [ Tag.isMedium ]
        [ str "With delete"
          Delete.delete [ ] [ ] ]
    Tag.tag [ Tag.isWarning; Tag.isLarge ]
        [ str "With delete"
          Delete.delete [ Delete.isLarge ] [ ] ]
```
    """

let list =
    """
```fsharp
    Tag.list [ Tag.List.HasAddons ]
        [ Tag.tag [ Tag.Color IsDanger ] [ str "Maxime Mangel" ]
          Tag.delete [ ] [ ] ]
```
    """

let init() =
    { Intro =
        """
# Tags

The **tags** can have different colors and sizes. You can also nest a *[Delete element](#elements/delete)* in it.

*[Bulma documentation](http://bulma.io/documentation/elements/tag/)*
        """
      ColorViewer = Viewer.State.init colorCode
      SizeViewer = Viewer.State.init sizeCode
      NestedDeleteViewer = Viewer.State.init nestedDeletedCode
      ListViewer = Viewer.State.init list }

let update msg model =
    match msg with
    | ColorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ColorViewer
        { model with ColorViewer = viewer }, Cmd.map ColorViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg

    | NestedDeleteViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.NestedDeleteViewer
        { model with NestedDeleteViewer = viewer }, Cmd.map NestedDeleteViewerMsg viewerMsg

    | ListViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ListViewer
        { model with ListViewer = viewer }, Cmd.map ListViewerMsg viewerMsg
