module Elements.Icon.State

open Elmish
open Types

let init () : Model =
  { text =
      "
# Buttons
The **button** can have different colors, sizes and states.
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
icon [ Small ] [ ] [ str "Small" ]
icon [ Normal ] [ ] [ str "Normal" ]
icon [ Medium ] [ ] [ str "Medium" ]
icon [ Large ] [ ] [ str "Large" ]
```
      """ }
