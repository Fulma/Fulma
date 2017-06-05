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
  [ Delete.isSmall ] [ ]
Delete.delete
  [ ] [ ]
Delete.delete
  [ Delete.isMedium ] [ ]
Delete.delete
  [ Delete.isLarge ] [ ]
```
      """ }
