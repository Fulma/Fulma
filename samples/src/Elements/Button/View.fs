module Elements.Button.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Button
open Global

let section1 model =
  div
    [ ClassName "columns" ]
    [
      div
        [ ClassName "column" ]
        [ div
            [ ClassName "block" ]
            [ Bulma.Button.view [] [] [ str "Button" ]
              Bulma.Button.view [ Level IsWhite ] [] [ str "White" ]
              Bulma.Button.view [ Level IsLight ] [] [ str "Light" ]
              Bulma.Button.view [ Level IsDark ] [] [ str "Dark" ]
              Bulma.Button.view [ Level IsBlack ] [] [ str "Black" ]
              Bulma.Button.view [ Level IsLink ] [] [ str "Link" ] ]
          div
            [ ClassName "block" ]
            [ Bulma.Button.view [ Level IsPrimary ] [] [ str "Primary" ]
              Bulma.Button.view [ Level IsInfo ] [] [ str "Info" ]
              Bulma.Button.view [ Level IsSuccess ] [] [ str "Success" ]
              Bulma.Button.view [ Level IsWarning ] [] [ str "Warning" ]
              Bulma.Button.view [ Level IsDanger ] [] [ str "Danger" ] ] ]
      div
        [ ClassName "column" ]
        [ renderMarkdown model.codeSection1 ]
    ]

let root model =
  div
    [ ]
    [
      div
        [ ClassName "content" ]
        [ renderMarkdown model.textSection1 ]
      section1 model
      hr []
      div
        [ ClassName "block" ]
        [ Bulma.Button.view [ Size Small ] [ ] [ str "Small" ]
          Bulma.Button.view [ ] [ ] [ str "Normal" ]
          Bulma.Button.view [ Size Medium ] [ ] [ str "Medium" ]
          Bulma.Button.view [ Size Large ] [ ] [ str "Large" ]
        ]
    ]
