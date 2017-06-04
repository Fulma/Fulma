namespace Elmish.Bulma

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Tag =

  [<StringEnum>]
  type TagSize =
    | [<CompiledName("is-medium")>] Medium
    | [<CompiledName("is-large")>]Large
    | [<CompiledName("")>] Normal

  [<StringEnum>]
  type TagColor =
    | [<CompiledName("is-black")>] Black
    | [<CompiledName("is-dark")>] Dark
    | [<CompiledName("is-light")>] Light
    | [<CompiledName("is-white")>] White
    | [<CompiledName("is-primary")>] Primary
    | [<CompiledName("is-info")>] Info
    | [<CompiledName("is-success")>] Success
    | [<CompiledName("is-warning")>] Warning
    | [<CompiledName("is-danger")>] Danger
    | [<CompiledName("")>] None

  type Option =
  | Size of TagSize
  | Color of TagColor

  type Options =
    { size: TagSize
      color : TagColor }

    static member Empty =
      { size = TagSize.Normal
        color = TagColor.None }

  let tag (options: Option list) (properties: IHTMLProp list) children =
    let parseOption result opt =
      match opt with
      | Size s ->
          { result with size = s }
      | Color c ->
          { result with color = c }

    let opts = options |> List.fold parseOption Options.Empty

    let className =
      ClassName (sprintf "tag %s %s" (unbox<string>opts.size) (unbox<string>opts.color) )

    span
      ((className :> IHTMLProp) :: properties)
      children
