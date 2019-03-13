namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Checkradio =

    type Option =
        | Color of IColor
        | Size of ISize
        /// Add `is-rtl` class
        | [<CompiledName("is-rtl")>] IsRtl
        /// Add `has-no-border` class
        | [<CompiledName("has-no-border")>] HasNoBorder
        /// Add `has-background-color` class
        | [<CompiledName("has-background-color")>] HasBackgroundColor
        /// Add `is-circle` class
        | [<CompiledName("is-circle")>] IsCircle
        /// Add `checked` HTMLAttr if true
        | Checked of bool
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        /// Add `is-block` class
        | [<CompiledName("is-block")>] IsBlock
        | LabelProps of IHTMLProp list
        | InputProps of IHTMLProp list
        | OnChange of (Browser.Types.Event -> unit)
        | CustomClass of string
        | Id of string
        | Name of string

    let private parseOptionsForInput (result : GenericOptions) option =
        match option with
        | Option.Color color -> ofColor color |> result.AddClass
        | Size size -> ofSize size |> result.AddClass
        | IsCircle
        | IsRtl
        | HasNoBorder
        | HasBackgroundColor
        | IsBlock -> result.AddCaseName option
        | Checked state -> Props.Checked state |> result.AddProp
        | Disabled state -> Props.Disabled state |> result.AddProp
        | Name customName -> Props.Name customName |> result.AddProp
        | InputProps props -> result.AddProps props
        | OnChange cb -> Props.OnChange cb |> result.AddProp
        | Id customId -> Props.Id customId |> result.AddProp
        | CustomClass customClass -> result.AddClass customClass
        // If option abose don't match, then others don't impact the input generation
        | LabelProps _ -> result

    let private parseOptionsForLabel (result : GenericOptions) option =
        match option with
        | Id customId -> Props.HtmlFor customId |> result.AddProp
        | LabelProps props -> result.AddProps props
        // If option abose don't match, then others don't impact the label generation
        | _ -> result

    let private hasId (options : Option list) =
        options
        |> List.tryPick (fun option ->
            match option with
            | Id _ -> Some true
            | _ -> None
        )
        |> Option.isSome

    let private genericElement inputType baseClass (options : Option list) children =
        if hasId options then
            let inputElement =
                GenericOptions.Parse(options, parseOptionsForInput, baseClass, [Props.Type inputType]).ToReactElement(input)

            let labelElement =
                GenericOptions.Parse(options, parseOptionsForLabel).ToReactElement(label, children)

            fragment [ ]
                [ inputElement
                  labelElement ]
        else
            Text.span [ Modifiers [ Modifier.TextColor IsDanger
                                    Modifier.TextWeight TextWeight.Bold ] ]
                [ str "You need to set an Id value for your Checkradio "]

    /// Generate
    /// <fragment>
    ///   <input class="is-checkradio" type="checkbox">
    ///   <label>One</label>
    /// </fragment>
    let checkboxInline (options : Option list) children =
        genericElement "checkbox" "is-checkradio" options children

    /// Generate
    /// <div class="field">
    ///   <fragment>
    ///     <input class="is-checkradio" type="checkbox">
    ///     <label>One</label>
    ///   </fragment>
    /// </div>
    let checkbox (options : Option list) children =
        Field.div [ ]
            [ checkboxInline options children ]

    /// Generate
    /// <fragment>
    ///   <input class="is-checkradio" type="radio">
    ///   <label>One</label>
    /// </fragment>
    let radioInline (options : Option list) children =
        genericElement "radio" "is-checkradio" options children

    /// Generate
    /// <div class="field">
    ///   <fragment>
    ///     <input class="is-checkradio" type="radio">
    ///     <label>One</label>
    ///   </fragment>
    /// </div>
    let radio (options : Option list) children =
        Field.div [ ]
            [ radioInline options children ]
