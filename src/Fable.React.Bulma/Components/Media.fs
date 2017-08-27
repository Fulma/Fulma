namespace Fable.React.Bulma.Components

open Fable.React.Bulma.BulmaClasses
open Fable.React.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Media =

    let media (options: GenericOption list) children =
        let opts = genericParse options

        article [ yield classBaseList Bulma.Media.Container
                                      [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
            children

    let left (options: GenericOption list) children =
        let opts = genericParse options

        figure [ yield classBaseList Bulma.Media.Left
                                     [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                 yield! opts.Props ]
            children

    let right (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Media.Right
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let content (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList Bulma.Media.Content
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
