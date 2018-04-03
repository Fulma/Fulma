module FulmaExtensions.Slider

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Extensions

let colorInteractive () =
    div [ ClassName "block" ]
                      [ Slider.slider [ Slider.Step 10.
                                        Slider.DefaultValue 40. ]
                        Slider.slider [ Slider.Color IsPrimary ]
                        Slider.slider [ Slider.Color IsInfo ]
                        Slider.slider [ Slider.Color IsSuccess ]
                        Slider.slider [ Slider.Color IsWarning ]
                        Slider.slider [ Slider.Color IsDanger ] ]

let sizeInteractive () =
    div [ ClassName "block" ]
        [ Slider.slider [ Slider.Size IsSmall ]
          Slider.slider [ ]
          Slider.slider [ Slider.Size IsMedium ]
          Slider.slider [ Slider.Size IsLarge ]
          br []
          br []
          Slider.slider [ Slider.IsFullWidth ]
        ]

let stylesInteractive () =
    div [ ClassName "block" ]
        [ Slider.slider [ Slider.IsCircle; Slider.Disabled true ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsPrimary ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsSuccess ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsWarning ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsDanger ]
          Slider.slider [ Slider.IsCircle; Slider.Color IsInfo ] ]

let stateInteractive () =
    div [ ClassName "block" ]
        [ Slider.slider [  Slider.Disabled true ] ]

[<Pojo>]
type SliderDemoProps =
    interface end

[<Pojo>]
type SliderDemoState =
    { Ratio : int }

type SliderDemo(props) =
    inherit React.Component<SliderDemoProps, SliderDemoState>(props)
    do base.setInitState({ Ratio = 50 })

    member this.onSlide (ev : React.FormEvent) =
        unbox<int> ev.currentTarget?value
        |> (fun newRatio -> { this.state with Ratio = newRatio })
        |> this.setState

    override this.render () =
        div [ ]
            [ Slider.slider [ Slider.OnChange this.onSlide ]
              div [ ] [ str (string this.state.Ratio) ] ]

let demoView () =
    // Fake values, and helpers
    let ratio = 50
    let onChange _ = ()
    // View part
    div [ ]
        [ Slider.slider [ Slider.OnChange onChange ]
          div [ ] [ str (string ratio) ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Slider

The **Slider** can have different colors, sizes and states.

*[Documentation](https://wikiki.github.io/form/slider/)*


## Npm packages

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Version</th>
            <th>CLI</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>`yarn add bulma bulma-slider`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-slider@0.0.2`</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.getViewSource colorInteractive))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.getViewSource sizeInteractive))
                     Render.docSection
                        """
### Styles
The Slider can be **rounded, outlined or both**.
                        """
                        (Widgets.Showcase.view stylesInteractive (Render.getViewSource stylesInteractive))
                     Render.docSection
                        "### States"
                        (Widgets.Showcase.view stateInteractive (Render.getViewSource stateInteractive))
                     Render.docSection
                        """
### Control is behavior

The following helper help you control the behavior of your slider:

- `Slider.DefaultValue`: Set the initial value. The slider value can change in time without requiring you to set it.
- `Slider.Value`: Force the value of the slider. You will need to update this value yourself if you want the slider to move.
- `Slider.Step`: control the step of the slider. Ex: If you set it to 10, it will increment 10 by 10
- `Slider.Min`: minimal value
- `Slider.Max`: maximal value
                        """
                        (div [] []) // No view for now
                     Render.docSection
                        """
### Events
You can subscribe to **OnChange**.
                        """
                        (Widgets.Showcase.view (fun _ -> ofType<SliderDemo,_,_> (unbox null) []) (Render.getViewSource demoView)) ]
