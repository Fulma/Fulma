module FulmaElmish.Dispatcher.View

open Types

let root fulmaElmishPage model dispatch =
    match fulmaElmishPage with
    | Router.FulmaElmishPage.Introduction ->
        FulmaElmish.Introduction.View.root ()

    | Router.DatePicker ->
        FulmaElmish.DatePicker.View.root model.DatePicker (DatePickerMsg >> dispatch)
