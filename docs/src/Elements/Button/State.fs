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
        }

let update msg model : Model =
    model
