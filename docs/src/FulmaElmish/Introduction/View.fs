module FulmaElmish.Introduction.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma.Elements
open Fulma.Components

let root =
    Render.contentFromMarkdown
        """
# Fulma.Elmish

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>
Provide ready to use *elmish components*.

---

## How to install ?

Add `Fulma.Elmish` denpendencies into your paket files.

```
// paket.denpendencies
nuget Fulma.Elmish

// paket.reference
Fulma.Elmish
```

Run `paket.exe update` at your project root and then `dotnet restore` on your `*.fsproj` file.

You are ready to start using Fulma.Elmish. You can confirm it by trying to open `Fulma.Elmish` namespace.

```fsharp
open Fulma.Elmish
```

        """
