namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module PageLoader =

    type Option =
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>] IsActive of bool
        | Color of IColor
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="pageloader"></div>
    let pageLoader (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Option.Color color -> ofColor color |> result.AddClass
            | IsActive state -> if state then result.AddCaseName option else result
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "pageloader").ToReactElement(div, children)
