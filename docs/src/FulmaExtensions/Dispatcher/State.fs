module FulmaExtensions.Dispatcher.State

open Elmish
open Types

let init() =
    { Calendar = FulmaExtensions.Calendar.State.init ()
      Tooltip = FulmaExtensions.Tooltip.State.init ()
      Divider = FulmaExtensions.Divider.State.init () }

let update msg model =
    match msg with
    | CalendarMsg msg ->
        let (calendar, calendarMsg) = FulmaExtensions.Calendar.State.update msg model.Calendar
        { model with Calendar = calendar }, Cmd.map CalendarMsg calendarMsg

    | TooltipMsg msg ->
        let (tooltip, tooltipMsg) = FulmaExtensions.Tooltip.State.update msg model.Tooltip
        { model with Tooltip = tooltip }, Cmd.map TooltipMsg tooltipMsg

    | DividerMsg msg ->
        let (divider, dividerMsg) = FulmaExtensions.Divider.State.update msg model.Divider
        { model with Divider = divider }, Cmd.map DividerMsg dividerMsg
