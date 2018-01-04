module FulmaExtensions.Slider.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Extensions
open Fulma.Elements
open Fulma.Extra.FontAwesome

let colorInteractive =
    div [ ClassName "block" ]
                      [ Slider.slider [ Slider.Step 10.
                                        Slider.DefaultValue 40. ]
                        Slider.slider [ Slider.Color IsPrimary ]
                        Slider.slider [ Slider.Color IsInfo ]
                        Slider.slider [ Slider.Color IsSuccess ]
                        Slider.slider [ Slider.Color IsWarning ]
                        Slider.slider [ Slider.Color IsDanger ] ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Slider.slider [ Slider.Size IsSmall ]
          Slider.slider [ ]
          Slider.slider [ Slider.Size IsMedium ]
          Slider.slider [ Slider.Size IsLarge ]
          br []
          br []
          Slider.slider [ Slider.IsFullWidth ]
        ]

let stylesInteractive =
    div [ ClassName "block" ]
        [ Slider.slider [ Slider.IsCircle; Slider.Disabled true ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsPrimary ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsSuccess ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsWarning ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsDanger ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsInfo ] ]

let stateInteractive =
    div [ ClassName "block" ]
        [ Slider.slider [  Slider.Disabled true ] ]

let eventInteractive model dispatch =
    div [ ClassName "block" ]
        [ Slider.slider [ Slider.OnChange (fun x -> dispatch (Change (unbox<int> x.currentTarget?value))) ]
          div [ ] [ str (string model.Value) ] ]

let root model dispatch =
    Render.docPage [    Render.contentFromMarkdown model.Intro
                        Render.docSection
                            "### Colors"
                            (Viewer.View.root colorInteractive model.ColorViewer (ColorViewerMsg >> dispatch))
                        Render.docSection
                            "### Sizes"
                            (Viewer.View.root sizeInteractive model.SizeViewer (SizeViewerMsg >> dispatch))
                        Render.docSection
                            """
### Styles
The Slider can be **rounded, outlined or both**.
                            """
                            (Viewer.View.root stylesInteractive model.CircleViewer (CircleViewerMsg >> dispatch))

                        Render.docSection
                            "### States"
                            (Viewer.View.root stateInteractive model.StateViewer (StateViewerMsg >> dispatch))
                        Render.docSection
                            """
### Control is behavior

The following helper help you control the behavior of your slider:

- `Slider.defaultValue`: Set the initial value. The slider value can change in time without requiring you to set it.
- `Slider.value`: Force the value of the slider. You will need to update this value yourself if you want the slider to move.
- `Slider.step`: control the step of the slider. Ex: If you set it to 10, it will increment 10 by 10
- `Slider.min`: minimal value
- `Slider.max`: maximal value
                            """
                            (div [] []) // No view for now
                        Render.docSection
                            """
### Events
You can subscribe to **OnChange**.
                            """
                            (Viewer.View.root (eventInteractive model dispatch) model.EventViewer (EventViewerMsg >> dispatch))
                    ]
