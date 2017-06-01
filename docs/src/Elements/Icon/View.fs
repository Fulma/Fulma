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
        [ iconSmall [ i [ ClassName "fa fa-home" ] [ ] ]
          iconNormal [ i [ ClassName "fa fa-home" ] [ ] ]
          iconMedium [ i [ ClassName "fa fa-home" ] [ ] ]
          iconLarge [ i [ ClassName "fa fa-home" ] [ ] ] ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
