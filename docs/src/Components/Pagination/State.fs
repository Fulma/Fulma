module Components.Pagination.State

open Elmish
open Types

let basic =
    """
```fsharp
    Pagination.pagination [ ]
        [ Pagination.previous [ ]
            [ str "Previous" ]
          Pagination.next [ ]
            [ str "Next page" ]
          Pagination.list [ ]
            [ Pagination.link [ ]
                [ str "1" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "32" ]
              Pagination.link [ Pagination.Link.isCurrent ]
                [ str "33" ]
              Pagination.link [ ]
                [ str "34" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "77" ] ] ]
```
    """

let alignment =
    """
```fsharp
    Pagination.pagination [ ]
        [ Pagination.previous [ ]
            [ str "Previous" ]
          Pagination.next [ ]
            [ str "Next page" ]
          Pagination.list [ ]
            [ Pagination.link [ ]
                [ str "1" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "32" ]
              Pagination.link [ Pagination.Link.isCurrent ]
                [ str "33" ]
              Pagination.link [ ]
                [ str "34" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "77" ] ] ]
```
    """

let size =
    """
```fsharp
    Pagination.pagination [ ]
        [ Pagination.previous [ ]
            [ str "Previous" ]
          Pagination.next [ ]
            [ str "Next page" ]
          Pagination.list [ ]
            [ Pagination.link [ ]
                [ str "1" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "32" ]
              Pagination.link [ Pagination.Link.isCurrent ]
                [ str "33" ]
              Pagination.link [ ]
                [ str "34" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "77" ] ] ]
```
    """

let init() =
    { Intro =
        """
# Pagination

*[Bulma documentation](http://bulma.io/documentation/components/pagination/)*
        """
      BasicViewer = Viewer.State.init basic
      AlignmentViewer = Viewer.State.init alignment
      SizeViewer = Viewer.State.init size }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg

    | AlignmentViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with AlignmentViewer = viewer }, Cmd.map AlignmentViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg
