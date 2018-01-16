module Components.Pagination

open Fable.Helpers.React
open Fulma
open Fulma.Components

let basic () =
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

let aligment () =
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

let size () =
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

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Pagination

*[Bulma documentation](http://bulma.io/documentation/components/pagination/)*
                        """
                     Render.docSection
                        ""
                        (Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        """

### Alignment

Supported size:

* `Content.isCentered`
* `Content.isRight`

When you do not set the alignment, it's consider *left*.
                        """
                        (Showcase.view aligment (Render.getViewSource aligment))
                     Render.docSection
                        """
### Size

Supported size:

* `Pagination.isSmall`
* `Pagination.isMedium`
* `Pagination.isLarge`

When you do not set the size, it's consider *normal*.
                        """
                        (Showcase.view size (Render.getViewSource size)) ]
