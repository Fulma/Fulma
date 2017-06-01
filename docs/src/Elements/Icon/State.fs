module Elements.Icon.State

open Elmish
open Types

let init () : Model =
  { text =
      "
# Icons
      "
    code =
      """
```fsharp
// Possible values
[<StringEnum>]
type Size =
  | [<CompiledName("is-small")>] Small
  | [<CompiledName("")>] Normal
  | [<CompiledName("is-medium")>] Medium
  | [<CompiledName("is-large")>] Large

// Example
icon
  [ Size Small ]
  [ ] [ i [ ClassName "fa fa-home" ] [ ] ]
icon
  [  ]
  [ ] [ i [ ClassName "fa fa-home" ] [ ] ]
icon
  [ Size Medium ]
  [ ] [ i [ ClassName "fa fa-home" ] [ ] ]
icon
  [ Size Large ]
  [ ] [ i [ ClassName "fa fa-home" ] [ ] ]
```
      """ }
