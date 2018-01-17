namespace Fulma.Components

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Navbar =

    module Classes =
        let [<Literal>] Container = "navbar"
        let [<Literal>] Brand = "navbar-brand"
        let [<Literal>] Burger = "navbar-burger"
        let [<Literal>] Content = "navbar-content"
        let [<Literal>] Divider = "navbar-divider"
        let [<Literal>] Start = "navbar-start"
        let [<Literal>] End = "navbar-end"
        module Item =
            let [<Literal>] Container = "navbar-item"
            let [<Literal>] IsHoverable = "is-hoverable"
            let [<Literal>] IsExpanded = "is-expanded"
            module State =
                let [<Literal>] IsActive = "is-active"
            module Style =
                let [<Literal>] HasDropdown = "has-dropdown"
                let [<Literal>] IsTab = "is-tab"
        module Menu =
            let [<Literal>] Container = "navbar-menu"
            module State =
                let [<Literal>] IsActive = "is-active"
        module Link =
            let [<Literal>] Container = "navbar-link"
            module State =
                let [<Literal>] IsActive = "is-active"
        module Dropdown =
            let [<Literal>] Container = "navbar-dropdown"
            let [<Literal>] IsBoxed = "is-boxed"
            let [<Literal>] IsRight = "is-right"
            module State =
                let [<Literal>] IsActive = "is-active"
        module Style =
            let [<Literal>] HasShadow = "has-shadow"
            let [<Literal>] IsTransparent = "is-transparent"
            let [<Literal>] IsFixedTop = "is-fixed-top"
            let [<Literal>] IsFixedBottom = "is-fixed-bottom"

    type Option =
        | Color of IColor
        | HasShadow
        | IsTransparent
        | IsFixedTop
        | IsFixedBottom
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { HasShadow : bool
          Color : string option
          IsTransparent : bool
          FixedInfo : string option
          CustomClass : string option
          Props : IHTMLProp list }

        static member Empty =
            { HasShadow = false
              Color = None
              FixedInfo = None
              IsTransparent = false
              CustomClass = None
              Props = [] }

    module Menu =

        type Option =
            | IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string

        type internal Options =
            { IsActive : bool
              CustomClass : string option
              Props : IHTMLProp list }

            static member Empty =
                { IsActive = false
                  CustomClass = None
                  Props = [] }

    module Item =

        type Option =
            | IsTab
            | IsActive of bool
            | IsHoverable
            | HasDropdown
            | IsExpanded
            | Props of IHTMLProp list
            | CustomClass of string

        type internal Options =
            { IsTab : bool
              IsActive : bool
              IsHoverable : bool
              HasDropdown : bool
              IsExpanded : bool
              CustomClass : string option
              Props : IHTMLProp list }

            static member Empty =
                { IsTab = false
                  IsActive = false
                  IsHoverable = false
                  IsExpanded = false
                  HasDropdown = false
                  CustomClass = None
                  Props = [] }

        let internal item element options children =
            let parseOptions (result: Options ) opt =
                match opt with
                | IsActive state -> { result with IsActive = state }
                | IsExpanded -> { result with IsExpanded = true }
                | IsTab -> { result with IsTab = true }
                | IsHoverable -> { result with IsHoverable = true }
                | HasDropdown -> { result with HasDropdown = true }
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = Some customClass }

            let opts = options |> List.fold parseOptions Options.Empty
            let classes =
                Helpers.classes Classes.Item.Container [opts.CustomClass]
                    [ Classes.Item.State.IsActive, opts.IsActive
                      Classes.Item.Style.IsTab, opts.IsTab
                      Classes.Item.IsHoverable, opts.IsHoverable
                      Classes.Item.Style.HasDropdown, opts.HasDropdown
                      Classes.Item.IsExpanded, opts.IsExpanded ]

            element (classes::opts.Props) children

        let div x y = item div x y
        let a x y = item a x y

    module Link =

        type Option =
            | IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string

        type internal Options =
            { IsActive : bool
              CustomClass : string option
              Props : IHTMLProp list }

            static member Empty =
                { IsActive = false
                  CustomClass = None
                  Props = [] }

        let internal link element (options : Option list) children =
            let parseOptions (result : Options) opt =
                match opt with
                | IsActive state -> { result with IsActive = state }
                | CustomClass customClass -> { result with CustomClass = Some customClass}
                | Props props -> { result with Props = props}

            let opts = options |> List.fold parseOptions Options.Empty
            let classes = Helpers.classes Classes.Link.Container [] [Classes.Link.State.IsActive, opts.IsActive]
            element (classes::opts.Props) children

        let div x y = link div x y
        let a x y = link a x y

    module Dropdown =

        type Option =
            | IsActive of bool
            | IsBoxed
            | IsRight
            | Props of IHTMLProp list
            | CustomClass of string

        type internal Options =
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

        let internal dropdown element (options : Option list) children =
            let parseOptions (result : Options) opt =
                match opt with
                | IsActive state -> { result with IsActive = state }
                | IsBoxed -> { result with IsBoxed = true }
                | IsRight -> { result with IsRight = true }
                | CustomClass customClass -> { result with CustomClass = Some customClass}
                | Props props -> { result with Props = props}

            let opts = options |> List.fold parseOptions Options.Empty
            let classes = Helpers.classes Classes.Dropdown.Container [] [Classes.Dropdown.IsBoxed, opts.IsBoxed; Classes.Dropdown.IsRight, opts.IsRight; Classes.Dropdown.State.IsActive, opts.IsActive]
            element (classes::opts.Props) children

        let div x y = dropdown div x y
        let a x y = dropdown a x y

    module Brand =
        let internal brand element (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Brand [opts.CustomClass] []
            element (classes::opts.Props) children

        let div x y = brand div x y
        let a x y = brand a x y

    module Start =
        let internal start element (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Start [opts.CustomClass] []
            element (classes::opts.Props) children

        let div x y = start div x y
        let a x y = start a x y

    module End =
        let internal ``end`` element (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.End [opts.CustomClass] []
            element (classes::opts.Props) children

        let div x y = ``end`` div x y
        let a x y = ``end`` a x y

    let navbar (options : Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | HasShadow -> { result with HasShadow = true }
            | Props props -> { result with Props = props }
            | IsFixedTop -> { result with FixedInfo = Some Classes.Style.IsFixedTop }
            | IsFixedBotton  -> { result with FixedInfo = Some Classes.Style.IsFixedBotton  }
            | IsTransparent -> { result with IsTransparent = true }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Color color -> { result with Color = ofColor color |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            Helpers.classes Classes.Container [opts.CustomClass; opts.Color; opts.FixedInfo ]
               [ Classes.Style.HasShadow, opts.HasShadow
                 Classes.Style.IsTransparent, opts.IsTransparent]

        nav (classes::opts.Props) children

    let menu options children =
        let parseOptions (result: Menu.Options ) opt =
            match opt with
            | Menu.IsActive state -> { result with IsActive = state }
            | Menu.Props props -> { result with Props = props }
            | Menu.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Menu.Options.Empty
        let classes =
            Helpers.classes Classes.Menu.Container [opts.CustomClass]
                [Classes.Menu.State.IsActive, opts.IsActive]

        div (classes::opts.Props) children

    let burger (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Burger [opts.CustomClass] []
        div (classes::opts.Props) children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Content [opts.CustomClass] []
        div (classes::opts.Props) children

    let divider (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Divider [opts.CustomClass] []
        div (classes::opts.Props) children
