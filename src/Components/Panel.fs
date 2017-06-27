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

            type Options =
                { Props : IHTMLProp list
                  IsActive : bool }

                static member Empty =
                    { Props = []
                      IsActive = false }

        module Tab =

            type Option =
            | Props of IHTMLProp list
            | IsActive

            type Options =
                { Props : IHTMLProp list
                  IsActive : bool }

                static member Empty =
                    { Props = []
                      IsActive = false }

    open Types


    module Block =
        let isActive = Block.IsActive

    let block (options : Block.Option list) children =
        let parseOptions (result: Block.Options ) opt =
            match opt with
            | Block.Props props -> { result with Props = props }
            | Block.IsActive -> { result with IsActive = true }

        let opts = options |> List.fold parseOptions Block.Options.Empty

        div [ yield classBaseList
                        bulma.Panel.Block.Container
                        [ bulma.Panel.Block.State.IsActive, opts.IsActive ] :> IHTMLProp
              yield! opts.Props ]
            children

    let checkbox (options : Block.Option list) children =
        let parseOptions (result: Block.Options ) opt =
            match opt with
            | Block.Props props -> { result with Props = props }
            | Block.IsActive -> { result with IsActive = true }

        let opts = options |> List.fold parseOptions Block.Options.Empty

        label [ yield classBaseList
                        bulma.Panel.Block.Container
                        [ bulma.Panel.Block.State.IsActive, opts.IsActive ] :> IHTMLProp
                yield! opts.Props ]
            children

    let panel children =
        nav [ ClassName bulma.Panel.Container ]
            children

    let heading children =
        div [ ClassName bulma.Panel.Heading ]
            children

    let tabs children =
        div [ ClassName bulma.Panel.Tabs.Container ]
            children

    module Tab =
        let isActive = Tab.IsActive

    let tab (options: Tab.Option list) children =
        let parseOptions (result: Tab.Options ) opt =
            match opt with
            | Tab.Props props -> { result with Props = props }
            | Tab.IsActive -> { result with IsActive = true }

        let opts = options |> List.fold parseOptions Tab.Options.Empty

        a [ yield classList [ bulma.Panel.Tabs.Tab.State.IsActive, opts.IsActive ] :> IHTMLProp
            yield! opts.Props ]
          children

    let icon children =
        span [ ClassName bulma.Panel.Block.Icon ]
            children
