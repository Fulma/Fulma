namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Level =

    module Types =

        module Level =

            type Option =
                | Props of IHTMLProp list
                | IsMobile

            type Options =
                { Props : IHTMLProp list
                  IsMobile : bool }

                static member Empty =
                    { Props = []
                      IsMobile = false }

        module Item =

            type Option =
                | Props of IHTMLProp list
                | HasTextCentered

            type Options =
                { Props : IHTMLProp list
                  HasTextCentered : bool }

                static member Empty =
                    { Props = []
                      HasTextCentered = false }

    open Types

    let level (options : Level.Option list) children =
        let parseOptions (result: Level.Options ) opt =
            match opt with
            | Level.Option.Props props -> { result with Props = props }
            | Level.Option.IsMobile -> { result with IsMobile = true }

        let opts = options |> List.fold parseOptions Level.Options.Empty

        nav [ yield classBaseList
                        bulma.Level.Container
                        [ bulma.Level.Mobile.IsHorizontal, opts.IsMobile ] :> IHTMLProp
              yield! opts.Props ]
            children

    let left props children =
        div [ yield ClassName bulma.Level.Left :> IHTMLProp
              yield! props ]
            children

    let right props children =
        div [ yield ClassName bulma.Level.Right :> IHTMLProp
              yield! props ]
            children

    let item (options : Item.Option list) children =
        let parseOptions (result: Item.Options ) opt =
            match opt with
            | Item.Props props -> { result with Props = props }
            | Item.HasTextCentered -> { result with HasTextCentered = true }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        nav [ yield classBaseList
                        bulma.Level.Item.Container
                        [ bulma.Level.Item.HasTextCentered, opts.HasTextCentered ] :> IHTMLProp
              yield! opts.Props ]
            children
