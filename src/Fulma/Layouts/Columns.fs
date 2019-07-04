namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Columns =

    type ISize =
        | [<CompiledName("is-1")>] Is1
        | [<CompiledName("is-2")>] Is2
        | [<CompiledName("is-3")>] Is3
        | [<CompiledName("is-4")>] Is4
        | [<CompiledName("is-5")>] Is5
        | [<CompiledName("is-6")>] Is6
        | [<CompiledName("is-7")>] Is7
        | [<CompiledName("is-8")>] Is8

        static member ToString (x : ISize)=
            Reflection.getCaseName x

    let inline private gapSizeGeneric (screen : Screen) (size : ISize) =
        ISize.ToString size + Screen.ToString screen

    let inline private gapSizeOnly (screen : Screen) (size : ISize) =
        match screen with
        | Screen.Tablet
        | Screen.Desktop
        | Screen.WideScreen ->
            "is-" + ISize.ToString size + Screen.ToString screen + "-only"
        | x ->
            let msg = sprintf "Screen `%s` does not support `is-%s-%s-only`." (Screen.ToString x) (ISize.ToString size) (Screen.ToString x)
            Fable.Core.JS.console.warn(msg)
            ""

    type Option =
        /// Add `is-centered` class
        | [<CompiledName("is-centered")>] IsCentered
        /// Add `is-vcentered` class
        | [<CompiledName("is-vcentered")>] IsVCentered
        /// Add `is-multiline` class
        | [<CompiledName("is-multiline")>] IsMultiline
        /// Add `is-gapless` class
        | [<CompiledName("is-gapless")>] IsGapless
        /// Add `is-grid` class
        | [<CompiledName("is-grid")>] IsGrid
        /// Add `is-mobile` class
        | [<CompiledName("is-mobile")>] IsMobile
        /// Add `is-desktop` class
        | [<CompiledName("is-desktop")>] IsDesktop
        /// Configure the gap size. You can configure the display and gap size
        /// Example: Columns.IsGap (Columns.Desktop, Columns.Is6)
        /// Becomes: `is-6-desktop`
        | IsGap of Screen * ISize
        /// Configure the gap size. You can configure the display and gap size
        /// Example: Columns.IsGapOnly (Columns.Tablet, Columns.Is6)
        /// Becomes: `is-6-tablet-only`
        | IsGapOnly of Screen * ISize
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="columns"></div>
    let columns (options: Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsCentered
            | IsVCentered
            | IsMultiline
            | IsGapless
            | IsGrid
            | IsMobile
            | IsDesktop -> result.AddCaseName option
            | IsGap (screen, size) ->
                if not (List.contains "is-variable" result.Classes) then
                    result.AddClass("is-variable").AddClass(gapSizeGeneric screen size)
                else
                    result.AddClass(gapSizeGeneric screen size)
            | IsGapOnly (screen, size) ->
                if not (List.contains "is-variable" result.Classes) then
                    result.AddClass("is-variable").AddClass(gapSizeOnly screen size)
                else
                    result.AddClass(gapSizeOnly screen size)
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "columns").ToReactElement(div, children)
