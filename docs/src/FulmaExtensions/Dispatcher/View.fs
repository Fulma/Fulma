module FulmaExtensions.Dispatcher.View

open Fable.Core
open Types
open Global

let root fulmaExtensionsPage model dispatch =
    match fulmaExtensionsPage with
    | FulmaExtensionsPage.Introduction ->
        FulmaExtensions.Introduction.View.root ()

    | Calendar ->
        FulmaExtensions.Calendar.View.root model.Calendar (CalendarMsg >> dispatch)

    | Tooltip ->
        FulmaExtensions.Tooltip.View.root model.Tooltip (TooltipMsg >> dispatch)
    
    | Checkradio ->
        FulmaExtensions.Checkradio.View.root model.Checkradio (CheckradioMsg >> dispatch)

    | Switch ->
        FulmaExtensions.Switch.View.root model.Switch (SwitchMsg >> dispatch)

    | Divider ->
        FulmaExtensions.Divider.View.root model.Divider (DividerMsg >> dispatch)

    | PageLoader ->
        FulmaExtensions.PageLoader.View.root model.PageLoader (PageLoaderMsg >> dispatch)

    | Slider ->
        FulmaExtensions.Slider.View.root model.Slider (SliderMsg >> dispatch)