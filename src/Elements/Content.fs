namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Content =

  type Option =
    | Size of string

  type Options =
    { size: string }

    static member Empty =
      { size = "" }

  // Sizes
  let isSmall = Size bulma.content.size.isSmall
  let isMedium = Size bulma.content.size.isMedium
  let isLarge = Size bulma.content.size.isLarge

  let content (options: Option list) children =
    let parseOption (result: Options) opt =
      match opt with
      | Size s ->
          { result with size = s }

    let opts = options |> List.fold parseOption Options.Empty

    div
      [ ClassName (bulma.content.container ++ opts.size) ]
      children
