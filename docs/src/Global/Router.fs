module Router

open Elmish.Navigation
open Elmish.UrlParser
open Fable.React.Props

type Elements =
    | Button
    | Icon
    | Title
    | Delete
    | Box
    | Content
    | Tag
    | Image
    | Progress
    | Table
    | Form
    | Notification

type Components =
    | Panel
    | Breadcrumb
    | Card
    | Media
    | Menu
    | Message
    | Navbar
    | Pagination
    | Tabs
    | Modal
    | Dropdown

type Layouts =
    | Container
    | Level
    | Hero
    | Footer
    | Section
    | Columns
    | Tile

type Modifiers =
    | Basics
    | Colors
    | Spacing
    | Typography
    | Responsive

type FulmaPage =
    | Element of Elements
    | Component of Components
    | Layout of Layouts
    | Modifier of Modifiers
    | Introduction

type FulmaExtensionsPage =
    | Calendar
    | Tooltip
    | Divider
    | PageLoader
    | Slider
    | Switch
    | Checkradio
    | Quickview
    | Timeline

type FulmaElmishPage =
    | Introduction
    | DatePicker

type FableFontAwesomePage =
    | Introduction
    | Usage

type Page =
    | Home
    | Showcase
    | Template
    | BlogIndex
    | BlogArticle of string option
    | Fulma of FulmaPage
    | FulmaExtensions of FulmaExtensionsPage
    | FulmaElmish of FulmaElmishPage
    | FableFontAwesome of FableFontAwesomePage

let private toHash page =
    match page with
    | Home -> "#home"
    | Showcase -> "#showcase"
    | Template -> "#template"
    | BlogIndex -> "#blog"
    | BlogArticle (Some file) -> "#blog-viewer?file=" + file
    | BlogArticle None -> "#blog-viewer?file="
    | Fulma pageType ->
        match pageType with
        | FulmaPage.Introduction -> "#fulma"
        | Modifier modifiers ->
            match modifiers with
            | Basics -> "#fulma/modifiers/basics"
            | Colors -> "#fulma/modifiers/colors"
            | Spacing -> "#fulma/modifiers/spacing"
            | Typography -> "#fulma/modifiers/typography"
            | Responsive -> "#fulma/modifiers/responsive"
        | Layout layout ->
            match layout with
            | Container -> "#fulma/layouts/container"
            | Level -> "#fulma/layouts/level"
            | Hero -> "#fulma/layouts/hero"
            | Footer -> "#fulma/layouts/footer"
            | Section -> "#fulma/layouts/section"
            | Tile -> "#fulma/layouts/tile"
            | Columns -> "#fulma/layouts/columns"
        | Element element ->
            match element with
            | Button -> "#fulma/elements/button"
            | Icon -> "#fulma/elements/icon"
            | Title -> "#fulma/elements/title"
            | Delete -> "#fulma/elements/delete"
            | Box -> "#fulma/elements/box"
            | Content -> "#fulma/elements/content"
            | Tag -> "#fulma/elements/tag"
            | Image -> "#fulma/elements/image"
            | Progress -> "#fulma/elements/progress"
            | Table -> "#fulma/elements/table"
            | Form -> "#fulma/elements/form"
            | Notification -> "#fulma/elements/notification"
        | Component ``component`` ->
            match ``component`` with
            | Panel -> "#fulma/components/panel"
            | Breadcrumb -> "#fulma/components/breadcrumb"
            | Card  -> "#fulma/components/card"
            | Media -> "#fulma/components/media"
            | Menu -> "#fulma/components/menu"
            | Message -> "#fulma/components/message"
            | Navbar -> "#fulma/components/navbar"
            | Pagination -> "#fulma/components/pagination"
            | Tabs -> "#fulma/components/tabs"
            | Modal -> "#fulma/components/modal"
            | Dropdown ->"#fulma/components/dropdown"
    | FulmaExtensions pageType ->
        match pageType with
        | Checkradio -> "#fulma-extensions/checkradio"
        | Calendar -> "#fulma-extensions/calendar"
        | Tooltip -> "#fulma-extensions/tooltip"
        | PageLoader -> "#fulma-extensions/pageloader"
        | Divider -> "#fulma-extensions/divider"
        | Switch -> "#fulma-extensions/switch"
        | Slider -> "#fulma-extensions/slider"
        | Quickview -> "#fulma-extensions/quickview"
        | Timeline -> "#fulma-extensions/timeline"
    | FulmaElmish pageType ->
        match pageType with
        | FulmaElmishPage.Introduction -> "#fulma-elmish"
        | FulmaElmishPage.DatePicker -> "#fulma-elmish/date-picker"
    | FableFontAwesome pageType ->
        match pageType with
        | FableFontAwesomePage.Introduction -> "#fable-fontawesome"
        | FableFontAwesomePage.Usage -> "#fable-fontawesome/usage"

let pageParser : Parser<Page -> Page, Page> =
    oneOf [ map Home (s "home")
            map Showcase (s "showcase")
            map Template (s "template")
            map BlogIndex (s "blog")
            map BlogArticle ( s "blog-viewer" <?> stringParam "file")
            map (Fulma FulmaPage.Introduction ) (s "fulma")
            map (Fulma (FulmaPage.Modifier Basics))  (s "fulma" </> s "modifiers" </> s "basics")
            map (Fulma (FulmaPage.Modifier Colors))  (s "fulma" </> s "modifiers" </> s "colors")
            map (Fulma (FulmaPage.Modifier Spacing))  (s "fulma" </> s "modifiers" </> s "spacing")
            map (Fulma (FulmaPage.Modifier Responsive))  (s "fulma" </> s "modifiers" </> s "responsive")
            map (Fulma (FulmaPage.Modifier Typography))  (s "fulma" </> s "modifiers" </> s "typography")
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
            // Fable FontAwesome
            map (FableFontAwesome (FableFontAwesomePage.Introduction)) (s "fable-fontawesome")
            map (FableFontAwesome (FableFontAwesomePage.Usage)) (s "fable-fontawesome" </> s "usage")
            // Fulma Extension
            map (FulmaExtensions Checkradio) (s "fulma-extensions" </> s "checkradio")
            map (FulmaExtensions Calendar) (s "fulma-extensions" </> s "calendar")
            map (FulmaExtensions Tooltip) (s "fulma-extensions" </> s "tooltip")
            map (FulmaExtensions Slider) (s "fulma-extensions" </> s "slider")
            map (FulmaExtensions PageLoader) (s "fulma-extensions" </> s "pageloader")
            map (FulmaExtensions Divider) (s "fulma-extensions" </> s "divider")
            map (FulmaExtensions Switch) (s "fulma-extensions" </> s "switch")
            map (FulmaExtensions Quickview) (s "fulma-extensions" </> s "quickview")
            map (FulmaExtensions Timeline) (s "fulma-extensions" </> s "timeline")
            // Fulma Elmish
            map (FulmaElmish FulmaElmishPage.Introduction) (s "fulma-elmish")
            map (FulmaElmish FulmaElmishPage.DatePicker) (s "fulma-elmish" </> s "date-picker")
            map (Fulma FulmaPage.Introduction ) top ]

let href route =
    Href (toHash route)

/// Alias for Elmish.Browser.Navigation.modifyUrl
let modifyUrl route =
    route |> toHash |> Navigation.modifyUrl

/// Alias for Elmish.Browser.Navigation.newUrl
let newUrl route =
    route |> toHash |> Navigation.newUrl

/// Alias for Browser.window.location.href
let modifyLocation route =
    Browser.Dom.window.location.href <- toHash route
