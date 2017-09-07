module FulmaExtensions.Slider.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Extensions
open Fulma.Elements
open Fulma.Extra.FontAwesome

let colorInteractive =
    div [ ClassName "block" ]
                      [
                        Slider.slider [ Slider.step 10.
                                        Slider.defaultValue 40. ] [ ]
                        Slider.slider [ Slider.isPrimary ] [ ]
                        Slider.slider [ Slider.isInfo ] [ ]
                        Slider.slider [ Slider.isSuccess ] [ ]
                        Slider.slider [ Slider.isWarning ] [ ]
                        Slider.slider [ Slider.isDanger ] [ ]
                      ]

let sizeInteractive =
    div [ ClassName "block" ]
        [ Slider.slider [ Slider.isSmall ] [ ]
          Slider.slider [ ] [ ]
          Slider.slider [ Slider.isMedium ] [ ]
          Slider.slider [ Slider.isLarge ] [ ]
          br []
          br []
          Slider.slider [ Slider.isFullWidth ] [ ]
        ]

let stylesInteractive =
    div [ ClassName "block" ]
        [  Slider.slider [ Slider.isCircle; Slider.isDisabled ] [ ]
           Slider.slider [ Slider.isCircle; Slider.isPrimary ] [ ]
           Slider.slider [ Slider.isCircle; Slider.isSuccess ] [ ]
           Slider.slider [ Slider.isCircle; Slider.isWarning ] [ ]
           Slider.slider [ Slider.isCircle; Slider.isDanger ] [ ]
           Slider.slider [ Slider.isCircle; Slider.isInfo ] [ ]
        ]

let stateInteractive =
    div [ ClassName "block" ]
        [ Slider.slider [  Slider.isDisabled ] [ ]
        ]

let eventInteractive model dispatch =
    div [ ClassName "block" ]
        [ Slider.slider [ Slider.onChange (fun x -> dispatch (Change (x.currentTarget?value |> sprintf "%O" |> int)))  ] [ ]
          div [] [ str (sprintf "%i" model.Value) ]
        ]

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
- `Slider.max`: maxime value
                            """
                            (div [] []) // No view for now
                        Render.docSection
                            """
### Events
You can subscribe to **OnChange**.
                            """
                            (Viewer.View.root (eventInteractive model dispatch) model.EventViewer (EventViewerMsg >> dispatch))
                    ]
