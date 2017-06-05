module Elements.Image.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish
open Elmish.Bulma.Elements
open Global

let imageDummy strSize imageSize =
  div
    [ ]
    [ Heading.h6
        [ Heading.isSubtitle ]
        [ str (strSize + "px") ]
      Image.image
        [ imageSize ]
        [ img
            [ Src (sprintf "https://dummyimage.com/%s/7a7a7a/fff" strSize) ] ] ]

let sectionSize model =
  div
    [ ]
    [ imageDummy "64x64" Image.is64x64
      hr [ ]
      imageDummy "128x128" Image.is128x128 ]
  |> docBlock model.codeSize
  |> toList
  |> sectionBase model.textSize

let sectionRatio model =
  div
    [ ]
    [ Image.image
        [ Image.is2by1 ]
        [ img
            [ Src "https://dummyimage.com/640x320/7a7a7a/fff" ] ] ]
  |> docBlock model.codeRatio
  |> toList
  |> sectionBase model.textRatio

let root model =
  div
    [ ]
    [ Content.content [ ] [ renderMarkdown model.text ]
      hr [ ]
      sectionSize model
      hr [ ]
      sectionRatio model ]
