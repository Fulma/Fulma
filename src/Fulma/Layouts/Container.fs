namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Container =

    type Option =
        /// Add `is-fluid` class
        | [<CompiledName("is-fluid")>] IsFluid
        /// Add `is-widescreen` class
        | [<CompiledName("is-widescreen")>] IsWideScreen
        /// Add `is-fullhd` class
        | [<CompiledName("is-fullhd")>] IsFullHD
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="container"></div>
    let container (options: Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsFluid
            | IsWideScreen
            | IsFullHD -> result.AddCaseName option
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "container").ToReactElement(div, children)
