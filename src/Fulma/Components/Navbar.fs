namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open System

module Navbar =

    module Types =

        module Navbar =

            type Option =
                | Level of ILevelAndColor
                | HasShadow
                | IsTransparent
                | Props of IHTMLProp list
                | CustomClass of string

            type Options =
                { HasShadow : bool
                  Level : string option
                  IsTransparent : bool
                  CustomClass : string option
                  Props : IHTMLProp list }

                static member Empty =
                    { HasShadow = false
                      Level = None
                      IsTransparent = false
                      CustomClass = None
                      Props = [] }


        module Item =

            type Option =
                | IsTab
                | IsActive
                | IsHoverable
                | HasDropdown
                | Props of IHTMLProp list
                | CustomClass of string

            type Options =
                { IsTab : bool
                  IsActive : bool
                  IsHoverable : bool
                  HasDropdown : bool
                  CustomClass : string option
                  Props : IHTMLProp list }

                static member Empty =
                    { IsTab = false
                      IsActive = false
                      IsHoverable = false
                      HasDropdown = false
                      CustomClass = None
                      Props = [] }

        module Link =

            type Option =
                | IsActive
                | Props of IHTMLProp list
                | CustomClass of string

            type Options =
                { IsActive : bool
                  CustomClass : string option
                  Props : IHTMLProp list }

                static member Empty =
                    { IsActive = false
                      CustomClass = None
                      Props = [] }

        module Menu =

            type Option =
                | IsActive
                | Props of IHTMLProp list
                | CustomClass of string

            type Options =
                { IsActive : bool
                  CustomClass : string option
                  Props : IHTMLProp list }

                static member Empty =
                    { IsActive = false
                      CustomClass = None
                      Props = [] }

        module Dropdown =

            type Option =
                | IsActive
                | IsBoxed
                | IsRight
                | Props of IHTMLProp list
                | CustomClass of string


            type Options =
                { IsActive : bool
                  IsBoxed : bool
                  IsRight : bool
                  Props : IHTMLProp list
                  CustomClass : string option }

                static member Empty =
                    { IsActive = false
                      IsBoxed = false
                      IsRight = false
                      Props = []
                      CustomClass = None }

    open Types

    // Helpers definitions

    let hasShadow = Navbar.HasShadow
    let isTransparent = Navbar.IsTransparent
    let props props = Navbar.Props props
    let customClass = Navbar.CustomClass

    // Levels and colors
    let isBlack = Navbar.Level IsBlack
    let isDark = Navbar.Level IsDark
    let isLight = Navbar.Level IsLight
    let isWhite = Navbar.Level IsWhite
    let isPrimary = Navbar.Level IsPrimary
    let isInfo = Navbar.Level IsInfo
    let isSuccess = Navbar.Level IsSuccess
    let isWarning = Navbar.Level IsWarning
    let isDanger = Navbar.Level IsDanger

    module Item =
        let isActive = Item.IsActive
        let isHoverable = Item.IsHoverable
        let isTab = Item.IsTab
        let props props = Item.Props props
        let customClass = Item.CustomClass
        let hasDropdown = Item.HasDropdown


        let item element options children =
            let parseOptions (result: Item.Options ) opt =
                match opt with
                | Item.IsActive -> { result with IsActive = true }
                | Item.IsTab -> { result with IsTab = true }
                | Item.IsHoverable -> { result with IsHoverable = true }
                | Item.HasDropdown -> { result with HasDropdown = true }
                | Item.Props props -> { result with Props = props }
                | Item.CustomClass customClass -> { result with CustomClass = Some customClass }

            let opts = options |> List.fold parseOptions Item.Options.Empty

            element [ yield (classBaseList Bulma.Navbar.Item.Container
                                      [ Bulma.Navbar.Item.State.IsActive, opts.IsActive
                                        Bulma.Navbar.Item.Style.IsTab, opts.IsTab
                                        Bulma.Navbar.Item.IsHoverable, opts.IsHoverable
                                        Bulma.Navbar.Item.Style.HasDropdown, opts.HasDropdown
                                        opts.CustomClass.Value, opts.CustomClass.IsSome ]) :> IHTMLProp
                      yield! opts.Props ]
                children

    module Link =
        let isActive = Link.IsActive
        let props props = Link.Props props
        let customClass = Link.CustomClass

        let link element (options : Link.Option list) children =
            let parseOptions (result : Link.Options) opt =
                match opt with
                | Link.IsActive -> { result with IsActive = true }
                | Link.CustomClass customClass -> { result with CustomClass = Some customClass}
                | Link.Props props -> { result with Props = props}

            let opts = options |> List.fold parseOptions Link.Options.Empty

            element [ yield (classBaseList Bulma.Navbar.Link.Container
                                       [ Bulma.Navbar.Link.State.IsActive, opts.IsActive ]) :> IHTMLProp
                      yield! opts.Props ]
                children

    module Menu =
        let isActive = Menu.IsActive
        let props props = Menu.Props props
        let customClass = Menu.CustomClass

    module Dropdown =
        let isActive = Dropdown.IsActive
        let isBoxed = Dropdown.IsBoxed
        let isRight = Dropdown.IsRight
        let props = Dropdown.Props
        let customClass = Dropdown.CustomClass

        let dropdown element (options : Dropdown.Option list) children =
            let parseOptions (result : Dropdown.Options) opt =
                match opt with
                | Dropdown.IsActive -> { result with IsActive = true }
                | Dropdown.IsBoxed -> { result with IsBoxed = true }
                | Dropdown.IsRight -> { result with IsRight = true }
                | Dropdown.CustomClass customClass -> { result with CustomClass = Some customClass}
                | Dropdown.Props props -> { result with Props = props}

            let opts = options |> List.fold parseOptions Dropdown.Options.Empty

            element [ yield (classBaseList Bulma.Navbar.Dropdown.Container
                                       [ Bulma.Navbar.Dropdown.IsBoxed, opts.IsBoxed
                                         Bulma.Navbar.Dropdown.IsRight, opts.IsRight
                                         Bulma.Navbar.Dropdown.State.IsActive, opts.IsActive ]) :> IHTMLProp
                      yield! opts.Props ]
                children

    module Brand =
        let brand element (options: GenericOption list) children =
            let opts = genericParse options

            element [ yield classBaseList Bulma.Navbar.Brand
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                      yield! opts.Props ]
                children

    module Start =
        let start element (options: GenericOption list) children =
            let opts = genericParse options

            element [ yield classBaseList Bulma.Navbar.Start
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                      yield! opts.Props ]
                children

    module End =

        let ``end`` element (options: GenericOption list) children =
            let opts = genericParse options

            element [ yield classBaseList Bulma.Navbar.End
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                      yield! opts.Props ]
                children

    let navbar (options : Navbar.Option list) children =
        let parseOptions (result: Navbar.Options ) opt =
            match opt with
            | Navbar.HasShadow -> { result with HasShadow = true }
            | Navbar.Props props -> { result with Props = props }
            | Navbar.IsTransparent -> { result with IsTransparent = true }
            | Navbar.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Navbar.Level level -> { result with Level = ofLevelAndColor level |> Some }

        let opts = options |> List.fold parseOptions Navbar.Options.Empty

        nav [ yield (classBaseList Bulma.Navbar.Container
                                   [ Bulma.Navbar.Style.HasShadow, opts.HasShadow
                                     opts.CustomClass.Value, opts.CustomClass.IsSome
                                     opts.Level.Value, opts.Level.IsSome
                                     Bulma.Navbar.Style.IsTransparent, opts.IsTransparent]) :> IHTMLProp
              yield! opts.Props ]
            children

    let link_a = Link.link a
    let link_div = Link.link div

    let item_a = Item.item a
    let item_div = Item.item div

    let dropdown_a = Dropdown.dropdown a
    let dropdown_div = Dropdown.dropdown div

    let brand_a = Brand.brand a
    let brand_div = Brand.brand div

    let start_a = Start.start a
    let start_div = Start.start div

    let end_a = End.``end`` a
    let end_div = End.``end`` div

    let menu options children =
        let parseOptions (result: Menu.Options ) opt =
            match opt with
            | Menu.IsActive -> { result with IsActive = true }
            | Menu.Props props -> { result with Props = props }
            | Menu.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Menu.Options.Empty

        div [ yield (classBaseList Bulma.Navbar.Menu.Container
                                    [ Bulma.Navbar.Menu.State.IsActive, opts.IsActive
                                      opts.CustomClass.Value, opts.CustomClass.IsSome ]) :> IHTMLProp
              yield! opts.Props ]
              children


    let burger (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Navbar.Burger
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let content (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Navbar.Content
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let divider (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Navbar.Divider
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
