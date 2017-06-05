module App.State

open Elmish
open Elmish.Bulma.Elements.Notification
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Global
open Types

let pageParser: Parser<Page->Page,Page> =
  oneOf [
    map Home (s "home")
    map (Element Button) (s "elements" </> s "button")
    map (Element Icon) (s "elements" </> s "icon")
    map (Element Title) (s "elements" </> s "title")
    map (Element Delete) (s "elements" </> s "delete")
    map (Element Box) (s "elements" </> s "box")
    map (Element Content) (s "elements" </> s "content")
    map (Element Tag) (s "elements" </> s "tag")
    map (Element Image) (s "elements" </> s "image")
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
    { button = Elements.Button.State.init ()
      icon = Elements.Icon.State.init ()
      image = Elements.Image.State.init ()
      title = Elements.Title.State.init()
      delete = Elements.Delete.State.init()
      box = Elements.Box.State.init()
      content = Elements.Content.State.init()
      tag = Elements.Tag.State.init() }

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
      model, Elmish.Bulma.Elements.Notification.Cmd.newNotification (notification [ (*Level Success*) ] [ ] [ str "coucou" ])
  | Test ->
      Browser.console.log "couocuo"
      model, []
