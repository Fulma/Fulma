module Elements.Icon.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Icon
open Global

let section model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ icon
            [ Size Small ]
            [ ] [ i [ ClassName "fa fa-home" ] [ ] ]
          icon
            [  ]
            [ ] [ i [ ClassName "fa fa-home" ] [ ] ]
          icon
            [ Size Medium ]
            [ ] [ i [ ClassName "fa fa-home" ] [ ] ]
          icon
            [ Size Large ]
            [ ] [ i [ ClassName "fa fa-home" ] [ ] ] ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
