namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Core.JsInterop

module Slider =

    module Classes =

        module Slider =
            let [<Literal>] Container  = "slider "
            let [<Literal>] IsCircle = "is-circle"
            let [<Literal>] IsFullwidth = "is-fullwidth"


    module Types =

        type ISize =
            | IsSmall
            | IsMedium
            | IsLarge
            | IsFullWidth
            | Nothing


        type Option =
            | Level of ILevelAndColor
            | Size of ISize
            | IsCircle
            | IsDisabled
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

        let ofSize size =
            match size with
            | IsSmall -> Bulma.Modifiers.Size.IsSmall
            | IsMedium -> Bulma.Modifiers.Size.IsMedium
            | IsLarge -> Bulma.Modifiers.Size.IsLarge
            | IsFullWidth -> Classes.Slider.IsFullwidth
            | ISize.Nothing -> ""

        let ofStyles style =
            match style with
            | IsCircle -> Classes.Slider.IsCircle
            | value -> failwithf "%A isn't a valid style value" value


        type ComponentId = string
        type Options =
            { Level : string option
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
                { Level = None
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
                  ComponentId = System.Guid.NewGuid() |> sprintf "%O" }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    let isFullWidth = Size IsFullWidth

    // States
    let isDisabled = IsDisabled

    // Styles
    let isCircle = IsCircle


    // Levels and colors
    let isBlack = Level IsBlack
    let isDark = Level IsDark
    let isLight = Level IsLight
    let isWhite = Level IsWhite
    let isPrimary = Level IsPrimary
    let isInfo = Level IsInfo
    let isSuccess = Level IsSuccess
    let isWarning = Level IsWarning
    let isDanger = Level IsDanger

    let value = Value
    let defaultValue = DefaultValue
    let min = Min
    let max = Max
    let step = Step

    // Extra
    let props = Props
    let customClass = CustomClass

    let onChange cb = OnChange cb

    let slider (options : Option list) children =


        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsCircle -> { result with IsCircle  = true }
            | IsDisabled -> { result with IsDisabled = true }
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

        input
            [ yield classBaseList
                (Helpers.generateClassName Classes.Slider.Container [ opts.Level; opts.Size; ])
                 [ Classes.Slider.IsCircle, opts.IsCircle
                   opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              if opts.OnChange.IsSome then
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
              yield! opts.Props
              yield Type "range" :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield Disabled opts.IsDisabled :> IHTMLProp
              if opts.IsVertical then
                yield !!("orient", "vertical")
              if opts.Value.IsSome then
                yield HTMLAttr.Value (string opts.Value.Value) :> IHTMLProp
              if opts.Step.IsSome then
                yield HTMLAttr.Step (string opts.Step.Value) :> IHTMLProp
              if opts.Min.IsSome then
                yield HTMLAttr.Min (string opts.Min.Value) :> IHTMLProp
              if opts.Max.IsSome then
                yield HTMLAttr.Max (string opts.Max.Value) :> IHTMLProp
              if opts.DefaultValue.IsSome then
                yield HTMLAttr.DefaultValue (string opts.DefaultValue.Value) :> IHTMLProp
            ]
