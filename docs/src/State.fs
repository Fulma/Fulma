module App.State

open Elmish
open Elmish.Bulma.Modifiers
open Elmish.Bulma.Notification
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map Home (s "home")
    map (Element Button) (s "elements" </> s "button")
    map Home top
  ]

let urlUpdate (result: Option<Page>) model =
  match result with
  | None ->
    Browser.console.error("Error parsing url")
    model,Navigation.modifyUrl (toHash model.currentPage)
  | Some page ->
      { model with currentPage = page }, []

let init result =
  let (home, homeCmd) = Home.State.init()

  let elements =
    { button = Elements.Button.State.init () }

  let (model, cmd) =
    urlUpdate result
      { currentPage = Home
        home = home
        elements = elements }
  model, Cmd.batch [ cmd
                     Cmd.map HomeMsg homeCmd ]

open Fable.Helpers.React
open Fable.Helpers.React.Props

let update msg model =
  match msg with
  | HomeMsg msg ->
      let (home, homeCmd) = Home.State.update msg model.home
      { model with home = home }, Cmd.map HomeMsg homeCmd
  | SendNotification ->
      model, Elmish.Bulma.Notification.Cmd.newNotification (notification [ Level Success ] [ ] [ str "coucou" ])
  | Test ->
      Browser.console.log "couocuo"
      model, []
