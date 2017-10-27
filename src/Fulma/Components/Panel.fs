namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Panel =

    module Types =

        module Block =

            type Option =
            | Props of IHTMLProp list
            | IsActive
            | CustomClass of string

            type Options =
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
            | IsActive
            | CustomClass of string

            type Options =
                { Props : IHTMLProp list
                  CustomClass : string option
                  IsActive : bool }

                static member Empty =
                    { Props = []
                      CustomClass = None
                      IsActive = false }

    open Types


    module Block =
        let isActive = Block.IsActive
        let props = Block.Props
        let customClass = Block.CustomClass

    let block (options : Block.Option list) children =
        let parseOptions (result: Block.Options ) opt =
            match opt with
            | Block.Props props -> { result with Props = props }
            | Block.IsActive -> { result with IsActive = true }
            | Block.CustomClass customClass -> { result with CustomClass = Some customClass }


        let opts = options |> List.fold parseOptions Block.Options.Empty

        div [ yield classBaseList
                        Bulma.Panel.Block.Container
                        [ Bulma.Panel.Block.State.IsActive, opts.IsActive
                          opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let checkbox (options : Block.Option list) children =
        let parseOptions (result: Block.Options ) opt =
            match opt with
            | Block.Props props -> { result with Props = props }
            | Block.IsActive -> { result with IsActive = true }
            | Block.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Block.Options.Empty

        label [ yield classBaseList
                        Bulma.Panel.Block.Container
                        [ Bulma.Panel.Block.State.IsActive, opts.IsActive
                          opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
            children

    let panel (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Panel.Container [opts.CustomClass] []
        nav (class'::opts.Props) children

    let heading (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Panel.Heading [opts.CustomClass] []
        div (class'::opts.Props) children

    let tabs (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Panel.Tabs.Container [opts.CustomClass] []
        div (class'::opts.Props) children

    module Tab =
        let isActive = Tab.IsActive
        let props = Tab.Props
        let customClass = Tab.CustomClass

    let tab (options: Tab.Option list) children =
        let parseOptions (result: Tab.Options ) opt =
            match opt with
            | Tab.Props props -> { result with Props = props }
            | Tab.IsActive -> { result with IsActive = true }
            | Tab.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Tab.Options.Empty

        a [ yield classList [ Bulma.Panel.Tabs.Tab.State.IsActive, opts.IsActive
                              opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
          children

    let icon (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Panel.Block.Icon [opts.CustomClass] []
        span (class'::opts.Props) children
