namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Heading =

  module Types =

    type ITitleSize =
      | Is1
      | Is2
      | Is3
      | Is4
      | Is5
      | Is6

    type ITitleType =
      | Title
      | Subtitle

    let ofTitleSize titleSize =
      match titleSize with
      | Is1 -> bulma.heading.size.is1
      | Is2 -> bulma.heading.size.is2
      | Is3 -> bulma.heading.size.is3
      | Is4 -> bulma.heading.size.is4
      | Is5 -> bulma.heading.size.is5
      | Is6 -> bulma.heading.size.is6

    let ofTitleType titleType =
      match titleType with
      | Title -> bulma.heading.title
      | Subtitle -> bulma.heading.subtitle

    type Option =
      | Size of ITitleSize
      | Type of ITitleType
      | IsSpaced

    type Options =
      { titleSize: string option
        titleType: string
        isSpaced: bool }

      static member Empty =
        { titleSize = None
          titleType = ""
          isSpaced = false }

  open Types

  //Types
  let isTitle = Type Title
  let isSubtitle = Type Subtitle
  // Sizes
  let is1 = Size Is1
  let is2 = Size Is2
  let is3 = Size Is3
  let is4 = Size Is4
  let is5 = Size Is5
  let is6 = Size Is6
  // Spacing
  let isSpaced = IsSpaced

  let title (element:IHTMLProp list -> React.ReactElement list -> React.ReactElement) (options: Option list) (children) =
      let parseOption result opt=
        match opt with
        | Size ts ->
            { result with titleSize = ofTitleSize ts |> Some }
        | Type tt ->
            { result with titleType = ofTitleType tt }
        | IsSpaced ->
            { result with isSpaced = true }

      let opts = options |> List.fold parseOption Options.Empty

      let className =
        classBaseList
          (Helpers.generateClassName opts.titleType [ opts.titleSize ])
          [ bulma.heading.spacing.isNormal, opts.isSpaced ]

      element
        [ className ]
        children

  // Alias
  let h1 = title h1
  let h2 = title h2
  let h3 = title h3
  let h4 = title h4
  let h5 = title h5
  let h6 = title h6
  let p = title p
