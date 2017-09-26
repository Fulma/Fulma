module Fulma.Dispatcher.View

open Fable.Core
open Types
open Global

let root fulmaPage model dispatch =
    match fulmaPage with
    | FulmaPage.Introduction -> Fulma.Introduction.View.root ()
    | FulmaPage.Versions -> Fulma.Versions.View.root ()
    | Element element ->
        match element with
        | Elements.Box -> Elements.Box.View.root model.Elements.Box (BoxMsg >> dispatch)
        | Elements.Button -> Elements.Button.View.root model.Elements.Button (ButtonMsg >> dispatch)
        | Elements.Content -> Elements.Content.View.root model.Elements.Content (ContentMsg >> dispatch)
        | Elements.Delete -> Elements.Delete.View.root model.Elements.Delete (DeleteMsg >> dispatch)
        | Elements.Icon -> Elements.Icon.View.root model.Elements.Icon (IconMsg >> dispatch)
        | Elements.Image -> Elements.Image.View.root model.Elements.Image (ImageMsg >> dispatch)
        | Elements.Progress -> Elements.Progress.View.root model.Elements.Progress (ProgressMsg >> dispatch)
        | Elements.Table -> Elements.Table.View.root model.Elements.Table (TableMsg >> dispatch)
        | Elements.Tag -> Elements.Tag.View.root model.Elements.Tag (TagMsg >> dispatch)
        | Elements.Title -> Elements.Title.View.root model.Elements.Title (TitleMsg >> dispatch)
        | Elements.Notification -> Elements.Notification.View.root model.Elements.Notification (NotificationMsg >> dispatch)
        | Elements.Form -> Elements.Form.View.root model.Elements.Form (FormMsg >> dispatch)
    | Component ``component`` ->
        match ``component`` with
        | Panel -> Components.Panel.View.root model.Components.Panel (PanelMsg >> dispatch)
        | Breadcrumb -> Components.Breadcrumb.View.root model.Components.Breadcrumb (BreadcrumbMsg >> dispatch)
        | Card -> Components.Card.View.root model.Components.Card (CardMsg >> dispatch)
        | Components.Media -> Components.Media.View.root model.Components.Media (MediaMsg >> dispatch)
        | Menu -> Components.Menu.View.root model.Components.Menu (MenuMsg >> dispatch)
        | Message -> Components.Message.View.root model.Components.Message (MessageMsg >> dispatch)
        | Navbar -> Components.Navbar.View.root model.Components.Navbar (NavbarMsg >> dispatch)
        | Pagination -> Components.Pagination.View.root model.Components.Pagination (PaginationMsg >> dispatch)
        | Tabs -> Components.Tabs.View.root model.Components.Tabs (TabsMsg >> dispatch)
        | Modal -> Components.Modal.View.root model.Components.Modal (ModalMsg >> dispatch)
        | Dropdown -> Components.Dropdown.View.root model.Components.Dropdown (DropdownMsg >> dispatch)
    | Layout layout ->
        match layout with
        | Container -> Layouts.Container.View.root model.Layouts.Container (ContainerMsg >> dispatch)
        | Level -> Layouts.Level.View.root model.Layouts.Level (LevelMsg >> dispatch)
        | Hero -> Layouts.Hero.View.root model.Layouts.Hero (HeroMsg >> dispatch)
        | Footer -> Layouts.Footer.View.root model.Layouts.Footer (FooterMsg >> dispatch)
        | Section -> Layouts.Section.View.root model.Layouts.Section (SectionMsg >> dispatch)
        | Tile -> Layouts.Tile.View.root model.Layouts.Tile (TileMsg >> dispatch)
        | Columns -> Layouts.Columns.View.root model.Layouts.Columns (ColumnsMsg >> dispatch)
