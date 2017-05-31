module App.View

open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Types
open App.State
open Global
open Elmish.Bulma

// Bulma + Docs site css
importAll "../sass/main.sass"
// Prism css
importAll "../css/prism.min.css"

[<Emit("Prism.languages.fsharp")>]
let prismFSharp = ""

// Configure markdown parser
let options =
  createObj [
    "highlight" ==> fun code -> PrismJS.Globals.Prism.highlight(code, unbox prismFSharp)
    "langPrefix" ==> "language-"
  ]

Marked.Globals.marked.setOptions(unbox options)
|> ignore

open Fable.Helpers.React
open Fable.Helpers.React.Props

let menuItem label page currentPage =
    li
      [ ]
      [ a
          [ classList [ "is-active", page = currentPage ]
            Href (toHash page) ]
          [ str label ] ]

let menu currentPage =
  aside
    [ ClassName "menu" ]
    [ p
        [ ClassName "menu-label" ]
        [ str "General" ]
      ul
        [ ClassName "menu-list" ]
        [ menuItem "Home" Home currentPage
          menuItem "Button" (Element Button) currentPage ] ]


let header =
    div
      [ ClassName "hero is-primary" ]
      [ div
          [ ClassName "hero-body" ]
          [ div
              [ ClassName "column has-text-centered" ]
              [  h2
                  [ ClassName "subtitle" ]
                  [ str "Binding for Elmish using Bulma CSS framework" ] ] ] ]

let root model dispatch =

  let pageHtml =
    function
    | Home -> Home.View.root model.home (HomeMsg >> dispatch)
    | Element element ->
        match element with
        | Button -> Elements.Button.View.root model.elements.button

  div
    []
    [ div
        [ ClassName "navbar-bg" ]
        [ div
            [ ClassName "container" ]
            [ Navbar.View.root ] ]
      header
      div
        [ ClassName "section" ]
        [ div
            [ ClassName "container" ]
            [ div
                [ ClassName "columns" ]
                [ div
                    [ ClassName "column is-2" ]
                    [ menu model.currentPage ]
                  div
                    [ ClassName "column" ]
                    [ pageHtml model.currentPage ] ] ] ] ]

open Elmish.React
open Elmish.Bulma.Notification

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.toNotifiable Bulma.Notification.defaultNotificationArea
|> Program.withReact "elmish-app"
|> Program.run
