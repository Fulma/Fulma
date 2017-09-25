module FulmaElmish.Dispatcher.View

open Fable.Core
open Types
open Global

let root fulmaElmishPage model dispatch =
    match fulmaElmishPage with
    | FulmaElmishPage.Introduction ->
        FulmaElmish.Introduction.View.root ()

    | DatePicker ->
        FulmaElmish.DatePicker.View.root model.DatePicker (DatePickerMsg >> dispatch)
