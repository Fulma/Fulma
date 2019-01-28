namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Checkbox =

    /// Generate <label class="checkbox"></label>
    let checkbox (options : GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "checkbox").ToReactElement(label, children)

    /// Generate <input type="checkbox" class="checkbox"/>
    let input (options : GenericOption list) =
        GenericOptions.Parse(options, parseOption, "checkbox", [ Type "checkbox" :> IHTMLProp ]).ToReactElement(input)
