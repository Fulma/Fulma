module App.Types

open Global

type Msg =
  | HomeMsg of Home.Types.Msg
  | SendNotification
  | Test

type Model = {
    currentPage: Page
    home: Home.Types.Model
  }
