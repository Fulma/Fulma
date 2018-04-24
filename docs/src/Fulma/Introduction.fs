module Fulma.Introduction

let view =
    Render.contentFromMarkdown
        """
# Fulma

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>
Provide a wrapper around [Bulma 0.6.2](http://bulma.io/) for [fable-react](https://github.com/fable-compiler/fable-react).

This website isn't intended into providing a full documentation of Bulma.

It's only serve as a documentation of the wrapper and also test that the wrappers are working as this website is build with Fulma itself.

---

## Getting started

There are two ways to get started with Fulma:

1. You can use the [Fulma-Minimal template](#template)
2. You can install it manually

### How to install manually?

Add `Fulma` dependency in your [Paket](https://fsprojects.github.io/Paket/) files: `paket add Fulma --project <your project>`

Then `dotnet restore` on your `*.fsproj` file.

You are ready to start using Fulma. You can confirm it by trying to open `Fulma` namespace.

```fsharp
open Fulma
```

Fulma has a depedency on [Bulma](https://bulma.io/documentation/overview/start/) and you will need to add it through [yarn](https://yarnpkg.com/en/docs/usage) or [npm](https://docs.npmjs.com/getting-started/using-a-package.json).

## Architecture

Fulma has been designed to provide the best experience over the Bulma CSS framework.
To achieve this goal, Fulma prevents you to open lower module of the hierarchy.

For example, if you want to use the Button element you will need to use `open Fulma` and not `open Fulma.Button`.

```fsharp
open Fulma

Button.button_a [ Button.isSmall ]
    [ str "A button" ]
```

### React DSL

Every function follow the "React DSL":

1. Name of the element
2. List of properties
3. Children

### Special helpers

Every element providing by Fulma will have at least 2 specials helpers:

- `customClass` allow you to add a custom class to an element

    ```fsharp
        Button.button_a [ Button.customClass "my-custom-button" ]
            [ str "I am a button" ]
    ```

    Note, that only one `customClass` can be provided. If you provide several, then the last got precedence. If you need apply more than one custom class, then provide it as a single string, i.e. `Button.customClass "custom1 custom2"`. See [discussion](https://github.com/MangelMaxime/Fulma/issues/111) for more information.

- `props`:

    ```fsharp
        Button.button_a [ Button.props [ OnClick (fun _ -> printfn "The button has been clicked") ] ]
            [ str "I am a button" ]
    ```

### BulmaClasses

*It's **important** to note that `BulmaClasses.fs` will be refactored before 1.0 release. It should not have much impact on your code, as you will rarely use this file in your application.*

Fulma do not only provide wrappers around Bulma but also intellisense for the classes provided.

For example, here is how to access the "is-hidden" class.

```fsharp

open Fulma.BulmaClasses

Bulma.Properties.Visibility.IsHidden

```

All the compoments documented on this website, are available in the library.

        """
