namespace Fulma.Layout

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Footer =

    let customClass cls = CustomClass cls
    let props props = Props props

    let footer (options: GenericOption list) children =
        let opts = genericParse options

        div
            [ yield classBaseList
                        Bulma.Footer.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
