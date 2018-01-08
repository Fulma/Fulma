module Elements.Button.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Elements
open Fulma.Layouts
open Fulma.Extra.FontAwesome


let colorInteractive =
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

let sizeInteractive =
    div [ ClassName "block" ]
        [ Button.button [ Button.Size IsSmall ] [ str "Small" ]
          Button.button [ ] [ str "Normal" ]
          Button.button [ Button.Size IsMedium ] [ str "Medium" ]
          Button.button [ Button.Size IsLarge ] [ str "Large" ] ]

let outlinedInteractive =
    div [ ClassName "block" ]
        [ Button.button [ Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsSuccess; Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsPrimary; Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsInfo; Button.IsOutlined ] [ str "Outlined" ]
          Button.button [ Button.Color IsDanger; Button.IsOutlined ] [ str "Outlined" ] ]

let mixedStyleInteractive =
    div [ ClassName "callout is-primary block" ]
        [ Button.button [ Button.IsInverted ] [ str "Inverted" ]
          Button.button [ Button.Color IsSuccess; Button.IsInverted ] [ str "Inverted" ]
          Button.button [ Button.Color IsDanger; Button.IsInverted; Button.IsOutlined ] [ str "Invert Outlined" ]
          Button.button [ Button.Color IsInfo; Button.IsInverted; Button.IsOutlined ] [ str "Invert Outlined" ] ]

let stateInteractive =
    div [ ClassName "block" ]
        [ Button.button [ ] [ str "Normal" ]
          Button.button [ Button.Color IsSuccess; Button.IsHovered ] [ str "Hover" ]
          Button.button [ Button.Color IsWarning; Button.IsFocused ] [ str "Focus" ]
          Button.button [ Button.Color IsInfo; Button.IsActive true ] [ str "Active" ]
          Button.button [ Button.Color IsBlack; Button.IsLoading true ] [ str "Loading" ] ]

let extraInteractive model dispatch =
    let buttonTxt =
        if model.ClickCount = 0 then
            "Click me !"
        else
            "Clicked: " + string model.ClickCount + "times."

    div [ ClassName "block" ]
        [ Button.button [ Button.OnClick (fun _ -> dispatch Click) ]
                        [ str buttonTxt ] ]

let staticView =
    Button.button [ Button.IsStatic ]
        [ str "Static" ]

let disabled =
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

let icons =
    div [ ClassName "block" ]
        [ Button.button [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Bold ] ]
          Button.button [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Italic ] ]
          Button.button [ ] [ Icon.faIcon [ ] [ Fa.icon Fa.I.Underline ] ]
          Button.button [ Button.Color IsDanger
                          Button.IsOutlined ] [ str "Danger" ] ]


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
