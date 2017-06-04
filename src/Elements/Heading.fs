namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Heading =

  type Option =
  | Size of string
  | Type of string
  | IsSpaced

  type Options =
    { titleSize: string
      titleType: string
      isSpaced: bool }

    static member Empty =
      { titleSize = ""
        titleType = ""
        isSpaced = false }

  //Types
  let isTitle = Type bulma.heading.title
  let isSubtitle = Type bulma.heading.subtitle
  // Sizes
  let is1 = Size bulma.heading.size.is1
  let is2 = Size bulma.heading.size.is2
  let is3 = Size bulma.heading.size.is3
  let is4 = Size bulma.heading.size.is4
  let is5 = Size bulma.heading.size.is5
  let is6 = Size bulma.heading.size.is6
  // Spacing
  let isSpaced = IsSpaced

  let title (element:IHTMLProp list -> React.ReactElement list -> React.ReactElement) (options: Option list) (children) =
      let parseOption result opt=
        match opt with
        | Size ts ->
            { result with titleSize = ts }
        | Type tt ->
            { result with titleType = tt }
        | IsSpaced ->
            { result with isSpaced = true }

      let opts = options |> List.fold parseOption Options.Empty

      let className =
        classBaseList
          (opts.titleType ++ opts.titleSize)
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
