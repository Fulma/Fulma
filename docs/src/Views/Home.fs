module Home

let view =
    Render.contentFromMarkdown
        """
<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>

# Fulma

Fulma provides a wrapper around [Bulma 0.8.0](http://bulma.io/), an open source CSS framework, for [fable-react](https://github.com/fable-compiler/fable-react).

Fulma is divided into 3 projects:

- [Fulma](#fulma), which provides you with a wrapper on top of Bulma
- [Fulma.Extensions](#fulma-extensions), which provides you with a wrapper on top of Bulma extensions
- [Fulma.Elmish](#fulma-elmish), which provides you with ready to use "elmish component" like a datepicker.

        """
