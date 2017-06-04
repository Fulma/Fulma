namespace Elmish.Bulma

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Delete =

  type Option =
    | Size of Size

  type Options =
    { size: Size }

    static member Empty =
      { size = Normal }

  let delete (element:IHTMLProp list -> React.ReactElement list -> React.ReactElement) (options: Option list) (properties: IHTMLProp list) children =
    let parseOption result opt =
        match opt with
        | Size s ->
            {result with size = s}

    let opts = options |> List.fold parseOption Options.Empty

    let className =
      ClassName (sprintf "delete %s" (unbox<string>opts.size))

    element
      ((className :> IHTMLProp) :: properties)
      children
