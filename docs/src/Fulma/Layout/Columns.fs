module Layouts.Columns

open Fable.Import
open Fable.React
open Fable.React.Props
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

type GapSizeProps =
    class end

type GapSizeState =
    { Size : Columns.ISize }

let private sizes =
    [ Columns.Is1
      Columns.Is2
      Columns.Is3
      Columns.Is4
      Columns.Is5
      Columns.Is6
      Columns.Is7
      Columns.Is8 ]

let private centerText txt =
    Notification.notification [ Notification.Color IsPrimary
                                Notification.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered)] ]
        [ str txt ]

type GapSize(props) =
    inherit Component<GapSizeProps, GapSizeState>(props)
    do base.setInitState({ Size = Columns.Is3 })

    member this.SetSize (newSize : Columns.ISize) =
        this.setState (fun prevState _ ->
            { prevState with Size = newSize }
        )

    override this.render () =
        let demoView =
            Columns.columns [ Columns.IsGap (Screen.All, this.state.Size) ]
                [ Column.column [ ]
                    [ centerText "Column" ]
                  Column.column [ ]
                    [ centerText "Column" ]
                  Column.column [ ]
                    [ centerText "Column" ]
                  Column.column [ ]
                    [ centerText "Column" ]
                  Column.column [ ]
                    [ centerText "Column" ] ]

        let controls =
            sizes
            |> List.map (fun size ->
                let color =
                    if size = this.state.Size then
                        IsInfo
                    else
                        IsLight
                Tag.tag [ Tag.Color color
                          Tag.Size IsMedium
                          Tag.Props [ OnMouseOver (fun _ ->
                                        this.SetSize size
                                      )
                                      Style [ Cursor "pointer" ] ] ]
                    [ str (Reflection.getCaseName size) ]
            )
            |> Tag.list [ ]

        div [ ]
            [ controls
              demoView ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Columns

A simple way to build **responsive** columns

*[Bulma documentation](http://bulma.io/documentation/columns/basics/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Variable gap
                        """
                        (Widgets.Showcase.view (fun _ -> ofType<GapSize,_,_> (unbox null) [ ]) (Render.includeCode __LINE__ __SOURCE_FILE__))
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
Column.Width (Screen.All, Column.Is3)
Column.Width (Screen.Desktop, Column.Is3)
Column.Width (Screen.Mobile, Column.IsFull)
```

You can set the offset of `Column` via:

Ex:

```
Column.Offset (Screen.All, Column.Is3)
Column.Offset (Screen.Desktop, Column.Is3)
Column.Offset (Screen.Mobile, Column.IsFull)
```
                        """
                         ]
