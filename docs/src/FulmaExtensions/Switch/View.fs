module FulmaExtensions.Switch.View

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
                  Switch.switch [ ] [ str "One" ]
                  Switch.switch [ ] [ str "Two" ]

                  b [] [str "Inline"]
                  Field.field [ ]
                      [ yield! Switch.switchInline [ ] [ str "One" ]
                        yield! Switch.switchInline [ ] [ str "Two" ] ] ] ] ]

let rtl =
    Switch.switch [ Switch.IsRtl ] [ str "Label is on the left" ]


let colorInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true ] [ str "Default" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsWhite ] [ str "White" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsLight ] [ str "Light" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsDark ] [ str "Dark" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsBlack ] [ str "Black" ] ] ]

          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true; Switch.Color IsPrimary ] [ str "Primary" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsInfo ] [ str "Info" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsSuccess ] [ str "Success" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsWarning ] [ str "Warning" ]
                    Switch.switch [ Switch.Checked true; Switch.Color IsDanger ] [ str "Danger" ] ] ] ]


let sizeInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.Checked true; Switch.Size IsSmall ] [ str "Small" ]
          Switch.switch [ Switch.Checked true ] [ str "Normal" ]
          Switch.switch [ Switch.Checked true; Switch.Size IsMedium ] [ str "Medium" ]
          Switch.switch [ Switch.Checked true; Switch.Size IsLarge ] [ str "Large" ] ]


let stylesInteractive =
    Columns.columns [ ]
        [ Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsThin
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsOutlined
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ]
          Column.column [ ]
            [ div [ ClassName "block" ]
                  [ Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Disabled true ] [ str "Disabled" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsPrimary ] [ str "Checkbox" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsSuccess ] [ str "Checkbox - success" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsWarning ] [ str "Checkbox - warning" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsDanger ] [ str "Checkbox - danger" ]
                    Switch.switch [ Switch.Checked true
                                    Switch.IsRounded
                                    Switch.IsOutlined
                                    Switch.Color IsInfo ] [ str "Checkbox - info" ] ] ] ]


let stateInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.Disabled true ] [ str "Disabled" ]
          Switch.switch [ Switch.Disabled true; Switch.Checked true ] [ str "Disabled & Checked" ]
          Switch.switch [ ] [ str "Unchecked" ]
          Switch.switch [ Switch.Checked true ] [ str "checked" ] ]

let eventInteractive model dispatch =
    let newState = not model.IsChecked

    div [ ClassName "block" ]
        [ Switch.switch
            [ Switch.Checked model.IsChecked
              Switch.OnChange (fun x -> dispatch (Change newState)) ]
            [ str (string model.IsChecked) ]
          Switch.switch
            [ Switch.Checked model.IsChecked
              Switch.OnChange (fun x -> dispatch (Change newState)) ]
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
