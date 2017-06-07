namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Content =

  module Types =

    type Option =
      | Size of ISize

    type Options =
      { size: string option }

      static member Empty =
        { size = None }

  open Types

  // Sizes
  let isSmall = Size IsSmall
  let isMedium = Size IsMedium
  let isLarge = Size IsLarge

  let content (options: Option list) children =
    let parseOption (result: Options) opt =
      match opt with
      | Size size ->
          { result with size = ofSize size |> Some }

    let opts = options |> List.fold parseOption Options.Empty

    div
      [ ClassName
          (Helpers.generateClassName bulma.content.container [ opts.size ]) ]
      children
