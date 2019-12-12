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

    module Previous =

        let internal previous element (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "pagination-previous").ToReactElement(element, children)

        /// Generate <a class="pagination-previous"></a>
        let a options children = previous a options children

        /// Generate <button class="pagination-previous"></button>
        let button options children = previous button options children

    /// Generate <button class="pagination-previous"></button>
    let previous options children = Previous.button options children

    module Next =

        let internal next element (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "pagination-next").ToReactElement(element, children)

        /// Generate <a class="pagination-next"></a>
        let a options children = next a options children

        /// Generate <button class="pagination-next"></button>
        let button options children = next button options children

    /// Generate <button class="pagination-next"></button>
    let next options children = Next.button options children

    module Link =

        type Option =
            /// Add `is-current` class if true
            | [<CompiledName("is-current")>] Current of bool
            | CustomClass of string
            | Props of IHTMLProp list
            | Modifiers of Modifier.IModifier list

        let internal link element (options: Option list) children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | Current state -> if state then result.AddCaseName option else result
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            li [ ]
               [ GenericOptions.Parse(options, parseOptions, "pagination-link").ToReactElement(element, children) ]

        /// Generate <li><a class="pagination-link"></a></li>
        /// You control the `a` element
        let a options children = link a options children

        /// Generate <li><button class="pagination-link"></button></li>
        /// You control the `button` element
        let button options children = link button options children

    /// Generate <li><button class="pagination-link"></button></li>
    /// You control the `button` element
    let link options children = Link.button options children

    /// Generate <li><button class="pagination-ellipsis">&hellip;</button></li>
    /// You control the `button` element
    let ellipsis (options: GenericOption list) =
        li [ ]
           [ GenericOptions
                .Parse(options, parseOptions, "pagination-ellipsis")
                .AddProp(DangerouslySetInnerHTML { __html = "&hellip;" })
                .ToReactElement(span) ]

    /// Generate <ul class="pagination-list"></ul>
    let list (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "pagination-list").ToReactElement(ul, children)
