namespace Fulma

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Heading =

    type Option =
        /// Add `is-1` class
        | [<CompiledName("is-1")>]Is1
        /// Add `is-2` class
        | [<CompiledName("is-2")>]Is2
        /// Add `is-3` class
        | [<CompiledName("is-3")>]Is3
        /// Add `is-4` class
        | [<CompiledName("is-4")>]Is4
        /// Add `is-5` class
        | [<CompiledName("is-5")>]Is5
        /// Add `is-6` class
        | [<CompiledName("is-6")>]Is6
        /// Add `subtitle` class
        | [<CompiledName("subtitle`")>]IsSubtitle
        /// Add `is-spaced` class
        | [<CompiledName("is-spaced")>]IsSpaced
        // Extra
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    let internal title (element : IHTMLProp list -> ReactElement list -> ReactElement) (options : Option list)
        (children) =
        let parseOptions (result : GenericOptions) option =
            match option with
            // Sizes
            | Is1
            | Is2
            | Is3
            | Is4
            | Is5
            | Is6
            | IsSpaced -> result.AddCaseName option
            // Styles
            | IsSubtitle ->
                result.RemoveClass("title").AddClass("subtitle")
            // Extra
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions).ToReactElement(element, children)

    // Alias
    /// Generate <h1 class="title is-1"></h1>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h1 (options : Option list) = title h1 (Is1 :: options)
    /// Generate <h2 class="title is-2"></h2>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h2 (options : Option list) = title h2 (Is2 :: options)
    /// Generate <h3 class="title is-3"></h3>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h3 (options : Option list) = title h3 (Is3 :: options)
    /// Generate <h4 class="title is-4"></h4>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h4 (options : Option list) = title h4 (Is4 :: options)
    /// Generate <h5 class="title is-5"></h5>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h5 (options : Option list) = title h5 (Is5 :: options)
    /// Generate <h6 class="title is-6"></h6>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let h6 (options : Option list) = title h6 (Is6 :: options)
    /// Generate <p class="title"></p>
    /// Class can be `subtitle` if you pass `Heading.IsSubtitle`
    let p opts children = title p opts children
