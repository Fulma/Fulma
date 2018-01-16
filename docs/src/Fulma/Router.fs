module Fulma.Router

open Global

let view fulmaPage =
    match fulmaPage with
    | FulmaPage.Introduction -> Fulma.Introduction.View.root ()
    | FulmaPage.Versions -> Fulma.Versions.View.root ()
    | Element element ->
        match element with
        | Elements.Box -> Elements.Box.view
        | Elements.Button -> Elements.Button.view
        | Elements.Content -> Elements.Content.view
        | Elements.Delete -> Elements.Delete.view
        | Elements.Icon -> Elements.Icon.view
        | Elements.Image -> Elements.Image.view
        | Elements.Progress -> Elements.Progress.view
        | Elements.Table -> Elements.Table.view
        | Elements.Tag -> Elements.Tag.view
        | Elements.Title -> Elements.Title.view
        | Elements.Notification -> Elements.Notification.view
        | Elements.Form -> Elements.Form.view
    | Component ``component`` ->
        match ``component`` with
        | Breadcrumb -> Components.Breadcrumb.view
        | Panel -> Components.Panel.view
        | Card -> Components.Card.view
        | Menu -> Components.Menu.view
        | Message -> Components.Message.view
        | Navbar -> Components.Navbar.view
        | Pagination -> Components.Pagination.view
        | Tabs -> Components.Tabs.view
        | Modal -> Components.Modal.view
        | Media -> Components.Media.view
        | Dropdown -> Components.Dropdown.view
    // | Layout layout ->
    //     match layout with
    //     | Container -> Layouts.Container.view
    //     | Level -> Layouts.Level.view
    //     | Hero -> Layouts.Hero.view
    //     | Footer -> Layouts.Footer.view
    //     | Section -> Layouts.Section.view
    //     | Tile -> Layouts.Tile.view
    //     | Columns -> Layouts.Columns.view
