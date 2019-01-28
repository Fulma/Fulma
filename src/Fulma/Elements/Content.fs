namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Content =

    type Option =
        | Size of ISize
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="content"></div>
    let content (options : Option list) children =
        let parseOption (result : GenericOptions) opt =
            match opt with
            | Size size -> ofSize size |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "content").ToReactElement(div, children)

    module Ol =

        type Option =
            | [<CompiledName("is-lower-roman")>] IsLowerRoman
            | [<CompiledName("is-upper-roman")>] IsUpperRoman
            | [<CompiledName("is-lower-alpha")>] IsLowerAlpha
            | [<CompiledName("is-upper-alpha")>] IsUpperAlpha
            | CustomClass of string
            | Modifiers of Modifier.IModifier list
            | Props of IHTMLProp list

        /// Generate <ol></ol>
        let ol (options : Option list) children =
            let parseOption (result : GenericOptions) opt =
                match opt with
                | IsLowerRoman
                | IsUpperRoman
                | IsLowerAlpha
                | IsUpperAlpha -> result.AddCaseName opt
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOption).ToReactElement(ol, children)
