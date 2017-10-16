namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tooltip =

    let [<Literal>] ClassName = "tooltip"
    let [<Literal>] IsTooltipTop = "is-tooltip-top"
    let [<Literal>] IsTooltipRight = "is-tooltip-right"
    let [<Literal>] IsTooltipBottom = "is-tooltip-bottom"
    let [<Literal>] IsTooltipLeft = "is-tooltip-left"

    let dataTooltip d = Data ("tooltip", d)
