module Elements.Tag.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Tag
open Global

let section model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ tag [] [] [str "Tag label"] ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text


let sectionColor model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ tag [Color Black] [] [str "Black"]
          tag [Color Dark] [] [str "Dark"]
          tag [Color Light] [] [str "Light"]
          tag [Color White] [] [str "White"]
          tag [Color Primary] [] [str "Primary"] ]
      br [ ]
      div
        [ ClassName "block" ]
        [
          tag [Color Info] [] [str "Info"]
          tag [Color Success] [] [str "Success"]
          tag [Color Warning] [] [str "Warning"]
          tag [Color Danger] [] [str "Danger"] ] ]
  |> docBlock model.colorCode
  |> toList
  |> sectionBase model.colorText

let sectionSize model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ tag [Color Success; Size Medium] [] [str "Medium"]
          tag [Color Info; Size Large] [] [str "Large"] ] ]
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
