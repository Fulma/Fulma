module Elements.Form.State

open Elmish
open Types

let init () : Model =
  { textColor =
      "
# Buttons
The **button** can have different colors, sizes and states.
      "
    codeColor =
      """
```fsharp
Button.button [ Button.isWhite ] [ str "White" ]
Button.button [ Button.isDark ] [ str "Dark" ]
Button.button [ Button.isInfo ] [ str "Info" ]
Button.button [ Button.isSuccess ] [ str "Success" ]
```
      """
    textSize =
      "## Sizes"
    codeSize =
      """
```fsharp
Button.button [ ] [ str "Normal" ]
Button.button [ Button.isMedium ] [ str "Medium" ]
```
      """
    textStyle =
      "
## Styles
The button can be **outlined** and/or **inverted**.
      "
    codeStyleOutlined =
      """
```fsharp
Button.button [ Button.isSuccess; Button.isOutlined ] [str "Outlined" ]
Button.button [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
```
      """
    codeStyleInverted =
      """
```fsharp
Button.button [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
Button.button [ Button.isPrimary; Button.isInverted ] [ str "Inverted" ]
```
      """
    codeStyleInvertOutlined =
      """
```fsharp
Button.button [ Button.isSuccess; Button.isOutlined; Button.isInverted ] [ str "Invert outlined" ]
```
      """
    textState =
      "
## State
You can control the state of the buttons.
      "
    codeState =
      """
```fsharp
Button.button [ Button.isSuccess ] [ str "Normal" ]
Button.button [ Button.isHovered; Button.isSuccess ] [ str "Hover" ]
Button.button [ Button.isFocused; Button.isSuccess ] [ str "Hover" ]
Button.button [ Button.isActive; Button.isSuccess ] [ str "Hover" ]
Button.button [ Button.isLoading; Button.isSuccess ] [ str "Hover" ]
```
      """ }
