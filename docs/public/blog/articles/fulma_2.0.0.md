## Breaking changes

### Fable.FontAwesome

We are removing Font Awesome from Fulma package. So now, you will need to use [Fable.FontAwesome](#fable-fontawesome).

<span class="is-size-5 has-text-info">
<i class="fas fa-exclamation-circle"></i>
Important
</span>

`Fable.FontAwesome` supports **Font Awesome 5**, while `Fulma.Extra.FontAwesome` was supporting **4.7.0**.

In this version of Fulma, we removed all the small helpers and now you have direct access to the DU types.

### Fulma.Extensions is now obselete

Fulma.Extensions has been splitted in different package. **One** package **per** extension.

For example,

- `Checkradio` is now inside `Fulma.Extensions.Wikiki.Checkradio`
- `Switch` is now inside `Fulma.Extensions.Wikiki.Switch`
- etc.

We are doing this split so we can update more easily the package and specify which version of the npm package goes with which nuget version.
