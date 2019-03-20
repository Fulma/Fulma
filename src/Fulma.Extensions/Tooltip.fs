namespace Fulma.Extensions

open Fable.React.Props

[<RequireQualifiedAccess>]
[<System.ObsoleteAttribute("Fulma.Extensions is obselete please use Fulma.Extensions.Wikiki.Tooltip package instead")>]
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

    let dataTooltip d = Data ("tooltip", d)
