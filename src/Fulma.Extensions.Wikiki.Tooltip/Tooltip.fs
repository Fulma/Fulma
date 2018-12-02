namespace Fulma.Extensions.Wikiki

open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tooltip =

    let [<Literal>] ClassName = "tooltip"
    let [<Literal>] IsTooltipTop = "is-tooltip-top"
    let [<Literal>] IsTooltipRight = "is-tooltip-right"
    let [<Literal>] IsTooltipBottom = "is-tooltip-bottom"
    let [<Literal>] IsTooltipLeft = "is-tooltip-left"
    let [<Literal>] IsMultiline = "is-tooltip-multiline"
    let [<Literal>] IsPrimary = "is-tooltip-primary"
    let [<Literal>] IsInfo = "is-tooltip-info"
    let [<Literal>] IsSuccess = "is-tooltip-success"
    let [<Literal>] IsWarning = "is-tooltip-warning"
    let [<Literal>] IsDanger = "is-tooltip-danger"
    let [<Literal>] IsActive =  "is-tooltip-active"

    let dataTooltip d = Data ("tooltip", d)
