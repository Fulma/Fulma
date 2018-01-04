namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Panel =

    module Classes =
        let [<Literal>] Container = "panel"
        let [<Literal>] Heading = "panel-heading"
        module Tabs =
            let [<Literal>] Container = "panel-tabs"
            module Tab =
                module State =
                    let [<Literal>] IsActive = "is-active"
        module Block =
            let [<Literal>] Container = "panel-block"
            let [<Literal>] Icon = "panel-icon"
            let [<Literal>] List = "panel-list"
            module State =
                let [<Literal>] IsActive = "is-active"

    module Block =

        type Option =
            | Props of IHTMLProp list
            | Active of bool
            | CustomClass of string

        type internal Options =
            { Props : IHTMLProp list
              CustomClass : string option
              IsActive : bool }

            static member Empty =
                { Props = []
                  CustomClass = None
                  IsActive = false }

    module Tab =

        type Option =
            | Props of IHTMLProp list
            | Active of bool
            | CustomClass of string

        type internal Options =
            { Props : IHTMLProp list
              CustomClass : string option
              IsActive : bool }

            static member Empty =
                { Props = []
                  CustomClass = None
                  IsActive = false }

    let block (options : Block.Option list) children =
        let parseOptions (result: Block.Options ) opt =
            match opt with
            | Block.Props props -> { result with Props = props }
            | Block.Active state -> { result with IsActive = state }
            | Block.CustomClass customClass -> { result with CustomClass = Some customClass }


        let opts = options |> List.fold parseOptions Block.Options.Empty
        let classes = Helpers.classes Classes.Block.Container [opts.CustomClass] [Classes.Block.State.IsActive, opts.IsActive]
        div (classes::opts.Props) children

    let checkbox (options : Block.Option list) children =
        let parseOptions (result: Block.Options ) opt =
            match opt with
            | Block.Props props -> { result with Props = props }
            | Block.Active state -> { result with IsActive = state }
            | Block.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Block.Options.Empty
        let classes = Helpers.classes Classes.Block.Container [opts.CustomClass] [Classes.Block.State.IsActive, opts.IsActive]
        label (classes::opts.Props) children

    let panel (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        nav (classes::opts.Props) children

    let heading (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Heading [opts.CustomClass] []
        div (classes::opts.Props) children

    let tabs (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Tabs.Container [opts.CustomClass] []
        div (classes::opts.Props) children

    let tab (options: Tab.Option list) children =
        let parseOptions (result: Tab.Options ) opt =
            match opt with
            | Tab.Props props -> { result with Props = props }
            | Tab.Active state -> { result with IsActive = state }
            | Tab.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Tab.Options.Empty
        let classes = Helpers.classes "" [opts.CustomClass] [Classes.Tabs.Tab.State.IsActive, opts.IsActive]
        a (classes::opts.Props) children

    let icon (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Block.Icon [opts.CustomClass] []
        span (classes::opts.Props) children
