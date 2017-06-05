module Elements.Button.State

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
// Possible values
[<StringEnum>]
type Level =
  | [<CompiledName("")>] NoLevel
  | [<CompiledName("is-primary")>] IsPrimary
  | [<CompiledName("is-info")>] IsInfo
  | [<CompiledName("is-success")>] IsSuccess
  | [<CompiledName("is-warning")>] IsWarning
  | [<CompiledName("is-danger")>] IsDanger
  interface ILevel

[<StringEnum>]
type ButtonColor =
  | [<CompiledName("is-white")>] IsWhite
  | [<CompiledName("is-light")>] IsLight
  | [<CompiledName("is-dark")>] IsDark
  | [<CompiledName("is-black")>] IsBlack
  | [<CompiledName("is-link")>] IsLink
  interface ILevel

// Examples
btn [ Level IsDark ] [] [ str "Dark" ]
btn [ Level IsSuccess ] [] [ str "Success" ]
```
      """
    textSize =
      "## Sizes"
    codeSize =
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
btn [ Size Large ] [ ] [ str "Large" ]
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
// Examples
btn [ Level IsSuccess; IsOutlined ] [ ] [str "Outlined" ]
btn [ Level IsPrimary; IsOutlined ] [ ] [str "Outlined" ]
```
      """
    codeStyleInverted =
      """
```fsharp
// Examples
btn [ IsOutlined ] [ ] [str "Outlined" ]
btn [ Level IsSuccess; IsInverted ] [ ] [str "Inverted" ]
```
      """
    codeStyleInvertOutlined =
      """
```fsharp
// Examples
btn [ IsOutlined; IsInverted ] [ ] [str "Invert Outlined" ]
btn [ Level IsSuccess; IsOutlined; IsInverted ] [ ] [str "Invert outlined" ]
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
btn [ Level Success ] [ ] [str "Normal" ]
btn [ State Hovered; Level Success ] [ ] [str "Hover" ]
btn [ State Focus; Level Success ] [ ] [str "Hover" ]
btn [ State Active; Level Success ] [ ] [str "Hover" ]
btn [ State Loading; Level Success ] [ ] [str "Hover" ]
```
      """ }
