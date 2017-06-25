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

type ElementsModel =
    { Box : Elements.Box.Types.Model
      Button : Elements.Button.Types.Model
      Content : Elements.Content.Types.Model
      Delete : Elements.Delete.Types.Model
      Icon : Elements.Icon.Types.Model
      Image : Elements.Image.Types.Model
      Progress : Elements.Progress.Types.Model
      Table : Elements.Table.Types.Model }

type Model =
    { CurrentPage : Page
      Home : Home.Types.Model
      Elements : ElementsModel }
