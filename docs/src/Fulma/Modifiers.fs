module Fulma.Modifiers

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Extensions

let inline isFrontsPoly<'a> = IsCustomColor "poly-fronts"
let inline isInstallationsPoly<'a> = IsCustomColor "poly-installations"
let customColor() =
    Field.div [ Field.IsGrouped ]
        [ yield! Checkradio.checkboxInline [ Checkradio.Color isInstallationsPoly
                                             Checkradio.HasBackgroundColor ]
                [ str "Installations" ]
          yield! Checkradio.checkboxInline [ Checkradio.Color isFrontsPoly
                                             Checkradio.HasBackgroundColor ]
                [ str "Fronts" ]
          yield! Checkradio.checkboxInline [ ]
                [ str "Zones fixes" ] ]

let textSize() =
    div [ ClassName "block" ]
        [ Content.content [ Content.Size IsSmall ] [ str "Small" ]
          Content.content [ ] [ str "Normal" ]
          Content.content [ Content.Size IsMedium ] [ str "Medium" ]
          Content.content [ Content.Size IsLarge ] [ str "Large" ] ]

let view =
    Render.docPage [
        Render.contentFromMarkdown
            """
# Modifiers

Fulma currently provide modifier support for `Colors` and `Sizes`.

## Colors

Color is a modifier that can be added to elements.

### Supported colors

Current colors are supported: `white`, `black`, `light`, `dark`, `primary`, `info`, `success`, `warning`, `danger`.

Following elements support the color modifier:
* [Button](#fulma/elements/button),
* [Notification](#fulma/elements/notification),
* [Progress](#fulma/elements/progress),
* [Tag](#fulma/elements/tag).

### Custom colors

You can add your own colors

```css
@import "./../../node_modules/bulma/sass/utilities/initial-variables";
@import "./../../node_modules/bulma/sass/utilities/functions";

// Setup custom Colors
$poly-installations: #9930ca;
$poly-installations-invert: findColorInvert($poly-installations);
$poly-fronts: #55b6ee;
$poly-fronts-invert: findColorInvert($poly-fronts);

// Add new color variables to the color map.
@import "./../../node_modules/bulma/sass/utilities/derived-variables";
$addColors: (
  "poly-fronts":($poly-fronts, $poly-fronts-invert),
  "poly-installations": ($poly-installations, $poly-installations-invert),
);
$colors: map-merge($colors, $addColors);
```

Now you are ready to use your custom colors in your code:

        """
        Render.docSection
            "### Customer Colors"
            (Widgets.Showcase.view customColor (Render.getViewSource customColor))
        Render.docSection
            """
### No colors


## Sizes

Size is a modifier that you can add to your layout, elements or components.
Current sizes are supported: `small`, `medium` and `large`.


            """
            (Widgets.Showcase.view textSize (Render.getViewSource textSize))]
