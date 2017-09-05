module Elements.Icon.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Extra.FontAwesome

let iconInteractive =
    div [ ClassName "block" ]
        [ Icon.icon [ Icon.isSmall ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon [ ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon [ Icon.isMedium ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon [ Icon.isLarge ]
            [ i [ ClassName "fa fa-home" ] [ ] ] ]

let fontAwesome =
    div [ ClassName "block" ]
        [ Icon.faIcon [ Icon.isSmall ] Fa.Home
          Icon.faIcon [ ] Fa.Tags
          Icon.faIcon [ Icon.isMedium ] Fa.``500px``
          Icon.faIcon [ Icon.isLarge ] Fa.Android ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root iconInteractive model.IconViewer (IconViewerMsg >> dispatch))
                     Render.docSection
                        """
### Convenience functions

We provide convenience functions for **[Font Awesome](http://fontawesome.io/)**.

You need the next `open` statement to access the FontAwesome convenience functions.

```fsharp
    open Fulma.Elements
    open Fulma.Extra.FontAwesome
```

If the icon you want to use isn't accessible via `Fa.*` please *[open an issue here](https://github.com/MangelMaxime/Fable.Elmish.Bulma/issues)*.
You can also use `Fa.Custom "fa-my-icon"` as a fix.

```fsharp
    // If the "fa-thumbs-up" icon was missing, you could use Fa.Custom to get it:
    Icon.faIcon [ Icon.isLarge ] (Fa.Custom "fa-thumbs-up")
```
                        """
                        (Viewer.View.root fontAwesome model.ConvenienceViewer (ConvenienceViewerMsg >> dispatch)) ]
