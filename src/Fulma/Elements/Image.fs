namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Image =

    module Classes =
        let [<Literal>] Container = "image"
        module Size =
            let [<Literal>] Is16x16 = "is-16x16"
            let [<Literal>] Is24x24 = "is-24x24"
            let [<Literal>] Is32x32 = "is-32x32"
            let [<Literal>] Is48x48 = "is-48x48"
            let [<Literal>] Is64x64 = "is-64x64"
            let [<Literal>] Is96x96 = "is-96x96"
            let [<Literal>] Is128x128 = "is-128x128"
        module Ratio =
            let [<Literal>] IsSquare = "is-square"
            let [<Literal>] Is1by1 = "is-1by1"
            let [<Literal>] Is5by4 = "is-5by4"
            let [<Literal>] Is4by3 = "is-4by3"
            let [<Literal>] Is3by2 = "is-3by2"
            let [<Literal>] Is5by3 = "is-5by3"
            let [<Literal>] Is16by9 = "is-16by9"
            let [<Literal>] Is2by1 = "is-2by1"
            let [<Literal>] Is3by1 = "is-3by1"
            let [<Literal>] Is4by5 = "is-4by5"
            let [<Literal>] Is3by4 = "is-3by4"
            let [<Literal>] Is2by3 = "is-2by3"
            let [<Literal>] Is3by5 = "is-3by5"
            let [<Literal>] Is9by16 = "is-9by16"
            let [<Literal>] Is1by2 = "is-1by2"
            let [<Literal>] Is1by3 = "is-1by3"

    type Option =
        // Size

        /// Add `is-16x16` class
        | Is16x16
        /// Add `is-24x24` class
        | Is24x24
        /// Add `is-32x32` class
        | Is32x32
        /// Add `is-48x48` class
        | Is48x48
        /// Add `is-64x64` class
        | Is64x64
        /// Add `is-96x96` class
        | Is96x96
        /// Add `is-128x128` class
        | Is128x128
        /// Add `is-square` class
        | IsSquare
        /// Add `is-1by1` class
        | Is1by1
        /// Add `is-5by4` class
        | Is5by4
        /// Add `is-4by3` class
        | Is4by3
        /// Add `is-3by2` class
        | Is3by2
        /// Add `is-5by3` class
        | Is5by3
        /// Add `is-16by9` class
        | Is16by9
        /// Add `is-2by1` class
        | Is2by1
        /// Add `is-3by1` class
        | Is3by1
        /// Add `is-4by5` class
        | Is4by5
        /// Add `is-3by4` class
        | Is3by4
        /// Add `is-2by3` class
        | Is2by3
        /// Add `is-3by5` class
        | Is3by5
        /// Add `is-9by16` class
        | Is9by16
        /// Add `is-1by2` class
        | Is1by2
        /// Add `is-1by3` class
        | Is1by3
        // Extra
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Size : string option
          Ratio : string option
          CustomClass : string option
          Props : IHTMLProp list
          Modifiers : string option list }
        static member Empty =
            { Size = None
              Ratio = None
              CustomClass = None
              Props = []
              Modifiers = [] }

    /// Generate <figure class="image"></figure>
    let image options children =
        let parseOptions (result : Options) =
            function
            // Size
            | Is16x16 -> { result with Size = Classes.Size.Is16x16 |> Some }
            | Is24x24 -> { result with Size = Classes.Size.Is24x24 |> Some }
            | Is32x32 -> { result with Size = Classes.Size.Is32x32 |> Some }
            | Is48x48 -> { result with Size = Classes.Size.Is48x48 |> Some }
            | Is64x64 -> { result with Size = Classes.Size.Is64x64 |> Some }
            | Is96x96 -> { result with Size = Classes.Size.Is96x96 |> Some }
            | Is128x128 -> { result with Size = Classes.Size.Is128x128 |> Some }
            // Ratio
            | IsSquare -> { result with Ratio = Classes.Ratio.IsSquare |> Some }
            | Is1by1 -> { result with Ratio = Classes.Ratio.Is1by1 |> Some }
            | Is5by4 -> { result with Ratio = Classes.Ratio.Is5by4 |> Some }
            | Is4by3 -> { result with Ratio = Classes.Ratio.Is4by3 |> Some }
            | Is3by2 -> { result with Ratio = Classes.Ratio.Is3by2 |> Some }
            | Is5by3 -> { result with Ratio = Classes.Ratio.Is5by3 |> Some }
            | Is16by9 -> { result with Ratio = Classes.Ratio.Is16by9 |> Some }
            | Is2by1 -> { result with Ratio = Classes.Ratio.Is2by1 |> Some }
            | Is3by1 -> { result with Ratio = Classes.Ratio.Is3by1 |> Some }
            | Is4by5 -> { result with Ratio = Classes.Ratio.Is4by5 |> Some }
            | Is3by4 -> { result with Ratio = Classes.Ratio.Is3by4 |> Some }
            | Is2by3 -> { result with Ratio = Classes.Ratio.Is2by3 |> Some }
            | Is3by5 -> { result with Ratio = Classes.Ratio.Is3by5 |> Some }
            | Is9by16 -> { result with Ratio = Classes.Ratio.Is9by16 |> Some }
            | Is1by2 -> { result with Ratio = Classes.Ratio.Is1by2 |> Some }
            | Is1by3 -> { result with Ratio = Classes.Ratio.Is1by3 |> Some }
            // Extra
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.Size
                          ::opts.Ratio
                          ::opts.CustomClass
                          ::opts.Modifiers )
                        [ ]
        figure (classes::opts.Props)
            children
