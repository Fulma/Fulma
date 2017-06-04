module Elements.Delete.State

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
delete a
    [ Size Small ]
    [ ] [ ]
delete a
    [  ]
    [ ] [ ]
delete a
    [ Size Medium ]
    [ ] [ ]
delete a
    [ Size Large ]
    [ ] [ ]

//or with buttons
delete button
    [ Size Small ]
    [ ] [ ]
delete button
    [  ]
    [ ] [ ]
delete button
    [ Size Medium ]
    [ ] [ ]
delete button
    [ Size Large ]
    [ ] [ ]
```
      """ }
