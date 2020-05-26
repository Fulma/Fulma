module FulmaExtensions.Router

let view fulmaExtensionsPage =
    match fulmaExtensionsPage with
    | Router.Calendar -> Calendar.view
    | Router.Tooltip -> Tooltip.view
    | Router.Checkradio -> Checkradio.view
    | Router.Switch -> Switch.view
    | Router.Divider -> Divider.view
    | Router.PageLoader -> PageLoader.view
    | Router.Slider -> Slider.view
    | Router.Quickview -> Quickview.view
    | Router.Timeline -> Timeline.view
