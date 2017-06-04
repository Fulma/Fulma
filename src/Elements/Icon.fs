namespace Elmish.Bulma

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

  let icon (options: Option list) (properties: IHTMLProp list) children =
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
      ((className :> IHTMLProp) :: properties)
      children
