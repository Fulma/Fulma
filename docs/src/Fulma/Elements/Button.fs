module Elements.Button

open Fable.React
open Fable.React.Props
open Fulma
open Fable.FontAwesome

let colorInteractive () =
    div [ ]
        [
            div [ ClassName "block" ]
                [ Button.button [ ]
                    [ str "Button" ]
                  Button.button [ Button.Color IsWhite ]
                    [ str "White" ]
                  Button.button [ Button.Color IsLight ]
                    [ str "Light" ]
                  Button.button [ Button.Color IsDark ]
                    [ str "Dark" ]
                  Button.button [ Button.Color IsBlack ]
                    [ str "Black" ] ]
            div [ ClassName "block" ]
                [ Button.button [ Button.IsLink ]
                    [ str "Link" ]
                  Button.button [ Button.Color IsPrimary ]
                    [ str "Primary" ]
                  Button.button [ Button.Color IsInfo ]
                    [ str "Info" ]
                  Button.button [ Button.Color IsSuccess ]
                    [ str "Success" ]
                  Button.button [ Button.Color IsWarning ]
                    [ str "Warning" ]
                  Button.button [ Button.Color IsDanger ]
                    [ str "Danger" ] ]
            div [ ClassName "block" ]
                [ Button.button [ Button.IsLink; Button.IsLight ]
                    [ str "Link" ]
                  Button.button [ Button.Color IsPrimary; Button.IsLight ]
                    [ str "Primary" ]
                  Button.button [ Button.Color IsInfo; Button.IsLight ]
                    [ str "Info" ]
                  Button.button [ Button.Color IsSuccess; Button.IsLight ]
                    [ str "Success" ]
                  Button.button [ Button.Color IsWarning; Button.IsLight ]
                    [ str "Warning" ]
                  Button.button [ Button.Color IsDanger; Button.IsLight ]
                    [ str "Danger" ] ]
        ]


let sizeInteractive () =
    div [ ClassName "block" ]
        [ Button.button [ Button.Size IsSmall ]
            [ str "Small" ]
          Button.button [ ]
            [ str "Normal" ]
          Button.button [ Button.Size IsMedium ]
            [ str "Medium" ]
          Button.button [ Button.Size IsLarge ]
            [ str "Large" ] ]

let outlinedInteractive () =
    div [ ClassName "block" ]
        [ Button.button [ Button.IsOutlined ]
            [ str "Outlined" ]
          Button.button [ Button.Color IsSuccess; Button.IsOutlined ]
            [ str "Outlined" ]
          Button.button [ Button.Color IsPrimary; Button.IsOutlined ]
            [ str "Outlined" ]
          Button.button [ Button.Color IsInfo; Button.IsOutlined ]
            [ str "Outlined" ]
          Button.button [ Button.Color IsDanger; Button.IsOutlined ]
            [ str "Outlined" ] ]

let mixedStyleInteractive () =
    div [ ClassName "callout is-primary block" ]
        [ Button.button [ Button.IsInverted ]
            [ str "Inverted" ]
          Button.button [ Button.Color IsSuccess; Button.IsInverted ]
            [ str "Inverted" ]
          Button.button [ Button.Color IsDanger; Button.IsInverted; Button.IsOutlined ]
            [ str "Invert Outlined" ]
          Button.button [ Button.Color IsInfo; Button.IsInverted; Button.IsOutlined ]
            [ str "Invert Outlined" ] ]

let stateInteractive () =
    div [ ClassName "block" ]
        [ Button.button [ ]
            [ str "Normal" ]
          Button.button [ Button.Color IsSuccess; Button.IsHovered true ]
            [ str "Hover" ]
          Button.button [ Button.Color IsWarning; Button.IsFocused true ]
            [ str "Focus" ]
          Button.button [ Button.Color IsInfo; Button.IsActive true ]
            [ str "Active" ]
          Button.button [ Button.Color IsBlack; Button.IsLoading true ]
            [ str "Loading" ] ]

let staticView () =
    Button.button [ Button.IsStatic true ]
        [ str "Static" ]

let disabled () =
    div [ ClassName "block" ]
        [ Button.button [ Button.Disabled true
                          Button.IsLink ]
                        [ str "Link" ]
          Button.button [ Button.Disabled true
                          Button.Color IsPrimary ]
                        [ str "Primary" ]
          Button.button [ Button.Disabled true
                          Button.Color IsInfo ]
                        [ str "Info" ]
          Button.button [ Button.Disabled true
                          Button.Color IsSuccess ]
                        [ str "Success" ]
          Button.button [ Button.Disabled true
                          Button.Color IsWarning ]
                        [ str "Warning" ]
          Button.button [ Button.Disabled true
                          Button.Color IsDanger ]
                        [ str "Danger" ] ]

let icons () =
    div [ ClassName "block" ]
        [ Button.button [ ]
            [ Icon.icon [ ]
                [ Fa.i [ Fa.Solid.Bold ]
                    [ ] ] ]
          Button.button [ ]
            [ Icon.icon [ ]
                [ Fa.i [ Fa.Solid.Italic ]
                    [ ] ] ]
          Button.button [ ]
            [ Icon.icon [ ]
                [ Fa.i [ Fa.Solid.Underline ]
                    [ ] ] ]
          Button.button [ Button.Color IsDanger
                          Button.IsOutlined ]
            [ Icon.icon [ ]
                [ Fa.i [ Fa.Solid.ExclamationTriangle ] [ ] ]
              span [] [ str "Danger" ] ] ]

let demoHelpers () =
    div [ ClassName "block" ]
        [ Button.a [ ]
            [ str "Anchor" ]
          Button.span [ ]
            [ str "Span" ]
          Button.button [ ]
            [ str "Button" ]
          Button.Input.reset [ Button.Props
            [ Value "Input `reset`" ] ]
          Button.Input.submit [ Button.Props
            [ Value "Input `submit`" ] ] ]



let demoList () =
    div [ ClassName "block" ]
        [ Button.list [ ]
            [ Button.span [ ]
                [ str "One" ]
              Button.span [ ]
                [ str "Two" ]
              Button.span [ ]
                [ str "Three" ]
              Button.span [ ]
                [ str "Four" ]
              Button.span [ ]
                [ str "Five" ]
              Button.span [ ]
                [ str "Six" ]
              Button.span [ ]
                [ str "Seven" ]
              Button.span [ ]
                [ str "Eight" ]
              Button.span [ ]
                [ str "Nine" ]
              Button.span [ ]
                [ str "Ten" ]
              Button.span [ ]
                [ str "Eleven" ]
              Button.span [ ]
                [ str "Twelve" ]
              Button.span [ ]
                [ str "Thirteen" ]
              Button.span [ ]
                [ str "Fourteen" ]
              Button.span [ ]
                [ str "Fifteen" ]
              Button.span [ ]
                [ str "Sixteen" ]
              Button.span [ ]
                [ str "Seventeen" ]
              Button.span [ ]
                [ str "Eighteen" ]
              Button.span [ ]
                [ str "Nineteen" ]
              Button.span [ ]
                [ str "Twenty" ] ] ]

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
                        (Widgets.Showcase.view demoHelpers (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Styles
The button can be **outlined** and/or **inverted**.
                        """
                        (div [ ]
                            [ Widgets.Showcase.view outlinedInteractive ((Render.includeCode __LINE__ __SOURCE_FILE__))
                              br []
                              Widgets.Showcase.view mixedStyleInteractive ((Render.includeCode __LINE__ __SOURCE_FILE__)) ])

                     Render.docSection
                        "### States"
                        (Widgets.Showcase.view stateInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Static"
                        (Widgets.Showcase.view staticView (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Disabled"
                        (Widgets.Showcase.view disabled (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### List of buttons
                        """
                        (Widgets.Showcase.view demoList (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        """
### Font awesome icons support

For more info, about Font Awesome support see [Convenience functions](#fulma/elements/icon).
                        """
                        (Widgets.Showcase.view icons (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
