namespace Fulma.Extensions

open Fulma
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

    type Option =
        | Color of IColor
        | Size of ISize
        | IsRtl
        | HasNoBorder
        | HasBackgroundColor
        | IsCircle
        | Checked of bool
        | Disabled of bool
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

    type internal Options =
        { Color : string option
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
            { Color = None
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

    let private parseOptions (result: Options) opt =
        match opt with
        | Option.Color color -> { result with Color = ofColor color |> Some }
        | Size size -> { result with Size = ofSize size |> Some }
        | IsCircle -> { result with IsCircle = true }
        | Checked state -> { result with IsChecked = state }
        | Disabled state -> { result with IsDisabled = state }
        | Name customName -> { result with Name = Some customName }
        | Props props -> { result with Props = props }
        | CustomClass customClass -> { result with CustomClass = Some customClass }
        | OnChange cb -> { result with OnChange = cb |> Some }
        | ComponentId customId -> {result with ComponentId = customId }
        | IsRtl -> { result with IsRtl = true }
        | HasNoBorder -> { result with HasNoBorder = true }
        | HasBackgroundColor -> { result with HasBackgroundColor = true }
        | IsBlock -> { result with IsBlock = true }

    let private genericElement inputType baseClass (options : Option list) children =
        let opts = options |> List.fold parseOptions Options.Empty

        [ input
            [ yield Helpers.classes baseClass [opts.Color; opts.Size; opts.CustomClass] [Classes.IsCircle, opts.IsCircle; Classes.IsRtl, opts.IsRtl; Classes.HasNoBorder, opts.HasNoBorder; Classes.IsBlock , opts.IsBlock; Classes.HasBackgroundColor, opts.HasBackgroundColor]
              if Option.isSome opts.OnChange then
                yield HTMLAttr.Checked opts.IsChecked :> IHTMLProp
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
              else
                yield DefaultChecked opts.IsChecked :> IHTMLProp
              yield! opts.Props
              if Option.isSome opts.Name then
                yield HTMLAttr.Name opts.Name.Value :> IHTMLProp
              yield Type inputType :> IHTMLProp
              yield Id opts.ComponentId :> IHTMLProp
              yield HTMLAttr.Disabled opts.IsDisabled :> IHTMLProp ]

          label [ HtmlFor opts.ComponentId ]
                children ]

    let checkboxInline (options : Option list) children =
        genericElement "checkbox" Classes.IsCheckox options children

    let checkbox (options : Option list) children =
        Field.field [ ]
            (checkboxInline options children)

    let radioInline (options : Option list) children =
        genericElement "radio" Classes.IsRadio options children


    let radio (options : Option list) children =
        Field.field [ ]
            (radioInline options children)
