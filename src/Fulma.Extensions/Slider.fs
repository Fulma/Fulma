namespace Fulma.Extensions

open Fulma
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

[<RequireQualifiedAccess>]
module Slider =

    module Classes =
            let [<Literal>] Slider  = "slider "
            let [<Literal>] IsCircle = "is-circle"
            let [<Literal>] IsFullwidth = "is-fullwidth"

    type Option =
        | Color of IColor
        | Size of ISize
        | IsFullWidth
        | IsCircle
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        | Props of IHTMLProp list
        | OnChange of (React.FormEvent -> unit)
        | CustomClass of string
        | ComponentId of string
        | Min of float
        | Max of float
        | Step of float
        | Value of float
        | DefaultValue of float
        | IsVertical

    type internal ComponentId = string
    type internal Options =
        { Color : string option
          Size : string option
          IsCircle : bool
          IsDisabled : bool
          Value : float option
          DefaultValue : float option
          Min : float option
          Max : float option
          Step : float option
          IsVertical : bool
          Props : IHTMLProp list
          CustomClass : string option
          OnChange : (React.FormEvent -> unit) option
          ComponentId: string }
        static member Empty =
            { Color = None
              Size = None
              IsCircle = false
              IsDisabled = false
              DefaultValue = None
              Value = None
              Min = None
              Max = None
              Step = None
              IsVertical = false
              Props = []
              CustomClass = None
              OnChange = None
              ComponentId = System.Guid.NewGuid().ToString() }

    let slider (options : Option list) =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Color color -> { result with Color = ofColor color |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsFullWidth -> { result with Size = Classes.IsFullwidth |> Some }
            | IsCircle -> { result with IsCircle  = true }
            | Disabled state -> { result with IsDisabled = state }
            | Value value -> { result with Value = Some value }
            | Min min -> { result with Min = Some min }
            | Max max -> { result with Max = Some max }
            | Step step -> { result with Step = Some step }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnChange cb -> { result with OnChange = cb |> Some }
            | ComponentId customId -> { result with ComponentId = customId }
            | IsVertical -> { result with IsVertical = true }
            | DefaultValue value -> { result with DefaultValue = Some value }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Slider
                        [ opts.CustomClass; opts.Color; opts.Size ]
                        [ Classes.IsCircle, opts.IsCircle ]

        input
            [ yield classes
              if Option.isSome opts.OnChange then
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
              yield! opts.Props
              yield Type "range" :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield HTMLAttr.Disabled opts.IsDisabled :> IHTMLProp
              if opts.IsVertical then
                yield !!("orient", "vertical")
              if Option.isSome opts.Value then
                yield HTMLAttr.Value (string opts.Value.Value) :> IHTMLProp
              if Option.isSome opts.Step then
                yield HTMLAttr.Step (string opts.Step.Value) :> IHTMLProp
              if Option.isSome opts.Min then
                yield HTMLAttr.Min (string opts.Min.Value) :> IHTMLProp
              if Option.isSome opts.Max then
                yield HTMLAttr.Max (string opts.Max.Value) :> IHTMLProp
              if Option.isSome opts.DefaultValue then
                yield HTMLAttr.DefaultValue (string opts.DefaultValue.Value) :> IHTMLProp
            ]
