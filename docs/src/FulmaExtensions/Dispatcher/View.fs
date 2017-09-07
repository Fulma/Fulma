module FulmaExtensions.Dispatcher.View

open Fable.Core
open Types
open Global

let root fulmaExtensionsPage model dispatch =
    match fulmaExtensionsPage with
    | Calendar ->
        FulmaExtensions.Calendar.View.root model.Calendar (CalendarMsg >> dispatch)

    | Tooltip ->
        FulmaExtensions.Tooltip.View.root model.Tooltip (TooltipMsg >> dispatch)

    | PageLoader ->
        FulmaExtensions.PageLoader.View.root model.PageLoader (PageLoaderMsg >> dispatch)
