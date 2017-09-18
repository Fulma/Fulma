module FulmaElmish.Dispatcher.State

open Elmish
open Types

let init() =
    { DatePicker = FulmaElmish.DatePicker.State.init () }

let update msg model =
    match msg with
    | DatePickerMsg msg ->
        let (datePicker, datePickerMsg) = FulmaElmish.DatePicker.State.update msg model.DatePicker
        { model with DatePicker = datePicker }, Cmd.map DatePickerMsg datePickerMsg
