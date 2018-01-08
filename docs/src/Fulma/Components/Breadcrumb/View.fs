module Components.Breadcrumb.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Elements
open Fulma.Components

let basic =
    Breadcrumb.breadcrumb [ ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Fable.React" ] ] ]

let alignmentCenter =
    Breadcrumb.breadcrumb [ Breadcrumb.IsCentered ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Elmish" ] ] ]

let icons =
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

let size =
    Breadcrumb.breadcrumb [ Breadcrumb.Size IsLarge ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Elmish" ] ] ]

let separator =
    Breadcrumb.breadcrumb [ Breadcrumb.HasSucceedsSeparator ]
        [ Breadcrumb.item [ ]
            [ a [ ] [ str "F#" ] ]
          Breadcrumb.item [ ]
            [ a [ ] [ str "Fable" ] ]
          Breadcrumb.item [ Breadcrumb.Item.IsActive true ]
            [ a [ ] [ str "Elmish" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.docSection
                        """
### Alignment

Supported alignment:

* `Breadcrumb.isCentered`
* `Breadcrumb.isRight`

When you do not set the alignment, it's align to the *left*.

                        """
                        (Viewer.View.root alignmentCenter model.AlignmentCenterViewer (AlignmentCenterViewerMsg >> dispatch))
                     Render.docSection
                        "### Icons"
                        (Viewer.View.root icons model.IconViewer (IconViewerMsg >> dispatch))
                     Render.docSection
                        """
### Size

Supported size:

* `Breadcrumb.isSmall`
* `Breadcrumb.isMedium`
* `Breadcrumb.isLarge`

By default, size is considered *normal*.

                        """
                        (Viewer.View.root size model.SizeViewer (SizeViewerMsg >> dispatch))
                     Render.docSection
                        """
### Separators

Supported separators:

* `Breadcrumb.hasArrowSeparator`
* `Breadcrumb.hasBulletSeparator`
* `Breadcrumb.hasDotSeparator`
* `Breadcrumb.hasSucceedsSeparator`

                        """
                        (Viewer.View.root separator model.SeparatorViewer (SeparatorViewerMsg >> dispatch)) ]
