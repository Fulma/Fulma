module Elements.Tag.State

open Elmish
open Types

let init () : Model =
      {
      text =
            "
# Tags
            "
      code =
            """
```fsharp
//Example
tag [] [] [str "Tag label"]
```
            """
      colorText =
            "
# Colors
            "
      colorCode =
            """
```fsharp
[<StringEnum>]
type TagColor =
| [<CompiledName("is-black")>] Black
| [<CompiledName("is-dark")>] Dark
| [<CompiledName("is-light")>] Light
| [<CompiledName("is-white")>] White
| [<CompiledName("is-primary")>] Primary
| [<CompiledName("is-info")>] Info
| [<CompiledName("is-success")>] Success
| [<CompiledName("is-warning")>] Warning
| [<CompiledName("is-danger")>] Danger
| [<CompiledName("")>] None

//Examples
tag [Color Black] [] [str "Black"]
tag [Color Dark] [] [str "Dark"]
tag [Color Light] [] [str "Light"]
tag [Color White] [] [str "White"]
tag [Color Primary] [] [str "Primary"]
tag [Color Info] [] [str "Info"]
tag [Color Success] [] [str "Success"]
tag [Color Warning] [] [str "Warning"]
tag [Color Danger] [] [str "Danger"]
```
            """
      sizeText =
            "
# Sizes
            "
      sizeCode =
            """
```fsharp
[<StringEnum>]
type TagSize =
| [<CompiledName("is-medium")>] Medium
| [<CompiledName("is-large")>]Large
| [<CompiledName("")>] None

tag [Color Success; Size Medium] [] [str "Medium"]
tag [Color Info; Size Large] [] [str "Large"]
```
            """
      }
