namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Field =

    type Option =
        /// Add `has-addons` class
        | [<CompiledName("has-addons")>] HasAddons
        /// Add `has-addons-centered` class
        | [<CompiledName("has-addons-centered")>] HasAddonsCentered
        /// Add `has-addons-right` class
        | [<CompiledName("has-addons-right")>] HasAddonsRight
        /// Add `has-addons-fullwidth` class
        | [<CompiledName("has-addons-fullwidth")>] HasAddonsFullWidth
        /// Add `is-grouped` class
        | [<CompiledName("is-grouped")>] IsGrouped
        /// Add `is-grouped-centered` class
        | [<CompiledName("is-grouped-centered")>] IsGroupedCentered
        /// Add `is-grouped-right` class
        | [<CompiledName("is-grouped-right")>] IsGroupedRight
        /// Add `is-horizontal` class
        | [<CompiledName("is-horizontal")>] IsHorizontal
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    module Label =

        type Option =
            | Size of ISize
            /// Add `is-normal` class
            | IsNormal
            | CustomClass of string
            | Props of IHTMLProp list
            | Modifiers of Modifier.IModifier list

    /// Generate <label class="field-body"></label>
    let body (options : GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "field-body").ToReactElement(label, children)

    /// Generate <label class="field-label"></label>
    let label options children =
        let parseOptions (result : GenericOptions) opt =
            match opt with
            | Label.Size size -> ofSize size |> result.AddClass
            | Label.IsNormal -> result.AddCaseName opt
            | Label.Props props -> result.AddProps props
            | Label.CustomClass customClass -> result.AddClass customClass
            | Label.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "field-label").ToReactElement(label, children)

    let internal fieldView element options children =
        let parseOption (result : GenericOptions) opt =
            match opt with
            | HasAddonsCentered -> result.AddClass("has-addons").AddCaseName opt
            | HasAddonsRight -> result.AddClass("has-addons").AddCaseName opt
            | HasAddonsFullWidth -> result.AddClass("has-addons").AddCaseName opt
            | IsGroupedCentered -> result.AddClass("is-grouped").AddCaseName opt
            | IsGroupedRight -> result.AddClass("is-grouped").AddCaseName opt
            | HasAddons
            | IsGrouped
            | IsHorizontal -> result.AddCaseName opt
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "field").ToReactElement(element, children)

    /// Generate <div class="field"></div>
    let div x y = fieldView div x y
    /// Generate <p class="field"></p>
    let p x y = fieldView p x y
