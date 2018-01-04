module FulmaExtensions.Checkradio.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
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
                    Field.field [ ]
                        [ yield! Checkradio.checkboxInline [ ] [ str "One " ]
                          yield! Checkradio.checkboxInline [ ] [ str "Two " ] ] ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ b [] [str "Block"]
                    Checkradio.radio [ Checkradio.Name "block" ] [ str "One" ]
                    Checkradio.radio [ Checkradio.Name "block"  ] [ str "Two" ]

                    b [] [str "Inline"]
                    Field.field [ ]
                        [ yield! Checkradio.radioInline [ Checkradio.Name "inline" ] [ str "One" ]
                          yield! Checkradio.radioInline [ Checkradio.Name "inline" ] [ str "Two " ] ] ] ] ]

let rtl =
    Columns.columns [ ]
        [ Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.IsRtl ] [ str "Label is on the left" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.IsRtl ] [ str "Label is on the left" ] ] ]

let colorInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.Checked true ] [ str "Checkbox" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsWhite ] [ str "White" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsLight ] [ str "Light" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsDark ] [ str "Dark" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsBlack ] [ str "Black" ] ]

          Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsPrimary ] [ str "Primary" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsInfo ] [ str "Info" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsSuccess ] [ str "Success" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsWarning ] [ str "Warning" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Color IsDanger ] [ str "Danger" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.Checked true; Checkradio.Name "rad" ] [ str "Checkbox" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsWhite; Checkradio.Name "rad" ] [ str "White" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsLight; Checkradio.Name "rad" ] [ str "Light" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsDark; Checkradio.Name "rad" ] [ str "Dark" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsBlack; Checkradio.Name "rad" ] [ str "Black" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsPrimary ; Checkradio.Name "rad1" ] [ str "Primary" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsInfo; Checkradio.Name "rad1" ] [ str "Info" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsSuccess; Checkradio.Name "rad1" ] [ str "Success" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsWarning; Checkradio.Name "rad1" ] [ str "Warning" ]
              Checkradio.radio [ Checkradio.Checked true; Checkradio.Color IsDanger; Checkradio.Name "rad1" ] [ str "Danger" ] ] ]

let sizeInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Size IsSmall ] [ str "Small" ]
              Checkradio.checkbox [ Checkradio.Checked true ] [ str "Normal" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Size IsMedium ] [ str "Medium" ]
              Checkradio.checkbox [ Checkradio.Checked true; Checkradio.Size IsLarge ] [ str "Large" ] ]

          Column.column [ ]
            [ Checkradio.radio [ Checkradio.Name "rSize"; Checkradio.Size IsSmall ] [ str "Small" ]
              Checkradio.radio [ Checkradio.Name "rSize";] [ str "Normal" ]
              Checkradio.radio [ Checkradio.Name "rSize"; Checkradio.Size IsMedium ] [ str "Medium" ]
              Checkradio.radio [ Checkradio.Name "rSize"; Checkradio.Size IsLarge ] [ str "Large" ] ] ]

let stylesInteractive =
    div [ ]
        [ b [ ]
            [ str "Checkbox" ]
          br [ ]
          Columns.columns [ ]
              [ Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.Checked true; Checkradio.IsCircle; Checkradio.Disabled true ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.IsCircle;  ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.IsCircle; Checkradio.Color IsPrimary ] [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.IsCircle; Checkradio.Color IsDanger ] [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.IsCircle; Checkradio.Color IsInfo ] [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.IsCircle; Checkradio.Color IsWarning ] [ str "Warning" ] ]

                Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasNoBorder; Checkradio.Disabled true ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasNoBorder;  ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasNoBorder; Checkradio.Color IsPrimary ] [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasNoBorder; Checkradio.Color IsDanger ] [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasNoBorder; Checkradio.Color IsInfo ] [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasNoBorder; Checkradio.Color IsWarning ] [ str "Warning" ] ]

                // Hide the isBlock display for now as the display is bad: https://github.com/Wikiki/bulma-checkradio/issues/10
                // Column.column [ ]
                //   [ Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.Disabled true ] [ str "Checkbox" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock;  ] [ str "Checkbox" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isPrimary ] [ str "Primary" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isDanger ] [ str "Danger" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isInfo ] [ str "Info" ]
                //     Checkradio.checkbox [ Checkradio.Checked true; Checkradio.isBlock; Checkradio.isWarning ] [ str "Warning" ] ]

                Column.column [ ]
                  [ Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Disabled true ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasBackgroundColor;  ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsPrimary ] [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsDanger ] [ str "Danger" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsInfo ] [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsWarning ] [ str "Warning" ] ] ]

          b [ ]
            [ str "Radio" ]
          br [ ]
          Columns.columns [ ]
              [ Column.column [ ]
                  [ Checkradio.radio [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Disabled true ] [ str "Checkbox" ]
                    Checkradio.radio [ Checkradio.Checked true; Checkradio.HasBackgroundColor;  ] [ str "Checkbox" ]
                    Checkradio.radio [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsPrimary ] [ str "Primary" ]
                    Checkradio.radio [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsDanger ] [ str "Danger" ]
                    Checkradio.radio [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsInfo ] [ str "Info" ]
                    Checkradio.radio [ Checkradio.Checked true; Checkradio.HasBackgroundColor; Checkradio.Color IsWarning ] [ str "Warning" ] ] ] ]

let stateInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Checkradio.checkbox [ Checkradio.Disabled true ] [ str "Disabled" ]
                    Checkradio.checkbox [ Checkradio.Disabled true; Checkradio.Checked true ] [ str "Disabled & Checked" ]
                    Checkradio.checkbox [ ] [ str "Unchecked" ]
                    Checkradio.checkbox [ Checkradio.Checked true;] [ str "Checked" ] ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Checkradio.radio [ Checkradio.Disabled true ] [ str "Disabled" ]
                    Checkradio.radio [ Checkradio.Disabled true; Checkradio.Checked true ] [ str "Disabled & Checked" ]
                    Checkradio.radio [ ] [ str "Unchecked" ]
                    Checkradio.radio [ Checkradio.Checked true;] [ str "Checked" ] ] ] ]

let eventInteractive model dispatch =
    let newState = not model.IsChecked

    div [ ClassName "block" ]
        [ Checkradio.checkbox
            [ Checkradio.Checked model.IsChecked
              Checkradio.OnChange (fun x -> dispatch (Change newState)) ]
            [ str  (string model.IsChecked) ]

          Checkradio.checkbox
                [ Checkradio.Checked model.IsChecked
                  Checkradio.OnChange (fun x -> dispatch (Change newState)) ]
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
