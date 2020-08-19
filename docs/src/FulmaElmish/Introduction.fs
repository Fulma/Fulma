module FulmaElmish.Introduction

let view =
    Render.contentFromMarkdown
        """
# Fulma.Elmish

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>
Provide ready to use *elmish components*.

---

## How to install ?

- Choose depending on your package manager:
    - `paket add Fulma.Extensions.Wikiki.Tooltip --project <your project>`
    - `dotnet add <your project> package Fulma.Extensions.Wikiki.Tooltip`
- Restore your package `dotnet restore <your project>`
- Follow instructions from `dotnet femto yourProject.fsproj` - [Femto documentation](https://github.com/Zaid-Ajaj/Femto/)
- Don't forget to configure the npm package in your project

You are ready to start using Fulma.Elmish. You can confirm it by trying to open `Fulma.Elmish` namespace.

```fsharp
open Fulma.Elmish
```

        """
