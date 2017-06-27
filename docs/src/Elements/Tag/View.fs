module Elements.Tag.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components.Grids


let colorInteractive =
    div [ ClassName "block" ]
        [ Tag.tag [ ] [ str "Default" ]
          Tag.tag [ Tag.isWhite ] [ str "White" ]
          Tag.tag [ Tag.isLight ] [ str "Light" ]
          Tag.tag [ Tag.isDark ] [ str "Dark" ]
          Tag.tag [ Tag.isBlack ] [ str "Black" ]
          Tag.tag [ Tag.isPrimary ] [ str "Primary" ]
          Tag.tag [ Tag.isInfo ] [ str "Info" ]
          Tag.tag [ Tag.isSuccess ] [ str "Success" ]
          Tag.tag [ Tag.isWarning ] [ str "Warning" ]
          Tag.tag [ Tag.isDanger ] [ str "Danger" ] ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Tag.tag [ ] [ str "Normal" ]
          Tag.tag [ Tag.isPrimary; Tag.isMedium ] [ str "Medium" ]
          Tag.tag [ Tag.isInfo; Tag.isLarge ] [ str "Large" ] ]

let nestedDeleteStyleInteractive =
    div [ ClassName "block" ]
        [ Tag.tag [ Tag.isDark ]
            [ str "With delete"
              Delete.delete [ Delete.isSmall ] [ ] ]
          Tag.tag [ Tag.isMedium ]
            [ str "With delete"
              Delete.delete [ ] [ ] ]
          Tag.tag [ Tag.isWarning; Tag.isLarge ]
            [ str "With delete"
              Delete.delete [ Delete.isLarge ] [ ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Colors"
                        (Viewer.View.root colorInteractive model.ColorViewer (ColorViewerMsg >> dispatch))
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root sizeInteractive model.SizeViewer (SizeViewerMsg >> dispatch))
                     Render.docSection
                        "### Nested delete"
                        (Viewer.View.root nestedDeleteStyleInteractive model.NestedDeleteViewer (NestedDeleteViewerMsg >> dispatch))
                               ]
