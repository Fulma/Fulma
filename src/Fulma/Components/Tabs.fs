namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Tabs =

    type Option =
        | Size of ISize
        /// Add `is-centered` class
        | [<CompiledName("is-centered")>] IsCentered
        /// Add `is-right` class
        | [<CompiledName("is-right")>] IsRight
        /// Add `is-boxed` class
        | [<CompiledName("is-boxed")>] IsBoxed
        /// Add `is-toggle` class
        | [<CompiledName("is-toggle")>] IsToggle
        /// Add `is-toggle-rounded` class
        | [<CompiledName("is-toggle-rounded")>] IsToggleRounded
        /// Add `is-fullwidth` class
        | [<CompiledName("is-fullwidth")>] IsFullWidth
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    module Tab =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | CustomClass of string
            | Props of IHTMLProp list
            | Modifiers of Modifier.IModifier list

    /// Generate <div class="tabs"><ul></ul></div>
    let tabs (options: Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsCentered
            | IsRight
            | IsBoxed
            | IsToggle
            | IsToggleRounded
            | IsFullWidth -> result.AddCaseName option
            | Size size -> ofSize size |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "tabs").ToReactElement(div, [ ul [ ] children ])

    /// Generate <li></li>
    let tab (options: Tab.Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Tab.IsActive state -> if state then result.AddCaseName option else result
            | Tab.Props props -> result.AddProps props
            | Tab.CustomClass customClass -> result.AddClass customClass
            | Tab.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions).ToReactElement(li, children)
