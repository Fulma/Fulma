module FulmaExtensions.Switch.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Grids
open Fulma.Extensions
open Fulma.Extra.FontAwesome

let inlineBlockInteractive = 
    Columns.columns [ ]
        [ 
            Column.column [ ]
                [ div [ ClassName "block" ]
                      [ 
                        b [] [str "Block"]
                        Switch.switch [ ] [ str "One" ]
                        Switch.switch [ ] [ str "Two" ]
                        
                        b [] [str "Inline"]
                        div [ ClassName "field"] [
                            yield! Switch.switchInline [ ] [ str "One " ]
                            yield! Switch.switchInline [ ] [ str "Two " ]
                        ]
                      ] 
                ]
            
        ]

let colorInteractive =
    Columns.columns [ ]
        [ 
            Column.column [ ]
                [
                    div   [ ClassName "block" ]
                          [ Switch.switch [ Switch.isChecked;  ] [ str "Default" ]
                            Switch.switch [ Switch.isChecked; Switch.isWhite ] [ str "White" ]
                            Switch.switch [ Switch.isChecked; Switch.isLight ] [ str "Light" ]
                            Switch.switch [ Switch.isChecked; Switch.isDark ] [ str "Dark" ]
                            Switch.switch [ Switch.isChecked; Switch.isBlack ] [ str "Black" ]
                          ]
                ]

            Column.column [ ]
                [
                    div   [ ClassName "block" ]
                          [ Switch.switch [ Switch.isChecked; Switch.isPrimary ] [ str "Primary" ]
                            Switch.switch [ Switch.isChecked; Switch.isInfo ] [ str "Info" ]
                            Switch.switch [ Switch.isChecked; Switch.isSuccess ] [ str "Success" ]
                            Switch.switch [ Switch.isChecked; Switch.isWarning ] [ str "Warning" ]
                            Switch.switch [ Switch.isChecked; Switch.isDanger ] [ str "Danger" ]
                          ]
                ]
        ]


let sizeInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [ Switch.isChecked; Switch.isSmall ] [ str "Small" ]
          Switch.switch [ Switch.isChecked ] [ str "Normal" ]
          Switch.switch [ Switch.isChecked; Switch.isMedium ] [ str "Medium" ]
          Switch.switch [ Switch.isChecked; Switch.isLarge ] [ str "Large" ] 
        ]
            

        

let stylesInteractive =
    Columns.columns [ ]
            [ 
              Column.column [ ]
                [
                    div [ ClassName "block" ]
                        [ Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isDisabled ] [ str "Disabled" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isPrimary ] [ str "Checkbox" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isSuccess ] [ str "Checkbox - success" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isWarning ] [ str "Checkbox - warning" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isDanger ] [ str "Checkbox - danger" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isInfo ] [ str "Checkbox - info" ]
                        ]
                ]
              Column.column [ ]
                [
                    div [ ClassName "block" ]
                        [ Switch.switch [ Switch.isChecked; Switch.isOutlined; Switch.isDisabled ] [ str "Disabled" ]
                          Switch.switch [ Switch.isChecked; Switch.isOutlined; Switch.isPrimary ] [ str "Checkbox" ]
                          Switch.switch [ Switch.isChecked; Switch.isOutlined; Switch.isSuccess ] [ str "Checkbox - success" ]
                          Switch.switch [ Switch.isChecked; Switch.isOutlined; Switch.isWarning ] [ str "Checkbox - warning" ]
                          Switch.switch [ Switch.isChecked; Switch.isOutlined; Switch.isDanger ] [ str "Checkbox - danger" ]
                          Switch.switch [ Switch.isChecked; Switch.isOutlined; Switch.isInfo ] [ str "Checkbox - info" ]
                        ]
                ]
              Column.column [ ]
                [
                    div [ ClassName "block" ]
                        [ Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isOutlined; Switch.isDisabled ] [ str "Disabled" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isOutlined; Switch.isPrimary ] [ str "Checkbox" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isOutlined; Switch.isSuccess ] [ str "Checkbox - success" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isOutlined; Switch.isWarning ] [ str "Checkbox - warning" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isOutlined; Switch.isDanger ] [ str "Checkbox - danger" ]
                          Switch.switch [ Switch.isChecked; Switch.isRounded; Switch.isOutlined; Switch.isInfo ] [ str "Checkbox - info" ]
                        ]
                ]

            ]
          

let stateInteractive =
    div [ ClassName "block" ]
        [ Switch.switch [  Switch.isDisabled ] [ str "Disabled" ]
          Switch.switch [  Switch.isDisabled; Switch.isChecked ] [ str "Disabled & Checked" ]
          Switch.switch [ ] [ str "Unchecked" ]
          Switch.switch [ Switch.isChecked;] [ str "checked" ]
        ]
          


let eventInteractive model dispatch =
    let state = not model.IsChecked
    
    div [ ClassName "block" ]
        [ Switch.switch 
            [
                if model.IsChecked then yield Switch.isChecked;  
                yield Switch.onChange (fun x -> dispatch (Change state))
            ] 
            [ str  (sprintf "%A" model.IsChecked) ]
        
          Switch.switch 
            [ 
                if model.IsChecked then yield Switch.isChecked;  
                yield Switch.onChange (fun x -> dispatch (Change state))
            ] 
            [ str  (if model.IsChecked then ":p" else ":'(") ]
        
          Switch.switch 
            [ 
                if model.IsChecked then yield Switch.isChecked;  
                yield Switch.onChange (fun x -> dispatch (Change state))
            ] 
            [ (if model.IsChecked then Icon.faIcon [ ] Fa.Plane else Icon.faIcon [ ] Fa.Rocket) ]
        ]

let root model dispatch =
    Render.docPage [    Render.contentFromMarkdown model.Intro
                        Render.docSection
                            "### Inline vs Block"
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
The switch can be **rounded, outlined or both**.
                            """
                            (Viewer.View.root stylesInteractive model.CircleViewer (CircleViewerMsg >> dispatch))
                     
                        Render.docSection 
                            "### States"
                            (Viewer.View.root stateInteractive model.StateViewer (StateViewerMsg >> dispatch))
                        
                        Render.docSection
                            "### Event handler"
                            (Viewer.View.root (eventInteractive model dispatch) model.EventViewer (EventViewerMsg >> dispatch))
                    ]