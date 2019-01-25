namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Breadcrumb =

    type Option =
        /// Add `is-centered` class
        | [<CompiledName("is-centered")>] IsCentered
        /// Add `is-right` class
        | [<CompiledName("is-right")>] IsRight
        /// Add `has-arrow-separator` class
        | [<CompiledName("has-arrow-separator")>] HasArrowSeparator
        /// Add `has-bullet-separator` class
        | [<CompiledName("has-bullet-separator")>] HasBulletSeparator
        /// Add `has-dot-separator` class
        | [<CompiledName("has-dot-separator")>] HasDotSeparator
        /// Add `has-succeeds-separator` class
        | [<CompiledName("has-succeeds-separator")>] HasSucceedsSeparator
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <nav class="breadcumb"></nav>
    let breadcrumb options children =
        let parseOption (result: GenericOptions) opt =
            match opt with
            | Props props -> result.AddProps props
            | Size size -> ofSize size |> result.AddClass
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers
            | IsCentered
            | IsRight
            // Separators
            | HasArrowSeparator
            | HasBulletSeparator
            | HasDotSeparator
            | HasSucceedsSeparator -> result.AddCaseName opt

        GenericOptions.Parse(options, parseOption, "breadcrumb")
                    .ToReactElement(nav, [ul [] children])

    module Item =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    /// Generate <li></li>
    let item (options: Item.Option list) children =
        let parseOption (result: GenericOptions) opt =
            match opt with
            | Item.IsActive state -> if state then result.AddCaseName opt else result
            | Item.Props props -> result.AddProps props
            | Item.CustomClass customClass -> result.AddClass customClass
            | Item.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption).ToReactElement(li, children)
