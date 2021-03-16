module FulmaExtensions.Tooltip

open Fable.React
open Fable.React.Props
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
            [ str "Bottom tooltip" ]
          Button.button [ Button.Props [ Tooltip.dataTooltip "to be active" ]
                          Button.CustomClass (Tooltip.ClassName + " " + Tooltip.IsTooltipRight + " " + Tooltip.IsActive) ]
            [ str "Force tooltip" ] ]


let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Tooltip

Display a **tooltip** attached to any kind of element, in different position.

*[Documentation](https://wikiki.github.io/elements/tooltip/)*

### Installation

- Choose depending on your package manager:
    - `paket add Fulma.Extensions.Wikiki.Tooltip --project <your project>`
    - `dotnet add <your project> package Fulma.Extensions.Wikiki.Tooltip`
- Follow instructions from `dotnet femto yourProject.fsproj` - [Femto documentation](https://github.com/Zaid-Ajaj/Femto/)
- Don't forget to configure the npm package in your project
                        """
                     Render.docSection
                        """
As tooltips can be attached to **any element**, we can't provide standard wrappers. However, we provide helpers over the classes and one to create the `data-tooltip` attribute.
                        """
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
