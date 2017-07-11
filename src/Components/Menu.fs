namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Menu =

    let menu (options: GenericOption list) children =
        let opts = genericParse options

        aside [ yield classBaseList bulma.Menu.Container
                                    [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                yield! opts.Props ]
              children

    let label (options: GenericOption list) children =
        let opts = genericParse options

        p [ yield classBaseList bulma.Menu.Label
                                [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
          children

    let list (options: GenericOption list) children =
        let opts = genericParse options

        ul [ yield classBaseList bulma.Menu.List
                                 [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
             yield! opts.Props ]
           children
