module Elements.Button.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components.Grids


let colorSection model =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button [ ] [ str "Button" ]
                    Button.button [ Button.isWhite ] [ str "White" ]
                    Button.button [ Button.isLight ] [ str "Light" ]
                    Button.button [ Button.isLight ] [ str "Light" ]
                    Button.button [ Button.isDark ] [ str "Dark" ]
                    Button.button [ Button.isBlack ] [ str "Black" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button [ Button.isLink ] [ str "Link" ]
                    Button.button [ Button.isPrimary ] [ str "Primary" ]
                    Button.button [ Button.isInfo ] [ str "Info" ]
                    Button.button [ Button.isSuccess ] [ str "Success" ]
                    Button.button [ Button.isWarning ] [ str "Warning" ]
                    Button.button [ Button.isDanger ] [ str "Danger" ] ] ] ]
    |> Render.docPreview model.colorCode
    |> Render.toList
    |> Render.docSection model.colorIntro

let root model =
    Render.docPage [ Render.contentFromMarkdown model.intro
                     colorSection model
                     div [ ClassName "maxime"; ClassName "second" ] [ ]
                     ]
