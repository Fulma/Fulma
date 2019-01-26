namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Section =

    type Option =
        | Props of IHTMLProp list
        | CustomClass of string
        /// Add `is-medium` class
        | [<CompiledName("is-medium")>] IsMedium
        /// Add `is-large` class
        | [<CompiledName("is-large")>] IsLarge
        | Modifiers of Modifier.IModifier list

    /// Generate <section class="section"></section>
    let section (options: Option list) children =
        let parseOption (result: GenericOptions) opt =
            match opt with
            | IsMedium
            | IsLarge -> result.AddCaseName opt
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "section").ToReactElement(section, children)
