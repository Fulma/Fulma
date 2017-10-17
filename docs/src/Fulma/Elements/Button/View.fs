module Elements.Button.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Layouts
open Fulma.Extra.FontAwesome


let colorInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button_a [ ] [ str "Button" ]
                    Button.button_a [ Button.isWhite ] [ str "White" ]
                    Button.button_a [ Button.isLight ] [ str "Light" ]
                    Button.button_a [ Button.isDark ] [ str "Dark" ]
                    Button.button_a [ Button.isBlack ] [ str "Black" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button_a [ Button.isLink ] [ str "Link" ]
                    Button.button_a [ Button.isPrimary ] [ str "Primary" ]
                    Button.button_a [ Button.isInfo ] [ str "Info" ]
                    Button.button_a [ Button.isSuccess ] [ str "Success" ]
                    Button.button_a [ Button.isWarning ] [ str "Warning" ]
                    Button.button_a [ Button.isDanger ] [ str "Danger" ] ] ] ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Button.button_a [ Button.isSmall ] [ str "Small" ]
          Button.button_a [ ] [ str "Normal" ]
          Button.button_a [ Button.isMedium ] [ str "Medium" ]
          Button.button_a [ Button.isLarge ] [ str "Large" ] ]

let outlinedInteractive =
    div [ ClassName "block" ]
        [ Button.button_a [ Button.isOutlined ] [ str "Outlined" ]
          Button.button_a [ Button.isSuccess; Button.isOutlined ] [ str "Outlined" ]
          Button.button_a [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
          Button.button_a [ Button.isInfo; Button.isOutlined ] [ str "Outlined" ]
          Button.button_a [ Button.isDanger;  Button.isOutlined ] [ str "Outlined" ] ]

let mixedStyleInteractive =
    div [ ClassName "callout is-primary block" ]
        [ Button.button_a [ Button.isInverted ] [ str "Inverted" ]
          Button.button_a [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
          Button.button_a [ Button.isDanger; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
          Button.button_a [ Button.isInfo; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ] ]

let stateInteractive =
    div [ ClassName "block" ]
        [ Button.button_a [ ] [ str "Normal" ]
          Button.button_a [ Button.isSuccess; Button.isHovered ] [ str "Hover" ]
          Button.button_a [ Button.isWarning; Button.isFocused ] [ str "Focus" ]
          Button.button_a [ Button.isInfo; Button.isActive ] [ str "Active" ]
          Button.button_a [ Button.isBlack; Button.isLoading ] [ str "Loading" ] ]

let extraInteractive model dispatch =
    let buttonTxt =
        if model.ClickCount = 0 then
            "Click me !"
        else
            sprintf "Clicked: %i times." model.ClickCount

    div [ ClassName "block" ]
        [ Button.button_a [ Button.onClick (fun _ -> dispatch Click) ]
                          [ str buttonTxt ]
          Button.button_a [ Button.props [ Disabled true ] ]
                          [ str "Disabled via props" ] ]

let staticView =
    Button.button_a [ Button.isStatic ]
        [ str "Static" ]

let disabled =
    div [ ClassName "block" ]
        [ Button.button_a [ Button.isDisabled
                            Button.isLink ] [ str "Link" ]
          Button.button_a [ Button.isDisabled
                            Button.isPrimary ] [ str "Primary" ]
          Button.button_a [ Button.isDisabled
                            Button.isInfo ] [ str "Info" ]
          Button.button_a [ Button.isDisabled
                            Button.isSuccess ] [ str "Success" ]
          Button.button_a [ Button.isDisabled
                            Button.isWarning ] [ str "Warning" ]
          Button.button_a [ Button.isDisabled
                            Button.isDanger ] [ str "Danger" ] ]

let icons =
    div [ ClassName "block" ]
        [ Button.button_a [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Bold ] ]
          Button.button_a [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Italic ] ]
          Button.button_a [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Underline ] ]
          Button.button_a [ Button.isDanger
                            Button.isOutlined ] [ str "Danger" ] ]

let demoHelpers =
    div [ ClassName "block" ]
        [ Button.button_a [ ]
            [ str "I am an anchor button"]
          Button.button_btn [ ]
            [ str "I am a form button"]
          Button.button_input [ Button.value "I am an input button"
                                Button.typeIsReset ] ]


let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        """
**Important information about the helpers**

In order to match the same features as Bulma, Fulma provide you three ways to create a button:

1. `Button.button_a`, produce a button with an **anchor** element as root: `<a class="button"></a>`
2. `Button.button_btn`, produce a button with a **button** element as root: `<button class="button"></button>`
3. `Button.button_input`, produce a button with an **input** element as root: `<input class="button"/>`

In order to make Fulma more friendly, depending on the choosen function, you can access custom helpers.

For `Button.button_a`:

- `Button.href "a string here"`

For `Button.button_input`:

- `Button.typeIsSubmit`
- `Button.typeIsReset`
- `Button.value "a string here"`

It's important to note, that the compiler will prevent you to use incorrect helpers on incorrect function. For example, you can't use `Button.href` on a `Button.button_btn` function.
                        """
                        (Viewer.View.root demoHelpers model.DemoHelpersViewer (DemoHelpersViewerMsg >> dispatch))
                     Render.docSection
                        "### Colors"
                        (Viewer.View.root colorInteractive model.ColorViewer (ColorViewerMsg >> dispatch))
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root sizeInteractive model.SizeViewer (SizeViewerMsg >> dispatch))
                     Render.docSection
                        """
### Styles
The button can be **outlined** and/or **inverted**.
                        """
                        (div [ ]
                            [ Viewer.View.root outlinedInteractive model.OutlinedViewer (OutlinedViewerMsg >> dispatch)
                              br []
                              Viewer.View.root mixedStyleInteractive model.MixedStyleViewer (MixedStyleViewerMsg >> dispatch) ])
                     Render.docSection
                        "### States"
                        (Viewer.View.root stateInteractive model.StateViewer (StateViewerMsg >> dispatch))
                     Render.docSection
                        "### Extra"
                        (Viewer.View.root (extraInteractive model dispatch) model.ExtraViewer (ExtraViewerMsg >> dispatch))
                     Render.docSection
                        "### Static"
                        (Viewer.View.root staticView model.StaticViewer (StaticViewerMsg >> dispatch))
                     Render.docSection
                        "### Disabled"
                        (Viewer.View.root disabled model.DisabledViewer (DisabledViewerMsg >> dispatch))
                     Render.docSection
                        """
### Font awesome icons support

For more info, about Font Awesome support see [Convenience functions](#fulma/elements/icon).
                        """
                        (Viewer.View.root icons model.IconsViewer (IconsViewerMsg >> dispatch))
                               ]
