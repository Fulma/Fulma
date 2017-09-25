module Fulma.Introduction.View

open Fable.Core

let root _ =
    Render.contentFromMarkdown
        """
# Fulma

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>
Provide a wrapper around [Bulma 0.5.2](http://bulma.io/versions/0.5.2/) for [fable-react](https://github.com/fable-compiler/fable-react).

This website isn't intended into providing a full documentation of Bulma.

It's only serve as a documentation of the wrapper and also test that the wrappers are working as this website is build with Fulma itself.

---

## How to install ?

Add `Fulma` dependence into your paket files: `paket add Fulma --project <your project>`

Then `dotnet restore` on your `*.fsproj` file.

You are ready to start using Fulma. You can confirm it by trying to open `Fulma` namespace.

```fsharp
open Fulma
```

## Architecture

Fulma has been designed to provide the best experience over the Bulma CSS framework.
To archieve this goal, we assume the user to follow some conventions.

Always open the "global" module and not the lower module of the hierarchie. For example, if you want to use the Button element you should follow this code:

```fsharp
open Fulma.Elements

Button.button [ Button.isSmall ]
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
        Button.button [ Button.customClass "my-custom-button" ]
            [ str "I am a button" ]
    ```
- `props`:

    ```fsharp
        Button.button [ Button.props [ OnClick (fun _ -> printfn "The button has been clicked") ] ]
            [ str "I am a button" ]
    ```

### BulmaClasses

*It's **important** to note that `BulmaClasses.fs` will be refactored before 1.0 release. It should not make much impact in your code has you will rarely use this file in your application.*

Fulma do not only provide wrappers around Bulma but also intellisense for the classes provided.

For example, here is how to access the "is-hidden" class.

```fsharp

open Fulma.BulmaClasses

Bulma.Properties.Visibility.IsHidden

```

All the compoments documented into this website, are availables into the library.

        """
