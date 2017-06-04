module App.Types

open Global

type Msg =
  | HomeMsg of Home.Types.Msg
  | SendNotification
  | Test

type ElementsModel =
  { button: Elements.Button.Types.Model
    icon: Elements.Icon.Types.Model
    title : Elements.Title.Types.Model
    delete : Elements.Delete.Types.Model
    box : Elements.Box.Types.Model
    content : Elements.Content.Types.Model}

type Model = {
    currentPage: Page
    home: Home.Types.Model
    elements: ElementsModel
  }
