module Layouts.Columns

open Fable.Helpers.React
open Fulma

let basic () =
    Columns.columns [ ]
        [ Column.column [ Column.Width (Screen.All, Column.Is6) ]
            [ Columns.columns [ ]
                [ Column.column [ ]
                    [ Notification.notification [ Notification.Color IsSuccess ]
                        [ str "Column n°1" ] ] ]
              Columns.columns [ Columns.IsGapless ]
                [ Column.column [ ]
                    [ Notification.notification [ Notification.Color IsInfo ]
                        [ str "Column n°1.1" ] ]
                  Column.column [ ]
                    [ Notification.notification [ Notification.Color IsWarning ]
                        [ str "Column n°1.2" ] ]
                  Column.column [ ]
                    [ Notification.notification [ Notification.Color IsDanger ]
                        [ str "Column n°1.3" ] ] ] ]
          Column.column [ ]
            [ Columns.columns [ ]
                [ Column.column [ ]
                    [ Notification.notification [ Notification.Color IsLight ]
                        [ str "Column n°2" ] ] ]
              Columns.columns [ Columns.IsCentered ]
                [ Column.column [ Column.Width (Screen.All, Column.Is7) ]
                    [ Notification.notification [ Notification.Color IsBlack ]
                        [ str "Column n°2.1" ] ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Columns

A simple way to build **responsive** columns

*[Bulma documentation](http://bulma.io/documentation/columns/basics/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.getViewSource basic))
                     Render.contentFromMarkdown
                        """
### Properties

#### Columns

Alignment:
- `Columns.IsCentered`
- `Columns.IsVCentered`

Display:
- `Columns.OnMobile`
- `Columns.OnDesktopOnly`

Spacing:
- `Columns.IsMultiline`
- `Columns.IsGapless`
- `Columns.IsGrid`

#### Column

You can set the width of `Column` via:

```
Column.Width (Column.All, Column.Is3)
Column.Width (Column.Desktop, Column.Is3)
Column.Width (Column.Mobile, Column.IsFull)
```

You can set the offset of `Column` via:

Ex:

```
Column.Offset (Column.All, Column.Is3)
Column.Offset (Column.Desktop, Column.Is3)
Column.Offset (Column.Mobile, Column.IsFull)
```
                        """
                         ]
