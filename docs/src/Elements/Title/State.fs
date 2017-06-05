module Elements.Title.State

open Elmish
open Types

let init() : Model =
    {
        text =
          "
# Titles
Simple **headings** to add depth to your page
          "
        typeText =
            "
## Types
**Title** can be of two types *Title* and *Subtitle*.
            "
        typeCode =
            """
```fsharp
Heading.h1 [ ] [str "Title"]
br []
Heading.h3 [ Heading.isSubtitle ] [str "Subtitle"]
```
            """
        sizeText =
            "
## Sizes
There can be **six** different sizes for title
            "
        sizeCode =
            """
```fsharp
Heading.h1 [ Heading.isTitle; Heading.is1 ] [str "Title 1"]
Heading.h1 [ Heading.isTitle; Heading.is2 ] [str "Title 2"]
Heading.h1 [ Heading.isTitle; Heading.is3 ] [str "Title 3 (Default size)"]
Heading.h1 [ Heading.isTitle; Heading.is4 ] [str "Title 4"]
Heading.h1 [ Heading.isTitle; Heading.is5 ] [str "Title 5"]
Heading.h1 [ Heading.isTitle; Heading.is6 ] [str "Title 6"]
br []
Heading.h1 [ Heading.isSubtitle; Heading.is1 ] [str "Subtitle 1"]
Heading.h1 [ Heading.isSubtitle; Heading.is2 ] [str "Subtitle 2"]
Heading.h1 [ Heading.isSubtitle; Heading.is3 ] [str "Subtitle 3"]
Heading.h1 [ Heading.isSubtitle; Heading.is4 ] [str "Subtitle 4"]
Heading.h1 [ Heading.isSubtitle; Heading.is5 ] [str "Subtitle 5 (Default size)"]
Heading.h1 [ Heading.isSubtitle; Heading.is6 ] [str "Subtitle 6"]
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
Heading.p [ Heading.isTitle; Heading.is1; Heading.isSpaced ] [ str "Title 1" ]
Heading.p [ Heading.isSubtitle; Heading.is3 ] [ str "Subtitle 3" ]
```
        """
    }
