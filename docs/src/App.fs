module App.View

open App.State
open Elmish
open Elmish.Browser.Navigation
open Elmish.Browser.UrlParser
open Elmish.Bulma
open Elmish.Bulma.Components
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Import.Browser
open Global
open Types

// Bulma + Docs site css
importSideEffects "../sass/main.sass"
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

let menuItem label page currentPage =
    li []
       [ a [ classList [ "is-active", page = currentPage ]
             Href(toHash page) ]
           [ str label ] ]

let menu currentPage =
    Menu.menu
        [ Menu.label "General"
          Menu.list
            [ menuItem "Home" Home currentPage
              menuItem "Button" (Element Button) currentPage
              menuItem "Icon" (Element Elements.Icon) currentPage
              menuItem "Image" (Element Elements.Image) currentPage
              menuItem "Title" (Element Elements.Title) currentPage
              menuItem "Delete" (Element Elements.Delete) currentPage
              menuItem "Progress" (Element Elements.Progress)  currentPage
              menuItem "Box" (Element Elements.Box) currentPage
              menuItem "Content" (Element Elements.Content)  currentPage
              menuItem "Table" (Element Elements.Table) currentPage
              //menuItem "Form" (Element Elements.Form) currentPage
              menuItem "Tag" (Element Elements.Tag) currentPage ] ]

let header =
    div [ ClassName "hero is-primary" ]
        [ div [ ClassName "hero-body" ]
              [ div [ ClassName "column has-text-centered" ]
                    [ h2 [ ClassName "subtitle cookieregular" ]
                         [ str "Binding for Elmish using Bulma CSS framework" ] ] ] ]

let root model dispatch =
    let pageHtml =
        function
        | Home -> Home.View.root model.Home
        | Element element ->
            match element with
            | Elements.Box -> Elements.Box.View.root model.Elements.Box (BoxMsg >> dispatch)
            | Elements.Button -> Elements.Button.View.root model.Elements.Button (ButtonMsg >> dispatch)
            | Elements.Content -> Elements.Content.View.root model.Elements.Content (ContentMsg >> dispatch)
            | Elements.Delete -> Elements.Delete.View.root model.Elements.Delete (DeleteMsg >> dispatch)
            | Elements.Icon -> Elements.Icon.View.root model.Elements.Icon (IconMsg >> dispatch)
            | Elements.Image -> Elements.Image.View.root model.Elements.Image (ImageMsg >> dispatch)
            | Elements.Progress -> Elements.Progress.View.root model.Elements.Progress (ProgressMsg >> dispatch)
            | Elements.Table -> Elements.Table.View.root model.Elements.Table (TableMsg >> dispatch)
            | Elements.Tag -> Elements.Tag.View.root model.Elements.Tag (TagMsg >> dispatch)
            | Elements.Title -> Elements.Title.View.root model.Elements.Title (TitleMsg >> dispatch)
            | _ -> div [] []

    div []
        [ div [ ClassName "navbar-bg" ]
              [ div [ ClassName "container" ] [ Navbar.View.root ] ]
          header
          div [ ClassName "section" ]
              [ div [ ClassName "container" ]
                    [ div [ ClassName "columns" ]
                          [ div [ ClassName "column is-2" ]
                                [ menu model.CurrentPage ]
                            div [ ClassName "column" ] [ pageHtml model.CurrentPage ] ] ] ] ]

open Elmish.Bulma.Elements.Notification
open Elmish.React

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.toNotifiable defaultNotificationArea
|> Program.withReact "elmish-app"
|> Program.run
