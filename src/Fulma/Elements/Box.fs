namespace Fulma.Elements

open Fulma.BulmaClasses
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma.Common

[<RequireQualifiedAccess>]
module Box =

    let customClass cls = CustomClass cls
    let inline props x = Props x

    let box' (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Box.Container [opts.CustomClass] []
        div (class'::opts.Props) children
