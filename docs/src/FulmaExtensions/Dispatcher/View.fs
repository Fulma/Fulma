module FulmaExtensions.Dispatcher.View

open Fable.Core
open Types
open Global

let root fulmaExtensionsPage model dispatch =
    match fulmaExtensionsPage with
    | FulmaExtensionsPage.Introduction ->
        FulmaExtensions.Introduction.View.root

    | Calendar ->
        FulmaExtensions.Calendar.View.root model.Calendar (CalendarMsg >> dispatch)

    | Tooltip ->
        FulmaExtensions.Tooltip.View.root model.Tooltip (TooltipMsg >> dispatch)

    | Divider ->
        FulmaExtensions.Divider.View.root model.Divider (DividerMsg >> dispatch)

    | PageLoader ->
        FulmaExtensions.PageLoader.View.root model.PageLoader (PageLoaderMsg >> dispatch)
