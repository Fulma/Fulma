namespace Fulma

open Fable.React
open Fulma

[<RequireQualifiedAccess>]
module Box =

    /// Generate <div class="box"></div>
    let box' (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "box").ToReactElement(div, children)
