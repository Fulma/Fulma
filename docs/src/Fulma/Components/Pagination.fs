module Components.Pagination

open Fable.React
open Fulma

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
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """

### Alignment

Supported size:

* `Content.IsCentered`
* `Content.IsRight`

When you do not set the alignment, it's consider *left*.
                        """
                        (Widgets.Showcase.view aligment (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Size

Supported size:

* `Pagination.Size IsSmall`
* `Pagination.Size IsMedium`
* `Pagination.Size IsLarge`

When you do not set the size, it's consider *normal*.
                        """
                        (Widgets.Showcase.view size (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
