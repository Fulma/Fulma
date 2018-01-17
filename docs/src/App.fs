module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fulma.Components
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser

[<Emit("Prism.languages.fsharp")>]
let prismFSharp = ""

// Configure markdown parser
let options =
    createObj [ "highlight" ==> fun code -> PrismJS.Globals.Prism.highlight (code, unbox prismFSharp)
                "langPrefix" ==> "language-" ]

Marked.Globals.marked.setOptions (unbox options) |> ignore

type Msg =
    | MenuMsg of Widgets.Menu.Msg
    | FulmaExtensionsMsg of FulmaExtensions.Dispatcher.Types.Msg
    | FulmaElmishMsg of FulmaElmish.Dispatcher.Types.Msg

type Model =
    { Menu : Widgets.Menu.Model
      CurrentPage : Router.Page
      FulmaExtensions : FulmaExtensions.Dispatcher.Types.Model
      FulmaElmish : FulmaElmish.Dispatcher.Types.Model }

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
                           Menu = Widgets.Menu.init Router.Home
                           FulmaExtensions = FulmaExtensions.Dispatcher.State.init ()
                           FulmaElmish = FulmaElmish.Dispatcher.State.init () }

    model, Cmd.batch [ cmd ]

open Fable.Helpers.React
open Fable.Helpers.React.Props

let update msg model =
    match msg with
    | MenuMsg msg ->
        let (menu, menuMsg) = Widgets.Menu.update msg model.Menu
        { model with Menu = menu }, Cmd.map MenuMsg menuMsg

    | FulmaExtensionsMsg msg ->
        let (fulmaExtensions, fulmaExtensionsMsg) = FulmaExtensions.Dispatcher.State.update msg model.FulmaExtensions
        { model with FulmaExtensions = fulmaExtensions }, Cmd.map FulmaExtensionsMsg fulmaExtensionsMsg

    | FulmaElmishMsg msg ->
        let (fulmaElmish, fulmaElmishMsg) = FulmaElmish.Dispatcher.State.update msg model.FulmaElmish
        { model with FulmaElmish = fulmaElmish }, Cmd.map FulmaElmishMsg fulmaElmishMsg


open Fable.Helpers.React
open Fable.Helpers.React.Props

let root model dispatch =
    let pageHtml =
        function
        | Router.Home -> Home.view
        | Router.Migration -> Migration.view
        | Router.Showcase -> Demo.view
        | Router.Fulma fulmaPage ->
            Fulma.Router.view fulmaPage
        | Router.FulmaExtensions fulmaExtensionsPage ->
            FulmaExtensions.Dispatcher.View.root fulmaExtensionsPage model.FulmaExtensions (FulmaExtensionsMsg >> dispatch)
        | Router.FulmaElmish fulmaElmishPage ->
            FulmaElmish.Dispatcher.View.root fulmaElmishPage model.FulmaElmish (FulmaElmishMsg >> dispatch)

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


// let test() =
//     div []
//         [ div [ ClassName "navbar-bg" ]
//               [ div [ ClassName "container" ] [ Navbar.View.root ] ]
//           div [ ClassName "section" ]
//               [ div [ ClassName "container" ]
//                     [ div [ ClassName "columns" ]
//                           [ div [ ClassName "column is-2" ] []
//                             div [ ClassName "column" ] [ ] ] ] ] ]



// printfn "CODE EXAMPLE: %s" (Render.getViewSource test)
