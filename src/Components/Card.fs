namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Card =

    let customClass = CustomClass
    let props = Props

    let card (options: GenericOption list) children =
        let opts = genericParse options
        div [ yield classBaseList
                        bulma.Card.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let header (options: GenericOption list) children =
        let opts = genericParse options
        header [ yield classBaseList
                        bulma.Card.Header.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                 yield! opts.Props ]
               children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        div [ yield classBaseList
                        bulma.Card.Content
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let footer (options: GenericOption list) children =
        let opts = genericParse options
        footer [ yield classBaseList
                        bulma.Card.Footer.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                 yield! opts.Props ]
               children

    module Header =

        let customClass = CustomClass
        let props = Props

        let icon (options: GenericOption list) children =
            let opts = genericParse options
            a [ yield classBaseList
                        bulma.Card.Header.Icon
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
              children

        let title (options: GenericOption list) children =
            let opts = genericParse options
            p [ yield classBaseList
                        bulma.Card.Header.Title
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
              children

    module Footer =

        let customClass = CustomClass
        let props = Props

        let item (options: GenericOption list) children =
            let opts = genericParse options

            a [ yield classBaseList
                        bulma.Card.Footer.Item
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
              children
