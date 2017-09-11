namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Section =

    module Types =

        type ISpacing =
            | Medium
            | Large

        type Option =
            | Props of IHTMLProp list
            | CustomClass of string
            | Spacing of ISpacing

        let ofSpacing =
            function
            | Medium -> Bulma.Section.Spacing.IsMedium
            | Large -> Bulma.Section.Spacing.IsLarge

        type Options =
            { Props : IHTMLProp list
              CustomClass : string option
              Spacing : string option }

            static member Empty =
                { Props = []
                  CustomClass = None
                  Spacing = None }

    open Types

    let props = Props
    let customClass = CustomClass
    let isMedium = IsMedium
    let isLarge = IsLarge

    let section (options: Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | Spacing spacing -> { result with Spacing = ofSpacing spacing |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty

        section [ yield classBaseList
                        Bulma.Section.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome
                          opts.Spacing.Value, opts.Spacing.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
            children
