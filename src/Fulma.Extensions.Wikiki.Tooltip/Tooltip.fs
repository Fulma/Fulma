namespace Fulma.Extensions.Wikiki

open Fable.React.Props

[<RequireQualifiedAccess>]
module Tooltip =

    let [<Literal>] ClassName = "tooltip"
    let [<Literal>] IsTooltipTop = "has-tooltip-top"
    let [<Literal>] IsTooltipRight = "has-tooltip-right"
    let [<Literal>] IsTooltipBottom = "has-tooltip-bottom"
    let [<Literal>] IsTooltipLeft = "has-tooltip-left"
    let [<Literal>] IsMultiline = "has-tooltip-multiline"
    let [<Literal>] IsPrimary = "has-tooltip-primary"
    let [<Literal>] IsInfo = "has-tooltip-info"
    let [<Literal>] IsSuccess = "has-tooltip-success"
    let [<Literal>] IsWarning = "has-tooltip-warning"
    let [<Literal>] IsDanger = "has-tooltip-danger"
    let [<Literal>] IsActive =  "has-tooltip-active"

    let dataTooltip d = Data ("tooltip", d)
