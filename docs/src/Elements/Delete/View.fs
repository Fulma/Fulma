module Elements.Delete.View

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
    [ renderMarkdown "Using `a` elements"
      br [ ]
      div
        [ ClassName "block" ]
        [ Delete.delete
            [ Delete.isSmall ]
            [ ]
          Delete.delete
            [ ] [ ]
          Delete.delete
            [ Delete.isMedium ] [ ]
          Delete.delete
            [ Delete.isLarge ] [ ] ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
