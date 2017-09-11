module Elements.Button.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Layouts


let colorInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button [ ] [ str "Button" ]
                    Button.button [ Button.isWhite ] [ str "White" ]
                    Button.button [ Button.isLight ] [ str "Light" ]
                    Button.button [ Button.isDark ] [ str "Dark" ]
                    Button.button [ Button.isBlack ] [ str "Black" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Button.button [ Button.isLink ] [ str "Link" ]
                    Button.button [ Button.isPrimary ] [ str "Primary" ]
                    Button.button [ Button.isInfo ] [ str "Info" ]
                    Button.button [ Button.isSuccess ] [ str "Success" ]
                    Button.button [ Button.isWarning ] [ str "Warning" ]
                    Button.button [ Button.isDanger ] [ str "Danger" ] ] ] ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Button.button [ Button.isSmall ] [ str "Small" ]
          Button.button [ ] [ str "Normal" ]
          Button.button [ Button.isMedium ] [ str "Medium" ]
          Button.button [ Button.isLarge ] [ str "Large" ] ]

let outlinedInteractive =
    div [ ClassName "block" ]
        [ Button.button [ Button.isOutlined ] [ str "Outlined" ]
          Button.button [ Button.isSuccess; Button.isOutlined ] [ str "Outlined" ]
          Button.button [ Button.isPrimary; Button.isOutlined ] [ str "Outlined" ]
          Button.button [ Button.isInfo; Button.isOutlined ] [ str "Outlined" ]
          Button.button [ Button.isDanger;  Button.isOutlined ] [ str "Outlined" ] ]

let mixedStyleInteractive =
    div [ ClassName "callout is-primary block" ]
        [ Button.button [ Button.isInverted ] [ str "Inverted" ]
          Button.button [ Button.isSuccess; Button.isInverted ] [ str "Inverted" ]
          Button.button [ Button.isDanger; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ]
          Button.button [ Button.isInfo; Button.isInverted; Button.isOutlined ] [ str "Invert Outlined" ] ]

let stateInteractive =
    div [ ClassName "block" ]
        [ Button.button [ ] [ str "Normal" ]
          Button.button [ Button.isSuccess; Button.isHovered ] [ str "Hover" ]
          Button.button [ Button.isWarning; Button.isFocused ] [ str "Focus" ]
          Button.button [ Button.isInfo; Button.isActive ] [ str "Active" ]
          Button.button [ Button.isBlack; Button.isLoading ] [ str "Loading" ] ]

let extraInteractive model dispatch =
    let buttonTxt =
        if model.ClickCount = 0 then
            "Click me !"
        else
            sprintf "Clicked: %i times." model.ClickCount

    div [ ClassName "block" ]
        [ Button.button [ Button.onClick (fun _ -> dispatch Click) ]
                        [ str buttonTxt ]
          Button.button [ Button.props [ Disabled true ] ]
                        [ str "Disabled via props" ] ]

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
                               ]
