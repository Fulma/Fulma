module App.Types

open Global

type Msg =
  | HomeMsg of Home.Types.Msg
  | SendNotification
  | Test

type ElementsModel =
  { button: Elements.Button.Types.Model
    icon: Elements.Icon.Types.Model }

type Model = {
    currentPage: Page
    home: Home.Types.Model
    elements: ElementsModel
  }
