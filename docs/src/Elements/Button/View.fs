module Elements.Button.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components.Grids


let colorInteractive =
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

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Viewer.View.root colorInteractive model.ColorViewer (ColorViewer >> dispatch)
                     ]
