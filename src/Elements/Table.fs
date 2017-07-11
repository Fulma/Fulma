namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Table =
    module Types =
        type TableOption =
            | IsBordered
            | IsStripped
            | IsNarrow
            | Classy of string
            | Props of IHTMLProp list

        type TableOptions =
            { IsBordered : bool
              IsStripped : bool
              IsNarrow : bool
              Classy : string option
              Props : IHTMLProp list }
            static member Empty =
                { IsBordered = false
                  IsStripped = false
                  IsNarrow = false
                  Classy = None
                  Props = [] }

    open Types

    // Styling
    let isBordered = IsBordered
    let isStripped = IsStripped
    // Spacing
    let isNarrow = IsNarrow
    // Extra
    let classy = Classy
    let props = Props

    let table options children =
        let parseOptions (result : TableOptions) =
            function
            | IsBordered -> { result with IsBordered = true }
            | IsStripped -> { result with IsStripped = true }
            | IsNarrow -> { result with IsNarrow = true }
            | Classy classy -> { result with Classy = classy |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions TableOptions.Empty
        table
            [ yield classBaseList bulma.Table.Container [ bulma.Table.Style.IsBordered, opts.IsBordered
                                                          bulma.Table.Style.IsStripped, opts.IsStripped
                                                          bulma.Table.Spacing.IsNarrow, opts.IsNarrow
                                                          opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    module Row =
        // Row
        let isSelected = ClassName bulma.Table.Row.State.IsSelected
