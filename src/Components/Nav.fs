namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Nav =

    module Types =

        module Nav =

            type Option =
                | HasShadow
                | Props of IHTMLProp list

            type Options =
                { HasShadow : bool
                  Props : IHTMLProp list }

                static member Empty =
                    { HasShadow = false
                      Props = [] }


        module Item =

            type Option =
                | IsTab
                | IsActive
                | Props of IHTMLProp list

            type Options =
                { IsTab : bool
                  IsActive : bool
                  Props : IHTMLProp list }

                static member Empty =
                    { IsTab = false
                      IsActive = false
                      Props = [] }

        module Toggle =

            type Option =
                | IsActive
                | Props of IHTMLProp list

            type Options =
                { IsActive : bool
                  Props : IHTMLProp list }

                static member Empty =
                    { IsActive = false
                      Props = [] }

        module Menu =

            type Option =
                | IsActive
                | Props of IHTMLProp list

            type Options =
                { IsActive : bool
                  Props : IHTMLProp list }

                static member Empty =
                    { IsActive = false
                      Props = [] }

    open Types

    // Helpers definitions

    let hasShadow = Nav.HasShadow
    let props props = Nav.Props props

    module Item =
        let isActive = Item.IsActive
        let isTab = Item.IsTab
        let props props = Item.Props props

    module Toggle =
        let isActive = Toggle.IsActive
        let props props = Toggle.Props props

    module Menu =
        let isActive = Menu.IsActive
        let props props = Menu.Props props

    let nav (options : Nav.Option list) children =
        let parseOptions (result: Nav.Options ) opt =
            match opt with
            | Nav.HasShadow -> { result with HasShadow = true }
            | Nav.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Nav.Options.Empty

        nav [ yield (classBaseList bulma.Nav.Container
                                   [ bulma.Nav.Style.HasShadow, opts.HasShadow ]) :> IHTMLProp
              yield! opts.Props ]
            children

    let left props children =
        div [ yield ClassName bulma.Nav.Left :> IHTMLProp
              yield! props ]
            children

    let right props children =
        div [ yield ClassName bulma.Nav.Right :> IHTMLProp
              yield! props ]
            children

    let center props children =
        div [ yield ClassName bulma.Nav.Center :> IHTMLProp
              yield! props ]
            children

    let item options children =
        let parseOptions (result: Item.Options ) opt =
            match opt with
            | Item.IsActive -> { result with IsActive = true }
            | Item.IsTab -> { result with IsTab = true }
            | Item.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        a [ yield (classBaseList bulma.Nav.Item.Container
                                  [ bulma.Nav.Item.State.IsActive, opts.IsActive
                                    bulma.Nav.Item.Style.IsTab, opts.IsTab ]) :> IHTMLProp
            yield! opts.Props ]
            children

    let toggle options =
        let parseOptions (result: Toggle.Options ) opt =
            match opt with
            | Toggle.IsActive -> { result with IsActive = true }
            | Toggle.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Toggle.Options.Empty

        span [ yield (classBaseList bulma.Nav.Toggle.Container
                                    [ bulma.Nav.Toggle.State.IsActive, opts.IsActive ]) :> IHTMLProp ]

    let menu options children =
        let parseOptions (result: Menu.Options ) opt =
            match opt with
            | Toggle.IsActive -> { result with IsActive = true }
            | Toggle.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Menu.Options.Empty

        span [ yield (classBaseList bulma.Nav.Menu.Container
                                    [ bulma.Nav.Menu.State.IsActive, opts.IsActive ]) :> IHTMLProp ]
              children
