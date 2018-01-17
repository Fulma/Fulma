module FulmaElmish.Router

let view fulmaElmishPage =
    match fulmaElmishPage with
    | Router.FulmaElmishPage.Introduction -> FulmaElmish.Introduction.view
    | Router.DatePicker -> FulmaElmish.DatePicker.view
