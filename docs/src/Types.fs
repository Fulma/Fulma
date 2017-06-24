module App.Types

open Global

type Msg =
    | SendNotification
    | Test
    | ButtonMsg of Elements.Button.Types.Msg
    | IconMsg of Elements.Icon.Types.Msg
    | ImageMsg of Elements.Image.Types.Msg

type ElementsModel =
    { Button : Elements.Button.Types.Model
      Icon : Elements.Icon.Types.Model
      Image : Elements.Image.Types.Model }

type Model =
    { CurrentPage : Page
      Home : Home.Types.Model
      Elements : ElementsModel }
