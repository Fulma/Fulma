module FulmaExtensions.Checkradio.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Layouts
open Fulma.Extensions
open Fulma.Extra.FontAwesome

let inlineBlockInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ b [] [str "Block"]
                    Checkradio.checkbox [ ] [ str "One" ]
                    Checkradio.checkbox [ ] [ str "Two" ]

                    b [] [str "Inline"]
                    Field.field_div [ ]
                        [ yield! Checkradio.checkboxInline [ ] [ str "One " ]
                          yield! Checkradio.checkboxInline [ ] [ str "Two " ] ] ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ b [] [str "Block"]
                    Checkradio.radio [ Checkradio.name "block" ] [ str "One" ]
                    Checkradio.radio [ Checkradio.name "block"  ] [ str "Two" ]

                    b [] [str "Inline"]
                    Field.field_div [ ]
                        [ yield! Checkradio.radioInline [ Checkradio.name "inline" ] [ str "One" ]
                          yield! Checkradio.radioInline [ Checkradio.name "inline" ] [ str "Two " ] ] ] ] ]

let rtl =
    Columns.columns [ ]
        [ Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.isRtl ] [ str "Label is on the left" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.isRtl ] [ str "Label is on the left" ] ] ]

let colorInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.isChecked true ] [ str "Checkbox" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isWhite ] [ str "White" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isLight ] [ str "Light" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isDark ] [ str "Dark" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isBlack ] [ str "Black" ] ]

          Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isPrimary ] [ str "Primary" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isInfo ] [ str "Info" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isSuccess ] [ str "Success" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isWarning ] [ str "Warning" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isDanger ] [ str "Danger" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.isChecked true; Checkradio.name "rad" ] [ str "Checkbox" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isWhite; Checkradio.name "rad" ] [ str "White" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isLight; Checkradio.name "rad" ] [ str "Light" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isDark; Checkradio.name "rad" ] [ str "Dark" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isBlack; Checkradio.name "rad" ] [ str "Black" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.isChecked true; Checkradio.isPrimary ; Checkradio.name "rad1" ] [ str "Primary" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isInfo; Checkradio.name "rad1" ] [ str "Info" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isSuccess; Checkradio.name "rad1" ] [ str "Success" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isWarning; Checkradio.name "rad1" ] [ str "Warning" ]
              Checkradio.radio [ Checkradio.isChecked true; Checkradio.isDanger; Checkradio.name "rad1" ] [ str "Danger" ] ] ]

let sizeInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isSmall ] [ str "Small" ]
              Checkradio.checkbox [ Checkradio.isChecked true ] [ str "Normal" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isMedium ] [ str "Medium" ]
              Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isLarge ] [ str "Large" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.name "rSize"; Checkradio.isSmall ] [ str "Small" ]
              Checkradio.radio [ Checkradio.name "rSize";] [ str "Normal" ]
              Checkradio.radio [ Checkradio.name "rSize"; Checkradio.isMedium ] [ str "Medium" ]
              Checkradio.radio [ Checkradio.name "rSize"; Checkradio.isLarge ] [ str "Large" ] ] ]

let stylesInteractive =
    div [ ]
        [ b [ ]
            [ str "Checkbox" ]
          br [ ]
          Columns.columns [ ]
              [ Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isCircle; Checkradio.isDisabled true ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isCircle;  ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isCircle; Checkradio.isPrimary ] [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isCircle; Checkradio.isDanger ] [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isCircle; Checkradio.isInfo ] [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isCircle; Checkradio.isWarning ] [ str "Warning" ] ]

                Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasNoBorder; Checkradio.isDisabled true ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasNoBorder;  ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasNoBorder; Checkradio.isPrimary ] [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasNoBorder; Checkradio.isDanger ] [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasNoBorder; Checkradio.isInfo ] [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasNoBorder; Checkradio.isWarning ] [ str "Warning" ] ]

                // Hide the isBlock display for now as the display is bad: https://github.com/Wikiki/bulma-checkradio/issues/10
                // Column.column [ ]
                //   [ Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isBlock; Checkradio.isDisabled true ] [ str "Checkbox" ]
                //     Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isBlock;  ] [ str "Checkbox" ]
                //     Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isBlock; Checkradio.isPrimary ] [ str "Primary" ]
                //     Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isBlock; Checkradio.isDanger ] [ str "Danger" ]
                //     Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isBlock; Checkradio.isInfo ] [ str "Info" ]
                //     Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.isBlock; Checkradio.isWarning ] [ str "Warning" ] ]

                Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isDisabled true ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasBackgroundColor;  ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isPrimary ] [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isDanger ] [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isInfo ] [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isWarning ] [ str "Warning" ] ] ]

          b [ ]
            [ str "Radio" ]
          br [ ]
          Columns.columns [ ]
              [ Column.column [ ]
                  [ Checkradio.radio [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isDisabled true ] [ str "Checkbox" ]
                    Checkradio.radio [ Checkradio.isChecked true; Checkradio.hasBackgroundColor;  ] [ str "Checkbox" ]
                    Checkradio.radio [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isPrimary ] [ str "Primary" ]
                    Checkradio.radio [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isDanger ] [ str "Danger" ]
                    Checkradio.radio [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isInfo ] [ str "Info" ]
                    Checkradio.radio [ Checkradio.isChecked true; Checkradio.hasBackgroundColor; Checkradio.isWarning ] [ str "Warning" ] ] ] ]

let stateInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Checkradio.checkbox [ Checkradio.isDisabled true ] [ str "Disabled" ]
                    Checkradio.checkbox [ Checkradio.isDisabled true; Checkradio.isChecked true ] [ str "Disabled & Checked" ]
                    Checkradio.checkbox [ ] [ str "Unchecked" ]
                    Checkradio.checkbox [ Checkradio.isChecked true;] [ str "Checked" ] ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Checkradio.radio [ Checkradio.isDisabled true ] [ str "Disabled" ]
                    Checkradio.radio [ Checkradio.isDisabled true; Checkradio.isChecked true ] [ str "Disabled & Checked" ]
                    Checkradio.radio [ ] [ str "Unchecked" ]
                    Checkradio.radio [ Checkradio.isChecked true;] [ str "Checked" ] ] ] ]

let eventInteractive model dispatch =
    let newState = not model.IsChecked

    div [ ClassName "block" ]
        [ Checkradio.checkbox
            [ Checkradio.isChecked model.IsChecked
              Checkradio.onChange (fun x -> dispatch (Change newState)) ]
            [ str  (sprintf "%A" model.IsChecked) ]

          Checkradio.checkbox
                [ Checkradio.isChecked model.IsChecked
                  Checkradio.onChange (fun x -> dispatch (Change newState)) ]
                [ if model.IsChecked then
                    yield Icon.faIcon [ ] [ Fa.icon Fa.I.Plane ]
                  else
                    yield Icon.faIcon [ ] [ Fa.icon Fa.I.Rocket] ] ]

let root model dispatch =
    Render.docPage [    Render.contentFromMarkdown model.Intro
                        Render.docSection
                            """
### Inline vs Block
By default checkradio are include in `div.field` element, so it's presented in block.
Use can use helpers functions to retrieve the input and the label by yourself.
"""
                            (Viewer.View.root inlineBlockInteractive model.InlineBlockViewer (InlineBlockViewerMsg >> dispatch))
                        Render.docSection
                            "### Text position"
                            (Viewer.View.root rtl model.ColorViewer (ColorViewerMsg >> dispatch))
                        Render.docSection
                            "### Colors"
                            (Viewer.View.root colorInteractive model.ColorViewer (ColorViewerMsg >> dispatch))
                        Render.docSection
                            "### Sizes"
                            (Viewer.View.root sizeInteractive model.SizeViewer (SizeViewerMsg >> dispatch))
                        Render.docSection
                            """
### Styles
The checkbox can be **circle**.
                            """
                            (Viewer.View.root stylesInteractive model.CircleViewer (CircleViewerMsg >> dispatch))

                        Render.docSection
                            "### States"
                            (Viewer.View.root stateInteractive model.StateViewer (StateViewerMsg >> dispatch))

                        Render.docSection
                            "### Event handler"
                            (Viewer.View.root (eventInteractive model dispatch) model.EventViewer (EventViewerMsg >> dispatch))
                    ]
