namespace Elmish.Bulma

open Fable.Core

module Modifiers =

  type ILevel = interface end

  [<StringEnum>]
  type Level =
    | [<CompiledName("")>] NoLevel
    | [<CompiledName("is-primary")>] Primary
    | [<CompiledName("is-info")>] Info
    | [<CompiledName("is-success")>] Success
    | [<CompiledName("is-warning")>] Warning
    | [<CompiledName("is-danger")>] Danger
    interface ILevel

  [<StringEnum>]
  type Size =
    | [<CompiledName("is-small")>] Small
    | [<CompiledName("")>] Normal
    | [<CompiledName("is-medium")>] Medium
    | [<CompiledName("is-large")>] Large
