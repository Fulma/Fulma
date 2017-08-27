module Menu.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fable.React.Bulma.Components
open Fable.React.Bulma.Elements
open Global

let menuItem label page currentPage =
    li []
       [ a [ classList [ "is-active", page = currentPage ]
             Href(toHash page) ]
           [ str label ] ]

let root model dispatch =
    let elementsClass =
        if not model.FableReactBulma.IsElementsExpanded then
            match model.CurrentPage with
            | FableReactBulma (Element _) ->
                "is-active"
            | _ -> ""
        else
            ""

    let componentsClass =
        if not model.FableReactBulma.IsComponentsExpanded then
            match model.CurrentPage with
            | FableReactBulma (Component _) ->
                "is-active"
            | _ -> ""
        else
            ""

    Menu.menu [ ]
        [ Menu.list [ ]
            [ menuItem "Home" Home model.CurrentPage ]
          Menu.label [ ] [ str "Fable.React.Bulma" ]
          Menu.list [ ]
            [ li [ ]
                 //Dummy class name to prevent default link style
                 [ yield a [ ClassName elementsClass
                             OnClick (fun _ -> ToggleMenu (Library.FableReactBulma Elements) |> dispatch ) ]
                           [ str "Elements" ]
                   if model.FableReactBulma.IsElementsExpanded then
                        yield ul [ ]
                                 [ menuItem "Button" (FableReactBulma (Element Elements.Button)) model.CurrentPage
                                   menuItem "Icon" (FableReactBulma (Element Elements.Icon)) model.CurrentPage
                                   menuItem "Image" (FableReactBulma (Element Elements.Image)) model.CurrentPage
                                   menuItem "Title" (FableReactBulma (Element Elements.Title)) model.CurrentPage
                                   menuItem "Delete" (FableReactBulma (Element Elements.Delete)) model.CurrentPage
                                   menuItem "Progress" (FableReactBulma (Element Elements.Progress))  model.CurrentPage
                                   menuItem "Box" (FableReactBulma (Element Elements.Box)) model.CurrentPage
                                   menuItem "Content" (FableReactBulma (Element Elements.Content))  model.CurrentPage
                                   menuItem "Table" (FableReactBulma (Element Elements.Table)) model.CurrentPage
                                   //menuItem "Form" (FableReactBulma (Element Elements.Form)) model.CurrentPage
                                   menuItem "Notification" (FableReactBulma (Element Elements.Notification)) model.CurrentPage
                                   menuItem "Tag" (FableReactBulma (Element Elements.Tag)) model.CurrentPage ] ] ]
          Menu.list [ ]
            [ li [ ]
                 [ yield a [ ClassName componentsClass
                             OnClick (fun _ -> ToggleMenu (Library.FableReactBulma Components) |> dispatch ) ]
                           [ str "Components" ]
                   if model.FableReactBulma.IsComponentsExpanded then
                        yield ul [ ]
                                 [ menuItem "Panel" (FableReactBulma (Component Components.Panel)) model.CurrentPage
                                   menuItem "Level" (FableReactBulma (Component Components.Level)) model.CurrentPage
                                   menuItem "Breadcrumb" (FableReactBulma (Component Components.Breadcrumb)) model.CurrentPage
                                   menuItem "Card" (FableReactBulma (Component Components.Card)) model.CurrentPage
                                   menuItem "Media" (FableReactBulma (Component Components.Media)) model.CurrentPage
                                   menuItem "Menu" (FableReactBulma (Component Components.Menu)) model.CurrentPage
                                   menuItem "Navbar" (FableReactBulma (Component Components.Navbar)) model.CurrentPage
                                   menuItem "Pagination" (FableReactBulma (Component Components.Pagination)) model.CurrentPage
                                   menuItem "Tabs" (FableReactBulma (Component Components.Tabs)) model.CurrentPage
                                   menuItem "Message" (FableReactBulma (Component Components.Message)) model.CurrentPage ] ] ] ]
