module Global

open Fable.Core

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
    | Level
    | Breadcrumb
    | Card
    | Media
    | Menu
    | Message
    | Navbar
    | Pagination
    | Tabs

type FableReactBulmaPage =
    | Element of Elements
    | Component of Components

type Page =
    | Home
    | FableReactBulma of FableReactBulmaPage

let toHash page =
    match page with
    | Home -> "#home"
    | FableReactBulma pageType ->
        match pageType with
        | Element element ->
            match element with
            | Button -> "#fable-react-bulma/elements/button"
            | Icon -> "#fable-react-bulma/elements/icon"
            | Title -> "#fable-react-bulma/elements/title"
            | Delete -> "#fable-react-bulma/elements/delete"
            | Box -> "#fable-react-bulma/elements/box"
            | Content -> "#fable-react-bulma/elements/content"
            | Tag -> "#fable-react-bulma/elements/tag"
            | Image -> "#fable-react-bulma/elements/image"
            | Progress -> "#fable-react-bulma/elements/progress"
            | Table -> "#fable-react-bulma/elements/table"
            | Form -> "#fable-react-bulma/elements/form"
            | Notification -> "#fable-react-bulma/elements/notification"
        | Component ``component`` ->
            match ``component`` with
            | Panel -> "#fable-react-bulma/components/panel"
            | Level -> "#fable-react-bulma/components/level"
            | Breadcrumb -> "#fable-react-bulma/components/breadcrumb"
            | Card  -> "#fable-react-bulma/components/card"
            | Media -> "#fable-react-bulma/components/media"
            | Menu -> "#fable-react-bulma/components/menu"
            | Message -> "#fable-react-bulma/components/message"
            | Navbar -> "#fable-react-bulma/components/navbar"
            | Pagination -> "#fable-react-bulma/components/pagination"
            | Tabs -> "#fable-react-bulma/components/tabs"
