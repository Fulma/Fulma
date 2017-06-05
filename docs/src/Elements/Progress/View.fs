module Elements.Progress.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Elements
open Global

let section model =
  div
    [ ]
    [ Progress.progress
        [ Progress.isSuccess
          Progress.isSmall
          Progress.props
            [ Value !^"15"
              Max !^"100" ] ]
        [ str "15%" ]
      Progress.progress
        [ Progress.isPrimary
          Progress.isMedium
          Progress.props
            [ Value !^"85"
              Max !^"100" ] ]
        [ str "15%" ]
      Progress.progress
        [ Progress.isDanger
          Progress.isLarge
          Progress.props
            [ Value !^"50"
              Max !^"100" ] ]
        [ str "15%" ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
