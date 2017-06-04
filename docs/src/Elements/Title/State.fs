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
//posible types
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
#Sizes
There can be **six** different sizes for title
            "
        sizeCode =
            """
```fsharp
//posible sizes
[<StringEnum>]
type TitleSize =
| [<CompiledName("is-1")>] Is1
| [<CompiledName("is-2")>] Is2
| [<CompiledName("is-3")>] Is3
| [<CompiledName("is-4")>] Is4
| [<CompiledName("is-5")>] Is5
| [<CompiledName("is-6")>] Is6
| [<CompiledName("")>] None

//Examples
title h1 [TitleSize Is1; TitleType TitleType.SubTitle] [] [str "Title 1"]
title h1 [TitleSize Is2] [] [str "Title 2"]
title h1 [TitleSize Is3] [] [str "Title 3"]
title h1 [TitleSize Is4] [] [str "Title 4"]
title h1 [TitleSize Is5] [] [str "Title 5"]
title h1 [TitleSize Is6] [] [str "Title 6"]
br []
title h1 [TitleType SubTitle; TitleSize Is1] [] [str "Subtitle 1"]
title h1 [TitleType SubTitle; TitleSize Is2] [] [str "Subtitle 2"]
title h1 [TitleType SubTitle; TitleSize Is3] [] [str "Subtitle 3"]
title h1 [TitleType SubTitle; TitleSize Is4] [] [str "Subtitle 4"]
title h1 [TitleType SubTitle; TitleSize Is5] [] [str "Subtitle 5"]
title h1 [TitleType SubTitle; TitleSize Is6] [] [str "Subtitle 6"]

```
            """
        extraText =
            "
#Extra
            "
        extraCode =
        """
```fsharp
//Title may have extra attributes like this in future
[<StringEnum>]
type TitleExtra =
| [<CompiledName("is-spaced")>] IsSpaced
| [<CompiledName("")>] None

//Examples
title p [TitleType TitleType.Title; TitleSize Is1; TitleExtra IsSpaced] [] [str "Title 1"]
title p [TitleType SubTitle; TitleSize Is3] [] [str "Subtitle 3"]
br []
title p [TitleType TitleType.Title; TitleSize Is2; TitleExtra IsSpaced] [] [str "Title 2"]
title p [TitleType SubTitle; TitleSize Is4] [] [str "Subtitle 4"]
br []
title p [TitleType TitleType.Title; TitleSize Is3; TitleExtra IsSpaced] [] [str "Title 3"]
title p [TitleType SubTitle; TitleSize Is5] [] [str "Subtitle 5"]
```
        """
    }
