namespace Fulma

open Fulma
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Textarea =

    type Option =
        | Size of ISize
        /// Add `is-fullwidth` class
        | [<CompiledName("is-fullwidth")>] IsFullWidth
        /// Add `is-inline` class
        | [<CompiledName("is-inline")>] IsInline
        /// Add `is-loading` class if true
        | [<CompiledName("is-loading")>] IsLoading of bool
        /// Add `is-focused` class
        | [<CompiledName("is-focused")>] IsFocused of bool
        /// Add `is-active` class if true
        | [<CompiledName("is-active")>] IsActive of bool
        /// Add `IsReadOnly` HTMLAttr
        | IsReadOnly of bool
        | Color of IColor
        | Id of string
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        /// Set `Value` HTMLAttr
        | Value of string
        /// Set `DefaultValue` HTMLAttr
        | DefaultValue of string
        /// `Ref` callback that sets the value of an input textbox after DOM element is created.
        | ValueOrDefault of string
        /// Set `Placeholder` HTMLAttr
        | Placeholder of string
        | Props of IHTMLProp list
        | OnChange of (React.FormEvent -> unit)
        | Ref of (Browser.Element->unit)
        | CustomClass of string
        /// Add `has-fixed-size` class
        | [<CompiledName("has-fixed-size")>] HasFixedSize
        | Modifiers of Modifier.IModifier list

    open Fable.Core.JsInterop

    /// Generate <textarea class="textarea"></textarea>
    let textarea options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Size size -> ofSize size |> result.AddClass
            | Color color -> ofColor color |> result.AddClass
            | IsFullWidth
            | HasFixedSize
            | IsInline -> result.AddCaseName option
            | IsLoading state
            | IsFocused state
            | IsActive state -> if state then result.AddCaseName option else result
            | Id id -> Props.Id id |> result.AddProp
            | Disabled disabled -> Props.Disabled disabled |> result.AddProp
            | IsReadOnly state -> Props.ReadOnly state |> result.AddProp
            | Value value -> Props.Value value |> result.AddProp
            | DefaultValue defaultValue -> Props.DefaultValue defaultValue |> result.AddProp
            | ValueOrDefault valueOrDefault ->
                Props.Ref <| (fun e ->
                    if e |> isNull |> not
                        && !!e?value <> valueOrDefault then
                        e?value <- valueOrDefault
                ) |> result.AddProp
            | Placeholder placeholder -> Props.Placeholder placeholder |> result.AddProp
            | OnChange cb -> Props.OnChange cb |> result.AddProp
            | Ref ref -> Props.Ref ref |> result.AddProp
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "textarea").ToReactElement(textarea, children)
