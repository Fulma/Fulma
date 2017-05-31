namespace Elmish.Bulma

open Fable.Core

module Modifiers =

  type ILevel = interface end

  [<StringEnum>]
  type Level =
    | [<CompiledName("")>] NoLevel
    | [<CompiledName("is-primary")>] IsPrimary
    | [<CompiledName("is-info")>] IsInfo
    | [<CompiledName("is-success")>] IsSuccess
    | [<CompiledName("is-warning")>] IsWarning
    | [<CompiledName("is-danger")>] IsDanger
    interface ILevel

  [<StringEnum>]
  type Size =
    | [<CompiledName("is-small")>] Small
    | [<CompiledName("")>] Normal
    | [<CompiledName("is-medium")>] Medium
    | [<CompiledName("is-large")>] Large
