namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Control =

    type Option =
        /// Add `has-icons-right` class
        | [<CompiledName("has-icons-right")>] HasIconRight
        /// Add `has-icons-left` class
        | [<CompiledName("has-icons-left")>] HasIconLeft
        /// Add `is-loading` class if true
        | [<CompiledName("is-loading")>] IsLoading of bool
        /// Add `is-expanded` class
        | [<CompiledName("is-expanded")>] IsExpanded
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    let internal controlView element options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | HasIconRight
            | HasIconLeft
            | IsExpanded -> result.AddCaseName option
            | IsLoading state -> if state then result.AddCaseName option else result
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "control").ToReactElement(element, children)

    /// Generate <div class="control"></div>
    let div x y = controlView div x y
    /// Generate <p class="control"></p>
    let p x y = controlView p x y
