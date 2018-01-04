namespace Fulma.Elements

open Fable.Helpers.React
open Fulma

[<RequireQualifiedAccess>]
module Box =

    module Classes =
        let [<Literal>] Container = "box"

    let box' (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        div (classes::opts.Props) children
