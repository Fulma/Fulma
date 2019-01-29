namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Message =

    type Option =
        | Color of IColor
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <article class="message"></article>
    let message options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Color color -> ofColor color |> result.AddClass
            | Size size -> ofSize size |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "message").ToReactElement(article, children)

    /// Generate <div class="message-header"></div>
    let header (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "message-header").ToReactElement(div, children)

    /// Generate <div class="message-body"></div>
    let body (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "message-body").ToReactElement(div, children)
