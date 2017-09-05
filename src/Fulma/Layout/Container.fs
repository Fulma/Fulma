namespace Fulma.Layout

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

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

    let props = Props
    let customClass = CustomClass
    let isFluid = IsFluid
    let isWideScreen = Breakpoint Widescreen
    let isFullHD = Breakpoint FullHD

    let container (options: Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | IsFluid -> { result with IsFluid = true }
            | Breakpoint breakpoint -> { result with Breakpoint = ofBreakpoint breakpoint |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield classBaseList
                        Bulma.Container.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome
                          Bulma.Container.IsFluid, opts.IsFluid
                          opts.Breakpoint.Value, opts.Breakpoint.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
