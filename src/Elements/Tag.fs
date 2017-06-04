namespace Elmish.Bulma.Elements

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

  type Option =
  | Size of TagSize
  | Color of ILevel

  type Options =
    { size: TagSize
      color : ILevel }

    static member Empty =
      { size = TagSize.Normal
        color = NoLevel }

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
