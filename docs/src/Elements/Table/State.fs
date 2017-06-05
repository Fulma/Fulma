module Elements.Table.State

open Elmish
open Types

let init () : Model =
      {
      generalText =
            "
# Table
            "
      generalCode =
            """
```fsharp
  Table.table
    [ ]
    [ thead
        [ ]
        [ tr
            [ ]
            [ th [ ] [ str "Firstname" ]
              th [ ] [ str "Surname" ]
              th [ ] [ str "Birthday" ] ] ]
      tbody
        [ ]
        [ tr
            [ ]
            [ td [ ] [ str "Maxime" ]
              td [ ] [ str "Mangel" ]
              td [ ] [ str "28/02/1992" ] ]
          tr
            [ Table.Row.isSelected ]
            [ td [ ] [ str "Jane" ]
              td [ ] [ str "Doe" ]
              td [ ] [ str "21/07/1987" ] ]
          tr
            [  ]
            [ td [ ] [ str "John" ]
              td [ ] [ str "Doe" ]
              td [ ] [ str "11/07/1978" ] ] ]
```
            """
      styleText =
            "
## Modifiers
You can also apply modifiers to the table
            "
      styleCode =
            """
```fsharp
  Table.table
    [ Table.isBordered
      Table.isNarrow
      Table.isStripped ]
    [ thead
        [ ]
        [ tr
            [ ]
            [ th [ ] [ str "Firstname" ]
              th [ ] [ str "Surname" ]
              th [ ] [ str "Birthday" ] ] ]
      tbody
        [ ]
        [ tr
            [ ]
            [ td [ ] [ str "Maxime" ]
              td [ ] [ str "Mangel" ]
              td [ ] [ str "28/02/1992" ] ]
          tr
            [ Table.Row.isSelected ]
            [ td [ ] [ str "Jane" ]
              td [ ] [ str "Doe" ]
              td [ ] [ str "21/07/1987" ] ]
          tr
            [  ]
            [ td [ ] [ str "John" ]
              td [ ] [ str "Doe" ]
              td [ ] [ str "11/07/1978" ] ] ]
```
            """ }
