namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.React
open Fable.React.Props
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module Slider =

    type Option =
        | Color of IColor
        | Size of ISize
        /// Add `is-fullwidth` class
        | [<CompiledName("is-fullwidth")>] IsFullWidth
        /// Add `is-circle` class
        | [<CompiledName("is-circle")>] IsCircle
        /// Set `Disabled` HTMLAttr
        | Disabled of bool
        /// Register the callback to `OnChange` HTMLAttr
        | OnChange of (Browser.Types.Event -> unit)
        /// Set `Id` HTMLAttr
        | Id of string
        /// Set `Min` HTMLAttr
        | Min of float
        /// Set `Max` HTMLAttr
        | Max of float
        /// Set `Step` HTMLAttr
        | Step of float
        /// Set `Value` HTMLAttr
        | Value of float
        /// Set `DefaultValue` HTMLAttr
        | DefaultValue of float
        /// `Ref` callback that sets the value of an input textbox after DOM element is created.
        | ValueOrDefault of string
        /// Set `orient` HTMLAttr to `vertical`
        | IsVertical
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <input class="slider"/>
    let slider (options : Option list) =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Option.Color color -> ofColor color |> result.AddClass
            | Size size -> ofSize size |> result.AddClass
            | IsFullWidth
            | IsCircle -> result.AddCaseName option
            | Disabled state -> Props.Disabled state |> result.AddProp
            | Value value -> Props.Value value |> result.AddProp
            | Min min -> Props.Min min |> result.AddProp
            | Max max -> Props.Max max |> result.AddProp
            | Step step -> Props.Step step |> result.AddProp
            | OnChange cb -> Props.OnChange cb |> result.AddProp
            | Id customId -> Props.Id customId |> result.AddProp
            | IsVertical -> !!("orient", "vertical") |> result.AddProp
            | DefaultValue value -> Props.DefaultValue value |> result.AddProp
            | ValueOrDefault valueOrDefault ->
                Props.Ref <| (fun e ->
                    if e |> isNull |> not
                        && !!e?value <> valueOrDefault then
                        e?value <- valueOrDefault
                ) |> result.AddProp
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "slider", [ Type "range" ]).ToReactElement(input)
