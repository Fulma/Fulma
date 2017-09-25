module Home.View

open Fable.Core

let root _ =
    Render.contentFromMarkdown
        """
# Fulma

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>

Fulma is divided into 3 projects:

- [Fulma](#fulma), which provide you wrapper on top of Bulma
- [Fulma.Extensions](#fulma-extensions), which provde you wrapper on top of Bulma extensions
- [Fulma.Elmish](#fulma-elmish), which provide you ready to use "elmish component" like a date picker.

        """
