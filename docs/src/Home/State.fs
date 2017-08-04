module Home.State

open Elmish
open Types

let init() : Model =
    { Intro =
        """
# Fable.Elmish.Bulma

Provide a wrapper around Bulma for [Elmish](https://fable-elmish.github.io/).

---

---


        """}

let update msg model : Model =
    model
