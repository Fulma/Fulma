module FulmaElmish.Introduction.View

open Fable.Core

let root _ =
    Render.contentFromMarkdown
        """
# Fulma.Elmish

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>
Provide ready to use *elmish components*.

---

## How to install ?

Add `Fulma.Elmish` dependencies into your paket files: `paket add Fulma.Elmish --project <your project>`

Then `dotnet restore` on your `*.fsproj` file.

You are ready to start using Fulma.Elmish. You can confirm it by trying to open `Fulma.Elmish` namespace.

```fsharp
open Fulma.Elmish
```

        """
