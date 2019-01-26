namespace Fulma

open Fulma
open Fable.Helpers.React

[<RequireQualifiedAccess>]
module Footer =

    /// Generate <div class="footer"></div>
    let footer (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "footer").ToReactElement(div, children)
