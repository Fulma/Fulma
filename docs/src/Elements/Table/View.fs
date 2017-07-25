module Elements.Table.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements

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
              tr [ Table.Row.isSelected ]
                 [ td [ ] [ str "Jane" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "21/07/1987" ] ]
              tr [  ]
                 [ td [ ] [ str "John" ]
                   td [ ] [ str "Doe" ]
                   td [ ] [ str "11/07/1978" ] ] ] ]

let modifierInteractive =
    Table.table [ Table.isBordered
                  Table.isNarrow
                  Table.isStripped ]
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
              tr [ Table.Row.isSelected ]
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

There is three modifiers:

- `Table.isBordered`
- `Table.isNarrow`
- `Table.isStripped`

You can apply any combination of this three.
                        """
                        (Viewer.View.root modifierInteractive model.ModifierViewer (ModifierViewerMsg >> dispatch)) ]
