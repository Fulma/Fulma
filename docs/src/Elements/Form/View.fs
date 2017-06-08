module Elements.Form.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Elements
open Elmish.Bulma.Elements.Form
open Global

let sectionColor model =
  div
    [ ]
    [ Field.field
        [ ]
        [ Label.label
            [ ]
            [ str "Name" ]
          Control.control
            [ ]
            [ Input.text
                [ Input.placeholder "Text input" ] ] ]
      Field.field
        [ ]
        [ Label.label
            [ ]
            [ str "Username" ]
          Control.control
            [ Control.hasIconLeft
              Control.hasIconRight ]
            [ Input.text
                [ Input.isSuccess
                  Input.placeholder "Text input"
                  Input.value "bulma" ]
              Icon.icon
                [ Icon.isSmall
                  Icon.isLeft]
                [ i [ ClassName "fa fa-user" ] [ ] ]
              Icon.icon
                [ Icon.isSmall
                  Icon.isRight]
                [ i [ ClassName "fa fa-check" ] [ ] ]
              p
                [ ClassName "help is-success" ]
                [ str "This username is available" ] ] ]

      Field.field
        [ ]
        [ Label.label
            [ ]
            [ str "Email" ]
          Control.control
            [ Control.hasIconLeft
              Control.hasIconRight ]
            [ Input.email
                [ Input.isDanger
                  Input.placeholder "Email input"
                  Input.value "hello@" ]
              Icon.icon
                [ Icon.isSmall
                  Icon.isLeft ]
                [ i [ ClassName "fa fa-envelope" ] [ ] ]
              Icon.icon
                [ Icon.isSmall
                  Icon.isRight ]
                [ i [ ClassName "fa fa-warning" ] [ ] ]
              p
                [ ClassName "help is-danger" ]
                [ str "This email is invalid" ] ] ] ]
  |> docBlock model.codeColor
  |> toList
  |> sectionBase model.textColor

let sectionSize model =
  div
    [ ClassName "block" ]
    [ Button.button [ Button.isSmall ] [ str "Small" ]
      Button.button [ ] [ str "Normal" ]
      Button.button [ Button.isMedium ] [ str "Medium" ]
      Button.button [ Button.isLarge ] [ str "Large" ] ]
  |> docBlock model.codeSize
  |> toList
  |> sectionBase model.textSize

let sectionStyle model =
  [ div
      [ ClassName "block" ]
      [ Button.button [ Button.isOutlined ] [str "Outlined" ]
        Button.button [ Button.isSuccess; Button.isOutlined ] [str "Outlined" ]
        Button.button [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
        Button.button [ Button.isInfo; Button.isOutlined ] [ str "Outlined" ]
        Button.button [ Button.isDark; Button.isOutlined ] [ str "Outlined" ] ], model.codeStyleOutlined
    div
      [ ClassName "block callout is-primary" ]
      [ Button.button [ Button.isOutlined ] [ str "Outlined" ]
        Button.button [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
        Button.button [ Button.isPrimary; Button.isInverted ] [ str "Inverted" ]
        Button.button [ Button.isInfo; Button.isInverted ] [ str "Inverted" ]
        Button.button [ Button.isDark; Button.isInverted ] [ str "Inverted" ] ], model.codeStyleInverted
    div
      [ ]
      [ div
          [ ClassName "block callout is-success" ]
          [ Button.button [ Button.isOutlined; Button.isInverted ] [ str "Invert Outlined" ]
            Button.button [ Button.isSuccess; Button.isOutlined; Button.isInverted ] [ str "Invert outlined" ]
            Button.button [ Button.isPrimary; Button.isOutlined; Button.isInverted ] [ str "Invert outlined" ] ] ], model.codeStyleInvertOutlined ]
  |> List.map (fun (children, code) -> docBlock code children )
  |> sectionBase model.textStyle

let sectionState model =
  div
    [ ClassName "block" ]
    [ Button.button [ Button.isSuccess ] [ str "Normal" ]
      Button.button [ Button.isHovered; Button.isSuccess ] [ str "Hover" ]
      Button.button [ Button.isFocused; Button.isSuccess ] [ str "Hover" ]
      Button.button [ Button.isActive; Button.isSuccess ] [ str "Hover" ]
      Button.button [ Button.isLoading; Button.isSuccess ] [ str "Hover" ] ]
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
