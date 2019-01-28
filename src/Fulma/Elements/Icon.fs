namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Icon =

    type Option =
        // Sizes
        | Size of ISize
        /// Add `is-left` class
        | [<CompiledName("is-left")>] IsLeft
        /// Add `is-right` class
        | [<CompiledName("is-right")>] IsRight
        // Extra
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <span class="icon"></span>
    let icon options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            // Sizes
            | Size size -> ofSize size |> result.AddClass
            // Position
            | IsLeft
            | IsRight -> result.AddCaseName option
            // Extra
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "icon").ToReactElement(span, children)
