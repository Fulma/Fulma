namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Fulma.Elements.Form

[<RequireQualifiedAccess>]
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
            | IsDisabled of bool
            | Props of IHTMLProp list
            | OnChange of (React.FormEvent -> unit)
            | CustomClass of string

        let ofStyles style =
            match style with
            | IsOutlined -> Classes.IsOutlined
            | IsRounded -> Classes.IsRounded
            | IsThin -> Classes.IsThin
            | value -> string value + " isn't a valid style value"


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
                  ComponentId = System.Guid.NewGuid().ToString() }

    open Types

    // Sizes
    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge

    // States
    let inline isChecked<'T> = IsChecked
    let inline isDisabled<'T> = IsDisabled

    // Classes
    let inline isOutlined<'T> = IsOutlined
    let inline isRounded<'T> = IsRounded
    let inline isThin<'T> = IsThin
    let inline isRtl<'T> = IsRtl


    // Levels and colors
    let inline isBlack<'T> = Level IsBlack
    let inline isDark<'T> = Level IsDark
    let inline isLight<'T> = Level IsLight
    let inline isWhite<'T> = Level IsWhite
    let inline isPrimary<'T> = Level IsPrimary
    let inline isInfo<'T> = Level IsInfo
    let inline isSuccess<'T> = Level IsSuccess
    let inline isWarning<'T> = Level IsWarning
    let inline isDanger<'T> = Level IsDanger

    // Label and Value
    let value data  = Value data

    // Extra
    let inline props x = Props x
    let inline customClass x = CustomClass x

    let onChange cb = OnChange cb

    let switchInline (options : Option list) children =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsOutlined -> { result with IsOutlined  = true }
            | IsRounded -> { result with IsRounded  = true }
            | IsChecked state -> { result with IsChecked = state }
            | IsDisabled state -> { result with IsDisabled = state }
            | IsRtl -> { result with IsRtl = true }
            | IsThin -> { result with IsThin = true }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnChange cb -> { result with OnChange = cb |> Some }

        let opts = options |> List.fold parseOptions Options.Empty

        [ input
            [ yield Helpers.classes Classes.Switch [opts.Level; opts.Size; opts.CustomClass] [Classes.IsOutlined, opts.IsOutlined; Classes.IsRounded, opts.IsRounded; Classes.IsThin, opts.IsThin; Classes.IsRtl, opts.IsRtl]
              if Option.isSome opts.OnChange then
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
                yield Checked opts.IsChecked :> IHTMLProp
              else
                yield DefaultChecked opts.IsChecked :> IHTMLProp
              yield! opts.Props
              yield Type "checkbox" :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield Disabled opts.IsDisabled :> IHTMLProp ]

          label [ HtmlFor opts.ComponentId ]
                children ]


    let switch (options : Option list) children =
        Field.field_div [ ]
            (switchInline options children)
