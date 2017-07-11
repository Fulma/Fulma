namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Elmish.Bulma.Common

module Box =

    let classy cls = Classy cls
    let props props = Props props

    let box' (options: GenericOption list) children =
        let opts = genericParse options

        div
            [ yield classBaseList
                        bulma.Box.Container
                        [ opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
