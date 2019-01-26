namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Level =

    module Level =

        type Option =
            | Props of IHTMLProp list
            /// Add `is-mobile` class
            | [<CompiledName("is-mobile")>] IsMobile
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    module Item =

        type Option =
            | Props of IHTMLProp list
            /// Add `has-text-centered` class
            | [<CompiledName("has-text-centered")>] HasTextCentered
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    /// Generate <nav class="level"></nav>
    let level (options : Level.Option list) children =
        let parseOption (result: GenericOptions ) opt =
            match opt with
            | Level.Option.IsMobile -> result.AddCaseName opt
            | Level.Props props -> result.AddProps props
            | Level.CustomClass customClass -> result.AddClass customClass
            | Level.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "level").ToReactElement(nav, children)

    /// Generate <div class="level-left"></div>
    let left (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "level-left").ToReactElement(div, children)

    /// Generate <div class="level-right"></div>
    let right (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "level-right").ToReactElement(div, children)

    /// Generate <div class="level-item"></div>
    let item (options : Item.Option list) children =
        let parseOption (result: GenericOptions ) opt =
            match opt with
            | Item.HasTextCentered -> result.AddCaseName opt
            | Item.Props props -> result.AddProps props
            | Item.CustomClass customClass -> result.AddClass customClass
            | Item.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "level-item").ToReactElement(div, children)

    /// Generate <p class="heading"></p>
    let heading (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "heading").ToReactElement(p, children)

    /// Generate <p class="title"></p>
    let title (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "title").ToReactElement(p, children)
