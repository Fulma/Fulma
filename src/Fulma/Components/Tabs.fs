namespace Fulma.Components

open Fulma
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tabs =

    module Classes =
        let [<Literal>] Container = "tabs"
        module State =
            let [<Literal>] IsActive = "is-active"
        module Alignment =
            let [<Literal>] Center = "is-centered"
            let [<Literal>] Right = "is-right"
        module Style =
            let [<Literal>] IsBoxed = "is-boxed"
            let [<Literal>] IsToggle = "is-toggle"
            let [<Literal>] IsFullwidth = "is-fullwidth"

    type Option =
        | IsCentered
        | IsRight
        | Size of ISize
        | IsBoxed
        | IsToggle
        | IsFullwidth
        | CustomClass of string
        | Props of IHTMLProp list

    type internal Options =
        { Alignment : string option
          Size : string option
          IsBoxed : bool
          IsToggle : bool
          IsFullwidth : bool
          CustomClass : string option
          Props : IHTMLProp list }

        static member Empty =
            { Alignment = None
              IsBoxed = false
              IsToggle = false
              IsFullwidth = false
              Size = None
              CustomClass = None
              Props = [] }

    module Tab =

        type Option =
            | Active of bool
            | CustomClass of string
            | Props of IHTMLProp list

        type internal Options =
            { IsActive : bool
              CustomClass : string option
              Props : IHTMLProp list }

            static member Empty =
                { IsActive = false
                  CustomClass = None
                  Props = [] }

    let tabs (options: Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | IsCentered -> { result with Alignment = Classes.Alignment.Center |> Some }
            | IsRight -> { result with Alignment = Classes.Alignment.Right |> Some }
            | IsBoxed -> { result with IsBoxed = true }
            | IsToggle -> { result with IsToggle = true }
            | IsFullwidth -> { result with IsFullwidth = true }
            | Size size -> { result with Size = ofSize size |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Alignment; opts.Size ]
                        [ Classes.Style.IsBoxed, opts.IsBoxed
                          Classes.Style.IsFullwidth, opts.IsFullwidth
                          Classes.Style.IsToggle, opts.IsToggle ]
        div (classes::opts.Props)
            [ ul [ ]
                 children ]

    let tab (options: Tab.Option list) children =
        let parseOptions (result: Tab.Options) opt =
            match opt with
            | Tab.Active state -> { result with IsActive = state }
            | Tab.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Tab.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Tab.Options.Empty
        let classes = classList [ Classes.State.IsActive, opts.IsActive ] :> IHTMLProp
        li (classes::opts.Props)
            children
