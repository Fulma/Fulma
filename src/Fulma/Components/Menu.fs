namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Menu =

    let menu (options: GenericOption list) children =
        let opts = genericParse options

        aside [ yield classBaseList Bulma.Menu.Container
                                    [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
              children

    let label (options: GenericOption list) children =
        let opts = genericParse options

        p [ yield classBaseList Bulma.Menu.Label
                                [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
          children

    let list (options: GenericOption list) children =
        let opts = genericParse options

        ul [ yield classBaseList Bulma.Menu.List
                                 [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
             yield! opts.Props ]
           children
