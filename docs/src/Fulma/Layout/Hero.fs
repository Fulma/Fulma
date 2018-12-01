module Layouts.Hero

open Fable.Helpers.React
open Fulma

let iconInteractive () =
    Hero.hero [ ]
        [ Hero.body [ ]
            [ Container.container [ Container.IsFluid ]
                [ Heading.h1 [ ]
                    [ str "Header" ]
                  Heading.h2 [ Heading.IsSubtitle ]
                    [ str "Subtitle" ] ] ] ]

let centered () =
    Hero.hero [ Hero.Color IsSuccess
                Hero.IsMedium ]
        [ Hero.head [ ]
            [ Tabs.tabs [ Tabs.IsBoxed
                          Tabs.IsCentered ]
                [ Tabs.tab [ Tabs.Tab.IsActive true ]
                    [ a [ ] [ str "Fable" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Elmish" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Bulma" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Hink" ] ] ] ]
          Hero.body [ ]
            [ Container.container [ Container.IsFluid
                                    Container.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
                [ Heading.h1 [ ]
                    [ str "Header" ]
                  Heading.h2 [ Heading.IsSubtitle ]
                    [ str "Subtitle" ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Hero

*[Bulma documentation](http://bulma.io/documentation/layout/hero/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view iconInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        ""
                        (Widgets.Showcase.view centered (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.contentFromMarkdown
                        """
### Properties

Colors:

- `Hero.Color IsBlack`
- `Hero.Color IsDark`
- `Hero.Color IsLight`
- `Hero.Color IsWhite`
- `Hero.Color IsPrimary`
- `Hero.Color IsInfo`
- `Hero.Color IsSuccess`
- `Hero.Color IsWarning`
- `Hero.Color IsDanger`

Sizes:

- `Hero.Size IsMedium`
- `Hero.Size IsLarge`
- `Hero.Size IsHalfHeight`
- `Hero.Size IsFullHeight`

Styles:

- `Hero.IsBold`
                        """
                        ]
