namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

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
                        bulma.Panel.Block.Container
                        [ bulma.Panel.Block.State.IsActive, opts.IsActive
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
                        bulma.Panel.Block.Container
                        [ bulma.Panel.Block.State.IsActive, opts.IsActive
                          opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
            children

    let panel (options: GenericOption list) children =
        let opts = genericParse options

        nav [ yield classBaseList bulma.Panel.Container
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let heading (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList bulma.Panel.Heading
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let tabs (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList bulma.Panel.Tabs.Container
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

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

        a [ yield classList [ bulma.Panel.Tabs.Tab.State.IsActive, opts.IsActive
                              opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
          children

    let icon (options: GenericOption list) children =
        let opts = genericParse options

        span [ yield classBaseList bulma.Panel.Block.Icon
                                   [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
               yield! opts.Props ]
            children
