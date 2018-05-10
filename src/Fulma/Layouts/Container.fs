namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Container =

    module Classes =
        let [<Literal>] Container = "container"
        let [<Literal>] IsFluid = "is-fluid"
        module Breakpoint =
            let [<Literal>] IsWideScreen = "is-widescreen"
            let [<Literal>] IsFullHD = "is-fullhd"

    type Option =
        /// Add `is-fluid` class
        | IsFluid
        /// Add `is-widescreen` class
        | IsWideScreen
        /// Add `is-fullhd` class
        | IsFullHD
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Props : IHTMLProp list
          CustomClass : string option
          IsFluid : bool
          Breakpoint : string option
          Modifiers : string option list }

        static member Empty =
            { Props = []
              CustomClass = None
              IsFluid = false
              Breakpoint = None
              Modifiers = [] }

    /// Generate <div class="container"></div>
    let container (options: Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | IsFluid -> { result with IsFluid = true }
            | IsWideScreen -> { result with Breakpoint = Classes.Breakpoint.IsWideScreen |> Some }
            | IsFullHD -> { result with Breakpoint = Classes.Breakpoint.IsFullHD |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes Classes.Container
                        ( opts.Breakpoint::opts.CustomClass::opts.Modifiers )
                        [Classes.IsFluid, opts.IsFluid]
        div (classes::opts.Props) children
