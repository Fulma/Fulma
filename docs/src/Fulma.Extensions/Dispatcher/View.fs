module Fulma.Extensions.Dispatcher.View

open Fable.Core
open Types
open Global

let root fulmaExtensionsPage model dispatch =
    match fulmaExtensionsPage with
    | Calendar ->
        Fulma.Extensions.Calendar.View.root model.Calendar (CalendarMsg >> dispatch)
