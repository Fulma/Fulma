module Elements.Content.State

open Elmish
open Types

let init () : Model =
  { text =
      "
# Content

A single class to handle WYSIWYG generated content, where only **HTML tags** are available.
      "
    sizeText =
        "
# Sizes
        "
    sizeCode =
    """
```fsharp
  // Possibles values
  [<StringEnum>]
  type Level =
    | [<CompiledName("")>] NoLevel
    | [<CompiledName("is-primary")>] Primary
    | [<CompiledName("is-info")>] Info
    | [<CompiledName("is-success")>] Success
    | [<CompiledName("is-warning")>] Warning
    | [<CompiledName("is-danger")>] Danger
    interface ILevel

  // Examples

  // Normal size
  content
    [] []
    [ h1 [] [str "Hello World"]
      ..... ]

  // For small size
  content
    [ Size Small ] []
    [ h1 [] [str "Hello World"]
      ..... ]
```
    """
  }
