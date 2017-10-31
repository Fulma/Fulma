namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Footer =

    let customClass cls = CustomClass cls
    let inline props x = Props x

    let footer (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Footer.Container [opts.CustomClass] []

        div (class'::opts.Props) children
