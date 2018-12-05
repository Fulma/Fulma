module FableFontAwesome.Introduction

let view =
    Render.contentFromMarkdown
        """
# Fable.FontAwesome

<div class="message is-info">
    <div class="message-header">Information</div>
    <div class="message-body">
        <p>The package is **Fable**.FontAwesome but we are hosting the package under **Fulma** repo for historical reasons.</p>

        <p>This means that `Fable.FontAwesome` can be used in any React project and is not dependent on `Fulma` package.</p>

        <p>In the future, we will probably move it to its own repo.</p>
    </div>
</div>

Provide a wrapper around [Font Awesome](https://fontawesome.com/).

---

## Versions compatibility

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Fable.FontAwesome</th>
            <th>Font Awesome</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>5.5.0</td>
        </tr>
    </tbody>
<table>

---

## How to install ?

Add `Fable.FontAwesome` dependency to your paket files: `paket add Fable.FontAwesome --project <your project>`

----

<span class="is-size-5 has-text-info">
<i class="fas fa-exclamation-circle"></i>
Important
</span>

Font Awesome comes with a **Free** and **Pro** version.

So you also need to install `Fable.FontAwesome.Free` **or** `Fable.FontAwesome.Pro` depending on your Font Awesome version. These packages will provide you bindings for the icons.

----

Then `dotnet restore` on your `*.fsproj` file.

You are ready to start using `Fable.FontAwesome`. You can test this by trying to open `Fable.FontAwesome` namespace.

```fsharp
open Fable.FontAwesome
```
        """
