namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Container =

    module Classes =
        let [<Literal>] Container = "container"
        let [<Literal>] IsFluid = "is-fluid"
        module Breakpoint =
            let [<Literal>] IsWideScreen = "is-widescreen"
            let [<Literal>] IsFullHD = "is-fullhd"

    type Option =
        | Props of IHTMLProp list
        | CustomClass of string
        /// Add `is-fluid` class
        | IsFluid
        /// Add `is-widescreen` class
        | IsWideScreen
        /// Add `is-fullhd` class
        | IsFullHD

    type internal Options =
        { Props : IHTMLProp list
          CustomClass : string option
          IsFluid : bool
          Breakpoint : string option }

        static member Empty =
            { Props = []
              CustomClass = None
              IsFluid = false
              Breakpoint = None }

    /// Generate <div class="container"></div>
    let container (options: Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | IsFluid -> { result with IsFluid = true }
            | IsWideScreen -> { result with Breakpoint = Classes.Breakpoint.IsWideScreen |> Some }
            | IsFullHD -> { result with Breakpoint = Classes.Breakpoint.IsFullHD |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes Classes.Container
                        [opts.Breakpoint; opts.CustomClass]
                        [Classes.IsFluid, opts.IsFluid]
        div (classes::opts.Props) children
