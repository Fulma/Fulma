module FulmaExtensions.Introduction

let view =
    Render.contentFromMarkdown
        """
# Fulma.Extensions

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>
Provide a wrapper around [bulma extensions](http://bulma.io/extensions/).

---

## How to install ?

Add `Fulma.Extensions` denpendencies into your paket files: `paket add Fulma.Extensions --project <your project>`

Then `dotnet restore` on your `*.fsproj` file.

You are ready to start using Fulma. You can confirm it by trying to open `Fulma` namespace.

```fsharp
open Fulma
open Fulma.Extensions
```

You will also need to provide the sass files of the extensions.

The recommanded way to do that is to include them via `yarn`.

`yarn add -D bulma bulma-calendar`

And then add a reference to them into your `main.sass` file.

```sass
// main.sass

@import './node_modules/bulma/bulma'

@import "./node_modules/bulma-calendar/calendar.sass"
```
        """
