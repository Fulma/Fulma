module App.Types

open Global

type Msg =
    | SendNotification
    | Test

type ElementsModel =
    { button : Elements.Button.Types.Model }

type Model =
    { currentPage : Page
      home : Home.Types.Model
      elements : ElementsModel }
