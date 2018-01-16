module Layouts.Columns

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Elements
open Fulma.Layouts

let basic () =
    Columns.columns [ ]
        [ Column.column [ Column.Width (Column.All, Column.Is6) ]
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
                [ Column.column [ Column.Width (Column.All, Column.Is7) ]
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
                        (Showcase.view basic (Render.getViewSource basic))
                     Render.contentFromMarkdown
                        """
### Properties

#### Columns

Alignment:
- `Columns.isCentered`
- `Columns.isVCentered`

Display:
- `Columns.onMobile`
- `Columns.onDesktopOnly`

Spacing:
- `Columns.isMultiline`
- `Columns.isGapless`
- `Columns.isGrid`

#### Column

You can access all the width properties of `Column` via `Column.Width.XXXX`.

Ex:

```
Column.Width.is3
Column.Width.Dekstop.is6
Column.Width.Mobile.isFull
```

You can access all the width properties of `Column` via `Column.Offset.XXXX`.

Ex:

```
Column.Offset.is3
Column.Offset.Dekstop.is6
Column.Offset.Mobile.isFull
```
                        """
                         ]
