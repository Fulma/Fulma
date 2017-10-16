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
module Checkradio =

    module Classes =
        let [<Literal>] IsCheckox = "is-checkbox"
        let [<Literal>] IsRadio = "is-radio"
        let [<Literal>] IsCircle = "is-circle"
        let [<Literal>] IsRtl = "is-rtl"
        let [<Literal>] IsBlock = "is-block"
        let [<Literal>] HasNoBorder = "has-no-border"
        let [<Literal>] HasBackgroundColor = "has-background-color"

    module Types =
        type Option =
            | Level of ILevelAndColor
            | Size of ISize
            | IsRtl
            | HasNoBorder
            | HasBackgroundColor
            | IsCircle
            | IsChecked of bool
            | IsDisabled of bool
            | IsBlock
            | Props of IHTMLProp list
            | OnChange of (React.FormEvent -> unit)
            | CustomClass of string
            | ComponentId of string
            | Name of string

        let ofStyles style =
            match style with
            | IsCircle -> Classes.IsCircle
            | value -> string value + " isn't a valid style value"

        type Options =
            { Level : string option
              Size : string option
              IsCircle : bool
              IsChecked : bool
              IsDisabled : bool
              IsRtl : bool
              IsBlock : bool
              HasNoBorder : bool
              HasBackgroundColor : bool
              Name : string option
              Props : IHTMLProp list
              CustomClass : string option
              OnChange : (React.FormEvent -> unit) option
              ComponentId: string }
            static member Empty =
                { Level = None
                  Size = None
                  IsCircle = false
                  IsChecked = false
                  IsDisabled = false
                  IsRtl = false
                  IsBlock = false
                  HasNoBorder = false
                  HasBackgroundColor = false
                  Name = None
                  Props = []
                  CustomClass = None
                  OnChange = None
                  ComponentId = System.Guid.NewGuid().ToString() }

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsCircle -> { result with IsCircle = true }
            | IsChecked state -> { result with IsChecked = state }
            | IsDisabled state -> { result with IsDisabled = state }
            | Name customName -> { result with Name = Some customName }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnChange cb -> { result with OnChange = cb |> Some }
            | ComponentId customId -> {result with ComponentId = customId }
            | IsRtl -> { result with IsRtl = true }
            | HasNoBorder -> { result with HasNoBorder = true }
            | HasBackgroundColor -> { result with HasBackgroundColor = true }
            | IsBlock -> { result with IsBlock = true }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge

    // States
    let isChecked = IsChecked
    let isDisabled = IsDisabled

    // Styles
    let isCircle = IsCircle
    let isRtl = IsRtl
    let hasNoBorder = HasNoBorder
    let hasBackgroundColor = HasBackgroundColor
    let isBlock = IsBlock

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

    // Extra
    let id customId = ComponentId customId
    let name customName = Name customName

    let props props = Props props
    let customClass = CustomClass

    let onChange cb = OnChange cb

    let genericElement inputType baseClass (options : Option list) children =
        let opts = options |> List.fold parseOptions Options.Empty

        [ input
            [ yield classBaseList baseClass
                 [ Classes.IsCircle, opts.IsCircle
                   opts.Level.Value, opts.Level.IsSome
                   opts.Size.Value, opts.Size.IsSome
                   opts.CustomClass.Value, opts.CustomClass.IsSome
                   Classes.IsRtl, opts.IsRtl
                   Classes.HasNoBorder, opts.HasNoBorder
                   Classes.IsBlock , opts.IsBlock
                   Classes.HasBackgroundColor, opts.HasBackgroundColor ] :> IHTMLProp
              if opts.OnChange.IsSome then
                yield Checked opts.IsChecked :> IHTMLProp
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
              else
                yield DefaultChecked opts.IsChecked :> IHTMLProp
              yield! opts.Props
              if opts.Name.IsSome then
                yield HTMLAttr.Name opts.Name.Value :> IHTMLProp
              yield Type inputType :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield Disabled opts.IsDisabled :> IHTMLProp ]

          label [ HtmlFor opts.ComponentId ]
                children ]


    let checkboxInline (options : Option list) children =
        genericElement "checkbox" Classes.IsCheckox options children

    let checkbox (options : Option list) children =
        Field.field_div [ ]
            (checkboxInline options children)

    let radioInline (options : Option list) children =
        genericElement "radio" Classes.IsRadio options children


    let radio (options : Option list) children =
        Field.field_div [ ]
            (radioInline options children)
