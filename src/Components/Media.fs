namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Media =

    let media (options: GenericOption list) children =
        let opts = genericParse options

        article [ yield classBaseList bulma.Media.Container
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
            children

    let left (options: GenericOption list) children =
        let opts = genericParse options

        figure [ yield classBaseList bulma.Media.Left
                                     [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                 yield! opts.Props ]
            children

    let right (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList bulma.Media.Right
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let content (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList bulma.Media.Content
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
