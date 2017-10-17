module FulmaExtensions.Tooltip.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Extensions
open Fulma.Elements
open Fulma.BulmaClasses

let basic =
    div [ ClassName "block" ]
        [ Button.button_a [ Button.props [ Tooltip.dataTooltip "Top tooltip" ]
                            Button.customClass Tooltip.ClassName ]
            [ str "Top tooltip" ]
          Button.button_a [ Button.props [ Tooltip.dataTooltip "Left tooltip" ]
                            Button.customClass (Tooltip.ClassName ++ Tooltip.IsTooltipLeft) ]
            [ str "Left tooltip" ]
          Button.button_a [ Button.props [ Tooltip.dataTooltip "Right tooltip" ]
                            Button.customClass (Tooltip.ClassName ++ Tooltip.IsTooltipRight) ]
            [ str "Right tooltip" ]
          Button.button_a [ Button.props [ Tooltip.dataTooltip "Bottom tooltip" ]
                            Button.customClass (Tooltip.ClassName ++ Tooltip.IsTooltipBottom) ]
            [ str "Bottom tooltip" ] ]


let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        """
As tooltips, can be attach to **any elements** we can't provide standard wrappers. However, we provide helpers over the classes and one to create the `data-tooltip` attribute.
                        """
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch)) ]
