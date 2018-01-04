module Components.Pagination.View

open Fable.Helpers.React
open Types
open Fulma
open Fulma.Components

let basic =
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
              Pagination.link [ Pagination.Link.Current true ]
                [ str "33" ]
              Pagination.link [ ]
                [ str "34" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "77" ] ] ]

let aligment =
    Pagination.pagination [ Pagination.IsCentered ]
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
              Pagination.link [ Pagination.Link.Current true ]
                [ str "33" ]
              Pagination.link [ ]
                [ str "34" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "77" ] ] ]

let size =
    Pagination.pagination [  Pagination.Size IsSmall]
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
              Pagination.link [ Pagination.Link.Current true ]
                [ str "33" ]
              Pagination.link [ ]
                [ str "34" ]
              Pagination.ellipsis [ ]
              Pagination.link [ ]
                [ str "77" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.docSection
                        """

### Alignment

Supported size:

* `Content.isCentered`
* `Content.isRight`

When you do not set the alignment, it's consider *left*.
                        """
                        (Viewer.View.root aligment model.AlignmentViewer (AlignmentViewerMsg >> dispatch))
                     Render.docSection
                        """
### Size

Supported size:

* `Pagination.isSmall`
* `Pagination.isMedium`
* `Pagination.isLarge`

When you do not set the size, it's consider *normal*.
                        """
                        (Viewer.View.root size model.SizeViewer (SizeViewerMsg >> dispatch)) ]
