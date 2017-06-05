namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Icon =

  module Types =

    type Option =
      | Size of ISize

    type Options =
      { size: string }

      static member Empty =
        { size = "" }

  open Types

  // Sizes
  let isSmall = Size IsSmall
  let isMedium = Size IsMedium
  let isLarge = Size IsLarge

  let icon options children =
    let parseOptions (result: Options) option =
      match option with
      | Size size -> { result with size = ofSize size}

    let opts = options |> List.fold parseOptions Options.Empty

    span
      [ ClassName (bulma.icon.container ++ opts.size) ]
      children
