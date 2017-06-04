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
  [ Icon.isSmall ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [  ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [ Icon.isMedium ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [ Icon.isLarge ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
```
      """ }
