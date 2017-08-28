module Fulma.Extensions.Dispatcher.State

open Elmish
open Types

let init() =
    { Calendar = Fulma.Extensions.Calendar.State.init () }

let update msg model =
    match msg with
    | CalendarMsg msg ->
        let (calendar, calendarMsg) = Fulma.Extensions.Calendar.State.update msg model.Calendar
        { model with Calendar = calendar }, Cmd.map CalendarMsg calendarMsg
