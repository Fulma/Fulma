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

let sectionBase title docBlocks =
  div
    [ ]
    ((div
        [ ClassName "content" ]
        [ renderMarkdown title ]) :: docBlocks)


let docBlock code children =
  div
    [ ClassName "columns" ]
    [ div
        [ ClassName "column" ]
        [ children ]
      div
        [ ClassName "column" ]
        [ renderMarkdown code ] ]

let sectionColor model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ btn [] [] [ str "Button" ]
          btn [ Level IsWhite ] [] [ str "White" ]
          btn [ Level IsLight ] [] [ str "Light" ]
          btn [ Level IsDark ] [] [ str "Dark" ]
          btn [ Level IsBlack ] [] [ str "Black" ]
          btn [ Level IsLink ] [] [ str "Link" ] ]
      div
        [ ClassName "block" ]
        [ btn [ Level IsPrimary ] [] [ str "Primary" ]
          btn [ Level IsInfo ] [] [ str "Info" ]
          btn [ Level IsSuccess ] [] [ str "Success" ]
          btn [ Level IsWarning ] [] [ str "Warning" ]
          btn [ Level IsDanger ] [] [ str "Danger" ] ] ]
  |> docBlock model.codeColor
  |> toList
  |> sectionBase model.textColor

let sectionSize model =
  div
    [ ClassName "block" ]
    [ btn [ Size Small ] [ ] [ str "Small" ]
      btn [ ] [ ] [ str "Normal" ]
      btn [ Size Medium ] [ ] [ str "Medium" ]
      btn [ Size Large ] [ ] [ str "Large" ] ]
  |> docBlock model.codeSize
  |> toList
  |> sectionBase model.textSize

let sectionStyle model =
  [ div
      [ ClassName "block" ]
      [ btn [ IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level IsSuccess; IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level IsPrimary; IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level IsInfo; IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level IsDark; IsOutlined ] [ ] [str "Outlined" ] ], model.codeStyleOutlined
    div
      [ ClassName "block callout is-primary" ]
      [ btn [ IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level IsSuccess; IsInverted ] [ ] [str "Inverted" ]
        btn [ Level IsPrimary; IsInverted ] [ ] [str "Inverted" ]
        btn [ Level IsInfo; IsInverted ] [ ] [str "Inverted" ]
        btn [ Level IsDark; IsInverted ] [ ] [str "Inverted" ] ], model.codeStyleInverted
    div
      [ ]
      [ div
          [ ClassName "block callout is-success" ]
          [ btn [ IsOutlined; IsInverted ] [ ] [str "Invert Outlined" ]
            btn [ Level IsSuccess; IsOutlined; IsInverted ] [ ] [str "Invert outlined" ]
            btn [ Level IsPrimary; IsOutlined; IsInverted ] [ ] [str "Invert outlined" ] ] ], model.codeStyleInvertOutlined ]
  |> List.map (fun (children, code) -> docBlock code children )
  |> sectionBase model.textStyle

let root model =
  div
    [ ]
    [
      sectionColor model
      hr []
      sectionSize model
      hr []
      sectionStyle model
    ]
