module Fulma.Modifiers

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
            [ Card.Header.title [ Card.Header.Title.Modifiers [ BackgroundColor IsGreyLighter; TextColor IsLink ] ]
                [ str "Component" ] ]
          Card.content [ ]
            [ Content.content [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Phasellus nec iaculis mauris." ] ]
          Card.footer [ ]
            [ Card.Footer.item [ Common.GenericOption.Modifiers [ BackgroundColor IsGreyLighter; TextColor IsInfo ] ]
                [ str "Save" ]
              Card.Footer.item [ Common.GenericOption.Modifiers [ BackgroundColor IsBlackBis; TextColor IsWhiteBis ] ]
                [ str "Edit" ]
              Card.Footer.item [ Common.GenericOption.Modifiers [ BackgroundColor IsGreyLighter; TextColor IsDanger ] ]
                [ str "Delete" ] ] ]

let view =
    Render.docPage [
        Render.contentFromMarkdown
            """
# Modifiers

## Colors

Color is a modifier that can be added to elements.

*[Bulma documentation](https://bulma.io/documentation/modifiers/color-helpers/)*

| | | | |
|---|---|---|---|
| <span class="preview-color has-background-black"></span> | `BackgroundColor IsBlack` | <span class="has-text-black">I am a colored text</span> | `TextColor IsBlack` |
| <span class="preview-color has-background-dark"></span> | `BackgroundColor IsDark` | <span class="has-text-dark">I am a colored text</span> | `TextColor IsDark` |
| <span class="preview-color has-background-light"></span> | `BackgroundColor IsLight` | <span class="has-text-light">I am a colored text</span> | `TextColor IsLight` |
| <span class="preview-color has-background-white"></span> | `BackgroundColor IsWhite` | <span class="has-text-white">I am a colored text</span> | `TextColor IsWhite` |
| <span class="preview-color has-background-primary"></span> | `BackgroundColor IsPrimary` | <span class="has-text-primary">I am a colored text</span> | `TextColor IsPrimary` |
| <span class="preview-color has-background-info"></span> | `BackgroundColor IsInfo` | <span class="has-text-info">I am a colored text</span> | `TextColor IsInfo` |
| <span class="preview-color has-background-success"></span> | `BackgroundColor IsSuccess` | <span class="has-text-success">I am a colored text</span> | `TextColor IsSuccess` |
| <span class="preview-color has-background-warning"></span> | `BackgroundColor IsWarning` | <span class="has-text-warning">I am a colored text</span> | `TextColor IsWarning` |
| <span class="preview-color has-background-danger"></span> | `BackgroundColor IsDanger` | <span class="has-text-danger">I am a colored text</span> | `TextColor IsDanger` |
| <span class="preview-color has-background-link"></span> | `BackgroundColor IsLink` | <span class="has-text-link">I am a colored text</span> | `TextColor IsLink` |

## Shades

Shade is a modifier that can be added to elements.

*[Bulma documentation](https://bulma.io/documentation/modifiers/color-helpers/)*

| | | | |
|---|---|---|---|
| <span class="preview-color has-background-black-bis"></span> | `BackgroundColor IsBlackBis` | <span class="has-text-black-bis">I am a shaded text</span> | `TextColor IsBlackBis` |
| <span class="preview-color has-background-black-ter"></span> | `BackgroundColor IsBlackTer` | <span class="has-text-black-ter">I am a shaded text</span> | `TextColor IsBlackTer` |
| <span class="preview-color has-background-grey-darker"></span> | `BackgroundColor IsGreyDarker` | <span class="has-text-grey-darker">I am a shaded text</span> | `TextColor IsGreyDarker` |
| <span class="preview-color has-background-grey-dark"></span> | `BackgroundColor IsGreyDark` | <span class="has-text-grey-dark">I am a shaded text</span> | `TextColor IsGreyDark` |
| <span class="preview-color has-background-grey"></span> | `BackgroundColor IsGrey` | <span class="has-text-grey">I am a shaded text</span> | `TextColor IsGrey` |
| <span class="preview-color has-background-grey-light"></span> | `BackgroundColor IsGreyLight` | <span class="has-text-grey-light">I am a shaded text</span> | `TextColor IsGreyLight` |
| <span class="preview-color has-background-grey-lighter"></span> | `BackgroundColor IsGreyLighter` | <span class="has-text-grey-lighter">I am a shaded text</span> | `TextColor IsGreyLighter` |
| <span class="preview-color has-background-white-ter"></span> | `BackgroundColor IsWhiteTer` | <span class="has-text-white-ter">I am a shaded text</span> | `TextColor IsWhiteTer` |
| <span class="preview-color has-background-white-bis"></span> | `BackgroundColor IsWhiteBis` | <span class="has-text-white-bis">I am a shaded text</span> | `TextColor IsWhiteBis` |
            """

        Render.docSection
            """### Demo"""
            (Widgets.Showcase.view backgroundAndTextColor (Render.getViewSource backgroundAndTextColor))

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
let inline isCustomPurple<'a> = IsCustomColor "custom-purple"
```

Now you are ready to use your custom colors in your code:
            """

        Render.docSection
            ""
            (Widgets.Showcase.view customColor (Render.getViewSource customColor))

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
            (Widgets.Showcase.view noColor (Render.getViewSource noColor)) ]
