namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Image =

    type Option =
        // Size

        /// Add `is-16x16` class
        | [<CompiledName("is-16x16")>] Is16x16
        /// Add `is-24x24` class
        | [<CompiledName("is-24x24")>] Is24x24
        /// Add `is-32x32` class
        | [<CompiledName("is-32x32")>] Is32x32
        /// Add `is-48x48` class
        | [<CompiledName("is-48x48")>] Is48x48
        /// Add `is-64x64` class
        | [<CompiledName("is-64x64")>] Is64x64
        /// Add `is-96x96` class
        | [<CompiledName("is-96x96")>] Is96x96
        /// Add `is-128x128` class
        | [<CompiledName("is-128x128")>] Is128x128
        /// Add `is-square` class
        | [<CompiledName("is-square")>] IsSquare
        /// Add `is-1by1` class
        | [<CompiledName("is-1by1")>] Is1by1
        /// Add `is-5by4` class
        | [<CompiledName("is-5by4")>] Is5by4
        /// Add `is-4by3` class
        | [<CompiledName("is-4by3")>] Is4by3
        /// Add `is-3by2` class
        | [<CompiledName("is-3by2")>] Is3by2
        /// Add `is-5by3` class
        | [<CompiledName("is-5by3")>] Is5by3
        /// Add `is-16by9` class
        | [<CompiledName("is-16by9")>] Is16by9
        /// Add `is-2by1` class
        | [<CompiledName("is-2by1")>] Is2by1
        /// Add `is-3by1` class
        | [<CompiledName("is-3by1")>] Is3by1
        /// Add `is-4by5` class
        | [<CompiledName("is-4by5")>] Is4by5
        /// Add `is-3by4` class
        | [<CompiledName("is-3by4")>] Is3by4
        /// Add `is-2by3` class
        | [<CompiledName("is-2by3")>] Is2by3
        /// Add `is-3by5` class
        | [<CompiledName("is-3by5")>] Is3by5
        /// Add `is-9by16` class
        | [<CompiledName("is-9by16")>] Is9by16
        /// Add `is-1by2` class
        | [<CompiledName("is-1by2")>] Is1by2
        /// Add `is-1by3` class
        | [<CompiledName("is-1by3")>] Is1by3
        // Extra
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <figure class="image"></figure>
    let image options children =
        let parseOptions (result : GenericOptions) opt =
            match opt with
            // Size
            | Is16x16
            | Is24x24
            | Is32x32
            | Is48x48
            | Is64x64
            | Is96x96
            | Is128x128
            // Ratio
            | IsSquare
            | Is1by1
            | Is5by4
            | Is4by3
            | Is3by2
            | Is5by3
            | Is16by9
            | Is2by1
            | Is3by1
            | Is4by5
            | Is3by4
            | Is2by3
            | Is3by5
            | Is9by16
            | Is1by2
            | Is1by3 -> result.AddCaseName opt
            // Extra
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "image").ToReactElement(figure, children)
