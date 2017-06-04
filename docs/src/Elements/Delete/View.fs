module Elements.Delete.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Elements.Delete
open Global

let section model =
  div
    [ ]
    [ renderMarkdown "Using `a` elements"
      br [ ]
      div
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
            [ ] [ ] ]
      renderMarkdown "Using `button` elements"
      br [ ]
      div
        [ ClassName "block" ]
        [ delete button
            [ Size Small ]
            [ ] [ ]
          delete button
            [  ]
            [ ] [ ]
          delete button
            [ Size Medium ]
            [ ] [ ]
          delete button
            [ Size Large ]
            [ ] [ ] ] ]
  |> docBlock model.code
  |> toList
  |> sectionBase model.text

let root model =
  div
    [ ]
    [ section model ]
