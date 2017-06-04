module Elements.Title.State

open Elmish
open Types

let init() : Model =
    {
        typeText =
            "
# Types
**Title** can be of two types *Title* and *Subtitle*.
            "
        typeCode =
            """
```fsharp
// Possible types
[<StringEnum>]
type TitleType =
| [<CompiledName("title")>] Title
| [<CompiledName("subtitle")>] SubTitle

// Examples
title h1 [] [] [str "Title"]
title h3 [TitleType SubTitle] [] [str "Subtitle"]
```
            """
        sizeText =
            "
# Sizes
There can be **six** different sizes for title
            "
        sizeCode =
            """
```fsharp
// Possible sizes
[<StringEnum>]
type TitleSize =
| [<CompiledName("is-1")>] Is1
| [<CompiledName("is-2")>] Is2
| [<CompiledName("is-3")>] Is3
| [<CompiledName("is-4")>] Is4
| [<CompiledName("is-5")>] Is5
| [<CompiledName("is-6")>] Is6
| [<CompiledName("")>] None

// Examples
// Title
title h1 [TitleSize Is1; TitleType TitleType.SubTitle] [] [str "Title 1"]
// Subtitle
title h1 [TitleType SubTitle; TitleSize Is6] [] [str "Subtitle 6"]
```
            """
        spacedText =
          "
When **conbining** a title and a subtile, they move closer together.

You can prevent this behavior by adding `IsSpaced` on the first element.
          "
        spacedCode =
        """
```fsharp
// Examples
title p [ TitleType TitleType.Title; TitleSize Is1; IsSpaced ] [] [ str "Title 1" ]
title p [ TitleType SubTitle; TitleSize Is3 ] [] [ str "Subtitle 3" ]
```
        """
    }
