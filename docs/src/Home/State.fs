module Home.State

open Elmish
open Types

let init() : Model =
    { Intro =
        """
# Fable.React.Bulma

Provide a wrapper around [Bulma](http://bulma.io/) for [fable-react](https://github.com/fable-compiler/fable-react).

This website isn't intended into providing a full documentation of Bulma.

It's only serve as a documentation of the wrapper and also test that the wrappers are working as this website is build with Fable.React.Bulma itself.

---

## How to install ?

Add `Fable.React.Bulma` dependence into your paket files.

```
// paket.denpendencies
nuget Fable.React.Bulma

// paket.reference
Fable.React.Bulma
```

Run `paket.exe update` at your project root and then `dotnet restore` on your `*.fsproj` file.

You are ready to start using Fable.React.Bulma. You can confirm it by trying to open `Fable.React.Bulma` namespace.

```fsharp
open Fable.React.Bulma
```

## Architecture

Fable.React.Bulma has been designed to provide the best experience over the Bulma CSS framework.
To archieve this goal, we assume the user to follow some conventions.

Always open the "global" module and not the lower module of the hierachie. For example, if you want to use the Button element you should follow this code:

```fsharp
open Fable.React.Bulma.Elements

Button.button [ Button.isSmall ]
    [ str "A button" ]
```

Every function follow the "React DSL":

1. Name of the element
2. List of properties
3. Children

Fable.React.Bulma do not only provide wrappers around Bulma but also intellisense for the classes provided.

For example, here is how to access the "is-hidden" class.

```fsharp

open Fable.React.Bulma.BulmaClasses

Bulma.Properties.Visibility.IsHidden

```

All the compoments documented into this website, are availables into the library.

   """}

let update msg model : Model =
    model
