module Demo.View

open Fable.Core

let root _ =
    Render.contentFromMarkdown
        """
# Demos

We currently have two demos availables for Fulma.

1. The docs site of Fulma is written with it and Elmish. Yes, I like the concept of *Eating your own dog food*
2. An application mimicing a Q/A website is online [here](https://mangelmaxime.github.io/fulma-demo/)
        """
