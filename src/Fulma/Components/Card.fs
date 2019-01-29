namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Card =

    /// Generate <div class="card"></div>
    let card (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "card").ToReactElement(div, children)

    /// Generate <div class="card-header"></div>
    let header (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "card-header").ToReactElement(header, children)

    /// Generate <div class="card-content"></div>
    let content (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "card-content").ToReactElement(div, children)

    /// Generate <div class="card-footer"></div>
    let footer (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "card-footer").ToReactElement(footer, children)

    /// Generate <div class="card-image"></div>
    let image (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "card-image").ToReactElement(div, children)
    module Header =

        module Title =

            type Option =
                /// Add `is-centered` class
                | [<CompiledName("is-centered")>] IsCentered
                | Props of IHTMLProp list
                | CustomClass of string
                | Modifiers of Modifier.IModifier list

        /// Generate <a class="card-header-icon"></a>
        let icon (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "card-header-icon").ToReactElement(a, children)

        /// Generate <p class="card-header-title"></p>
        let title (options: Title.Option list) children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | Title.IsCentered as opt -> result.AddCaseName option
                | Title.Props props -> result.AddProps props
                | Title.CustomClass customClass -> result.AddClass customClass
                | Title.Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOptions, "card-header-title").ToReactElement(p, children)

    module Footer =

        let internal itemView element (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "card-footer-item").ToReactElement(element, children)

        /// Generate <div class="card-footer-item"></a>
        let div x y = itemView div x y
        /// Generate <p class="card-footer-item"></a>
        let p x y = itemView p x y
        /// Generate <a class="card-footer-item"></a>
        let a x y = itemView a x y
