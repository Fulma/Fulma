namespace Fulma

open Fulma
open Fable.Helpers.React

[<RequireQualifiedAccess>]
module Footer =

    module Classes =
        let [<Literal>] Container = "footer"

    /// Generate <div class="footer"></div>
    let footer (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container ( opts.CustomClass::opts.Modifiers ) []
        div (classes::opts.Props) children
