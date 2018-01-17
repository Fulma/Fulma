module FulmaExtensions.Dispatcher.View

open Fable.Core
open Types

let root fulmaExtensionsPage model dispatch =
    match fulmaExtensionsPage with
    | Router.FulmaExtensionsPage.Introduction ->
        FulmaExtensions.Introduction.View.root ()

    | Router.Calendar ->
        FulmaExtensions.Calendar.View.root model.Calendar (CalendarMsg >> dispatch)

    | Router.Tooltip ->
        FulmaExtensions.Tooltip.View.root model.Tooltip (TooltipMsg >> dispatch)

    | Router.Checkradio ->
        FulmaExtensions.Checkradio.View.root model.Checkradio (CheckradioMsg >> dispatch)

    | Router.Switch ->
        FulmaExtensions.Switch.View.root model.Switch (SwitchMsg >> dispatch)

    | Router.Divider ->
        FulmaExtensions.Divider.View.root model.Divider (DividerMsg >> dispatch)

    | Router.PageLoader ->
        FulmaExtensions.PageLoader.View.root model.PageLoader (PageLoaderMsg >> dispatch)

    | Router.Slider ->
        FulmaExtensions.Slider.View.root model.Slider (SliderMsg >> dispatch)
