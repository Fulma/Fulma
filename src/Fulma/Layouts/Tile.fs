namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tile =

    type ISize =
        | [<CompiledName("is-1")>] Is1
        | [<CompiledName("is-2")>] Is2
        | [<CompiledName("is-3")>] Is3
        | [<CompiledName("is-4")>] Is4
        | [<CompiledName("is-5")>] Is5
        | [<CompiledName("is-6")>] Is6
        | [<CompiledName("is-7")>] Is7
        | [<CompiledName("is-8")>] Is8
        | [<CompiledName("is-9")>] Is9
        | [<CompiledName("is-10")>] Is10
        | [<CompiledName("is-11")>] Is11
        | [<CompiledName("is-12")>] Is12

        static member ToString (x : ISize)=
            Fable.Core.Reflection.getCaseName x

    type Option =
        | Size of ISize
        | CustomClass of string
        | Props of IHTMLProp list
        /// Add `is-child` class
        | [<CompiledName("is-child")>]IsChild
        /// Add `is-ancestor` class
        | [<CompiledName("is-ancestor")>]IsAncestor
        /// Add `is-parent` class
        | [<CompiledName("is-parent")>]IsParent
        /// Add `is-vertical` class
        | [<CompiledName("is-vertical")>]IsVertical
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="tile"></div>
    let tile (options: Option list) children =
        let parseOption (result: GenericOptions) opt =
            match opt with
            | Size size -> ISize.ToString size |> result.AddClass
            | IsChild
            | IsAncestor
            | IsParent
            | IsVertical -> result.AddCaseName opt
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "tile").ToReactElement(div, children)

    /// Generate <div class="tile is-parent"></div>
    let parent (options: Option list) children =
        tile (IsParent :: options) children

    /// Generate <div class="tile is-child"></div>
    let child (options: Option list) children =
        tile (IsChild :: options) children

    /// Generate <div class="tile is-ancestor"></div>
    let ancestor (options: Option list) children =
        tile (IsAncestor :: options) children
