module Fulma.Introduction

let view =
    Render.contentFromMarkdown
        """
<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>

# Fulma
Fulma provides a wrapper around [Bulma 0.9.3](http://bulma.io/), an open source CSS framework, for [fable-react](https://github.com/fable-compiler/fable-react).

However this website isn't intended to provide a full documentation of Bulma.

It only serves as a documentation of the wrapper and as a test that the wrappers are working, seeing how this website was built with Fulma itself.

---

## Getting started

There are two ways to get started with Fulma:

1. You can use the [Fulma-Minimal template](#template)
2. You can install it manually

### How to install manually?

- Choose depending on your package manager:
    - `paket add Fulma.Extensions.Wikiki.Tooltip --project <your project>`
    - `dotnet add <your project> package Fulma.Extensions.Wikiki.Tooltip`
- Restore your package `dotnet restore <your project>`
- Follow instructions from `dotnet femto yourProject.fsproj` - [Femto documentation](https://github.com/Zaid-Ajaj/Femto/)
- Don't forget to configure the npm package in your project

You are ready to start using Fulma. You can confirm it by trying to open `Fulma` namespace.

```fsharp
open Fulma
```

Fulma has a depedency on [Bulma](https://bulma.io/documentation/overview/start/) and you will need to add it through [yarn](https://yarnpkg.com/en/docs/usage) or [npm](https://docs.npmjs.com/getting-started/using-a-package.json).

Fulma support [Femto](https://github.com/Zaid-Ajaj/Femto/) so you can follow the instructions from `dotnet femto yourProject.fsproj`

## Architecture

Fulma has been designed to provide the best experience over the Bulma CSS framework.
To achieve this goal, Fulma prevents you to open lower modules of the hierarchy.

For example, if you want to use the Button element you will need to use `open Fulma` and not `open Fulma.Button`.

```fsharp
open Fulma

Button.button [ Button.Size IsSmall ]
    [ str "A button" ]
```

### React DSL

Every function follows the "React DSL":

1. Name of the element
2. List of properties
3. Children

### Special helpers

Every element provided by Fulma will have at least 3 special helpers:

- `CustomClass` allows you to add a custom class to an element

    ```fsharp
        Button.button [ Button.CustomClass "my-custom-button" ]
            [ str "I am a button" ]
    ```

    Note that only one `customClass` can be provided. If you provide several, then the last one takes precedence. If you need to apply more than one custom class, then provide it as a single string, i.e. `Button.customClass "custom1 custom2"`. See [discussion](https://github.com/MangelMaxime/Fulma/issues/111) for more information.

- `Props`:

    ```fsharp
        Button.button [ Button.Props [ OnClick (fun _ -> printfn "The button has been clicked") ] ]
            [ str "I am a button" ]
    ```

- `Modifiers`:

    ```fsharp
        Message.message [ ]
            [ Message.body [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                  [ str "Text centered" ] ]
    ```

All the compoments documented on this website, are available in the library.

### Side notes when using Ionide

*Original issue: [Ionide open the wrong Color module](https://github.com/MangelMaxime/Fulma/issues/134)*

When using Fulma with Ionide, we recommend to add these settings to your configuration:

```json
// Enables resolve unopened namespaces and modules code fix.
"FSharp.resolveNamespaces": false,
// Includes external (from unopened modules and namespaces) symbols in autocomplete. Automatically adds open statements.
"FSharp.externalAutocomplete": false,
```

We recommend these settings, otherwise Ionide can open the module `open System` when you type `Color.xxx`.

### Type conflict

*Original issue: [Combination Fulma and Fable.Import.Browser conflict](https://github.com/MangelMaxime/Fulma/issues/142)*

If you do:

```fsharp
open Fulma
open Fable.Import.Browser
```

Then `Column.Width (Screen.All, Column.Is3)` will result in an error because you are using `Fable.Import.Browser.Screen` type instead of `Fulma.Screen`.

In general, we recommend not opening `Fable.Import.Browser` but only `Fable.Import` and use `Browser.xxx` to use the Browser API.

However, if you prefer not prefixing your statement, you can simply inverse the `open` statement like:

```fsharp
open Fable.Import.Browser
open Fulma
```

        """
