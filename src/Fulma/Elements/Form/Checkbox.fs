namespace Fulma.Elements.Form

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Checkbox =

    module Classes =
        let [<Literal>] Container = "checkbox"

    /// Generate <label class="checkbox"></label>
    let checkbox (options : GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        label (classes::opts.Props) children

    /// Generate <input type="checkbox" class="checkbox"></input>
    let input (options : GenericOption list) =
        let opts = genericParse options
        let classes = Helpers.classes "" [opts.CustomClass] []
        input (classes::(Type "checkbox" :> IHTMLProp)::opts.Props)
