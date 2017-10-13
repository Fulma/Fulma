namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Fulma.Elements.Form

module Switch =

    module Classes =
        let [<Literal>] Switch = "switch"
        let [<Literal>] IsRounded = "is-rounded"
        let [<Literal>] IsOutlined = "is-outlined"
        let [<Literal>] IsThin = "is-thin"
        let [<Literal>] IsRtl = "is-rtl"

    module Types =
        type Option =
            | Level of ILevelAndColor
            | Size of ISize
            | IsOutlined
            | IsRounded
            | IsThin
            | IsRtl
            | IsChecked of bool
            | IsDisabled
            | Props of IHTMLProp list
            | OnChange of (React.FormEvent -> unit)
            | CustomClass of string

        let ofStyles style =
            match style with
            | IsOutlined -> Classes.IsOutlined
            | IsRounded -> Classes.IsRounded
            | IsThin -> Classes.IsThin
            | value -> failwithf "%A isn't a valid style value" value


        type ComponentId = string
        type Options =
            { Level : string option
              Size : string option
              IsOutlined : bool
              IsRounded : bool
              IsChecked : bool
              IsDisabled : bool
              IsRtl : bool
              IsThin : bool
              Props : IHTMLProp list
              CustomClass : string option
              OnChange : (React.FormEvent -> unit) option
              ComponentId: string }
            static member Empty =
                { Level = None
                  Size = None
                  IsOutlined = false
                  IsRounded = false
                  IsChecked = false
                  IsDisabled = false
                  IsRtl = false
                  IsThin = false
                  Props = []
                  CustomClass = None
                  OnChange = None
                  ComponentId = System.Guid.NewGuid() |> sprintf "%O" }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge

    // States
    let isChecked = IsChecked
    let isDisabled = IsDisabled

    // Classes
    let isOutlined = IsOutlined
    let isRounded = IsRounded
    let isThin = IsThin
    let isRtl = IsRtl


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

    // Label and Value
    let value data  = Value data

    // Extra
    let props props = Props props
    let customClass = CustomClass

    let onChange cb = OnChange cb

    let switchInline (options : Option list) txt =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsOutlined -> { result with IsOutlined  = true }
            | IsRounded -> { result with IsRounded  = true }
            | IsChecked state -> { result with IsChecked = state }
            | IsDisabled -> { result with IsDisabled = true }
            | IsRtl -> { result with IsRtl = true }
            | IsThin -> { result with IsThin = true }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnChange cb -> { result with OnChange = cb |> Some }

        let opts = options |> List.fold parseOptions Options.Empty

        [ input
            [ yield classBaseList Classes.Switch
                 [ opts.Level.Value, opts.Level.IsSome
                   opts.Size.Value, opts.Size.IsSome
                   Classes.IsOutlined, opts.IsOutlined
                   Classes.IsRounded, opts.IsRounded
                   Classes.IsThin, opts.IsThin
                   Classes.IsRtl, opts.IsRtl
                   opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              if opts.OnChange.IsSome then
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
                yield Checked opts.IsChecked :> IHTMLProp
              else
                yield DefaultChecked opts.IsChecked :> IHTMLProp
              yield! opts.Props
              yield Type "checkbox" :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield Disabled opts.IsDisabled :> IHTMLProp ]

          label [ HtmlFor opts.ComponentId ]
                [ str txt ] ]


    let switch (options : Option list) txt =
        Field.field_div [ ]
            (switchInline options txt)
