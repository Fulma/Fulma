namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Quickview =

    type Option =
        | Props of IHTMLProp list
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>] IsActive of bool
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// <header class="quickview-header"></header>
    let header (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "quickview-header").ToReactElement(header, children)

    /// <p class="title"></p>
    let title (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "title").ToReactElement(p, children)

    /// <div class="quickview-body"></div>
    let body (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "quickview-body").ToReactElement(div, children)

    /// <div class="quickview-block"></div>
    let block (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "quickview-block").ToReactElement(div, children)

    /// <footer class="quickview-footer"></footer>
    let footer (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "quickview-footer").ToReactElement(footer, children)

    /// Generate <div class="quickview"></div>
    let quickview options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsActive state -> if state then result.AddCaseName option else result
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "quickview").ToReactElement(div, children)
