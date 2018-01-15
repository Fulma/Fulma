module Elements.Tag.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Elements

let colorInteractive =
    div [ ClassName "block" ]
        [ Tag.tag [ ] [ str "Default" ]
          Tag.tag [ Tag.Color IsWhite ] [ str "White" ]
          Tag.tag [ Tag.Color IsLight ] [ str "Light" ]
          Tag.tag [ Tag.Color IsDark ] [ str "Dark" ]
          Tag.tag [ Tag.Color IsBlack ] [ str "Black" ]
          Tag.tag [ Tag.Color IsPrimary ] [ str "Primary" ]
          Tag.tag [ Tag.Color IsInfo ] [ str "Info" ]
          Tag.tag [ Tag.Color IsSuccess ] [ str "Success" ]
          Tag.tag [ Tag.Color IsWarning ] [ str "Warning" ]
          Tag.tag [ Tag.Color IsDanger ] [ str "Danger" ] ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Tag.tag [ ] [ str "Normal" ]
          Tag.tag [ Tag.Color IsPrimary; Tag.Size IsMedium ] [ str "Medium" ]
          Tag.tag [ Tag.Color IsInfo; Tag.Size IsLarge ] [ str "Large" ] ]

let nestedDeleteStyleInteractive =
    div [ ClassName "block" ]
        [ Tag.tag [ Tag.Color IsDark ]
            [ str "With delete"
              Delete.delete [ Delete.Size IsSmall ] [ ] ]
          Tag.tag [ Tag.Size IsMedium ]
            [ str "With delete"
              Delete.delete [ ] [ ] ]
          Tag.tag [ Tag.Color IsWarning; Tag.Size IsLarge ]
            [ str "With delete"
              Delete.delete [ Delete.Size IsLarge ] [ ] ] ]

let list =
    Tag.list [ Tag.List.HasAddons ]
        [ Tag.tag [ Tag.Color IsDanger ] [ str "Maxime Mangel" ]
          Tag.delete [ ] [ ] ]

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
                     Render.docSection
                        "### Tag List"
                        (Viewer.View.root list model.ListViewer (ListViewerMsg >> dispatch)) ]
