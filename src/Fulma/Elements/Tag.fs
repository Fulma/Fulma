namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Tag =

    type Option =
        | Size of ISize
        | Color of IColor
        /// Add `is-delete` class
        | [<CompiledName("is-delete")>] IsDelete
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <span class="tag"></span>
    let tag (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Size IsSmall ->
                Fable.Core.JS.console.warn("`is-small` is not a valid size for the tag element")
                result
            | Size size -> ofSize size |> result.AddClass
            | IsDelete -> result.AddCaseName option
            | Color color -> ofColor color |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "tag").ToReactElement(span, children)

    /// Generate <span class="tag is-delete"></span>
    let delete options children = tag (IsDelete::options) children

    module List =

        type Option =
            /// Add `has-addons` class
            | [<CompiledName("has-addons")>]HasAddons
            /// Add `is-centered` class
            | [<CompiledName("is-centered")>]IsCentered
            /// Add `is-right` class
            | [<CompiledName("is-right")>]IsRight
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    /// Generate <div class="tags"></div>
    let list (options : List.Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | List.HasAddons
            | List.IsCentered
            | List.IsRight -> result.AddCaseName option
            | List.Props props -> result.AddProps props
            | List.CustomClass customClass -> result.AddClass customClass
            | List.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "tags").ToReactElement(div, children)
