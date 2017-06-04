module Elements.Delete.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Delete
open Global

let section model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ delete a
            [ Size Small ]
            [ ] [ ]
          delete a
            [  ]
            [ ] [ ]
          delete a
            [ Size Medium ]
            [ ] [ ]
          delete a
            [ Size Large ]
            [ ] [ ]
        ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
