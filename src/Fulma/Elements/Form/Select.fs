namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Select =

    type Option =
        | Size of ISize
        /// Add `is-fullwidth` class
        | [<CompiledName("is-fullwidth")>] IsFullWidth
        /// Add `is-inline` class
        | [<CompiledName("is-inline")>] IsInline
        /// Add `is-loading` class if true
        | [<CompiledName("is-loading")>] IsLoading of bool
        /// Add `is-focused` class if true
        | [<CompiledName("is-focused")>] IsFocused of bool
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>] IsActive of bool
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        | Color of IColor
        /// Add `is-rounded` class
        | [<CompiledName("is-rounded")>] IsRounded
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="select"></div>
    let select (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Size size -> ofSize size |> result.AddClass
            | Color color -> ofColor color |> result.AddClass
            | IsFullWidth
            | IsInline
            | IsRounded -> result.AddCaseName option
            | IsLoading state
            | IsFocused state
            | IsActive state
            | Disabled state -> if state then result.AddCaseName option else result
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "select").ToReactElement(div, children)
