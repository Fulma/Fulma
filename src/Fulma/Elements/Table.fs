namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Table =

    type TableOption =
        /// Set `is-hovered` class
        | [<CompiledName("is-hovered")>]IsBordered
        /// Set `is-striped` class
        | [<CompiledName("is-striped")>]IsStriped
        /// Add `is-fullwidth` class
        | [<CompiledName("is-fullwidth")>]IsFullWidth
        /// Set `is-narrow` class
        | [<CompiledName("is-narrow")>]IsNarrow
        /// Set `is-hoverable` class
        | [<CompiledName("is-hoverable")>]IsHoverable
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <table class="table"></table>
    let table options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsBordered
            | IsStriped
            | IsFullWidth
            | IsNarrow
            | IsHoverable -> result.AddCaseName option
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "table").ToReactElement(table, children)
