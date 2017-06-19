module Home.State

open Elmish
open Types

let init() : Model =
    { intro =
        """
# Fable.Elmish.Bulma

Bring Bulma power into Elmish.

---
    test
---


        """}

let update msg model : Model =
    model
