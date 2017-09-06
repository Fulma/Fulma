module FulmaExtensions.Checkradio.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Layouts
open Fulma.Extensions
open Fulma.Elements
open Fulma.Extra.FontAwesome

let inlineBlockInteractive =
    Columns.columns [ ]
        [
            Column.column [ ]
                [ div [ ClassName "block" ]
                      [
                        b [] [str "Block"]
                        Checkradio.checkbox [ Checkradio.text "One" ] [ ]
                        Checkradio.checkbox [ Checkradio.text "Two" ] [ ]


                        b [] [str "Inline"]
                        div [ ClassName "field"] [
                            yield! Checkradio.checkboxInline [ ] [ str "One " ]
                            yield! Checkradio.checkboxInline [ ] [ str "Two " ]
                        ]
                      ]
                ]

            Column.column [ ]
                [ div [ ClassName "block" ]
                      [
                        b [] [str "Block"]
                        Checkradio.radio [ Checkradio.name "block" ] [ str "One" ]
                        Checkradio.radio [ Checkradio.name "block"  ] [ str "Two" ]


                        b [] [str "Inline"]
                        div [ ClassName "field"] [
                            yield! Checkradio.radioInline [ Checkradio.name "inline" ] [ str "One" ]
                            yield! Checkradio.radioInline [ Checkradio.name "inline" ] [ str "Two " ]
                        ]
                      ]
                ]
        ]

let colorInteractive =
    Columns.columns [ ]
        [
            Column.column [ ]
                [
                    Checkradio.checkbox [ Checkradio.isChecked ] [ str "Checkbox" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isWhite ] [ str "White" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isLight ] [ str "Light" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isDark ] [ str "Dark" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isBlack ] [ str "Black" ]
                ]

            Column.column [ ]
                [
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isPrimary ] [ str "Primary" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isInfo ] [ str "Info" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isSuccess ] [ str "Success" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isWarning ] [ str "Warning" ]
                    Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isDanger ] [ str "Danger" ]
                ]

            Column.column [ ]
                [
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.name "rad" ] [ str "Checkbox" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isWhite; Checkradio.name "rad" ] [ str "White" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isLight; Checkradio.name "rad" ] [ str "Light" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isDark; Checkradio.name "rad" ] [ str "Dark" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isBlack; Checkradio.name "rad" ] [ str "Black" ]
                ]

            Column.column [ ]
                [
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isPrimary ; Checkradio.name "rad1" ] [ str "Primary" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isInfo; Checkradio.name "rad1" ] [ str "Info" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isSuccess; Checkradio.name "rad1" ] [ str "Success" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isWarning; Checkradio.name "rad1" ] [ str "Warning" ]
                    Checkradio.radio [ Checkradio.isChecked; Checkradio.isDanger; Checkradio.name "rad1" ] [ str "Danger" ]
                ]
        ]

let sizeInteractive =
    Columns.columns [ ]
        [
          Column.column [ ]
            [
                Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isSmall ] [ str "Small" ]
                Checkradio.checkbox [ Checkradio.isChecked ] [ str "Normal" ]
                Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isMedium ] [ str "Medium" ]
                Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isLarge ] [ str "Large" ]
            ]

          Column.column [ ]
            [
                Checkradio.radio [ Checkradio.name "rSize"; Checkradio.isSmall ] [ str "Small" ]
                Checkradio.radio [ Checkradio.name "rSize";] [ str "Normal" ]
                Checkradio.radio [ Checkradio.name "rSize"; Checkradio.isMedium ] [ str "Medium" ]
                Checkradio.radio [ Checkradio.name "rSize"; Checkradio.isLarge ] [ str "Large" ]
            ]
        ]

let stylesInteractive =
    Columns.columns [ ]
        [
          Column.column [ ]
            [
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isDisabled ] [ str "Checkbox" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle;  ] [ str "Checkbox" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isWhite ] [ str "White" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isLight ] [ str "Light" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isDark ] [ str "Dark" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isBlack ] [ str "Black" ]
            ]

          Column.column [ ]
            [
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isPrimary ] [ str "Primary" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isSuccess ] [ str "Success" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isWarning ] [ str "Warning" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isDanger ] [ str "Danger" ]
            Checkradio.checkbox [ Checkradio.isChecked; Checkradio.isCircle; Checkradio.isInfo ] [ str "Info" ]
            ]
        ]


let stateInteractive =
    Columns.columns [ ]
            [
              Column.column [ ]
                [
                    div [ ClassName "block" ]
                        [ Checkradio.checkbox [  Checkradio.isDisabled ] [ str "Disabled" ]
                          Checkradio.checkbox [  Checkradio.isDisabled; Checkradio.isChecked ] [ str "Disabled & Checked" ]
                          Checkradio.checkbox [ ] [ str "Unchecked" ]
                          Checkradio.checkbox [ Checkradio.isChecked;] [ str "checked" ]
                        ]
                ]

              Column.column [ ]
                [
                    div [ ClassName "block" ]
                        [ Checkradio.radio [  Checkradio.isDisabled ] [ str "Disabled" ]
                          Checkradio.radio [  Checkradio.isDisabled; Checkradio.isChecked ] [ str "Disabled & Checked" ]
                          Checkradio.radio [ ] [ str "Unchecked" ]
                          Checkradio.radio [ Checkradio.isChecked;] [ str "checked" ]
                        ]
                ]
            ]



let eventInteractive model dispatch =
    let state = not model.IsChecked

    div [ ClassName "block" ]
        [ Checkradio.checkbox
                [
                    if model.IsChecked then yield Checkradio.isChecked;
                    yield Checkradio.onChange (fun x -> dispatch (Change state))
                ]
                [ str  (sprintf "%A" model.IsChecked) ]

          Checkradio.checkbox
                [
                    if model.IsChecked then yield Checkradio.isChecked;
                    yield Checkradio.onChange (fun x -> dispatch (Change state))
                ]
                [ str  (if model.IsChecked then ":p" else ":'(") ]

          Checkradio.checkbox
                [
                    if model.IsChecked then yield Checkradio.isChecked;
                    yield Checkradio.onChange (fun x -> dispatch (Change state))
                ]
                [ (if model.IsChecked then Icon.faIcon [ ] [ Fa.icon Fa.I.Plane ] else Icon.faIcon [ ] [ Fa.icon Fa.I.Rocket]) ]
        ]

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
