module App.Types

open Global

type Msg =
    | SendNotification
    | Test
    | ButtonMsg of Elements.Button.Types.Msg

type ElementsModel =
    { Button : Elements.Button.Types.Model }

type Model =
    { CurrentPage : Page
      Home : Home.Types.Model
      Elements : ElementsModel }
