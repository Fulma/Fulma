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
## Sizes
        "
    sizeCode =
    """
```fsharp
  // Normal size
  Content.content
    [] []
    [ h1 [] [str "Hello World"]
      ..... ]

  // Small size
  Content.content
    [ Content.isSmall ] []
    [ h1 [] [str "Hello World"]
      ..... ]

  // Medium size
  Content.content
    [ Content.isMedium ] []
    [ h1 [] [str "Hello World"]
      ..... ]

  // Large size
  Content.content
    [ Content.isLarge ] []
    [ h1 [] [str "Hello World"]
      ..... ]
```
    """
  }
