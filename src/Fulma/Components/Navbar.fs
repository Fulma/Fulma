namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open System

[<RequireQualifiedAccess>]
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

    let inline hasShadow<'T> = Navbar.HasShadow
    let inline isTransparent<'T> = Navbar.IsTransparent
    let inline props props = Navbar.Props props
    let inline customClass x = Navbar.CustomClass x

    // Levels and colors
    let inline isBlack<'T> = Navbar.Level IsBlack
    let inline isDark<'T> = Navbar.Level IsDark
    let inline isLight<'T> = Navbar.Level IsLight
    let inline isWhite<'T> = Navbar.Level IsWhite
    let inline isPrimary<'T> = Navbar.Level IsPrimary
    let inline isInfo<'T> = Navbar.Level IsInfo
    let inline isSuccess<'T> = Navbar.Level IsSuccess
    let inline isWarning<'T> = Navbar.Level IsWarning
    let inline isDanger<'T> = Navbar.Level IsDanger

    module Item =
        let inline isActive<'T> = Item.IsActive
        let inline isHoverable<'T> = Item.IsHoverable
        let inline isTab<'T> = Item.IsTab
        let inline props props = Item.Props props
        let inline customClass x = Item.CustomClass x
        let inline hasDropdown<'T> = Item.HasDropdown


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
            let class' =
                Helpers.classes Bulma.Navbar.Item.Container [opts.CustomClass]
                    [ Bulma.Navbar.Item.State.IsActive, opts.IsActive
                      Bulma.Navbar.Item.Style.IsTab, opts.IsTab
                      Bulma.Navbar.Item.IsHoverable, opts.IsHoverable
                      Bulma.Navbar.Item.Style.HasDropdown, opts.HasDropdown ]

            element (class'::opts.Props) children

    module Link =
        let inline isActive<'T> = Link.IsActive
        let inline props props = Link.Props props
        let inline customClass x = Link.CustomClass x

        let link element (options : Link.Option list) children =
            let parseOptions (result : Link.Options) opt =
                match opt with
                | Link.IsActive -> { result with IsActive = true }
                | Link.CustomClass customClass -> { result with CustomClass = Some customClass}
                | Link.Props props -> { result with Props = props}

            let opts = options |> List.fold parseOptions Link.Options.Empty
            let class' = Helpers.classes Bulma.Navbar.Link.Container [] [Bulma.Navbar.Link.State.IsActive, opts.IsActive]
            element (class'::opts.Props) children

    module Menu =
        let inline isActive<'T> = Menu.IsActive
        let inline props props = Menu.Props props
        let inline customClass x = Menu.CustomClass x

    module Dropdown =
        let inline isActive<'T> = Dropdown.IsActive
        let inline isBoxed<'T> = Dropdown.IsBoxed
        let inline isRight<'T> = Dropdown.IsRight
        let inline props props = Dropdown.Props props
        let inline customClass x = Dropdown.CustomClass x

        let dropdown element (options : Dropdown.Option list) children =
            let parseOptions (result : Dropdown.Options) opt =
                match opt with
                | Dropdown.IsActive -> { result with IsActive = true }
                | Dropdown.IsBoxed -> { result with IsBoxed = true }
                | Dropdown.IsRight -> { result with IsRight = true }
                | Dropdown.CustomClass customClass -> { result with CustomClass = Some customClass}
                | Dropdown.Props props -> { result with Props = props}

            let opts = options |> List.fold parseOptions Dropdown.Options.Empty
            let class' = Helpers.classes Bulma.Navbar.Dropdown.Container [] [Bulma.Navbar.Dropdown.IsBoxed, opts.IsBoxed; Bulma.Navbar.Dropdown.IsRight, opts.IsRight; Bulma.Navbar.Dropdown.State.IsActive, opts.IsActive]
            element (class'::opts.Props) children

    module Brand =
        let brand element (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Navbar.Brand [opts.CustomClass] []
            element (class'::opts.Props) children

    module Start =
        let start element (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Navbar.Start [opts.CustomClass] []
            element (class'::opts.Props) children

    module End =

        let ``end`` element (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Navbar.End [opts.CustomClass] []
            element (class'::opts.Props) children

    let navbar (options : Navbar.Option list) children =
        let parseOptions (result: Navbar.Options ) opt =
            match opt with
            | Navbar.HasShadow -> { result with HasShadow = true }
            | Navbar.Props props -> { result with Props = props }
            | Navbar.IsTransparent -> { result with IsTransparent = true }
            | Navbar.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Navbar.Level level -> { result with Level = ofLevelAndColor level |> Some }

        let opts = options |> List.fold parseOptions Navbar.Options.Empty
        let class' =
            Helpers.classes Bulma.Navbar.Container [opts.CustomClass; opts.Level]
               [ Bulma.Navbar.Style.HasShadow, opts.HasShadow
                 Bulma.Navbar.Style.IsTransparent, opts.IsTransparent]

        nav (class'::opts.Props) children

    let inline link_a x y = Link.link a x y
    let inline link_div x y = Link.link div x y

    let inline item_a x y = Item.item a x y
    let inline item_div x y = Item.item div x y

    let inline dropdown_a x y = Dropdown.dropdown a x y
    let inline dropdown_div x y = Dropdown.dropdown div x y

    let inline brand_a x y = Brand.brand a x y
    let inline brand_div x y = Brand.brand div x y

    let inline start_a x y = Start.start a x y
    let inline start_div x y = Start.start div x y

    let inline end_a x y = End.``end`` a x y
    let inline end_div x y = End.``end`` div x y

    let menu options children =
        let parseOptions (result: Menu.Options ) opt =
            match opt with
            | Menu.IsActive -> { result with IsActive = true }
            | Menu.Props props -> { result with Props = props }
            | Menu.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Menu.Options.Empty
        let class' =
            Helpers.classes Bulma.Navbar.Menu.Container [opts.CustomClass]
                [Bulma.Navbar.Menu.State.IsActive, opts.IsActive]

        div (class'::opts.Props) children


    let burger (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Navbar.Burger [opts.CustomClass] []
        div (class'::opts.Props) children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Navbar.Content [opts.CustomClass] []
        div (class'::opts.Props) children

    let divider (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Navbar.Divider [opts.CustomClass] []
        div (class'::opts.Props) children
