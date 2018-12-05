## Breaking changes

### Fable.FontAwesome

We are removing Font Awesome from Fulma package. So now, you will need to use [Fable.FontAwesome](#fable-fontawesome).

<span class="is-size-5 has-text-info">
<i class="fas fa-exclamation-circle"></i>
Important
</span>

`Fable.FontAwesome` supports **Font Awesome 5**, while `Fulma.FontAwesome` was supporting **4.7.0**.

In this version of Fulma, we removed all the small helpers and now you have direct access to the DU types.

------------

#### Migrate your code:

1. Rename all `open Fulma.FontAwesome` to `open Fable.FontAwesome`
2. Adapt your code:

```fsharp
// Old code
Icon.faIcon [ ]
    [ Fa.icon Fa.I.Play ] ]

// New code
Icon.icon [  ]
    [ Fa.i [ Fa.Solid.Book ]
        [ ] ]

// ------------

// Old code
Icon.faIcon [ Icon.Size IsMedium ]
    [ Fa.icon Fa.I.FileTextO
      Fa.faLg ]

// New code
Icon.icon [ Icon.Size IsMedium ]
    [ Fa.i [ Fa.Regular.FileAlt
             Fa.Size Fa.FaLarge ]
        [ ] ]
```


### Fulma.Extensions is now obselete

Fulma.Extensions has been splitted in different package. **One** package **per** extension.

For example,

- `Checkradio` is now inside `Fulma.Extensions.Wikiki.Checkradio`
- `Switch` is now inside `Fulma.Extensions.Wikiki.Switch`
- etc.

*[Wikiki](https://www.npmjs.com/~wikiki) is the author of the npm packages*

We are doing this split so we can update more easily the package and specify which version of the npm package goes with which nuget version.

------------

#### Migrate your code:

Rename `open Fulma.Extensions` to `open Fulma.Extensions.Wikiki`

------------

For `Checkradio` and `Switch`, if you were using their inline version, they now return a `React.ReactElement` instead of `React.ReactElement list`.

```fsharp
// Old code
div [ FragmentProp.Key key ]
    (Checkradio.checkboxInline [ Checkradio.Color IsBlack
                                 Checkradio.Checked isChecked ]
        [ str text ])

// New code
div [ FragmentProp.Key key ]
    [ Checkradio.checkboxInline [ Checkradio.Color IsBlack
                                 Checkradio.Checked isChecked ]
        [ str text ] ]
```
