namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Icon =

  type Option =
    | Size of string

  type Options =
    { size: string }

    static member Empty =
      { size = "" }

  let internal builder (options: Option list) children =
    let parseOptions (result: Options) option =
      match option with
      | Size size -> { result with size = size}

    let opts = options |> List.fold parseOptions Options.Empty

    let className =
      ClassName (bulma.icon.container + opts.size)

    span
      [ className ]
      children

  let small = Size bulma.icon.size.isSmall

  let medium = Size bulma.icon.size.isMedium

  let large = Size bulma.icon.size.isLarge

  let icon options children = builder options children
