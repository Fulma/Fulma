module FableFontAwesome.Router

let view fulmaElmishPage =
    match fulmaElmishPage with
    | Router.FableFontAwesomePage.Introduction -> FableFontAwesome.Introduction.view
    | Router.FableFontAwesomePage.Usage -> FableFontAwesome.Usage.view
