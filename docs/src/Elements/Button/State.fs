module Elements.Button.State

open Elmish
open Types

let init() : Model =
    { intro =
        """
# Buttons

The **button** can have different colors, sizes and states.
        """
      colorIntro =
        """
### Colors
        """
      colorCode =
        """
```fsharp
Button.button [ ] [ str "Button" ]
Button.button [ Button.isWhite ] [ str "White" ]
Button.button [ Button.isLight ] [ str "Light" ]
Button.button [ Button.isLight ] [ str "Light" ]
Button.button [ Button.isDark ] [ str "Dark" ]
Button.button [ Button.isBlack ] [ str "Black" ]
Button.button [ Button.isLink ] [ str "Link" ]
Button.button [ Button.isPrimary ] [ str "Primary" ]
Button.button [ Button.isInfo ] [ str "Info" ]
Button.button [ Button.isSuccess ] [ str "Success" ]
Button.button [ Button.isWarning ] [ str "Warning" ]
Button.button [ Button.isDanger ] [ str "Danger" ]
```
        """
        }

let update msg model : Model =
    model
