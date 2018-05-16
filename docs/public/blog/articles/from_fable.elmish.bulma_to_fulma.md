# Migration guide from Fable.Elmish.Bulma

Fulma was first known as Fable.Elmish.Bulma, in this post I will try to explain the reason of changing the name and also how to migrate your existing code base.

## Why a new name?

After some discussions with [Alfonso Garcia-Caro](https://twitter.com/alfonsogcnunez), we agreed that Fable.Elmish.Bulma doesn't depend
on [Elmish](https://github.com/fable-elmish/elmish) but on [Fable.React](https://github.com/fable-compiler/fable-react). So we decided to rename the project to remove Elmish from it.

Thanks to [Vincent Bourdon](https://twitter.com/Evilznet)'s idea of using Fable logo we ended with **Fulma**.

<center style="width: 200px;margin: auto;">
![Fulma logo](assets/logo_transparent.svg)
</center>

## How to migrate?

In this section, you will learn how to migrate your existing code to Fulma. Don't panic, it should be easy because the compiler will help you to detect all the errors and fix them.

### Dependencies

In your `paket.dependencies` and `paket.reference` replace `Fable.Elmish.Bulma` by `Fulma`.

Run `paket.exe update` at your project root and then `dotnet restore` on your `*.fsproj` file.

### Fix namespace errors

Now, you should see a lot of errors telling you `Fable.Elmish.Bulma namespace or module is not defined`.

Replace `open Fable.Elmish.Bulma.*` with `open Fulma.*`.

These rules should work for most of the open statements, however please note `open Fable.Elmish.Bulma.Grids` should be replaced with `open Fulma.Layouts`.

#### Breaking changes

- `Nav` element has been **removed**, it is deprecated by Bulma and will be removed in the future. You should use `Navbar` element as a replacement.
- `Field.field` has been replaced with `Field.field_div` and `Field.field_p`. Use `Field.field_div` to have the same behavior as before.
- `Control.control` has been replaced with `Control.control_div` and `Control.control_p`. Use `Control.control_div` to have the same behavior as before.

### Any issues ?

If you have any issues porting your project please [open an issue](https://github.com/MangelMaxime/Fulma/issues) so we can help you and prevent other users to be alone with it :).
       """
