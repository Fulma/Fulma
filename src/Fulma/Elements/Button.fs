namespace Fulma.Elements

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Button =

    module Classes =
        let [<Literal>] Container = "button"
        module State =
              let [<Literal>] IsHovered = "is-hovered"
              let [<Literal>] IsFocused = "is-focus"
              let [<Literal>] IsActive = "is-active"
              let [<Literal>] IsLoading = "is-loading"
              let [<Literal>] IsStatic = "is-static"
        module Styles =
            let [<Literal>] IsFullwidth = "is-fullwidth"
            let [<Literal>] IsLink = "is-link"
            let [<Literal>] IsOutlined = "is-outlined"
            let [<Literal>] IsInverted = "is-inverted"
            let [<Literal>] IsText = "is-text"

    type Option =
        // Colors
        | Color of IColor
        | Size of ISize
        // Styles
        | IsFullwidth
        | IsLink
        | IsOutlined
        | IsInverted
        | IsText
        // States
        | IsHovered
        | IsFocused
        | IsActive of bool
        | IsLoading of bool
        | IsStatic
        | Disabled of bool
        | Props of IHTMLProp list
        | OnClick of (MouseEvent -> unit)
        | CustomClass of string

    type internal Options =
        { Level : string option
          Size : string option
          IsOutlined : bool
          IsInverted : bool
          IsDisabled : bool
          IsText : bool
          State : string option
          Props : IHTMLProp list
          CustomClass : string option
          OnClick : (MouseEvent -> unit) option }
        static member Empty =
            { Level = None
              Size = None
              IsOutlined = false
              IsInverted = false
              IsDisabled = false
              IsText = false
              State = None
              Props = []
              CustomClass = None
              OnClick = None }

    let button (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Color color -> { result with Level = ofColor color |> Some }
            // Sizes
            | Size size -> { result with Size = ofSize size |> Some }
            // Styles
            | IsFullwidth -> { result with Size = Classes.Styles.IsFullwidth  |> Some }
            | IsLink -> { result with Level = Classes.Styles.IsLink |> Some }
            | IsOutlined -> { result with IsOutlined = true }
            | IsInverted -> { result with IsInverted = true }
            | IsText -> { result with IsText = true }
            // States
            | IsHovered -> { result with State = Classes.State.IsHovered |> Some }
            | IsFocused -> { result with State = Classes.State.IsFocused |> Some }
            | IsActive true -> { result with State = Classes.State.IsActive |> Some }
            | IsActive false -> { result with State = None }
            | IsLoading true -> { result with State = Classes.State.IsLoading |> Some }
            | IsLoading false -> { result with State = None }
            | IsStatic -> { result with State = Classes.State.IsStatic |> Some }
            | Disabled isDisabled -> { result with IsDisabled = isDisabled }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnClick cb -> { result with OnClick = cb |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Level
                          opts.Size
                          opts.State
                          opts.CustomClass ]
                        [ Classes.Styles.IsOutlined, opts.IsOutlined
                          Classes.Styles.IsInverted, opts.IsInverted
                          Classes.Styles.IsText, opts.IsText ]

        button
            [ yield classes
              yield Fable.Helpers.React.Props.Disabled opts.IsDisabled :> IHTMLProp
              if Option.isSome opts.OnClick then
                yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
              yield! opts.Props ]
            children
