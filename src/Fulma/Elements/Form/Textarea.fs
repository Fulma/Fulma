namespace Fulma.Elements.Form

open Fulma
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
        | IsFullwidth
        | IsInline
        | Loading of bool
        | Focused of bool
        | IsActive of bool
        | IsReadOnly of bool
        | Color of IColor
        | Id of string
        | Disabled of bool
        | Value of string
        | DefaultValue of string
        | Placeholder of string
        | Props of IHTMLProp list
        | CustomClass of string
        | HasFixedSize

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
          Placeholder : string option
          Props : IHTMLProp list
          CustomClass : string option }

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
              Placeholder = None
              Props = []
              CustomClass = None }

    let textarea options children =
        let parseOptions (result : Options) option =
            match option with
            | Size size -> { result with Size = ofSize size |> Some }
            | IsFullwidth -> { result with Size = Classes.Size.IsFullwidth |> Some }
            | IsInline -> { result with Size = Classes.Size.IsInline |> Some }
            | Loading state -> { result with IsLoading = state }
            | Focused state -> { result with IsFocused = state }
            | IsActive state -> { result with IsActive = state }
            | Color color -> { result with Color = ofColor color |> Some }
            | Id id -> { result with Id = Some id }
            | Disabled state -> { result with Disabled = state }
            | IsReadOnly state -> { result with IsReadOnly = state }
            | Value value -> { result with Value = Some value }
            | DefaultValue defaultValue -> { result with DefaultValue = Some defaultValue }
            | Placeholder placeholder -> { result with Placeholder = Some placeholder }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | HasFixedSize -> { result with HasFixedSize = true }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            Helpers.classes
                Classes.Container
                [ opts.Color
                  opts.CustomClass
                  opts.Size ]
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
                   if Option.isSome opts.Placeholder then yield Props.Placeholder opts.Placeholder.Value :> IHTMLProp
                   yield! opts.Props ]
            children
