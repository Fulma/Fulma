module Elements.Tag.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Elements
open Global

let section model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ Tag.tag [] [ str "Tag label" ] ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text


let sectionColor model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ Tag.tag [ Tag.isBlack ] [ str "Black" ]
          Tag.tag [ Tag.isDark ] [ str "Dark" ]
          Tag.tag [ Tag.isLight ] [ str "Light" ]
          Tag.tag [ Tag.isWhite ] [ str "White" ]
          Tag.tag [ Tag.isPrimary ] [ str "Primary"]  ]
      br [ ]
      div
        [ ClassName "block" ]
        [
          Tag.tag [ Tag.isInfo ] [ str "Info" ]
          Tag.tag [ Tag.isSuccess ] [ str "Success" ]
          Tag.tag [ Tag.isWarning ] [ str "Warning" ]
          Tag.tag [ Tag.isDanger ] [ str "Danger" ] ] ]
  |> docBlock model.colorCode
  |> toList
  |> sectionBase model.colorText

let sectionSize model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ Tag.tag [ Tag.isSuccess; Tag.isMedium ] [ str "Medium" ]
          Tag.tag [ Tag.isInfo; Tag.isLarge ] [ str "Large" ] ] ]
  |> docBlock model.sizeCode
  |> toList
  |> sectionBase model.sizeText
let root model =
  div
    [ ]
    [ section model
      hr []
      sectionColor model
      hr []
      sectionSize model ]
