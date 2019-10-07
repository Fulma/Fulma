namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Pagination =

    type Option =
        /// Add `is-centered` class
        | [<CompiledName("is-centered")>] IsCentered
        /// Add `is-right` class
        | [<CompiledName("is-right")>] IsRight
        /// Add `is-rounded` class
        | [<CompiledName("is-rounded")>] IsRounded
        | Size of ISize
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    module Link =

        type Option =
            /// Add `is-current` class if true
            | [<CompiledName("is-current")>] Current of bool
            | CustomClass of string
            | Props of IHTMLProp list
            | Modifiers of Modifier.IModifier list

    /// Generate <nav class="pagination"></nav>
    let pagination (options: Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsCentered
            | IsRight
            | IsRounded -> result.AddCaseName option
            | Size size -> ofSize size |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "pagination").ToReactElement(nav, children)

    /// Generate <button class="pagination-previous"></button>
    let previous (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "pagination-previous").ToReactElement(button, children)

    /// Generate <button class="pagination-next"></button>
    let next (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "pagination-next").ToReactElement(button, children)

    /// Generate <li><button class="pagination-link"></button></li>
    /// You control the `button` element
    let link (options: Link.Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Link.Current state -> if state then result.AddCaseName option else result
            | Link.Props props -> result.AddProps props
            | Link.CustomClass customClass -> result.AddClass customClass
            | Link.Modifiers modifiers -> result.AddModifiers modifiers

        li [ ]
           [ GenericOptions.Parse(options, parseOptions, "pagination-link").ToReactElement(a, children) ]

    /// Generate <li><button class="pagination-ellipsis">&hellip;</button></li>
    /// You control the `button` element
    let ellipsis (options: GenericOption list) =
        li [ ]
           [ GenericOptions
                .Parse(options, parseOptions, "pagination-ellipsis")
                .AddProp(DangerouslySetInnerHTML { __html = "&hellip;" })
                .ToReactElement(button) ]

    /// Generate <ul class="pagination-list"></ul>
    let list (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "pagination-list").ToReactElement(ul, children)
