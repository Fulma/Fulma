module Elements.Box.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Box
open Global

let section model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ box' [] [
            str
                "Lorem ipsum dolor sit amet, consectetur adipisicing elit
                , sed do eiusmod tempor incididunt ut labore et dolore
                magna aliqua.
                "
            ]
        ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
