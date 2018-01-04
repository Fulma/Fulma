module Elements.Table.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements

let simpleInteractive =
    Table.table [ ]
        [ thead [ ]
            [ tr
            [ ]
            [ th [ ] [ str "Firstname" ]
              th [ ] [ str "Surname" ]
              th [ ] [ str "Birthday" ] ] ]
          tbody [ ]
            [ tr [ ]
                 [ td [ ] [ str "Maxime" ]
                   td [ ] [ str "Mangel" ]
                   td [ ] [ str "28/02/1992" ] ]
              tr [ ClassName "is-selected" ]
                 [ td [ ] [ str "Jane" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "21/07/1987" ] ]
              tr [  ]
                 [ td [ ] [ str "John" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "11/07/1978" ] ] ] ]

let modifierInteractive =
    Table.table [ Table.IsBordered
                  Table.IsNarrow
                  Table.IsStripped ]
        [ thead [ ]
            [ tr [ ]
                 [ th [ ] [ str "Firstname" ]
                   th [ ] [ str "Surname" ]
                   th [ ] [ str "Birthday" ] ] ]
          tbody [ ]
            [ tr [ ]
                [ td [ ] [ str "Maxime" ]
                  td [ ] [ str "Mangel" ]
                  td [ ] [ str "28/02/1992" ] ]
              tr [ ClassName "is-selected" ]
                 [ td [ ] [ str "Jane" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "21/07/1987" ] ]
              tr [  ]
                 [ td [ ] [ str "John" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "11/07/1978" ] ] ] ]

let modifierFullWitdth =
    Table.table [ Table.IsBordered
                  Table.IsFullwidth
                  Table.IsStripped ]
        [ thead [ ]
            [ tr [ ]
                 [ th [ ] [ str "Firstname" ]
                   th [ ] [ str "Surname" ]
                   th [ ] [ str "Birthday" ] ] ]
          tbody [ ]
            [ tr [ ]
                [ td [ ] [ str "Maxime" ]
                  td [ ] [ str "Mangel" ]
                  td [ ] [ str "28/02/1992" ] ]
              tr [ ClassName "is-selected" ]
                 [ td [ ] [ str "Jane" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "21/07/1987" ] ]
              tr [  ]
                 [ td [ ] [ str "John" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "11/07/1978" ] ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Table"
                        (Viewer.View.root simpleInteractive model.SimpleViewer (SimpleViewerMsg >> dispatch))
                     Render.docSection
                        """
### Modifiers

There are four modifiers:
- `Table.isBordered`
- `Table.isStripped`

and 2 options for table spacing:
- `Table.isNarrow`
- `Table.isFullwidth`

You can apply any combination of the first two modifiers and one of option for spacing.
Below is displayed one table with narrow spacing:
                        """
                        (Viewer.View.root modifierInteractive model.ModifierViewer (ModifierViewerMsg >> dispatch))
                     Render.docSection
                        """
Below is displayed one example of table with fullwidth spacing. The table fills the full width of its parent component:
                        """
                        (Viewer.View.root modifierFullWitdth model.ModifierFullWidth (ModifierFullWidthMsg >> dispatch)) ]
