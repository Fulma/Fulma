namespace Elmish.Bulma

open Fable.Core

module Modifiers =

  [<StringEnum>]
  type Level =
    | [<CompiledName("")>] None
    | [<CompiledName("is-primary")>] IsPrimary
    | [<CompiledName("is-info")>] IsInfo
    | [<CompiledName("is-success")>] IsSuccess
    | [<CompiledName("is-warning")>] IsWarning
    | [<CompiledName("is-danger")>] IsDanger
