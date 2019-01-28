namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module File =

    type Option =
        | CustomClass of string
        | Props of IHTMLProp list
        | Size of ISize
        /// Add `is-focused` class if true
        | [<CompiledName("is-focused")>]IsFocused of bool
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>]IsActive of bool
        /// Add `is-hovered` class if true
        | [<CompiledName("is-hovered")>]IsHovered of bool
        /// Add `is-fullwidth` class
        | [<CompiledName("is-fullwidth")>]IsFullWidth
        /// Add `is-centered` class
        | [<CompiledName("is-centered")>]IsCentered
        /// Add `is-right` class
        | [<CompiledName("is-right")>]IsRight
        /// Add `is-boxed` class
        | [<CompiledName("is-boxed")>]IsBoxed
        /// Add `has-name` class
        | [<CompiledName("has-name")>]HasName
        /// Add `is-empty` class if true
        | [<CompiledName("is-empty")>]IsEmpty of bool
        | Color of IColor
        | Modifiers of Modifier.IModifier list

    /// Generate <div class="file"></div>
    let file (options : Option list) children =
        let parseOption (result : GenericOptions) option =
            match option with
            | Size size -> ofSize size |> result.AddClass
            | IsFullWidth
            | IsCentered
            | IsRight
            | IsBoxed
            | HasName -> result.AddCaseName option
            | Color color -> ofColor color |> result.AddClass
            | IsFocused state
            | IsActive state
            | IsHovered state
            | IsEmpty state -> if state then result.AddCaseName option else result
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "file").ToReactElement(div, children)

    /// Generate <span class="file-cta"></span>
    let cta (options : GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "file-cta").ToReactElement(span, children)

    /// Generate <span class="file-name"></span>
    let name (options : GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "file-name").ToReactElement(span, children)

    /// Generate <span class="file-icon"></span>
    let icon (options : GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "file-icon").ToReactElement(span, children)

    /// Generate <label class="file-label"></label>
    let label (options : GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "file-label").ToReactElement(label, children)

    /// Generate <input type="file" class="file-input"/>
    let input (options : GenericOption list) =
        GenericOptions.Parse(options, parseOption, "file-input", [Type "file" :> IHTMLProp]).ToReactElement(input)
