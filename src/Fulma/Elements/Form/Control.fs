namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Control =

    module Classes =
        let [<Literal>] Container = "control"
        module HasIcon =
            let [<Literal>] Left = "has-icons-left"
            let [<Literal>] Right = "has-icons-right"
        module State =
            let [<Literal>] IsLoading = "is-loading"
        let [<Literal>] IsExpanded = "is-expanded"

    type Option =
        /// Add `has-icon-right` class
        | HasIconRight
        /// Add `has-icon-left` class
        | HasIconLeft
        /// Add `is-loading` class if true
        | IsLoading of bool
        /// Add `is-expanded` class
        | IsExpanded
        | CustomClass of string
        | Props of IHTMLProp list

    type internal Options =
        { HasIconLeft : bool
          HasIconRight : bool
          CustomClass : string option
          Props : IHTMLProp list
          IsLoading : bool
          IsExpanded : bool }
        static member Empty =
            { HasIconLeft = false
              HasIconRight = false
              CustomClass = None
              Props = []
              IsLoading = false
              IsExpanded = false }

    let internal controlView element options children =
        let parseOptions (result : Options) =
            function
            | HasIconRight -> { result with HasIconRight = true }
            | HasIconLeft -> { result with HasIconLeft = true }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | IsLoading state -> { result with IsLoading = state }
            | IsExpanded  -> { result with IsExpanded = state }

        let opts = options |> List.fold parseOptions Options.Empty

        let classes = Helpers.classes
                        Classes.Container
                        [ opts.CustomClass ]
                        [ Classes.State.IsLoading, opts.IsLoading
                          Classes.HasIcon.Right, opts.HasIconRight
                          Classes.HasIcon.Left, opts.HasIconLeft
                          Classes.IsExpanded, opts.IsExpanded ]

        element (classes::opts.Props)
            children

    /// Generate <div class="control"></div>
    let div x y = controlView div x y
    /// Generate <p class="control"></p>
    let p x y = controlView p x y
