module Elements.Icon.View

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
        [ Icon.icon
            [ Icon.small ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon
            [  ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon
            [ Icon.medium ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon
            [ Icon.large ]
            [ i [ ClassName "fa fa-home" ] [ ] ] ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
