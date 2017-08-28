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

let root model dispatch =
    let pageHtml =
        function
        | Home -> Home.View.root model.Home
        | FableReactBulma pageType ->
            match pageType with
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
                | Elements.Notification -> Elements.Notification.View.root model.Elements.Notification (NotificationMsg >> dispatch)
            | Component ``component`` ->
                match ``component`` with
                | Panel -> Components.Panel.View.root model.Components.Panel (PanelMsg >> dispatch)
                | Level -> Components.Level.View.root model.Components.Level (LevelMsg >> dispatch)
                | Breadcrumb -> Components.Breadcrumb.View.root model.Components.Breadcrumb (BreadcrumbMsg >> dispatch)
                | Card -> Components.Card.View.root model.Components.Card (CardMsg >> dispatch)
                | Components.Media -> Components.Media.View.root model.Components.Media (MediaMsg >> dispatch)
                | Menu -> Components.Menu.View.root model.Components.Menu (MenuMsg >> dispatch)
                | Message -> Components.Message.View.root model.Components.Message (MessageMsg >> dispatch)
                | Navbar -> Components.Navbar.View.root model.Components.Navbar (NavbarMsg >> dispatch)
                | Pagination -> Components.Pagination.View.root model.Components.Pagination (PaginationMsg >> dispatch)
                | Tabs -> Components.Tabs.View.root model.Components.Tabs (TabsMsg >> dispatch)

    div []
        [ div [ ClassName "navbar-bg" ]
              [ div [ ClassName "container" ] [ Navbar.View.root ] ]
          div [ ClassName "section" ]
              [ div [ ClassName "container" ]
                    [ div [ ClassName "columns" ]
                          [ div [ ClassName "column is-2" ]
                                [ Menu.View.root model.Menu (MenuTempMsg >> dispatch) ]
                            div [ ClassName "column" ] [ pageHtml model.CurrentPage ] ] ] ] ]

open Elmish.React

// App
Program.mkProgram init update root
|> Program.toNavigable (parseHash pageParser) urlUpdate
|> Program.withReact "elmish-app"
|> Program.run
