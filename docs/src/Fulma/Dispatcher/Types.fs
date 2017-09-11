module Fulma.Dispatcher.Types

open Global

type ElementsModel =
    { Box : Elements.Box.Types.Model
      Button : Elements.Button.Types.Model
      Content : Elements.Content.Types.Model
      Delete : Elements.Delete.Types.Model
      Icon : Elements.Icon.Types.Model
      Image : Elements.Image.Types.Model
      Progress : Elements.Progress.Types.Model
      Table : Elements.Table.Types.Model
      Tag : Elements.Tag.Types.Model
      Notification : Elements.Notification.Types.Model
      Title : Elements.Title.Types.Model }

type ComponentsModel =
    { Panel : Components.Panel.Types.Model
      Breadcrumb : Components.Breadcrumb.Types.Model
      Card : Components.Card.Types.Model
      Media : Components.Media.Types.Model
      Menu : Components.Menu.Types.Model
      Navbar : Components.Navbar.Types.Model
      Pagination : Components.Pagination.Types.Model
      Tabs : Components.Tabs.Types.Model
      Message : Components.Message.Types.Model
      Modal : Components.Modal.Types.Model }

type LayoutModel =
    { Container : Layouts.Container.Types.Model
      Hero : Layouts.Hero.Types.Model
      Footer : Layouts.Footer.Types.Model
      Section : Layouts.Section.Types.Model
      Level : Layouts.Level.Types.Model }

type Model =
    { Elements : ElementsModel
      Components : ComponentsModel
      Layouts : LayoutModel }

type Msg =
    | BoxMsg of Elements.Box.Types.Msg
    | ButtonMsg of Elements.Button.Types.Msg
    | ContentMsg of Elements.Content.Types.Msg
    | DeleteMsg of Elements.Delete.Types.Msg
    | IconMsg of Elements.Icon.Types.Msg
    | ImageMsg of Elements.Image.Types.Msg
    | ProgressMsg of Elements.Progress.Types.Msg
    | TableMsg of Elements.Table.Types.Msg
    | TagMsg of Elements.Tag.Types.Msg
    | NotificationMsg of Elements.Notification.Types.Msg
    | TitleMsg of Elements.Title.Types.Msg
    | PanelMsg of Components.Panel.Types.Msg
    | BreadcrumbMsg of Components.Breadcrumb.Types.Msg
    | CardMsg of Components.Card.Types.Msg
    | MediaMsg of Components.Media.Types.Msg
    | MenuMsg of Components.Menu.Types.Msg
    | MessageMsg of Components.Message.Types.Msg
    | NavbarMsg of Components.Navbar.Types.Msg
    | PaginationMsg of Components.Pagination.Types.Msg
    | TabsMsg of Components.Tabs.Types.Msg
    | ModalMsg of Components.Modal.Types.Msg
    | ContainerMsg of Layouts.Container.Types.Msg
    | LevelMsg of Layouts.Level.Types.Msg
    | HeroMsg of Layouts.Hero.Types.Msg
    | FooterMsg of Layouts.Footer.Types.Msg
    | SectionMsg of Layouts.Section.Types.Msg
