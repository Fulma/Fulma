## Breaking changes in the API (>= 1.0.0-beta-006)

In this version of Fulma, we introduced a large number of breaking changes. However, it's important to note that the compiler will help you fix them.

[Click here](https://github.com/MangelMaxime/fulma-demo/commit/6245f2b0048e882e7290807aef087ac92d355b63) to see the diff resulting of updating a project [Fulma-demo](https://mangelmaxime.github.io/fulma-demo/).

### Remove the small helpers

In this version of Fulma, we removed all the small helpers and now you have direct access to the DU types.

```fsharp
// Before
Button.button_a [ Button.isOutlined ]
    [ str "Outlined" ]

// Now
Button.button [ Button.IsOutlined ]
    [ str "Outlined" ]
```

*Tips: Most of the time, this means you need to capitalize your properties*

The benefit of removing the small helpers is we now have a clear separation between the *properties* in `PascalCase` and the *render functions* in `camelCase`.

### Mutualize common properties

Common properties like colors, size are now mutualized.

```fsharp
// Before
open Fulma.Elements
Button.button_a [ Button.isSuccess
                  Button.isSmall ]
    [ str "A button" ]

// Now
open Fulma
open Fulma.Elements
Button.button [ Button.Color IsSuccess
                Button.Size IsSmall ]
    [ str "A button" ]
```

### Exposed `GenericOption` properties

By removing the small helpers, we are now exposing `GenericOption` to the user.

If a Fulma element only needs to expose `CustomClass` and `Props` we have the following change:

```fsharp
// Before
open Fulma.Elements
Modal.background [ Modal.Background.props [ OnClick (fun _ -> dispatch ToggleCardModal) ] ] [ ]

// Now
open Fulma
open Fulma.Elements

Modal.background [ Props [ OnClick (fun _ -> dispatch ToggleBasicModal) ] ] [ ]
```

### Remove `underscore` function

In previous version of Fulma, we introduce special *render functions* like `Button.button_a`, `Button.button_div`, `Field.field_div`, `Field.field_p`.

We now removed the `_` and use modules to provide a more friendly API.

```fsharp
// Before
Navbar.brand_div [ ]
            [ Navbar.item_a [ Navbar.Item.props [ Href "#" ] ]
                [ img [ Style [ Width "2.5em" ] // Force svg display
                        Src "/assets/logo_transparent.svg" ] ] ]
// Now
Navbar.Brand.div [ ]
            [ Navbar.Item.a [ Navbar.Item.Props [ Href "#" ] ]
                [ img [ Style [ Width "2.5em" ] // Force svg display
                        Src "/assets/logo_transparent.svg" ] ] ]
```

### Avoid computation list usage in user code

Before, in order to make a button conditionally loading you needed to use a computation list. We removed this need by adding a boolean to some properties.

```fsharp
// Before
Button.button [ if model.IsLoading then
                 yield Button.isLoading ]
    [ str "Loading" ]

// Now
Button.button [ Button.IsLoading model.IsLoading ]
    [ str "Loading" ]
```
