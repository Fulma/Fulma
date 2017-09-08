module FulmaExtensions.Dispatcher.State

open Elmish
open Types

let init() =
    { Calendar = FulmaExtensions.Calendar.State.init ()
      Tooltip = FulmaExtensions.Tooltip.State.init ()
      Divider = FulmaExtensions.Divider.State.init ()
      PageLoader = FulmaExtensions.PageLoader.State.init ()
      Slider = FulmaExtensions.Slider.State.init ()
      Switch = FulmaExtensions.Switch.State.init () }

let update msg model =
    match msg with
    | CalendarMsg msg ->
        let (calendar, calendarMsg) = FulmaExtensions.Calendar.State.update msg model.Calendar
        { model with Calendar = calendar }, Cmd.map CalendarMsg calendarMsg

    | TooltipMsg msg ->
        let (tooltip, tooltipMsg) = FulmaExtensions.Tooltip.State.update msg model.Tooltip
        { model with Tooltip = tooltip }, Cmd.map TooltipMsg tooltipMsg

    | SwitchMsg msg ->
        let (switch, switchMsg) = FulmaExtensions.Switch.State.update msg model.Switch
        { model with Switch = switch }, Cmd.map SwitchMsg switchMsg

    | DividerMsg msg ->
        let (divider, dividerMsg) = FulmaExtensions.Divider.State.update msg model.Divider
        { model with Divider = divider }, Cmd.map DividerMsg dividerMsg

    | PageLoaderMsg msg ->
            let (pageLoader, pageLoaderMsg) = FulmaExtensions.PageLoader.State.update msg model.PageLoader
            { model with PageLoader = pageLoader }, Cmd.map PageLoaderMsg pageLoaderMsg

    | SliderMsg msg ->
        let (slider, sliderMsg) = FulmaExtensions.Slider.State.update msg model.Slider
        { model with Slider = slider }, Cmd.map SliderMsg sliderMsg