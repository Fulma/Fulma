namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Divider =

    type Option =
        /// Add `is-divider-vertical` class if true
        | [<CompiledName("is-divider-vertical")>] IsVertical
        | Label of string
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="is-divider"></div>
    let divider (options : Option list) =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsVertical ->
                result.RemoveClass("is-divider").AddCaseName(option)
            | Label label -> Data("content", label) |> result.AddProp
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "is-divider").ToReactElement(div, [])
