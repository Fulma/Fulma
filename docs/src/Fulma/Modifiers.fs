module Fulma.Modifiers

let view =
    Render.contentFromMarkdown
        """
# Modifiers

Fulma currently provide modifier support for `Colors` and `Sizes`.

## Colors


### Supported colors

Current colors are supported: `white`, `black`, `light`, `dark`, `primary`, `info`, `success`, `warning`, `danger`.

Follow elements can have color attribute:
* [Button](#fulma/elements/button),
* [Notification](#fulma/elements/notification),
* [Progress](#fulma/elements/progress),
* [Tag](#fulma/elements/tag)

### Custom colors

```fsharp
let inline isFrontsPoly<'a> = IsCustomColor "poly-fronts"
let inline isInstallationsPoly<'a> = IsCustomColor "poly-installations"

let private viewFilters =
    Field.div [ Field.IsGrouped ]
        [ yield! Checkradio.checkboxInline [ Checkradio.Color isInstallationsPoly
                                             Checkradio.HasBackgroundColor ]
                [ str "Installations" ]
          yield! Checkradio.checkboxInline [ Checkradio.Color isFrontsPoly
                                             Checkradio.HasBackgroundColor ]
                [ str "Fronts" ]
          yield! Checkradio.checkboxInline [ ]
                [ str "Zones fixes" ] ]
```

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

### No colors


## Sizes

TODO: Text about supported sizes


        """
