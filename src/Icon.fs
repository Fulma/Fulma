namespace Elmish.Bulma

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Icon =

  let icon (size: Size) children =
    let className = ClassName (sprintf "icon %s" (unbox<string>size))

    span
      [ className ]
      children

  let iconSmall = icon Small

  let iconNormal = icon Normal

  let iconMedium = icon Medium

  let iconLarge = icon Large
