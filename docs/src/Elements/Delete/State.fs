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
Delete.delete
  [ Delete.small ] [ ]
Delete.delete
  [ ] [ ]
Delete.delete
  [ Delete.medium ] [ ]
Delete.delete
  [ Delete.large ] [ ]
```
      """ }
