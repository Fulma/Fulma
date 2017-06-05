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
## Colors
            "
      colorCode =
            """
```fsharp
Tag.tag [ Tag.isBlack ] [ str "Black" ]
Tag.tag [ Tag.isDark ] [ str "Dark" ]
Tag.tag [ Tag.isLight ] [ str "Light" ]
Tag.tag [ Tag.isWhite ] [ str "White" ]
Tag.tag [ Tag.isPrimary ] [ str "Primary"]
Tag.tag [ Tag.isInfo ] [ str "Info" ]
Tag.tag [ Tag.isSuccess ] [ str "Success" ]
Tag.tag [ Tag.isWarning ] [ str "Warning" ]
Tag.tag [ Tag.isDanger ] [ str "Danger" ]
```
            """
      sizeText =
            "
## Sizes
            "
      sizeCode =
            """
```fsharp
Tag.tag [ Tag.isSuccess; Tag.isMedium ] [ str "Medium" ]
Tag.tag [ Tag.isInfo; Tag.isLarge ] [ str "Large" ]
```
            """
      }
