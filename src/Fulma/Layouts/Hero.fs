namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Hero =

    type Option =
        /// Add `is-bold` class
        | [<CompiledName("is-bold")>] IsBold
        /// Add `is-medium` class
        | [<CompiledName("is-medium")>] IsMedium
        /// Add `is-large` class
        | [<CompiledName("is-large")>] IsLarge
        /// Add `is-halfheight` class
        | [<CompiledName("is-halfheight")>] IsHalfHeight
        /// Add `is-fullheight-with-navbar` class
        | [<CompiledName("is-fullheight-with-navbar")>] IsFullheightWithNavbar
        /// Add `is-fullheight` class
        | [<CompiledName("is-fullheight")>] IsFullHeight
        | Color of IColor
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="hero"></div>
    let hero (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsMedium
            | IsLarge
            | IsHalfHeight
            | IsFullHeight
            | IsFullheightWithNavbar
            | IsBold -> result.AddCaseName option
            | Color color -> ofColor color |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "hero").ToReactElement(div, children)

    /// Generate <div class="hero-head"></div>
    let head (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "hero-head").ToReactElement(div, children)

    /// Generate <div class="hero-body"></div>
    let body (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "hero-body").ToReactElement(div, children)

    /// Generate <div class="hero-foot"></div>
    let foot (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "hero-foot").ToReactElement(div, children)

    /// Generate <div class="hero-video"></div>
    let video (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "hero-video").ToReactElement(div, children)

    /// Generate <div class="hero-buttons"></div>
    let buttons (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "hero-buttons").ToReactElement(div, children)
