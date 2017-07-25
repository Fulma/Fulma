module Components.Breadcrumb.State

open Elmish
open Types

let basic =
    """
```fsharp
    Breadcrumb.breadcrumb [ ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.isActive ]
            [ a [ ] [ str "Elmish" ] ] ]
```
    """

let alignmentCenter =
    """
```fsharp
    Breadcrumb.breadcrumb [ Breadcrumb.isCentered ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.isActive ]
            [ a [ ] [ str "Elmish" ] ] ]
```
    """

let icons =
    """
```fsharp
    Breadcrumb.breadcrumb [ ]
        [ Breadcrumb.item [ ]
            [ a [ ]
                [ Icon.icon [ Icon.isSmall ]
                    [ i [ ClassName "fa fa-home" ] [ ] ]
                  str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ]
                [ Icon.icon [ Icon.isSmall ]
                    [ i [ ClassName "fa fa-book" ] [ ] ]
                  str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.isActive ]
            [ a [ ]
                [ Icon.icon [ Icon.isSmall ]
                    [ i [ ClassName "fa fa-thumbs-up" ] [ ] ]
                  str "Elmish" ] ] ]
```
    """

let size =
    """
```fsharp
    Breadcrumb.breadcrumb [ Breadcrumb.isLarge ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.isActive ]
            [ a [ ] [ str "Elmish" ] ] ]
```
    """

let separator =
    """
```fsharp
    Breadcrumb.breadcrumb [ Breadcrumb.hasSucceedsSeparator ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.isActive ]
            [ a [ ] [ str "Elmish" ] ] ]
```
    """

let init() =
    { Intro =
        """
# Breadcrumb

*[Bulma documentation](http://bulma.io/documentation/components/breadcrumb/)*
        """
      BasicViewer = Viewer.State.init basic
      AlignmentCenterViewer = Viewer.State.init alignmentCenter
      IconViewer = Viewer.State.init icons
      SizeViewer = Viewer.State.init size
      SeparatorViewer = Viewer.State.init separator }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg

    | AlignmentCenterViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.AlignmentCenterViewer
        { model with AlignmentCenterViewer = viewer }, Cmd.map AlignmentCenterViewerMsg viewerMsg

    | IconViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.IconViewer
        { model with IconViewer = viewer }, Cmd.map IconViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg

    | SeparatorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SeparatorViewer
        { model with SeparatorViewer = viewer }, Cmd.map SeparatorViewerMsg viewerMsg
