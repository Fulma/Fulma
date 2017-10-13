module FulmaExtensions.Switch.View

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
                  Switch.switch [ ] "One"
                  Switch.switch [ ] "Two"

                  b [] [str "Inline"]
                  Field.field_div [ ]
                      [ yield! Switch.switchInline [ ] "One "
                        yield! Switch.switchInline [ ] "Two " ] ] ] ]

let rtl =
    Switch.switch [ Switch.isRtl ] "Label is on the left"


let colorInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true ] "Default"
                    Switch.switch [ Switch.isChecked true; Switch.isWhite ] "White"
                    Switch.switch [ Switch.isChecked true; Switch.isLight ] "Light"
                    Switch.switch [ Switch.isChecked true; Switch.isDark ] "Dark"
                    Switch.switch [ Switch.isChecked true; Switch.isBlack ] "Black" ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true; Switch.isPrimary ] "Primary"
                    Switch.switch [ Switch.isChecked true; Switch.isInfo ] "Info"
                    Switch.switch [ Switch.isChecked true; Switch.isSuccess ] "Success"
                    Switch.switch [ Switch.isChecked true; Switch.isWarning ] "Warning"
                    Switch.switch [ Switch.isChecked true; Switch.isDanger ] "Danger" ] ] ]


let sizeInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.isChecked true; Switch.isSmall ] "Small"
          Switch.switch [ Switch.isChecked true ] "Normal"
          Switch.switch [ Switch.isChecked true; Switch.isMedium ] "Medium"
          Switch.switch [ Switch.isChecked true; Switch.isLarge ] "Large" ]


let stylesInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isDisabled ] "Disabled"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isPrimary ] "Checkbox"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isSuccess ] "Checkbox - success"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isWarning ] "Checkbox - warning"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isDanger ] "Checkbox - danger"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isInfo ] "Checkbox - info" ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isDisabled ] "Disabled"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isPrimary ] "Checkbox"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isSuccess ] "Checkbox - success"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isWarning ] "Checkbox - warning"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isDanger ] "Checkbox - danger"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isInfo ] "Checkbox - info" ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isDisabled ] "Disabled"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isPrimary ] "Checkbox"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isSuccess ] "Checkbox - success"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isWarning ] "Checkbox - warning"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isDanger ] "Checkbox - danger"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isInfo ] "Checkbox - info" ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isDisabled ] "Disabled"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isPrimary ] "Checkbox"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isSuccess ] "Checkbox - success"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isWarning ] "Checkbox - warning"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isDanger ] "Checkbox - danger"
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isInfo ] "Checkbox - info" ] ] ]


let stateInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.isDisabled ] "Disabled"
          Switch.switch [ Switch.isDisabled; Switch.isChecked true ] "Disabled & Checked"
          Switch.switch [ ] "Unchecked"
          Switch.switch [ Switch.isChecked true ] "checked" ]



let eventInteractive model dispatch =
    let state = not model.IsChecked

    div [ ClassName "block" ]
        [ Switch.switch
            [ Switch.isChecked model.IsChecked
              Switch.onChange (fun x -> dispatch (Change state)) ]
            (sprintf "%A" model.IsChecked) ]

let root model dispatch =
    Render.docPage [    Render.contentFromMarkdown model.Intro
                        Render.docSection
                            "### Inline vs Block"
                            (Viewer.View.root inlineBlockInteractive model.InlineBlockViewer (InlineBlockViewerMsg >> dispatch))
                        Render.docSection
                            "### Text position"
                            (Viewer.View.root rtl model.RtlViewer (RtlViewerMsg >> dispatch))
                        Render.docSection
                            "### Colors"
                            (Viewer.View.root colorInteractive model.ColorViewer (ColorViewerMsg >> dispatch))
                        Render.docSection
                            "### Sizes"
                            (Viewer.View.root sizeInteractive model.SizeViewer (SizeViewerMsg >> dispatch))
                        Render.docSection
                            """
### Styles
The switch can be **rounded, outlined, thin or any combinaison of those**.
                            """
                            (Viewer.View.root stylesInteractive model.CircleViewer (CircleViewerMsg >> dispatch))

                        Render.docSection
                            "### States"
                            (Viewer.View.root stateInteractive model.StateViewer (StateViewerMsg >> dispatch))

                        Render.docSection
                            "### Event handler"
                            (Viewer.View.root (eventInteractive model dispatch) model.EventViewer (EventViewerMsg >> dispatch))
                    ]
