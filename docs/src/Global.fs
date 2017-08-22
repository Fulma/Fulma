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

type Page =
    | Home
    | Element of Elements
    | Component of Components

let toHash page =
    match page with
    | Home -> "#home"
    | Element element ->
        match element with
        | Button -> "#elements/button"
        | Icon -> "#elements/icon"
        | Title -> "#elements/title"
        | Delete -> "#elements/delete"
        | Box -> "#elements/box"
        | Content -> "#elements/content"
        | Tag -> "#elements/tag"
        | Image -> "#elements/image"
        | Progress -> "#elements/progress"
        | Table -> "#elements/table"
        | Form -> "#elements/form"
    | Component ``component`` ->
        match ``component`` with
        | Panel -> "#components/panel"
        | Level -> "#components/level"
        | Breadcrumb -> "#components/breadcrumb"
        | Card  -> "#components/card"
        | Media -> "#components/media"
        | Menu -> "#components/menu"
        | Message -> "#components/message"
        | Navbar -> "#components/navbar"
        | Pagination -> "#components/pagination"
        | Tabs -> "#components/tabs"
