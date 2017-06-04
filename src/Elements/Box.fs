namespace Elmish.Bulma

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Box =

  let box' (properties: IHTMLProp list) children =
    let className =
      ClassName (sprintf "box")

    div
      ((className :> IHTMLProp) :: properties)
      children
