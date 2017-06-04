namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Button =

  [<StringEnum>]
  type ButtonLevel =
    | [<CompiledName("is-link")>] Link
    interface ILevel

  [<StringEnum>]
  type ButtonState =
    | [<CompiledName("")>] Normal
    | [<CompiledName("is-hovered")>] Hovered
    | [<CompiledName("is-focus")>] Focus
    | [<CompiledName("is-active")>] Active
    | [<CompiledName("is-loading")>] Loading

  type Option =
    | Level of ILevel
    | Size of Size
    | IsOutlined
    | IsInverted
    | State of ButtonState

  type Options =
    { level: ILevel
      size: Size
      isOutlined: bool
      isInverted: bool
      state: ButtonState }

    static member Empty =
      { level = NoLevel
        size = Size.Normal
        isOutlined = false
        isInverted = false
        state = Normal }

  let btn (options: Option list) (properties: IHTMLProp list) children =
    let rec parseOptions options result =
      match options with
      | x::xs ->
          match x with
          | Level level ->
              { result with level = level }
          | Size size ->
              { result with size = size }
          | IsOutlined ->
              { result with isOutlined = true }
          | IsInverted ->
              { result with isInverted = true }
          | State state ->
              { result with state = state }
          |> parseOptions xs
      | [] -> result

    let opts = parseOptions options Options.Empty

    let className =
      classBaseList
        (sprintf "button %s %s %s" (unbox<string>opts.level) (unbox<string>opts.size) (unbox<string>opts.state))
        [ "is-outlined", opts.isOutlined
          "is-inverted", opts.isInverted ]

    a
      ((className :> IHTMLProp) :: properties)
      children
