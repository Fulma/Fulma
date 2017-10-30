namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Container =

    module Types =

        type IBreakpoint =
            | Widescreen
            | FullHD

        type Option =
            | Props of IHTMLProp list
            | CustomClass of string
            | IsFluid
            | Breakpoint of IBreakpoint

        let ofBreakpoint =
            function
            | Widescreen -> Bulma.Container.Breakpoint.IsWideScreen
            | FullHD -> Bulma.Container.Breakpoint.IsFullHD

        type Options =
            { Props : IHTMLProp list
              CustomClass : string option
              IsFluid : bool
              Breakpoint : string option }

            static member Empty =
                { Props = []
                  CustomClass = None
                  IsFluid = false
                  Breakpoint = None }

    open Types

    let inline props x = Props x
    let inline customClass x = CustomClass x
    let inline isFluid<'T> = IsFluid
    let inline isWideScreen<'T> = Breakpoint Widescreen
    let inline isFullHD<'T> = Breakpoint FullHD

    let container (options: Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | IsFluid -> { result with IsFluid = true }
            | Breakpoint breakpoint -> { result with Breakpoint = ofBreakpoint breakpoint |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty
        let class' = Helpers.classes Bulma.Container.Container
                        [opts.Breakpoint; opts.CustomClass]
                        [Bulma.Container.IsFluid, opts.IsFluid]
        div (class'::opts.Props) children
