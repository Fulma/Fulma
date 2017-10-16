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
                  Switch.switch [ ] [ str "One" ]
                  Switch.switch [ ] [ str "Two" ]

                  b [] [str "Inline"]
                  Field.field_div [ ]
                      [ yield! Switch.switchInline [ ] [ str "One" ]
                        yield! Switch.switchInline [ ] [ str "Two" ] ] ] ] ]

let rtl =
    Switch.switch [ Switch.isRtl ] [ str "Label is on the left" ]


let colorInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true ] [ str "Default" ]
                    Switch.switch [ Switch.isChecked true; Switch.isWhite ] [ str "White" ]
                    Switch.switch [ Switch.isChecked true; Switch.isLight ] [ str "Light" ]
                    Switch.switch [ Switch.isChecked true; Switch.isDark ] [ str "Dark" ]
                    Switch.switch [ Switch.isChecked true; Switch.isBlack ] [ str "Black" ] ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true; Switch.isPrimary ] [ str "Primary" ]
                    Switch.switch [ Switch.isChecked true; Switch.isInfo ] [ str "Info" ]
                    Switch.switch [ Switch.isChecked true; Switch.isSuccess ] [ str "Success" ]
                    Switch.switch [ Switch.isChecked true; Switch.isWarning ] [ str "Warning" ]
                    Switch.switch [ Switch.isChecked true; Switch.isDanger ] [ str "Danger" ] ] ] ]


let sizeInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.isChecked true; Switch.isSmall ] [ str "Small" ]
          Switch.switch [ Switch.isChecked true ] [ str "Normal" ]
          Switch.switch [ Switch.isChecked true; Switch.isMedium ] [ str "Medium" ]
          Switch.switch [ Switch.isChecked true; Switch.isLarge ] [ str "Large" ] ]


let stylesInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isDisabled ] [ str "Disabled" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isDisabled ] [ str "Disabled" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isThin
                                    Switch.isInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isDisabled ] [ str "Disabled" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isOutlined
                                    Switch.isInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isDisabled ] [ str "Disabled" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.isChecked true
                                    Switch.isRounded
                                    Switch.isOutlined
                                    Switch.isInfo ] [ str "Checkbox - info" ] ] ] ]


let stateInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.isDisabled ] [ str "Disabled" ]
          Switch.switch [ Switch.isDisabled; Switch.isChecked true ] [ str "Disabled & Checked" ]
          Switch.switch [ ] [ str "Unchecked" ]
          Switch.switch [ Switch.isChecked true ] [ str "checked" ] ]



let eventInteractive model dispatch =
    let newState = not model.IsChecked

    div [ ClassName "block" ]
        [ Switch.switch
            [ Switch.isChecked model.IsChecked
              Switch.onChange (fun x -> dispatch (Change newState)) ]
            [ str (sprintf "%A" model.IsChecked) ]
          Switch.switch
            [ Switch.isChecked model.IsChecked
              Switch.onChange (fun x -> dispatch (Change newState)) ]
            [ if model.IsChecked then
                yield Icon.faIcon [ ] [ Fa.icon Fa.I.Check ]
              else
                yield Icon.faIcon [ ] [ Fa.icon Fa.I.Times ] ] ]

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
