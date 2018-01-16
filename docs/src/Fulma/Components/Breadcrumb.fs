module Components.Breadcrumb

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Components
open Fulma.Elements
open Fulma.Extra.FontAwesome

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
                        (Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        """
### Alignment

Supported alignment:

* `Breadcrumb.isCentered`
* `Breadcrumb.isRight`

When you do not set the alignment, it's align to the *left*.

                        """
                        (Showcase.view alignmentCenter (Render.getViewSource alignmentCenter))
                     Render.docSection
                        "### Icons"
                        (Showcase.view icons (Render.getViewSource icons))
                     Render.docSection
                        """
### Size

Supported size:

* `Breadcrumb.isSmall`
* `Breadcrumb.isMedium`
* `Breadcrumb.isLarge`

By default, size is considered *normal*.

                        """
                        (Showcase.view size (Render.getViewSource size))
                     Render.docSection
                        """
### Separators

Supported separators:

* `Breadcrumb.hasArrowSeparator`
* `Breadcrumb.hasBulletSeparator`
* `Breadcrumb.hasDotSeparator`
* `Breadcrumb.hasSucceedsSeparator`

                        """
                        (Showcase.view separator (Render.getViewSource separator)) ]
