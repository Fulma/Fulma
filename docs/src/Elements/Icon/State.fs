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
Icon.icon
  [ Icon.small ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [  ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [ Icon.medium ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [ Icon.large ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
```
      """ }
