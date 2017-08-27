module Menu.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fable.React.Bulma.Components
open Fable.React.Bulma.Elements
open Fable.React.Bulma.Extra.FontAwesome
open Global

let menuItem label page currentPage =
    li []
       [ a [ classList [ "is-active", page = currentPage ]
             Href(toHash page) ]
           [ str label ] ]

let menuFableReactBulma currentPage subModel dispatch =
    let (elementsClass, elementsIcon) =
        if not subModel.IsElementsExpanded then
            match currentPage with
            | FableReactBulma (Element _) ->
                "menu-group is-active", Fa.AngleDown
            | _ -> "menu-group", Fa.AngleDown
        else
            "menu-group", Fa.AngleUp

    let (componentsClass, componentsIcon) =
        if not subModel.IsComponentsExpanded then
            match currentPage with
            | FableReactBulma (Component _) ->
                "menu-group is-active", Fa.AngleDown
            | _ -> "menu-group", Fa.AngleDown
        else
            "menu-group", Fa.AngleUp

    [ Menu.label [ ] [ str "Fable.React.Bulma" ]
      Menu.list [ ]
        [ li [ ]
             //Dummy class name to prevent default link style
             [ yield a [ ClassName elementsClass
                         OnClick (fun _ -> ToggleMenu (Library.FableReactBulma Elements) |> dispatch ) ]
                       [ span [ ] [ str "Elements" ]
                         Icon.faIcon [ ] elementsIcon ]
               if subModel.IsElementsExpanded then
                    yield ul [ ]
                             [ menuItem "Button" (FableReactBulma (Element Elements.Button)) currentPage
                               menuItem "Icon" (FableReactBulma (Element Elements.Icon)) currentPage
                               menuItem "Image" (FableReactBulma (Element Elements.Image)) currentPage
                               menuItem "Title" (FableReactBulma (Element Elements.Title)) currentPage
                               menuItem "Delete" (FableReactBulma (Element Elements.Delete)) currentPage
                               menuItem "Progress" (FableReactBulma (Element Elements.Progress))  currentPage
                               menuItem "Box" (FableReactBulma (Element Elements.Box)) currentPage
                               menuItem "Content" (FableReactBulma (Element Elements.Content))  currentPage
                               menuItem "Table" (FableReactBulma (Element Elements.Table)) currentPage
                               //menuItem "Form" (FableReactBulma (Element Elements.Form)) currentPage
                               menuItem "Notification" (FableReactBulma (Element Elements.Notification)) currentPage
                               menuItem "Tag" (FableReactBulma (Element Elements.Tag)) currentPage ] ] ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName componentsClass
                         OnClick (fun _ -> ToggleMenu (Library.FableReactBulma Components) |> dispatch ) ]
                       [ span [ ] [ str "Components" ]
                         Icon.faIcon [ ] componentsIcon ]
               if subModel.IsComponentsExpanded then
                    yield ul [ ]
                             [ menuItem "Panel" (FableReactBulma (Component Components.Panel)) currentPage
                               menuItem "Level" (FableReactBulma (Component Components.Level)) currentPage
                               menuItem "Breadcrumb" (FableReactBulma (Component Components.Breadcrumb)) currentPage
                               menuItem "Card" (FableReactBulma (Component Components.Card)) currentPage
                               menuItem "Media" (FableReactBulma (Component Components.Media)) currentPage
                               menuItem "Menu" (FableReactBulma (Component Components.Menu)) currentPage
                               menuItem "Navbar" (FableReactBulma (Component Components.Navbar)) currentPage
                               menuItem "Pagination" (FableReactBulma (Component Components.Pagination)) currentPage
                               menuItem "Tabs" (FableReactBulma (Component Components.Tabs)) currentPage
                               menuItem "Message" (FableReactBulma (Component Components.Message)) currentPage ] ] ] ]

let root model dispatch =
    Menu.menu [ ]
        [ yield Menu.list [ ]
                    [ menuItem "Home" Home model.CurrentPage ]
          yield! menuFableReactBulma model.CurrentPage model.FableReactBulma dispatch ]
