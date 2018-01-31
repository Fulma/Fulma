module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fulma.Components
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import

[<Emit("Prism.languages.fsharp")>]
let prismFSharp = ""

// Configure markdown parser
let options =
    createObj [ "highlight" ==> fun code -> PrismJS.Globals.Prism.highlight (code, unbox prismFSharp)
                "langPrefix" ==> "language-" ]

Marked.Globals.marked.setOptions (unbox options) |> ignore

type Msg =
    | MenuMsg of Widgets.Menu.Msg

type Model =
    { Menu : Widgets.Menu.Model
      CurrentPage : Router.Page }

let urlUpdate (result : Option<Router.Page>) model =
    match result with
    | None ->
        Browser.console.error ("Error parsing url")
        model, Router.modifyUrl model.CurrentPage

    | Some page ->
        { model with CurrentPage = page
                     Menu = { model.Menu with CurrentPage = page } }, Cmd.none

let init result =
    let (model, cmd) =
        urlUpdate result { CurrentPage = Router.Home
                           Menu = Widgets.Menu.init Router.Home }

    model, Cmd.batch [ cmd ]

open Fable.Helpers.React
open Fable.Helpers.React.Props

let update msg model =
    match msg with
    | MenuMsg msg ->
        let (menu, menuMsg) = Widgets.Menu.update msg model.Menu
        { model with Menu = menu }, Cmd.map MenuMsg menuMsg

let root model dispatch =
    let pageHtml =
        function
        | Router.Home -> Home.view
        | Router.Showcase -> Demo.view
        | Router.BlogIndex ->
            Widgets.MdViewer.view "blog/index.md"
        | Router.BlogArticle (Some file) ->
            div [ Key file ]
                [ Widgets.MdViewer.view file ]
        | Router.BlogArticle None ->
            str "blog index"
        | Router.Fulma fulmaPage ->
            Fulma.Router.view fulmaPage
        | Router.FulmaExtensions fulmaExtensionsPage ->
            FulmaExtensions.Router.view fulmaExtensionsPage
        | Router.FulmaElmish fulmaElmishPage ->
            FulmaElmish.Router.view fulmaElmishPage

    div []
        [ div [ ClassName "navbar-bg" ]
              [ div [ ClassName "container" ] [ Navbar.view ] ]
          div [ ClassName "section" ]
              [ div [ ClassName "container" ]
                    [ div [ ClassName "columns" ]
                          [ div [ ClassName "column is-2" ]
                                [ Widgets.Menu.view model.Menu (MenuMsg >> dispatch) ]
                            div [ ClassName "column" ] [ pageHtml model.CurrentPage ] ] ] ] ]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash Router.pageParser) urlUpdate
#if DEBUG
|> Program.withHMR
|> Program.withDebugger
#endif
|> Program.withReact "elmish-app"
|> Program.run
