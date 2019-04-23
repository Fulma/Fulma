module App.View

open Elmish
open Elmish.Navigation
open Elmish.UrlParser
open Fulma
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
        JS.console.error ("Error parsing url")
        model, Router.modifyUrl model.CurrentPage

    | Some page ->
        { model with CurrentPage = page
                     Menu = { model.Menu with CurrentPage = page } }, Cmd.none

let init result =
    let (model, cmd) =
        urlUpdate result { CurrentPage = Router.Home
                           Menu = Widgets.Menu.init Router.Home }

    model, Cmd.batch [ cmd ]

open Fable.React
open Fable.React.Props

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
        | Router.Template -> Template.view
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
        | Router.FableFontAwesome fableFontAwesome ->
            FableFontAwesome.Router.view fableFontAwesome

    div [ ]
        [ Navbar.view
          Section.section [ ]
              [ Container.container [ ]
                    [ Columns.columns [ ]
                          [ Column.column [ Column.Width (Screen.All, Column.IsOneFifth) ]
                                [ Widgets.Menu.view model.Menu (MenuMsg >> dispatch) ]
                            Column.column [ ]
                                [ pageHtml model.CurrentPage ] ] ] ] ]

open Elmish.React
// open Elmish.Debug
// open Elmish.HMR

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash Router.pageParser) urlUpdate
// #if DEBUG
// |> Program.withDebugger
// #endif
|> Program.withReactBatched "elmish-app"
|> Program.run
