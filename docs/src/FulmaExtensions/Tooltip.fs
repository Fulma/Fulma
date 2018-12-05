module FulmaExtensions.Tooltip

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Extensions.Wikiki

let basic () =
    div [ ClassName "block" ]
        [ Button.button [ Button.Props [ Tooltip.dataTooltip "Top tooltip" ]
                          Button.CustomClass Tooltip.ClassName ]
            [ str "Top tooltip" ]
          Button.button [ Button.Props [ Tooltip.dataTooltip "Left tooltip" ]
                          Button.CustomClass (Tooltip.ClassName + " " + Tooltip.IsTooltipLeft) ]
            [ str "Left tooltip" ]
          Button.button [ Button.Props [ Tooltip.dataTooltip "Right tooltip" ]
                          Button.CustomClass (Tooltip.ClassName + " " + Tooltip.IsTooltipRight) ]
            [ str "Right tooltip" ]
          Button.button [ Button.Props [ Tooltip.dataTooltip "Bottom tooltip" ]
                          Button.CustomClass (Tooltip.ClassName + " " + Tooltip.IsTooltipBottom) ]
            [ str "Bottom tooltip" ] ]


let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Tooltip

Display a **tooltip** attached to any kind of element, in different position.

*[Documentation](https://wikiki.github.io/elements/tooltip/)*

### Installation

- `paket add Fulma.Extensions.Wikiki.Tooltip --project <your project>`
- `yarn add bulma-tooltip@2.0.2`

### Versions compatibility

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Fulma.Extensions.Wikiki.Tooltip</th>
            <th>bulma-tooltip</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>2.0.2</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                        """
As tooltips can be attached to **any element**, we can't provide standard wrappers. However, we provide helpers over the classes and one to create the `data-tooltip` attribute.
                        """
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
