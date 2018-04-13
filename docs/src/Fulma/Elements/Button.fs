module Elements.Button

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome

let colorInteractive () =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button [ ] [ str "Button" ]
                    Button.button [ Button.Color IsWhite ] [ str "White" ]
                    Button.button [ Button.Color IsLight ] [ str "Light" ]
                    Button.button [ Button.Color IsDark ] [ str "Dark" ]
                    Button.button [ Button.Color IsBlack ] [ str "Black" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button [ Button.IsLink ] [ str "Link" ]
                    Button.button [ Button.Color IsPrimary ] [ str "Primary" ]
                    Button.button [ Button.Color IsInfo ] [ str "Info" ]
                    Button.button [ Button.Color IsSuccess ] [ str "Success" ]
                    Button.button [ Button.Color IsWarning ] [ str "Warning" ]
                    Button.button [ Button.Color IsDanger ] [ str "Danger" ] ] ] ]

let sizeInteractive () =
    div [ ClassName "block" ]
        [ Button.button [ Button.Size IsSmall ] [ str "Small" ]
          Button.button [ ] [ str "Normal" ]
          Button.button [ Button.Size IsMedium ] [ str "Medium" ]
          Button.button [ Button.Size IsLarge ] [ str "Large" ] ]

let outlinedInteractive () =
    div [ ClassName "block" ]
        [ Button.button [ Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsSuccess; Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsPrimary; Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsInfo; Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsDanger; Button.IsOutlined ] [ str "Outlined" ] ]

let mixedStyleInteractive () =
    div [ ClassName "callout is-primary block" ]
        [ Button.button [ Button.IsInverted ] [ str "Inverted" ]
          Button.button [ Button.Color IsSuccess; Button.IsInverted ] [ str "Inverted" ]
          Button.button [ Button.Color IsDanger; Button.IsInverted; Button.IsOutlined ] [ str "Invert Outlined" ]
          Button.button [ Button.Color IsInfo; Button.IsInverted; Button.IsOutlined ] [ str "Invert Outlined" ] ]

let stateInteractive () =
    div [ ClassName "block" ]
        [ Button.button [ ] [ str "Normal" ]
          Button.button [ Button.Color IsSuccess; Button.IsHovered true ] [ str "Hover" ]
          Button.button [ Button.Color IsWarning; Button.IsFocused true ] [ str "Focus" ]
          Button.button [ Button.Color IsInfo; Button.IsActive true ] [ str "Active" ]
          Button.button [ Button.Color IsBlack; Button.IsLoading true ] [ str "Loading" ] ]

let staticView () =
    Button.button [ Button.IsStatic true ]
        [ str "Static" ]

let disabled () =
    div [ ClassName "block" ]
        [ Button.button [ Button.Disabled true
                          Button.IsLink ] [ str "Link" ]
          Button.button [ Button.Disabled true
                          Button.Color IsPrimary ] [ str "Primary" ]
          Button.button [ Button.Disabled true
                          Button.Color IsInfo ] [ str "Info" ]
          Button.button [ Button.Disabled true
                          Button.Color IsSuccess ] [ str "Success" ]
          Button.button [ Button.Disabled true
                          Button.Color IsWarning ] [ str "Warning" ]
          Button.button [ Button.Disabled true
                          Button.Color IsDanger ] [ str "Danger" ] ]

let icons () =
    div [ ClassName "block" ]
        [ Button.button [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Bold ] ]
          Button.button [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Italic ] ]
          Button.button [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Underline ] ]
          Button.button [ Button.Color IsDanger
                          Button.IsOutlined ] [ str "Danger" ] ]

let demoHelpers () =
    div [ ClassName "block" ]
        [ Button.a [ ] [ str "Anchor" ]
          Button.span [ ] [ str "Span" ]
          Button.button [ ] [ str "Button" ]
          Button.Input.reset [ Button.Props [ Value "Input `reset`" ] ]
          Button.Input.submit [ Button.Props [ Value "Input `submit`" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Buttons

The **buttons** can have different colors, sizes and states.

*[Bulma documentation](http://bulma.io/documentation/elements/button/)*
                        """
                     Render.docSection
                        """
**Important information about the helpers**

Due to popular, request Fulma allow you to choose which HTMLElement you want your button to render.

You can choose between:

- `Button.button`
- `Button.span`
- `Button.a`
- `Button.Input.reset`
- `Button.Input.submit`
                        """
                        (Widgets.Showcase.view demoHelpers (Render.getViewSource demoHelpers))
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.getViewSource colorInteractive))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.getViewSource sizeInteractive))
                     Render.docSection
                        """
### Styles
The button can be **outlined** and/or **inverted**.
                        """
                        (div [ ]
                            [ Widgets.Showcase.view outlinedInteractive (Render.getViewSource outlinedInteractive)
                              br []
                              Widgets.Showcase.view mixedStyleInteractive (Render.getViewSource mixedStyleInteractive) ])

                     Render.docSection
                        "### States"
                        (Widgets.Showcase.view stateInteractive (Render.getViewSource stateInteractive))
                     Render.docSection
                        "### Static"
                        (Widgets.Showcase.view staticView (Render.getViewSource staticView))
                     Render.docSection
                        "### Disabled"
                        (Widgets.Showcase.view disabled (Render.getViewSource disabled))
                     Render.docSection
                        """
### Font awesome icons support

For more info, about Font Awesome support see [Convenience functions](#fulma/elements/icon).
                        """
                        (Widgets.Showcase.view icons (Render.getViewSource icons)) ]
