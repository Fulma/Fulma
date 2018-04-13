module Components.Breadcrumb

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome

let basic () =
    Breadcrumb.breadcrumb [ ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Fable.React" ] ] ]

let alignmentCenter () =
    Breadcrumb.breadcrumb [ Breadcrumb.IsCentered ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Elmish" ] ] ]

let icons () =
    Breadcrumb.breadcrumb [ ]
        [ Breadcrumb.item [ ]
            [ a [ ]
                [ Icon.icon [ Icon.Size IsSmall ]
                    [ i [ ClassName "fa fa-home" ] [ ] ]
                  str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ]
                [ Icon.icon [ Icon.Size IsSmall ]
                    [ i [ ClassName "fa fa-book" ] [ ] ]
                  str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ]
                [ Icon.icon [ Icon.Size IsSmall ]
                    [ i [ ClassName "fa fa-thumbs-up" ] [ ] ]
                  str "Elmish" ] ] ]

let size () =
    Breadcrumb.breadcrumb [ Breadcrumb.Size IsLarge ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Elmish" ] ] ]

let separator () =
    Breadcrumb.breadcrumb [ Breadcrumb.HasSucceedsSeparator ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Elmish" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Breadcrumb

*[Bulma documentation](http://bulma.io/documentation/components/breadcrumb/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        """
### Alignment

Supported alignment:

* `Breadcrumb.IsCentered`
* `Breadcrumb.IsRight`

When you do not set the alignment, it's align to the *left*.

                        """
                        (Widgets.Showcase.view alignmentCenter (Render.getViewSource alignmentCenter))
                     Render.docSection
                        "### Icons"
                        (Widgets.Showcase.view icons (Render.getViewSource icons))
                     Render.docSection
                        """
### Size

Supported size:

* `Breadcrumb.Size IsSmall`
* `Breadcrumb.Size IsMedium`
* `Breadcrumb.Size IsLarge`

By default, size is considered *normal*.

                        """
                        (Widgets.Showcase.view size (Render.getViewSource size))
                     Render.docSection
                        """
### Separators

Supported separators:

* `Breadcrumb.HasArrowSeparator`
* `Breadcrumb.HasBulletSeparator`
* `Breadcrumb.HasDotSeparator`
* `Breadcrumb.HasSucceedsSeparator`

                        """
                        (Widgets.Showcase.view separator (Render.getViewSource separator)) ]
