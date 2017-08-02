module App.Types

open Global

type Msg =
    | SendNotification
    | Test
    | BoxMsg of Elements.Box.Types.Msg
    | ButtonMsg of Elements.Button.Types.Msg
    | ContentMsg of Elements.Content.Types.Msg
    | DeleteMsg of Elements.Delete.Types.Msg
    | IconMsg of Elements.Icon.Types.Msg
    | ImageMsg of Elements.Image.Types.Msg
    | ProgressMsg of Elements.Progress.Types.Msg
    | TableMsg of Elements.Table.Types.Msg
    | TagMsg of Elements.Tag.Types.Msg
    | TitleMsg of Elements.Title.Types.Msg
    | PanelMsg of Components.Panel.Types.Msg
    | LevelMsg of Components.Level.Types.Msg
    | BreadcrumbMsg of Components.Breadcrumb.Types.Msg
    | CardMsg of Components.Card.Types.Msg
    | MediaMsg of Components.Media.Types.Msg
    | MenuMsg of Components.Menu.Types.Msg

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
      Title : Elements.Title.Types.Model }

type ComponentsModel =
    { Panel : Components.Panel.Types.Model
      Level : Components.Level.Types.Model
      Breadcrumb : Components.Breadcrumb.Types.Model
      Card : Components.Card.Types.Model
      Media : Components.Media.Types.Model
      Menu : Components.Menu.Types.Model }

type Model =
    { CurrentPage : Page
      Home : Home.Types.Model
      Elements : ElementsModel
      Components : ComponentsModel }
