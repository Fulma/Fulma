module Widgets.Menu

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Elmish
open Fulma
open Fable.FontAwesome

type FulmaModules =
    | Elements
    | Components
    | Layouts
    | Modifiers

type Library =
    | Fulma of FulmaModules

type Fulma =
    { IsElementsExpanded : bool
      IsComponentsExpanded : bool
      IsLayoutExpanded : bool
      IsChangeLogExpanded : bool
      IsModifiersExpanded : bool }

type Model =
    { Fulma : Fulma
      CurrentPage : Router.Page }

type Msg =
    | ToggleMenu of Library

let init currentPage : Model =
    { Fulma =
            { IsElementsExpanded = false
              IsComponentsExpanded = false
              IsLayoutExpanded = false
              IsChangeLogExpanded = false
              IsModifiersExpanded = false }
      CurrentPage = currentPage }

let update msg model =
    match msg with
    | ToggleMenu library ->
        match library with
        | Fulma ``module`` ->
            match ``module`` with
            | Elements ->
                { model with Fulma =
                                { model.Fulma with IsElementsExpanded = not model.Fulma.IsElementsExpanded } }
            | Components ->
                { model with Fulma =
                                { model.Fulma with IsComponentsExpanded = not model.Fulma.IsComponentsExpanded } }

            | Layouts ->
                { model with Fulma =
                                { model.Fulma with IsLayoutExpanded = not model.Fulma.IsLayoutExpanded } }

            | Modifiers ->
                { model with Fulma =
                                { model.Fulma with IsModifiersExpanded = not model.Fulma.IsModifiersExpanded } }

        , Cmd.none

open Router

let private menuItem label page currentPage =
    li []
       [ a [ classList [ "is-active", page = currentPage ]
             Router.href page ]
           [ str label ] ]

let private menuFulma currentPage subModel dispatch =
    let (elementsClass, elementsIcon) =
        if not subModel.IsElementsExpanded then
            match currentPage with
            | Fulma (Element _) ->
                "menu-group is-active", Fa.Solid.AngleDown
            | _ -> "menu-group", Fa.Solid.AngleDown
        else
            "menu-group", Fa.Solid.AngleUp

    let (componentsClass, componentsIcon) =
        if not subModel.IsComponentsExpanded then
            match currentPage with
            | Fulma (Component _) ->
                "menu-group is-active", Fa.Solid.AngleDown
            | _ -> "menu-group", Fa.Solid.AngleDown
        else
            "menu-group", Fa.Solid.AngleUp

    let (layoutsClass, layoutsIcon) =
        if not subModel.IsLayoutExpanded then
            match currentPage with
            | Fulma (Layout _) ->
                "menu-group is-active", Fa.Solid.AngleDown
            | _ -> "menu-group", Fa.Solid.AngleDown
        else
            "menu-group", Fa.Solid.AngleUp

    let (modifiersClass, modifiersIcon) =
        if not subModel.IsModifiersExpanded then
            match currentPage with
            | Fulma (Modifier _) ->
                "menu-group is-active", Fa.Solid.AngleDown
            | _ -> "menu-group", Fa.Solid.AngleDown
        else
            "menu-group", Fa.Solid.AngleUp

    [ Menu.label [ ] [ str "Fulma" ]
      Menu.list [ ]
        [ menuItem "Introduction" (Fulma FulmaPage.Introduction) currentPage
          menuItem "Versions" (Fulma FulmaPage.Versions) currentPage ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName modifiersClass
                         OnClick (fun _ -> ToggleMenu (Library.Fulma Modifiers) |> dispatch ) ]
                       [ span [ ]
                            [ str "Modifiers" ]
                         Icon.icon [ ]
                            [ Fa.i [ modifiersIcon ]
                                [ ] ] ]
               if subModel.IsModifiersExpanded then
                    yield ul [ ]
                             [ menuItem "Basics" (Fulma (Modifier Modifiers.Basics)) currentPage
                               menuItem "Colors & Shades" (Fulma (Modifier Modifiers.Colors)) currentPage
                               menuItem "Typography" (Fulma (Modifier Modifiers.Typography)) currentPage
                               menuItem "Responsive" (Fulma (Modifier Modifiers.Responsive)) currentPage ] ] ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName layoutsClass
                         OnClick (fun _ -> ToggleMenu (Library.Fulma Layouts) |> dispatch ) ]
                       [ span [ ] [ str "Layouts" ]
                         Icon.icon [ ]
                            [ Fa.i [ layoutsIcon ]
                                [ ] ] ]
               if subModel.IsLayoutExpanded then
                    yield ul [ ]
                             [ menuItem "Columns" (Fulma (Layout Layouts.Columns)) currentPage
                               menuItem "Container" (Fulma (Layout Layouts.Container)) currentPage
                               menuItem "Footer" (Fulma (Layout Layouts.Footer)) currentPage
                               menuItem "Hero" (Fulma (Layout Layouts.Hero)) currentPage
                               menuItem "Level" (Fulma (Layout Layouts.Level)) currentPage
                               menuItem "Section" (Fulma (Layout Layouts.Section)) currentPage
                               menuItem "Tile" (Fulma (Layout Layouts.Tile)) currentPage ] ] ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName elementsClass
                         OnClick (fun _ -> ToggleMenu (Library.Fulma Elements) |> dispatch ) ]
                       [ span [ ] [ str "Elements" ]
                         Icon.icon [ ]
                            [ Fa.i [ elementsIcon ]
                                [ ] ] ]
               if subModel.IsElementsExpanded then
                    yield ul [ ]
                             [ menuItem "Box" (Fulma (Element Elements.Box)) currentPage
                               menuItem "Button" (Fulma (Element Elements.Button)) currentPage
                               menuItem "Content" (Fulma (Element Elements.Content))  currentPage
                               menuItem "Delete" (Fulma (Element Elements.Delete)) currentPage
                               menuItem "Form" (Fulma (Element Elements.Form)) currentPage
                               menuItem "Icon" (Fulma (Element Elements.Icon)) currentPage
                               menuItem "Image" (Fulma (Element Elements.Image)) currentPage
                               menuItem "Notification" (Fulma (Element Elements.Notification)) currentPage
                               menuItem "Progress" (Fulma (Element Elements.Progress))  currentPage
                               menuItem "Table" (Fulma (Element Elements.Table)) currentPage
                               menuItem "Tag" (Fulma (Element Elements.Tag)) currentPage
                               menuItem "Title" (Fulma (Element Elements.Title)) currentPage ] ] ]
      Menu.list [ ]
        [ li [ ]
             [ yield a [ ClassName componentsClass
                         OnClick (fun _ -> ToggleMenu (Library.Fulma Components) |> dispatch ) ]
                       [ span [ ] [ str "Components" ]
                         Icon.icon [ ]
                            [ Fa.i [ componentsIcon ]
                                [ ] ] ]
               if subModel.IsComponentsExpanded then
                    yield ul [ ]
                             [ menuItem "Breadcrumb" (Fulma (Component Components.Breadcrumb)) currentPage
                               menuItem "Card" (Fulma (Component Components.Card)) currentPage
                               menuItem "Dropdown" (Fulma (Component Components.Dropdown)) currentPage
                               menuItem "Media" (Fulma (Component Components.Media)) currentPage
                               menuItem "Menu" (Fulma (Component Components.Menu)) currentPage
                               menuItem "Message" (Fulma (Component Components.Message)) currentPage
                               menuItem "Modal" (Fulma (Component Components.Modal)) currentPage
                               menuItem "Navbar" (Fulma (Component Components.Navbar)) currentPage
                               menuItem "Pagination" (Fulma (Component Components.Pagination)) currentPage
                               menuItem "Panel" (Fulma (Component Components.Panel)) currentPage
                               menuItem "Tabs" (Fulma (Component Components.Tabs)) currentPage ] ] ] ]

let private menuFableFontAwesome currentPage =
    [ Menu.label [ ] [ str "Fable.FontAwesome" ]
      Menu.list [ ]
        [ menuItem "Introduction" (FableFontAwesome FableFontAwesomePage.Introduction) currentPage ]
      Menu.list [ ]
        [ menuItem "Usage" (FableFontAwesome FableFontAwesomePage.Usage) currentPage ] ]

let private menuFulmaExtensions currentPage =
    [ Menu.label [ ] [ str "Fulma.Extensions.Wikiki" ]
      Menu.list [ ]
        [ menuItem "Calendar" (FulmaExtensions Calendar) currentPage
          menuItem "Checkradio" (FulmaExtensions Checkradio) currentPage
          menuItem "Divider" (FulmaExtensions Divider) currentPage
          menuItem "Page-loader" (FulmaExtensions PageLoader) currentPage
          menuItem "Quickview" (FulmaExtensions Quickview) currentPage
          menuItem "Slider" (FulmaExtensions Slider) currentPage
          menuItem "Switch" (FulmaExtensions Switch) currentPage
          menuItem "Tooltip" (FulmaExtensions Tooltip) currentPage ] ]

let private menuFulmaElmish currentPage =
    [ Menu.label [ ] [ str "Fulma.Elmish" ]
      Menu.list [ ]
        [ menuItem "Introduction" (FulmaElmish FulmaElmishPage.Introduction) currentPage ]
      Menu.list [ ]
        [ menuItem "Date picker" (FulmaElmish DatePicker) currentPage ] ]

let view model dispatch =
    Menu.menu [ ]
        [ yield Menu.list [ ]
                   [ menuItem "Introduction" Home model.CurrentPage
                     menuItem "Demo" Showcase model.CurrentPage
                     menuItem "Template" Template model.CurrentPage
                     menuItem "Blog" BlogIndex model.CurrentPage ]
          yield! menuFulma model.CurrentPage model.Fulma dispatch
          yield! menuFableFontAwesome model.CurrentPage
          yield! menuFulmaExtensions model.CurrentPage
          yield! menuFulmaElmish model.CurrentPage ]
