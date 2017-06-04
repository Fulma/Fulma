module Elements.Title.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Title
open Global

let sectionHeading model =
  div [] [
    div [ClassName "block"] [
      title h1 [] [] [str "Titles"]
      title h3 [ TitleType SubTitle ] [] [
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
        [ ClassName "block" ][
          title h1 [] [] [str "Title"]
          br []
          title h3 [TitleType SubTitle] [] [str "Subtitle"]
        ] ]
  |> docBlock model.typeCode
  |> toList
  |> sectionBase model.typeText

let sectionSize model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [
          title h1 [TitleSize Is1; TitleType TitleType.SubTitle] [] [str "Title 1"]
          title h1 [TitleSize Is2] [] [str "Title 2"]
          title h1 [TitleSize Is3] [] [str "Title 3 (Default size)"]
          title h1 [TitleSize Is4] [] [str "Title 4"]
          title h1 [TitleSize Is5] [] [str "Title 5"]
          title h1 [TitleSize Is6] [] [str "Title 6"]
          br []
          title h1 [TitleType SubTitle; TitleSize Is1] [] [str "Subtitle 1"]
          title h1 [TitleType SubTitle; TitleSize Is2] [] [str "Subtitle 2"]
          title h1 [TitleType SubTitle; TitleSize Is3] [] [str "Subtitle 3"]
          title h1 [TitleType SubTitle; TitleSize Is4] [] [str "Subtitle 4"]
          title h1 [TitleType SubTitle; TitleSize Is5] [] [str "Subtitle 5 (Default size)"]
          title h1 [TitleType SubTitle; TitleSize Is6] [] [str "Subtitle 6"]
        ] ]
  |> docBlock model.sizeCode
  |> toList
  |> sectionBase model.sizeText

let sectionExtra model =
  div
    [ ]
    [ div
        [ ClassName "block" ]
        [
          str "Default behavior"
          title p [ TitleType TitleType.Title; TitleSize Is1 ] [] [ str "Title 1" ]
          title p [ TitleType SubTitle; TitleSize Is3 ] [] [ str "Subtitle 3" ]
          br []
          str "Behavior when using IsSpaced"
          title p [ TitleType TitleType.Title; TitleSize Is1; IsSpaced ] [] [ str "Title 1" ]
          title p [ TitleType SubTitle; TitleSize Is3 ] [] [ str "Subtitle 3" ]
        ] ]
  |> docBlock model.spacedCode
  |> toList
  |> sectionBase model.spacedText

let root model =
  div
    [ ]
    [
      sectionHeading model
      hr []
      sectionType model
      hr []
      sectionSize model
      hr []
      sectionExtra model
      ]
