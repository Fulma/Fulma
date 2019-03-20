namespace Fulma

open Fulma
open Fable.React

[<RequireQualifiedAccess>]
module Footer =

    /// Generate <footer class="footer"></footer>
    let footer (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "footer").ToReactElement(footer, children)
