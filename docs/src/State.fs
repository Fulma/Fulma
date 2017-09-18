module App.State

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Import
open Global
open Types

let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map Home (s "home")
            map (Fulma FulmaPage.Introduction ) (s "fulma")
            // Layouts
            map (Fulma (Layout Tile)) (s "fulma" </> s "layouts" </> s "tile")
            map (Fulma (Layout Container)) (s "fulma" </> s "layouts" </> s "container")
            map (Fulma (Layout Layouts.Level)) (s "fulma" </> s "layouts" </> s "level")
            map (Fulma (Layout Hero)) (s "fulma" </> s "layouts" </> s "hero")
            map (Fulma (Layout Footer)) (s "fulma" </> s "layouts" </> s "footer")
            map (Fulma (Layout Section)) (s "fulma" </> s "layouts" </> s "section")
            map (Fulma (Layout Columns)) (s "fulma" </> s "layouts" </> s "columns")
            // Elements
            map (Fulma (Element Button)) (s "fulma" </> s "elements" </> s "button")
            map (Fulma (Element Icon)) (s "fulma" </> s "elements" </> s "icon")
            map (Fulma (Element Title)) (s "fulma" </> s "elements" </> s "title")
            map (Fulma (Element Delete)) (s "fulma" </> s "elements" </> s "delete")
            map (Fulma (Element Box)) (s "fulma" </> s "elements" </> s "box")
            map (Fulma (Element Content)) (s "fulma" </> s "elements" </> s "content")
            map (Fulma (Element Tag)) (s "fulma" </> s "elements" </> s "tag")
            map (Fulma (Element Image)) (s "fulma" </> s "elements" </> s "image")
            map (Fulma (Element Progress)) (s "fulma" </> s "elements" </> s "progress")
            map (Fulma (Element Table)) (s "fulma" </> s "elements" </> s "table")
            map (Fulma (Element Form)) (s "fulma" </> s "elements" </> s "form")
            map (Fulma (Element Notification)) (s "fulma" </> s "elements" </> s "notification")
            // Components
            map (Fulma (Component Panel)) (s "fulma" </> s "components" </> s "panel")
            map (Fulma (Component Breadcrumb)) (s "fulma" </> s "components" </> s "breadcrumb")
            map (Fulma (Component Card)) (s "fulma" </> s "components" </> s "card")
            map (Fulma (Component Media)) (s "fulma" </> s "components" </> s "media")
            map (Fulma (Component Menu)) (s "fulma" </> s "components" </> s "menu")
            map (Fulma (Component Message)) (s "fulma" </> s "components" </> s "message")
            map (Fulma (Component Navbar)) (s "fulma" </> s "components" </> s "navbar")
            map (Fulma (Component Pagination)) (s "fulma" </> s "components" </> s "pagination")
            map (Fulma (Component Tabs)) (s "fulma" </> s "components" </> s "tabs")
            map (Fulma (Component Modal)) (s "fulma" </> s "components" </> s "modal")
            map (Fulma (Component Dropdown)) (s "fulma" </> s "components" </> s "dropdown")
            // Fulma Extension
            map (FulmaExtensions FulmaExtensionsPage.Introduction ) (s "fulma-extensions")
            map (FulmaExtensions Calendar) (s "fulma-extensions" </> s "calendar")
            map (FulmaExtensions Tooltip) (s "fulma-extensions" </> s "tooltip")
            map (FulmaExtensions Divider) (s "fulma-extensions" </> s "divider")
            // Fulma Elmish
            map (FulmaElmish FulmaElmishPage.Introduction) (s "fulma-elmish")
            map (FulmaElmish FulmaElmishPage.DatePicker) (s "fulma-elmish" </> s "date-picker")
            map (Fulma FulmaPage.Introduction ) top ]

let urlUpdate (result : Option<Page>) model =
    match result with
    | None ->
        Browser.console.error ("Error parsing url")
        model, Navigation.modifyUrl (toHash model.CurrentPage)

    | Some page ->
        { model with CurrentPage = page
                     Menu = { model.Menu with CurrentPage = page } }, Cmd.none

let init result =
    let (model, cmd) =
        urlUpdate result { CurrentPage = Home
                           Menu = Menu.State.init Home
                           Home = Home.State.init ()
                           Fulma = Fulma.Dispatcher.State.init ()
                           FulmaExtensions = FulmaExtensions.Dispatcher.State.init ()
                           FulmaElmish = FulmaElmish.Dispatcher.State.init () }

    model, Cmd.batch [ cmd ]

open Fable.Helpers.React
open Fable.Helpers.React.Props

let update msg model =
    match msg with
    | MenuMsg msg ->
        let (menu, menuMsg) = Menu.State.update msg model.Menu
        { model with Menu = menu }, Cmd.map MenuMsg menuMsg

    | FulmaMsg msg ->
        let (fulma, fulmaMsg) = Fulma.Dispatcher.State.update msg model.Fulma
        { model with Fulma = fulma }, Cmd.map FulmaMsg fulmaMsg

    | FulmaExtensionsMsg msg ->
        let (fulmaExtensions, fulmaExtensionsMsg) = FulmaExtensions.Dispatcher.State.update msg model.FulmaExtensions
        { model with FulmaExtensions = fulmaExtensions }, Cmd.map FulmaExtensionsMsg fulmaExtensionsMsg

    | FulmaElmishMsg msg ->
        let (fulmaElmish, fulmaElmishMsg) = FulmaElmish.Dispatcher.State.update msg model.FulmaElmish
        { model with FulmaElmish = fulmaElmish }, Cmd.map FulmaElmishMsg fulmaElmishMsg
