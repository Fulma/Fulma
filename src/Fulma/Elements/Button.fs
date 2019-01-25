namespace Fulma

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Button =

    type Option =
        // Colors
        | Color of IColor
        | Size of ISize
        /// Add `is-fullwidth` class
        | [<CompiledName("is-fullwidth")>] IsFullWidth
        /// Add `is-link` class
        | [<CompiledName("is-link")>] IsLink
        /// Add `is-outlined` class
        | [<CompiledName("is-outlined")>] IsOutlined
        /// Add `is-inverted` class
        | [<CompiledName("is-inverted")>] IsInverted
        /// Add `is-text` class
        | [<CompiledName("is-text")>] IsText
        /// Add `is-rounded` class
        | [<CompiledName("is-rounded")>] IsRounded
        /// Add `is-expanded` class
        | [<CompiledName("is-expanded")>] IsExpanded
        /// Add `is-hovered` class if true
        | [<CompiledName("is-hovered")>] IsHovered of bool
        /// Add `is-focused` class if true
        | [<CompiledName("is-focused")>] IsFocused of bool
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>] IsActive of bool
        /// Add `is-loading` class if true
        | [<CompiledName("is-loading")>] IsLoading of bool
        /// Add `is-static` class if true
        | [<CompiledName("is-static")>] IsStatic of bool
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        | Props of IHTMLProp list
        | OnClick of (MouseEvent -> unit)
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    let internal btnView element (options : Option list) children =
        let parseOption (result : GenericOptions) opt =
            match opt with
            | Color color -> ofColor color |> result.AddClass
            | Size size -> ofSize size |> result.AddClass
            // Styles
            | IsLink
            | IsFullWidth
            | IsOutlined
            | IsInverted
            | IsText
            | IsRounded
            | IsExpanded -> result.AddCaseName opt
            // States
            | IsHovered state
            | IsFocused state
            | IsActive state
            | IsLoading state
            | IsStatic state -> if state then result.AddCaseName opt else result
            | Disabled isDisabled -> Fable.Helpers.React.Props.Disabled isDisabled |> result.AddProp
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | OnClick cb -> DOMAttr.OnClick cb |> result.AddProp
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "button").ToReactElement(element, children)

    /// Generate <button class="button"></button>
    let button options children = btnView button options children
    /// Generate <span class="button"></span>
    let span options children = btnView span options children
    /// Generate <a class="button"></a>
    let a options children = btnView a options children

    module Input =
        let internal btnInput typ options =
            let hasProps =
                options
                |> List.exists (fun opts ->
                    match opts with
                    | Props _ -> true
                    | _ -> false
                )

            if hasProps then
                let newOptions =
                    options
                    |> List.map (fun opts ->
                        match opts with
                        | Props props -> Props ((Type typ :> IHTMLProp) ::props)
                        | forward -> forward
                    )
                btnView (fun options _ -> input options) newOptions [ ]

            else
                btnView (fun options _ -> input options) ((Props [ Type typ ])::options) [ ]

        /// Generate <input type="reset" class="button" />
        let reset options = btnInput "reset" options
        /// Generate <input type="submit" class="button" />
        let submit options = btnInput "submit" options

    module List =

        type Option =
            | [<CompiledName("has-addons")>] HasAddons
            | [<CompiledName("is-centered")>] IsCentered
            | [<CompiledName("is-right")>] IsRight
            // | Size of ISize
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    /// Generate <div class="buttons"></div>
    let list (options : List.Option list) children =
        let parseOption (result : GenericOptions) opt =
            match opt with
            | List.HasAddons
            | List.IsCentered
            | List.IsRight -> Fable.Core.Reflection.getCaseName opt |> result.AddClass
            | List.Props props -> result.AddProps props
            | List.CustomClass customClass -> result.AddClass customClass
            | List.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "buttons").ToReactElement(div, children)
