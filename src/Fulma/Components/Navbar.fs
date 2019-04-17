namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Navbar =

    type Option =
        | Color of IColor
        /// Add `has-shadow` class
        | [<CompiledName("has-shadow")>] HasShadow
        /// Add `is-transparent` class
        | [<CompiledName("is-transparent")>] IsTransparent
        /// Add `is-fixed-top` class
        /// You also need to add `has-navbar-fixed-top` to your html tag
        | [<CompiledName("is-fixed-top")>] IsFixedTop
        /// Add `is-fixed-bottom` class
        /// You also need to add `has-navbar-fixed-bottom` to your html tag
        | [<CompiledName("is-fixed-bottom")>] IsFixedBottom
        /// Add `is-spaced` class
        /// Increases horizontal and vertical padding of the navbar
        | [<CompiledName("is-spaced")>] IsSpaced
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    module Menu =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    module Item =

        type Option =
            /// Add `is-tab` class
            | [<CompiledName("is-tab")>] IsTab
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            /// Add `is-hoverable` class
            | [<CompiledName("is-hoverable")>] IsHoverable
            /// Add `has-dropdown` class
            | [<CompiledName("has-dropdown")>] HasDropdown
            /// Add `is-expanded` class
            | [<CompiledName("is-expanded")>] IsExpanded
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

        let internal item element options children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | IsActive state -> if state then result.AddCaseName option else result
                | IsExpanded
                | IsTab
                | IsHoverable
                | HasDropdown -> result.AddCaseName option
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOptions, "navbar-item").ToReactElement(element, children)

        /// Generate <div class="navbar-item"></div>
        let div x y = item div x y
        /// Generate <a class="navbar-item"></a>
        let a x y = item a x y

    module Link =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            /// Add `is-arrowless`
            | [<CompiledName("is-arrowless")>] IsArrowless
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

        let internal link element (options : Option list) children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | IsActive state -> if state then result.AddCaseName option else result
                | IsArrowless -> result.AddCaseName option
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOptions, "navbar-link").ToReactElement(element, children)

        /// Generate <div class="navbar-link"></div>
        let div x y = link div x y
        /// Generate <a class="navbar-link"></a>
        let a x y = link a x y

    module Dropdown =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            /// Add `is-boxed` class
            | [<CompiledName("is-boxed")>] IsBoxed
            /// Add `is-right` class
            | [<CompiledName("is-right")>] IsRight
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

        let internal dropdown element (options : Option list) children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | IsActive state -> if state then result.AddCaseName option else result
                | IsBoxed
                | IsRight -> result.AddCaseName option
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOptions, "navbar-dropdown").ToReactElement(element, children)

        /// Generate <div class="navbar-dropdown"></div>
        let div x y = dropdown div x y
        /// Generate <a class="navbar-dropdown"></a>
        let a x y = dropdown a x y

    module Brand =
        let internal brand element (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "navbar-brand").ToReactElement(element, children)

        /// Generate <div class="navbar-brand"></div>
        let div x y = brand div x y
        /// Generate <a class="navbar-brand"></a>
        let a x y = brand a x y

    module Start =
        let internal start element (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "navbar-start").ToReactElement(element, children)

        /// Generate <div class="navbar-start"></div>
        let div x y = start div x y
        /// Generate <a class="navbar-start"></a>
        let a x y = start a x y

    module End =
        let internal ``end`` element (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "navbar-end").ToReactElement(element, children)

        /// Generate <div class="navbar-end"></div>
        let div x y = ``end`` div x y
        /// Generate <a class="navbar-end"></a>
        let a x y = ``end`` a x y

    /// Generate <nav class="navbar"></nav>
    let navbar (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | HasShadow
            | IsFixedTop
            | IsFixedBottom
            | IsTransparent
            | IsSpaced -> result.AddCaseName option
            | Color color -> ofColor color |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "navbar").ToReactElement(nav, children)

    /// Generate <div class="navbar-menu"></div>
    let menu options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Menu.IsActive state -> if state then result.AddCaseName option else result
            | Menu.Props props -> result.AddProps props
            | Menu.CustomClass customClass -> result.AddClass customClass
            | Menu.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "navbar-menu").ToReactElement(div, children)

    /// Generate <div class="navbar-burger"></div>
    let burger (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "navbar-burger").ToReactElement(div, children)

    /// Generate <div class="navbar-content"></div>
    let content (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "navbar-content").ToReactElement(div, children)

    /// Generate <div class="navbar-divider"></div>
    let divider (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "navbar-divider").ToReactElement(div, children)
