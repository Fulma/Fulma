namespace Fulma

open Fulma
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Textarea =

    module Classes =
        let [<Literal>] Container = "textarea"
        module State =
            let [<Literal>] IsDisabled = "is-disabled"
            let [<Literal>] IsLoading = "is-loading"
            let [<Literal>] IsFocused = "is-focused"
            let [<Literal>] IsActive = "is-active"
        let [<Literal>] HasFixedSize = "has-fixed-size"
        module Size =
            let [<Literal>] IsSmall = "is-small"
            let [<Literal>] IsMedium = "is-medium"
            let [<Literal>] IsLarge = "is-large"
            let [<Literal>] IsFullwidth = "is-fullwidth"
            let [<Literal>] IsInline = "is-inline"

    type Option =
        | Size of ISize
        /// Add `is-fullwidth` class
        | IsFullWidth
        /// Add `is-inline` class
        | IsInline
        // Add `is-loading` class if true
        | IsLoading of bool
        /// Add `is-focused` class
        | IsFocused of bool
        /// Add `is-active` class if true
        | IsActive of bool
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
        | HasFixedSize
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Size : string option
          IsLoading : bool
          IsFocused : bool
          IsActive : bool
          Color : string option
          Id : string option
          Disabled : bool
          IsReadOnly : bool
          HasFixedSize : bool
          Value : string option
          DefaultValue : string option
          ValueOrDefault : string option
          Placeholder : string option
          OnChange : (React.FormEvent -> unit) option
          Ref : (Browser.Element->unit) option
          Props : IHTMLProp list
          CustomClass : string option
          Modifiers : string option list }

        static member Empty =
            { Size = None
              IsLoading = false
              IsFocused = false
              IsActive = false
              Color = None
              Id = None
              Disabled = false
              IsReadOnly = false
              Value = None
              HasFixedSize = false
              DefaultValue = None
              ValueOrDefault = None
              Placeholder = None
              OnChange = None
              Ref = None
              Props = []
              CustomClass = None
              Modifiers = [] }

    open Fable.Core.JsInterop

    /// Generate <textarea class="textarea"></textarea>
    let textarea options children =
        let parseOptions (result : Options) option =
            match option with
            | Size size -> { result with Size = ofSize size |> Some }
            | IsFullWidth -> { result with Size = Classes.Size.IsFullwidth |> Some }
            | IsInline -> { result with Size = Classes.Size.IsInline |> Some }
            | IsLoading state -> { result with IsLoading = state }
            | IsFocused state -> { result with IsFocused = state }
            | IsActive state -> { result with IsActive = state }
            | Color color -> { result with Color = ofColor color |> Some }
            | Id id -> { result with Id = Some id }
            | Disabled state -> { result with Disabled = state }
            | IsReadOnly state -> { result with IsReadOnly = state }
            | Value value -> { result with Value = Some value }
            | DefaultValue defaultValue -> { result with DefaultValue = Some defaultValue }
            | ValueOrDefault valueOrDefault -> { result with ValueOrDefault = Some valueOrDefault }
            | Placeholder placeholder -> { result with Placeholder = Some placeholder }
            | Props props -> { result with Props = props }
            | OnChange cb -> { result with OnChange = cb |> Some }
            | Ref cb -> { result with Ref = cb |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | HasFixedSize -> { result with HasFixedSize = true }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            Helpers.classes
                Classes.Container
                ( opts.Color
                  ::opts.CustomClass
                  ::opts.Size
                  ::opts.Modifiers )
                [ Classes.HasFixedSize, opts.HasFixedSize
                  Classes.State.IsLoading, opts.IsLoading
                  Classes.State.IsFocused, opts.IsFocused
                  Classes.State.IsActive, opts.IsActive ]

        textarea [ yield classes
                   yield Props.Disabled opts.Disabled :> IHTMLProp
                   yield Props.ReadOnly opts.IsReadOnly :> IHTMLProp
                   if Option.isSome opts.Id then yield Props.Id opts.Id.Value :> IHTMLProp
                   if Option.isSome opts.Value then yield Props.Value opts.Value.Value :> IHTMLProp
                   if Option.isSome opts.DefaultValue then yield Props.DefaultValue opts.DefaultValue.Value :> IHTMLProp
                   if Option.isSome opts.ValueOrDefault then
                        yield Props.Ref <| (fun e -> if e |> isNull |> not && !!e?value <> !!opts.ValueOrDefault.Value then e?value <- !!opts.ValueOrDefault.Value) :> IHTMLProp
                   if Option.isSome opts.Placeholder then yield Props.Placeholder opts.Placeholder.Value :> IHTMLProp
                   if Option.isSome opts.OnChange then yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
                   if Option.isSome opts.Ref then yield Prop.Ref opts.Ref.Value :> IHTMLProp
                   yield! opts.Props ]
            children
