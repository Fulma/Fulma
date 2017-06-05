module Elements.Title.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Elements
open Global

let sectionHeading model =
  div [] [
    div [ClassName "block"] [
      Heading.h1 [ Heading.isTitle ] [str "Titles"]
      Heading.h3 [ Heading.isSubtitle ] [
        str "Simple "
        strong [] [str "headings "]
        str "to add depth to your page"
        ]
    ]
  ]

let sectionType model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ Heading.h1 [ ] [str "Title"]
          br []
          Heading.h3 [ Heading.isSubtitle ] [str "Subtitle"] ] ]
  |> docBlock model.typeCode
  |> toList
  |> sectionBase model.typeText

let sectionSize model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ Heading.h1 [ Heading.isTitle; Heading.is1 ] [str "Title 1"]
          Heading.h1 [ Heading.isTitle; Heading.is2 ] [str "Title 2"]
          Heading.h1 [ Heading.isTitle; Heading.is3 ] [str "Title 3 (Default size)"]
          Heading.h1 [ Heading.isTitle; Heading.is4 ] [str "Title 4"]
          Heading.h1 [ Heading.isTitle; Heading.is5 ] [str "Title 5"]
          Heading.h1 [ Heading.isTitle; Heading.is6 ] [str "Title 6"]
          br []
          Heading.h1 [ Heading.isSubtitle; Heading.is1 ] [str "Subtitle 1"]
          Heading.h1 [ Heading.isSubtitle; Heading.is2 ] [str "Subtitle 2"]
          Heading.h1 [ Heading.isSubtitle; Heading.is3 ] [str "Subtitle 3"]
          Heading.h1 [ Heading.isSubtitle; Heading.is4 ] [str "Subtitle 4"]
          Heading.h1 [ Heading.isSubtitle; Heading.is5 ] [str "Subtitle 5 (Default size)"]
          Heading.h1 [ Heading.isSubtitle; Heading.is6 ] [str "Subtitle 6"] ] ]
  |> docBlock model.sizeCode
  |> toList
  |> sectionBase model.sizeText

let sectionExtra model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [ str "Default behavior"
          Heading.p [ Heading.isTitle; Heading.is1 ] [ str "Title 1" ]
          Heading.p [ Heading.isSubtitle; Heading.is3 ] [ str "Subtitle 3" ]
          br []
          str "Behavior when using IsSpaced"
          Heading.p [ Heading.isTitle; Heading.is1; Heading.isSpaced ] [ str "Title 1" ]
          Heading.p [ Heading.isSubtitle; Heading.is3 ] [ str "Subtitle 3" ] ] ]
  |> docBlock model.spacedCode
  |> toList
  |> sectionBase model.spacedText

let root model =
  div
    [ ]
    [ sectionHeading model
      hr []
      sectionType model
      hr []
      sectionSize model
      hr []
      sectionExtra model ]
