module Modifiers.Colors

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Extensions

let customColor() =
    // Define helpers to get intellisense
    let isCustomLightBlue = IsCustomColor "custom-light-blue"
    let isCustomPurple = IsCustomColor "custom-purple"
    // Demo
    Columns.columns [ ]
        [ Column.column [ ]
            [ Button.button [ Button.Color isCustomLightBlue ]
                [ str "A button with custom color" ] ]
          Column.column [ ]
            [ Field.div [ Field.IsGrouped ]
                [ yield! Checkradio.checkboxInline [ Checkradio.Color isCustomPurple
                                                     Checkradio.HasBackgroundColor ]
                        [ str "Installations" ]
                  yield! Checkradio.checkboxInline [ Checkradio.Color isCustomLightBlue
                                                     Checkradio.HasBackgroundColor ]
                        [ str "Fronts" ]
                  yield! Checkradio.checkboxInline [ ]
                        [ str "Zones fixes" ] ] ] ]

let noColor() =
    let inputColor hasError =
        if hasError then
            IsDanger
        else
            NoColor
        |> Input.Color
    // Render view
    div [ ClassName "block" ]
        [ Input.text [ inputColor true
                       Input.Value "An error has been found" ]
          br [ ]
          br [ ]
          Input.text [ inputColor false
                       Input.Value "No error found" ] ]

let backgroundAndTextColor() =
    Card.card [ ]
        [ Card.header [ ]
            [ Card.Header.title [ Card.Header.Title.Modifiers [ Modifier.BackgroundColor IsGreyLighter
                                                                Modifier.TextColor IsLink ] ]
                [ str "Component" ] ]
          Card.content [ ]
            [ Content.content [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris." ] ]
          Card.footer [ ]
            [ Card.Footer.a [ Modifiers [ Modifier.BackgroundColor IsGreyLighter
                                          Modifier.TextColor IsInfo ] ]
                [ str "Save" ]
              Card.Footer.a [ Modifiers [ Modifier.BackgroundColor IsBlackBis
                                          Modifier.TextColor IsWhiteBis ] ]
                [ str "Edit" ]
              Card.Footer.a [ Modifiers [ Modifier.BackgroundColor IsGreyLighter
                                          Modifier.TextColor IsDanger ] ]
                [ str "Delete" ] ] ]

let view =
    Render.docPage [
        Render.contentFromMarkdown
            """
# Modifiers - Colors & Shades

## Colors

Color is a modifier that can be added to elements.

*[Bulma documentation](https://bulma.io/documentation/modifiers/color-helpers/)*

<table>
    <tbody>
        <tr>
            <td>
                <span class="preview-color has-background-black"></span>
            </td>
            <td>
                <code>BackgroundColor IsBlack</code>
            </td>
            <td>
                <span class="has-text-black">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsBlack</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-dark"></span>
            </td>
            <td>
                <code>BackgroundColor IsDark</code>
            </td>
            <td>
                <span class="has-text-dark">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsDark</code>
            </td>
        </tr>
        <tr class="has-background-grey">
            <td>
                <span class="preview-color has-background-light"></span>
            </td>
            <td>
                <code>BackgroundColor IsLight</code>
            </td>
            <td>
                <span class="has-text-light">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsLight</code>
            </td>
        </tr>
        <tr class="has-background-grey">
            <td>
                <span class="preview-color has-background-white"></span>
            </td>
            <td>
                <code>BackgroundColor IsWhite</code>
            </td>
            <td>
                <span class="has-text-white">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsWhite</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-primary"></span>
            </td>
            <td>
                <code>BackgroundColor IsPrimary</code>
            </td>
            <td>
                <span class="has-text-primary">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsPrimary</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-info"></span>
            </td>
            <td>
                <code>BackgroundColor IsInfo</code>
            </td>
            <td>
                <span class="has-text-info">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsInfo</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-success"></span>
            </td>
            <td>
                <code>BackgroundColor IsSuccess</code>
            </td>
            <td>
                <span class="has-text-success">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsSuccess</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-warning"></span>
            </td>
            <td>
                <code>BackgroundColor IsWarning</code>
            </td>
            <td>
                <span class="has-text-warning">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsWarning</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-danger"></span>
            </td>
            <td>
                <code>BackgroundColor IsDanger</code>
            </td>
            <td>
                <span class="has-text-danger">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsDanger</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-link"></span>
            </td>
            <td>
                <code>BackgroundColor IsLink</code>
            </td>
            <td>
                <span class="has-text-link">I am a colored text</span>
            </td>
            <td>
                <code>TextColor IsLink</code>
            </td>
        </tr>
    </tbody>
</table>

## Shades

Shade is a modifier that can be added to elements.

*[Bulma documentation](https://bulma.io/documentation/modifiers/color-helpers/)*

<table>
    <tbody>
        <tr>
            <td>
                <span class="preview-color has-background-black-bis"></span>
            </td>
            <td>
                <code>BackgroundColor IsBlackBis</code>
            </td>
            <td>
                <span class="has-text-black-bis">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsBlackBis</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-black-ter"></span>
            </td>
            <td>
                <code>BackgroundColor IsBlackTer</code>
            </td>
            <td>
                <span class="has-text-black-ter">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsBlackTer</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-grey-darker"></span>
            </td>
            <td>
                <code>BackgroundColor IsGreyDarker</code>
            </td>
            <td>
                <span class="has-text-grey-darker">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsGreyDarker</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-grey-dark"></span>
            </td>
            <td>
                <code>BackgroundColor IsGreyDark</code>
            </td>
            <td>
                <span class="has-text-grey-dark">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsGreyDark</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-grey"></span>
            </td>
            <td>
                <code>BackgroundColor IsGrey</code>
            </td>
            <td>
                <span class="has-text-grey">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsGrey</code>
            </td>
        </tr>
        <tr>
            <td>
                <span class="preview-color has-background-grey-light"></span>
            </td>
            <td>
                <code>BackgroundColor IsGreyLight</code>
            </td>
            <td>
                <span class="has-text-grey-light">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsGreyLight</code>
            </td>
        </tr>
        <tr class="has-background-grey">
            <td>
                <span class="preview-color has-background-grey-lighter"></span>
            </td>
            <td>
                <code>BackgroundColor IsGreyLighter</code>
            </td>
            <td>
                <span class="has-text-grey-lighter">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsGreyLighter</code>
            </td>
        </tr>
        <tr class="has-background-grey-dark">
            <td>
                <span class="preview-color has-background-white-ter"></span>
            </td>
            <td>
                <code>BackgroundColor IsWhiteTer</code>
            </td>
            <td>
                <span class="has-text-white-ter">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsWhiteTer</code>
            </td>
        </tr>
        <tr class="has-background-grey-darker">
            <td>
                <span class="preview-color has-background-white-bis"></span>
            </td>
            <td>
                <code>BackgroundColor IsWhiteBis</code>
            </td>
            <td>
                <span class="has-text-white-bis">I am a shaded text</span>
            </td>
            <td>
                <code>TextColor IsWhiteBis</code>
            </td>
        </tr>
    </tbody>
</table>
            """

        Render.docSection
            """### Demo"""
            (Widgets.Showcase.view backgroundAndTextColor (Render.includeCode __LINE__ __SOURCE_FILE__))

        Render.contentFromMarkdown
            """
### Custom colors

You can add your own colors:

```css
// First include initial variables and helpers function from Bulma
@import "./../../node_modules/bulma/sass/utilities/initial-variables";
@import "./../../node_modules/bulma/sass/utilities/functions";

// Setup custom Colors
$custom-purple: #9930ca;
$custom-purple-invert: findColorInvert($custom-purple);
$custom-light-blue: #55b6ee;
$custom-light-blue-invert: findColorInvert($custom-light-blue);

// Since bulma 7.0 we have `custom-colors` and `custom-shades`
$custom-colors: (
  "custom-light-blue":($custom-light-blue, $custom-light-blue-invert),
  "custom-purple": ($custom-purple, $custom-purple-invert),
);

// Import the derived variables from Bulma
// It will use our $custom-colors
@import "./../../node_modules/bulma/sass/utilities/derived-variables";

// Import all Bulma
@import '../node_modules/bulma/bulma';
```

Benefit of using Bulma `$custom-colors` and `$custom-shades` is that even Bulma extensions will support the new colors.

In Fulma, you can get intellisense for your own colors by creating your own helpers:

```fs
// By using inline the caller will be replaced directly by the function body
let inline isCustomLightBlue<'a> = IsCustomColor "custom-light-blue"
```

Now you are ready to use your custom colors in your code:
            """

        Render.docSection
            ""
            (Widgets.Showcase.view customColor (Render.includeCode __LINE__ __SOURCE_FILE__))

        Render.docSection
            """
### No colors

The `NoColor` case is an addition of Fulma. It is useful if you want to a color based on a condition.

Example:
*If there is an error we use `IsDanger`, otherwise we use `NoColor`*

```fs
let inputColor hasError =
    if hasError then
        IsDanger
    else
        NoColor
    |> Input.Color
```

"""
            (Widgets.Showcase.view noColor (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
