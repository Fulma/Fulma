namespace Fable.React.Bulma.Elements

open Fable.React.Bulma.BulmaClasses
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.React.Bulma.Common

module Box =

    let customClass cls = CustomClass cls
    let props props = Props props

    let box' (options: GenericOption list) children =
        let opts = genericParse options

        div
            [ yield classBaseList
                        Bulma.Box.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
