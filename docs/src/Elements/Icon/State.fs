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
  [ Icon.iconSmall ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [  ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [ Icon.iconMedium ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
Icon.icon
  [ Icon.iconLarge ]
  [ i [ ClassName "fa fa-home" ] [ ] ]
```
      """ }
