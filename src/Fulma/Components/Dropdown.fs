namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Dropdown =

    type Option =
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>] IsActive of bool
        /// Add `is-hoverable` class
        | [<CompiledName("is-hoverable")>] IsHoverable
        /// Add `is-right` class
        | [<CompiledName("is-right")>] IsRight
        /// Add `is-up` class
        | [<CompiledName("is-up")>] IsUp
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="dropdown"></div>
    let dropdown (options: Option list) children =
        let parseOption (result : GenericOptions) opt =
            match opt with
            | IsActive state -> if state then result.AddCaseName opt else result
            | IsRight
            | IsHoverable
            | IsUp as opt -> result.AddCaseName opt
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "dropdown").ToReactElement(div, children)

    /// Generate <div class="dropdown-menu"></div>
    let menu (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "dropdown-menu").ToReactElement(div, children)

    /// Generate <div class="dropdown-content"></div>
    let content (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "dropdown-content").ToReactElement(div, children)

    /// Generate <div class="dropdown-divider"></div>
    let divider (options: GenericOption list) =
        GenericOptions.Parse(options, parseOption, "dropdown-divider").ToReactElement(hr)

    module Item =
        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

        let internal item element (options: Option list) children =
            let parseOption (result : GenericOptions) opt =
                match opt with
                | IsActive state -> if state then result.AddCaseName opt else result
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOption, "dropdown-item").ToReactElement(element, children)

        /// Generate <div class="dropdown-item"></div>
        let div x y = item div x y

        /// Generate <a class="dropdown-item"></a>
        let a x y = item a x y

        /// Generate <button class="dropdown-item"></button>
        let button x y = item button x y
