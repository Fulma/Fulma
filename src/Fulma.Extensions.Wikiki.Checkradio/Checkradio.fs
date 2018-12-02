namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Checkradio =

    module Classes =
        let [<Literal>] IsCheckradio = "is-checkradio"
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
        /// Add `checked` HTMLAttr if true
        | Checked of bool
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        | IsBlock
        | Props of IHTMLProp list
        | OnChange of (React.FormEvent -> unit)
        | CustomClass of string
        | Id of string
        | Name of string

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
          Id : string option }

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
              Id = None }

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
        | Id customId -> { result with Id = Some customId }
        | IsRtl -> { result with IsRtl = true }
        | HasNoBorder -> { result with HasNoBorder = true }
        | HasBackgroundColor -> { result with HasBackgroundColor = true }
        | IsBlock -> { result with IsBlock = true }

    let private genericElement inputType baseClass (options : Option list) children =
        let opts = options |> List.fold parseOptions Options.Empty

        [ input
            [ yield Helpers.classes baseClass [opts.Color; opts.Size; opts.CustomClass] [Classes.IsCircle, opts.IsCircle; Classes.IsRtl, opts.IsRtl; Classes.HasNoBorder, opts.HasNoBorder; Classes.IsBlock , opts.IsBlock; Classes.HasBackgroundColor, opts.HasBackgroundColor]
              if Option.isSome opts.OnChange then
                yield HTMLAttr.Checked opts.IsChecked
                yield DOMAttr.OnChange opts.OnChange.Value
              else
                yield DefaultChecked opts.IsChecked
              yield! opts.Props
              if Option.isSome opts.Name then
                yield HTMLAttr.Name opts.Name.Value
              yield Type inputType
              if Option.isSome opts.Id then
                yield HTMLAttr.Id opts.Id.Value
              yield HTMLAttr.Disabled opts.IsDisabled ]

          label [ if Option.isSome opts.Id then
                    yield HtmlFor opts.Id.Value ]
                children ]

    let checkboxInline (options : Option list) children =
        fragment [ ]
            (genericElement "checkbox" Classes.IsCheckradio options children)

    let checkbox (options : Option list) children =
        Field.div [ ]
            [ checkboxInline options children ]

    let radioInline (options : Option list) children =
        fragment [ ]
            (genericElement "radio" Classes.IsCheckradio options children)

    let radio (options : Option list) children =
        Field.div [ ]
            [ radioInline options children ]
