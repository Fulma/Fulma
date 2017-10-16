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
                  [ Button.button_div [ ] [ str "Button" ]
                    Button.button_div [ Button.isWhite ] [ str "White" ]
                    Button.button_div [ Button.isLight ] [ str "Light" ]
                    Button.button_div [ Button.isDark ] [ str "Dark" ]
                    Button.button_div [ Button.isBlack ] [ str "Black" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button_div [ Button.isLink ] [ str "Link" ]
                    Button.button_div [ Button.isPrimary ] [ str "Primary" ]
                    Button.button_div [ Button.isInfo ] [ str "Info" ]
                    Button.button_div [ Button.isSuccess ] [ str "Success" ]
                    Button.button_div [ Button.isWarning ] [ str "Warning" ]
                    Button.button_div [ Button.isDanger ] [ str "Danger" ] ] ] ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Button.button_div [ Button.isSmall ] [ str "Small" ]
          Button.button_div [ ] [ str "Normal" ]
          Button.button_div [ Button.isMedium ] [ str "Medium" ]
          Button.button_div [ Button.isLarge ] [ str "Large" ] ]

let outlinedInteractive =
    div [ ClassName "block" ]
        [ Button.button_div [ Button.isOutlined ] [ str "Outlined" ]
          Button.button_div [ Button.isSuccess; Button.isOutlined ] [ str "Outlined" ]
          Button.button_div [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
          Button.button_div [ Button.isInfo; Button.isOutlined ] [ str "Outlined" ]
          Button.button_div [ Button.isDanger;  Button.isOutlined ] [ str "Outlined" ] ]

let mixedStyleInteractive =
    div [ ClassName "callout is-primary block" ]
        [ Button.button_div [ Button.isInverted ] [ str "Inverted" ]
          Button.button_div [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
          Button.button_div [ Button.isDanger; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
          Button.button_div [ Button.isInfo; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ] ]

let stateInteractive =
    div [ ClassName "block" ]
        [ Button.button_div [ ] [ str "Normal" ]
          Button.button_div [ Button.isSuccess; Button.isHovered ] [ str "Hover" ]
          Button.button_div [ Button.isWarning; Button.isFocused ] [ str "Focus" ]
          Button.button_div [ Button.isInfo; Button.isActive ] [ str "Active" ]
          Button.button_div [ Button.isBlack; Button.isLoading ] [ str "Loading" ] ]

let extraInteractive model dispatch =
    let buttonTxt =
        if model.ClickCount = 0 then
            "Click me !"
        else
            sprintf "Clicked: %i times." model.ClickCount

    div [ ClassName "block" ]
        [ Button.button_div [ Button.onClick (fun _ -> dispatch Click) ]
                            [ str buttonTxt ]
          Button.button_div [ Button.props [ Disabled true ] ]
                            [ str "Disabled via props" ] ]

let staticView =
    Button.button_div [ Button.isStatic ]
        [ str "Static" ]

let disabled =
    div [ ClassName "block" ]
        [ Button.button_div [ Button.isDisabled
                              Button.isLink ] [ str "Link" ]
          Button.button_div [ Button.isDisabled
                              Button.isPrimary ] [ str "Primary" ]
          Button.button_div [ Button.isDisabled
                              Button.isInfo ] [ str "Info" ]
          Button.button_div [ Button.isDisabled
                              Button.isSuccess ] [ str "Success" ]
          Button.button_div [ Button.isDisabled
                              Button.isWarning ] [ str "Warning" ]
          Button.button_div [ Button.isDisabled
                              Button.isDanger ] [ str "Danger" ] ]

let icons =
    div [ ClassName "block" ]
        [ Button.button_div [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Bold ] ]
          Button.button_div [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Italic ] ]
          Button.button_div [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Underline ] ]
          Button.button_div [ Button.isDanger
                              Button.isOutlined ] [ str "Danger" ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
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
