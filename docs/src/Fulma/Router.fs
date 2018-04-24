module Fulma.Router

let view fulmaPage =
    match fulmaPage with
    | Router.FulmaPage.Introduction -> Fulma.Introduction.view
    | Router.FulmaPage.Versions -> Fulma.Versions.view
    | Router.FulmaPage.Modifiers -> Fulma.Modifiers.view
    | Router.Element element ->
        match element with
        | Router.Elements.Box -> Elements.Box.view
        | Router.Elements.Button -> Elements.Button.view
        | Router.Elements.Content -> Elements.Content.view
        | Router.Elements.Delete -> Elements.Delete.view
        | Router.Elements.Icon -> Elements.Icon.view
        | Router.Elements.Image -> Elements.Image.view
        | Router.Elements.Progress -> Elements.Progress.view
        | Router.Elements.Table -> Elements.Table.view
        | Router.Elements.Tag -> Elements.Tag.view
        | Router.Elements.Title -> Elements.Title.view
        | Router.Elements.Notification -> Elements.Notification.view
        | Router.Elements.Form -> Elements.Form.view
    | Router.Component ``component`` ->
        match ``component`` with
        | Router.Breadcrumb -> Components.Breadcrumb.view
        | Router.Panel -> Components.Panel.view
        | Router.Card -> Components.Card.view
        | Router.Menu -> Components.Menu.view
        | Router.Message -> Components.Message.view
        | Router.Navbar -> Components.Navbar.view
        | Router.Pagination -> Components.Pagination.view
        | Router.Tabs -> Components.Tabs.view
        | Router.Modal -> Components.Modal.view
        | Router.Media -> Components.Media.view
        | Router.Dropdown -> Components.Dropdown.view
    | Router.Layout layout ->
        match layout with
        | Router.Container -> Layouts.Container.view
        | Router.Level -> Layouts.Level.view
        | Router.Hero -> Layouts.Hero.view
        | Router.Footer -> Layouts.Footer.view
        | Router.Section -> Layouts.Section.view
        | Router.Tile -> Layouts.Tile.view
        | Router.Columns -> Layouts.Columns.view
