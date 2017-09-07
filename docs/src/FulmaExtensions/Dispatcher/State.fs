module FulmaExtensions.Dispatcher.State

open Elmish
open Types

let init() =
    { Calendar = FulmaExtensions.Calendar.State.init ()
      Tooltip = FulmaExtensions.Tooltip.State.init ()
      PageLoader = FulmaExtensions.PageLoader.State.init () }

let update msg model =
    match msg with
    | CalendarMsg msg ->
        let (calendar, calendarMsg) = FulmaExtensions.Calendar.State.update msg model.Calendar
        { model with Calendar = calendar }, Cmd.map CalendarMsg calendarMsg

    | TooltipMsg msg ->
        let (tooltip, tooltipMsg) = FulmaExtensions.Tooltip.State.update msg model.Tooltip
        { model with Tooltip = tooltip }, Cmd.map TooltipMsg tooltipMsg

    | PageLoaderMsg msg ->
            let (pageLoader, pageLoaderMsg) = FulmaExtensions.PageLoader.State.update msg model.PageLoader
            { model with PageLoader = pageLoader }, Cmd.map PageLoaderMsg pageLoaderMsg
