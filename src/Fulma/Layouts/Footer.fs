namespace Fulma.Layouts

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Footer =

    module Classes =
        let [<Literal>] Container = "footer"

    /// Generate <div class="footer"></div>
    let footer (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        div (classes::opts.Props) children
