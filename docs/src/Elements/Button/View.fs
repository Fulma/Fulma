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

let sectionColor model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ btn [] [] [ str "Button" ]
          btn [ Level White ] [] [ str "White" ]
          btn [ Level Light ] [] [ str "Light" ]
          btn [ Level Dark ] [] [ str "Dark" ]
          btn [ Level Black ] [] [ str "Black" ]
          btn [ Level Link ] [] [ str "Link" ] ]
      div
        [ ClassName "block" ]
        [ btn [ Level Primary ] [] [ str "Primary" ]
          btn [ Level Info ] [] [ str "Info" ]
          btn [ Level Success ] [] [ str "Success" ]
          btn [ Level Warning ] [] [ str "Warning" ]
          btn [ Level Danger ] [] [ str "Danger" ] ] ]
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
        btn [ Level Success; IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level Primary; IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level Info; IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level Dark; IsOutlined ] [ ] [str "Outlined" ] ], model.codeStyleOutlined
    div
      [ ClassName "block callout is-primary" ]
      [ btn [ IsOutlined ] [ ] [str "Outlined" ]
        btn [ Level Success; IsInverted ] [ ] [str "Inverted" ]
        btn [ Level Primary; IsInverted ] [ ] [str "Inverted" ]
        btn [ Level Info; IsInverted ] [ ] [str "Inverted" ]
        btn [ Level Dark; IsInverted ] [ ] [str "Inverted" ] ], model.codeStyleInverted
    div
      [ ]
      [ div
          [ ClassName "block callout is-success" ]
          [ btn [ IsOutlined; IsInverted ] [ ] [str "Invert Outlined" ]
            btn [ Level Success; IsOutlined; IsInverted ] [ ] [str "Invert outlined" ]
            btn [ Level Primary; IsOutlined; IsInverted ] [ ] [str "Invert outlined" ] ] ], model.codeStyleInvertOutlined ]
  |> List.map (fun (children, code) -> docBlock code children )
  |> sectionBase model.textStyle

let sectionState model =
  div
    [ ClassName "block" ]
    [ btn [ Level Success ] [ ] [str "Normal" ]
      btn [ State Hovered; Level Success ] [ ] [str "Hover" ]
      btn [ State Focus; Level Success ] [ ] [str "Hover" ]
      btn [ State Active; Level Success ] [ ] [str "Hover" ]
      btn [ State Loading; Level Success ] [ ] [str "Hover" ] ]
  |> docBlock model.codeState
  |> toList
  |> sectionBase model.textState

let root model =
  div
    [ ]
    [
      sectionColor model
      hr []
      sectionSize model
      hr []
      sectionStyle model
      hr []
      sectionState model
    ]
