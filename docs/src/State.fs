module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.Bulma.Elements.Notification
open Fable.Import
open Global
open Types

let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map Home (s "home")
            map (Element Button) (s "elements" </> s "button")
            map (Element Icon) (s "elements" </> s "icon")
            map (Element Title) (s "elements" </> s "title")
            map (Element Delete) (s "elements" </> s "delete")
            map (Element Box) (s "elements" </> s "box")
            map (Element Content) (s "elements" </> s "content")
            map (Element Tag) (s "elements" </> s "tag")
            map (Element Image) (s "elements" </> s "image")
            map (Element Progress) (s "elements" </> s "progress")
            map (Element Table) (s "elements" </> s "table")
            map (Element Form) (s "elements" </> s "form")
            map Home top ]

let urlUpdate (result : Option<Page>) model =
    match result with
    | None ->
        Browser.console.error ("Error parsing url")
        model, Navigation.modifyUrl (toHash model.CurrentPage)

    | Some page -> { model with CurrentPage = page }, []

let init result =
    let elements =
        { Button = Elements.Button.State.init ()
          Delete = Elements.Delete.State.init ()
          Icon = Elements.Icon.State.init ()
          Image = Elements.Image.State.init ()
          Progress = Elements.Progress.State.init () }

    let (model, cmd) =
        urlUpdate result { CurrentPage = Home
                           Home = Home.State.init ()
                           Elements = elements }

    model, Cmd.batch [ cmd ]

open Fable.Helpers.React
open Fable.Helpers.React.Props

let update msg model =
    match msg with
    | SendNotification ->
        model, Elmish.Bulma.Elements.Notification.Cmd.newNotification (notification [] [] [ (*Level Success*) str "coucou" ])

    | Test ->
        model, Cmd.none

    | ButtonMsg msg ->
        let (button, buttonMsg) = Elements.Button.State.update msg model.Elements.Button
        { model with Elements =
                        { model.Elements with Button = button } }, Cmd.map ButtonMsg buttonMsg

    | IconMsg msg ->
        let (icon, iconMsg) = Elements.Icon.State.update msg model.Elements.Icon
        { model with Elements =
                        { model.Elements with Icon = icon } }, Cmd.map IconMsg iconMsg

    | ImageMsg msg ->
        let (image, imageMsg) = Elements.Image.State.update msg model.Elements.Image
        { model with Elements =
                        { model.Elements with Image = image } }, Cmd.map ImageMsg imageMsg

    | DeleteMsg msg ->
        let (delete, deleteMsg) = Elements.Delete.State.update msg model.Elements.Delete
        { model with Elements =
                        { model.Elements with Delete = delete } }, Cmd.map DeleteMsg deleteMsg

    | ProgressMsg msg ->
        let (progress, progressMsg) = Elements.Progress.State.update msg model.Elements.Progress
        { model with Elements =
                        { model.Elements with Progress = progress } }, Cmd.map ProgressMsg progressMsg
