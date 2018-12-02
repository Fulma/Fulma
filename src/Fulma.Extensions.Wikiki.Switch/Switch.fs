namespace Fulma.Extensions.Wikiki

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Switch =

    module Classes =
        let [<Literal>] Switch = "switch"
        let [<Literal>] IsRounded = "is-rounded"
        let [<Literal>] IsOutlined = "is-outlined"
        let [<Literal>] IsThin = "is-thin"
        let [<Literal>] IsRtl = "is-rtl"

    type Option =
        | Color of IColor
        | Size of ISize
        | IsOutlined
        | IsRounded
        | IsThin
        | IsRtl
        | Checked of bool
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        | Props of IHTMLProp list
        | OnChange of (React.FormEvent -> unit)
        | CustomClass of string

    type internal Options =
        { Color : string option
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
          Id : string option }
        static member Empty =
            { Color = None
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
              Id = None }

    let switchInline (options : Option list) children =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Color color -> { result with Color = ofColor color |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsOutlined -> { result with IsOutlined  = true }
            | IsRounded -> { result with IsRounded  = true }
            | Checked state -> { result with IsChecked = state }
            | Disabled state -> { result with IsDisabled = state }
            | IsRtl -> { result with IsRtl = true }
            | IsThin -> { result with IsThin = true }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnChange cb -> { result with OnChange = cb |> Some }

        let opts = options |> List.fold parseOptions Options.Empty

        fragment [ ]
            [ input
                [ yield Helpers.classes Classes.Switch [opts.Color; opts.Size; opts.CustomClass] [Classes.IsOutlined, opts.IsOutlined; Classes.IsRounded, opts.IsRounded; Classes.IsThin, opts.IsThin; Classes.IsRtl, opts.IsRtl]
                  if Option.isSome opts.OnChange then
                    yield DOMAttr.OnChange opts.OnChange.Value
                    yield HTMLAttr.Checked opts.IsChecked
                  else
                    yield DefaultChecked opts.IsChecked
                  yield! opts.Props
                  yield Type "checkbox"
                  if Option.isSome opts.Id then
                    yield HTMLAttr.Id opts.Id.Value
                  yield HTMLAttr.Disabled opts.IsDisabled ]

              label [ if Option.isSome opts.Id then
                        yield HtmlFor opts.Id.Value ]
                    children ]

    let switch (options : Option list) children =
        Field.div [ ]
            [ switchInline options children ]
