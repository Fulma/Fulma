module Elements.Box.State

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

// Example
box' [] [
        str
            "
            Lorem ipsum dolor sit amet, consectetur adipisicing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.
            "
        ]
```
      """ }
