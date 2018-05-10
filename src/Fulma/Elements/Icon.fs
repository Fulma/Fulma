namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Icon =

    module Classes =
        let [<Literal>] Container = "icon"
        module Position =
              let [<Literal>] Left = "is-left"
              let [<Literal>] Right = "is-right"

    type Option =
        // Sizes
        | Size of ISize
        /// Add `is-left` class
        | IsLeft
        /// Add `is-right` class
        | IsRight
        // Extra
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Size : string option
          Position : string option
          CustomClass : string option
          Props : IHTMLProp list
          Modifiers : string option list }
        static member Empty =
            { Size = None
              Position = None
              CustomClass = None
              Props = []
              Modifiers = [] }

    /// Generate <span class="icon"></span>
    let icon options children =
        let parseOptions (result : Options) option =
            match option with
            // Sizes
            | Size size -> { result with Size = ofSize size |> Some }
            // Position
            | IsLeft -> { result with Position = Classes.Position.Left |> Some }
            | IsRight -> { result with Position = Classes.Position.Right |> Some }
            // Extra
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.Size
                          ::opts.Position
                          ::opts.CustomClass
                          ::opts.Modifiers )
                        [ ]
        span (classes::opts.Props)
            children
