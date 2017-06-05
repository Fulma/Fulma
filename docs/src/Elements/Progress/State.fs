module Elements.Progress.State

open Elmish
open Types

let init () : Model =
  { text =
      "
# Progress bars
Progress bars can have **colors** or **sizes** modifiers
      "
    code =
      """
```fsharp
Progress.progress
  [ Progress.isSuccess
    Progress.isSmall
    Progress.props
      [ Value !^"15"
        Max !^"100" ] ]
  [ str "15%" ]
Progress.progress
  [ Progress.isPrimary
    Progress.isMedium
    Progress.props
      [ Value !^"85"
        Max !^"100" ] ]
  [ str "85%" ]
Progress.progress
  [ Progress.isDanger
    Progress.isLarge
    Progress.props
      [ Value !^"50"
        Max !^"100" ] ]
  [ str "50%" ]
```
      """ }
