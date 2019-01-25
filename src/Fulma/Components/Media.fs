namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Media =

    type Option =
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <article class="media"></article>
    let media (options: Option list) children =
        let parseOption (result : GenericOptions) opt =
            match opt with
            | Size IsSmall
            | Size IsMedium ->
                Fable.Import.Browser.console.warn("`is-small` and `is-medium` are not valid sizes for the media component")
                result
            | Size size -> ofSize size |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "media").ToReactElement(article, children)

    /// Generate <div class="media-left"></div>
    let left (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "media-left").ToReactElement(div, children)

    /// Generate <div class="media-right"></div>
    let right (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "media-right").ToReactElement(div, children)

    /// Generate <div class="media-content"></div>
    let content (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "media-content").ToReactElement(div, children)
