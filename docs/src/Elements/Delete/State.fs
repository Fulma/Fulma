module Elements.Delete.State

open Elmish
open Types

let init () : Model =
  { text =
      "
# Delete
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
delete a
    [ Size Small ]
    [ ] [ ]
delete a
    [  ]
    [ ] [ ]

//or with buttons
delete button
    [ Size Medium ]
    [ ] [ ]
delete button
    [ Size Large ]
    [ ] [ ]
```
      """ }
