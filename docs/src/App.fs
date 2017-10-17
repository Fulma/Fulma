module App.View

open App.State
open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fulma.Components
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Global
open Types

// Bulma + Docs site css
importSideEffects "../scss/main.scss"
// Prism css
importSideEffects "../css/prism.min.css"

[<Emit("Prism.languages.fsharp")>]
let prismFSharp = ""

// Configure markdown parser
let options =
    createObj [ "highlight" ==> fun code -> PrismJS.Globals.Prism.highlight (code, unbox prismFSharp)
                "langPrefix" ==> "language-" ]

Marked.Globals.marked.setOptions (unbox options) |> ignore

open Fable.Helpers.React
open Fable.Helpers.React.Props

let root model dispatch =
    let pageHtml =
        function
        | Home -> Home.View.root ()
        | Migration -> Migration.View.root ()
        | Showcase -> Showcase.View.root ()
        | Fulma fulmaPage ->
            Fulma.Dispatcher.View.root fulmaPage model.Fulma (FulmaMsg >> dispatch)
        | FulmaExtensions fulmaExtensionsPage ->
            FulmaExtensions.Dispatcher.View.root fulmaExtensionsPage model.FulmaExtensions (FulmaExtensionsMsg >> dispatch)
        | FulmaElmish fulmaElmishPage ->
            FulmaElmish.Dispatcher.View.root fulmaElmishPage model.FulmaElmish (FulmaElmishMsg >> dispatch)

    div []
        [ div [ ClassName "navbar-bg" ]
              [ div [ ClassName "container" ] [ Navbar.View.root ] ]
          div [ ClassName "section" ]
              [ div [ ClassName "container" ]
                    [ div [ ClassName "columns" ]
                          [ div [ ClassName "column is-2" ]
                                [ Menu.View.root model.Menu (MenuMsg >> dispatch) ]
                            div [ ClassName "column" ] [ pageHtml model.CurrentPage ] ] ] ] ]

open Elmish.React
open Elmish.Debug

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
#if DEBUG
|> Program.withConsoleTrace
|> Program.withDebugger
#endif
|> Program.run
