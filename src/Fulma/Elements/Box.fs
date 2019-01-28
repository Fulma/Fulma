namespace Fulma

open Fable.Helpers.React
open Fulma

[<RequireQualifiedAccess>]
module Box =

    /// Generate <div class="box"></div>
    let box' (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "box").ToReactElement(div, children)
