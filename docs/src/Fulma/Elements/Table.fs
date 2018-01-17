module Elements.Table

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma.Elements

let simpleInteractive () =
    Table.table [ Table.IsHoverable ]
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

let modifierInteractive () =
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

let modifierFullWitdth () =
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

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Table

*[Bulma documentation](http://bulma.io/documentation/elements/table/)*
                        """
                     Render.docSection
                        "### Table"
                        (Widgets.Showcase.view simpleInteractive (Render.getViewSource simpleInteractive))
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
                        (Widgets.Showcase.view modifierInteractive (Render.getViewSource modifierInteractive))
                     Render.docSection
                        """
Below is displayed one example of table with fullwidth spacing. The table fills the full width of its parent component:
                        """
                        (Widgets.Showcase.view modifierFullWitdth (Render.getViewSource modifierFullWitdth)) ]
