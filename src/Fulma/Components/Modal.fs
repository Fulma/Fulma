namespace Fulma

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Modal =

    type Option =
        | Props of IHTMLProp list
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>] IsActive of bool
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    module Close =
        type Option =
            | Size of ISize
            | OnClick of (MouseEvent -> unit)
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of Modifier.IModifier list

    /// Generate <div class="modal"></div>
    let modal (options : Option list) children =
        let parseOption (result: GenericOptions ) opt =
            match opt with
            | IsActive state -> if state then result.AddCaseName opt else result
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "modal").ToReactElement(div, children)

    /// Generate <button class="modal-close"></button>
    let close (options : Close.Option list) children =
        let parseOption (result: GenericOptions ) opt =
            match opt with
            | Close.Size IsSmall
            | Close.Size IsMedium ->
                Fable.Import.Browser.console.warn("`is-small` and `is-medium` are not valid sizes for 'modal close'")
                result
            | Close.Size size -> ofSize size |> result.AddClass
            | Close.OnClick cb -> DOMAttr.OnClick cb |> result.AddProp
            | Close.Props props -> result.AddProps props
            | Close.CustomClass customClass -> result.AddClass customClass
            | Close.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "modal-close").ToReactElement(button, children)

    /// Generate <div class="modal-background"></div>
    let background (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "modal-background").ToReactElement(div, children)

    /// Generate <div class="modal-content"></div>
    let content (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "modal-content").ToReactElement(div, children)

    module Card =

        /// Generate <div class="modal-card"></div>
        let card (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOption, "modal-card").ToReactElement(div, children)

        /// Generate <header class="modal-card-head"></header>
        let head (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOption, "modal-card-head").ToReactElement(header, children)

        /// Generate <footer class="modal-card-foot"></footer>
        let foot (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOption, "modal-card-foot").ToReactElement(footer, children)

        /// Generate <div class="modal-card-title"></div>
        let title (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOption, "modal-card-title").ToReactElement(div, children)

        /// Generate <div class="modal-card-body"></div>
        let body (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOption, "modal-card-body").ToReactElement(section, children)
