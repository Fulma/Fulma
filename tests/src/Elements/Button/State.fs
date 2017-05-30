module Elements.Button.State

open Elmish
open Types

let init () : Model =
  { textSection1 =
      "
# Buttons
The **button** can have different colors, sizes and states.
      "
    codeSection1 =
      """
```fsharp
  div
    [ ClassName "block" ]
    [ Bulma.Button.view [] [] [ str "Button" ]
      Bulma.Button.view [ Level IsWhite ] [] [ str "White" ]
      Bulma.Button.view [ Level IsLight ] [] [ str "Light" ]
      Bulma.Button.view [ Level IsDark ] [] [ str "Dark" ]
      Bulma.Button.view [ Level IsBlack ] [] [ str "Black" ]
      Bulma.Button.view [ Level IsLink ] [] [ str "Link" ] ]
  div
    [ ClassName "block" ]
    [ Bulma.Button.view [ Level IsPrimary ] [] [ str "Primary" ]
      Bulma.Button.view [ Level IsInfo ] [] [ str "Info" ]
      Bulma.Button.view [ Level IsSuccess ] [] [ str "Success" ]
      Bulma.Button.view [ Level IsWarning ] [] [ str "Warning" ]
      Bulma.Button.view [ Level IsDanger ] [] [ str "Danger" ] ]
```
      """ }
