namespace Elmish.Bulma

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Content =

  type Option =
    | Size of Size

  type Options =
    { size: Size }

    static member Empty =
      { size = Normal }

  let content (options: Option list) (properties: IHTMLProp list) children =
    let parseOption result opt =
        match opt with
        | Size s ->
            {result with size = s}

    let opts = options |> List.fold parseOption Options.Empty

    let className =
      ClassName (sprintf "content %s" (unbox<string>opts.size))

    div
      ((className :> IHTMLProp) :: properties)
      children
