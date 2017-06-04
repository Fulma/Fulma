namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Icon =

  type Option =
    | Size of Size

  type Options =
    { size: Size }

    static member Empty =
      { size = Normal }

  let internal builder (options: Option list) children =
    let rec parseOptions options result =
      match options with
      | x::xs ->
          match x with
          | Size size -> { result with size = size}
      | [] -> result

    let opts = parseOptions options Options.Empty

    let className =
      ClassName (sprintf "icon %s" (unbox<string>opts.size))

    span
      [ className ]
      children

  let iconSmall = Size Small

  let iconNormal = Size Normal

  let iconMedium = Size Medium

  let iconLarge = Size Large

  let icon options children = builder options children
