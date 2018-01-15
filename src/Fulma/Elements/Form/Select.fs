namespace Fulma.Elements.Form

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Select =

    module Classes =
        let [<Literal>] Container = "select"
        module State =
            let [<Literal>] IsDisabled = "is-disabled"
            let [<Literal>] IsLoading = "is-loading"
            let [<Literal>] IsFocused = "is-focused"
            let [<Literal>] IsActive = "is-active"
        module Size =
            let [<Literal>] IsSmall = "is-small"
            let [<Literal>] IsMedium = "is-medium"
            let [<Literal>] IsLarge = "is-large"
            let [<Literal>] IsFullwidth = "is-fullwidth"
            let [<Literal>] IsInline = "is-inline"
        module Styles =
            let [<Literal>] IsRounded = "is-rounded"

    type Option =
        | Size of ISize
        | IsFullwidth
        | IsInline
        | Loading of bool
        | Focused of bool
        | IsActive of bool
        | Disabled of bool
        | Color of IColor
        | IsRounded
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { Size : string option
          Color : string option
          IsLoading : bool
          IsFocused : bool
          IsActive : bool
          IsDisabled : bool
          IsRounded : bool
          Props : IHTMLProp list
          CustomClass : string option }
        static member Empty =
            { Size = None
              Color = None
              IsLoading = false
              IsFocused = false
              IsActive = false
              IsDisabled = false
              IsRounded = false
              Props = []
              CustomClass = None }

    let select (options : Option list) children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with Size = ofSize size |> Some }
            | IsFullwidth -> { result with Size = Classes.Size.IsFullwidth |> Some }
            | IsInline -> { result with Size = Classes.Size.IsInline |> Some }
            | Loading state -> { result with IsLoading = state }
            | Focused state -> { result with IsFocused = state }
            | IsActive state -> { result with IsActive = state }
            | Disabled state -> { result with IsDisabled = state }
            | IsRounded -> { result with IsRounded = true }
            | Color color -> { result with Color = ofColor color |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            Helpers.classes
                Classes.Container
                [ opts.Size
                  opts.Color
                  opts.CustomClass ]
                [ Classes.State.IsLoading, opts.IsLoading
                  Classes.State.IsFocused, opts.IsFocused
                  Classes.State.IsActive, opts.IsActive
                  Classes.State.IsDisabled, opts.IsDisabled
                  Classes.Styles.IsRounded, opts.IsRounded ]
        div (classes::opts.Props) children
