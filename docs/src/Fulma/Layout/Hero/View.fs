module Layouts.Hero.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Layouts
open Fulma.Elements.Form
open Fulma.Elements
open Fulma.Components
open Fulma.BulmaClasses

let iconInteractive =
    Hero.hero [ ]
        [ Hero.body [ ]
            [ Container.container [ Container.isFluid ]
                [ Heading.h1 [ ]
                    [ str "Header" ]
                  Heading.h2 [ Heading.isSubtitle ]
                    [ str "Subtitle" ] ] ] ]

let centered =
    Hero.hero [ Hero.isSuccess
                Hero.isMedium ]
        [ Hero.head [ ]
            [ Tabs.tabs [ Tabs.isBoxed
                          Tabs.isCentered ]
                [ Tabs.tab [ Tabs.Tab.isActive ]
                    [ a [ ] [ str "Fable" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Elmish" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Bulma" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Hink" ] ] ] ]
          Hero.body [ ]
            [ Container.container [ Container.isFluid
                                    Container.customClass Bulma.Properties.Alignment.HasTextCentered ]
                [ Heading.h1 [ ]
                    [ str "Header" ]
                  Heading.h2 [ Heading.isSubtitle ]
                    [ str "Subtitle" ] ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.BoxViewer (BoxViewerMsg >> dispatch))
                     Render.docSection
                        ""
                        (Viewer.View.root centered model.CenteredViewer (CenteredViewerMsg >> dispatch))
                     Render.contentFromMarkdown
                        """
### Properties

Colors:

- `Hero.isBlack`
- `Hero.isDark`
- `Hero.isLight`
- `Hero.isWhite`
- `Hero.isPrimary`
- `Hero.isInfo`
- `Hero.isSuccess`
- `Hero.isWarning`
- `Hero.isDanger`

Sizes:

- `Hero.isMedium`
- `Hero.isLarge`
- `Hero.isHalfHeight`
- `Hero.isFullHeight`

Styles:

- `Hero.isBold`
                        """
                        ]
