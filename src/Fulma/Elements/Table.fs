namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Table =
    module Types =
        type TableOption =
            | IsBordered
            | IsStripped
            | IsNarrow
            | CustomClass of string
            | Props of IHTMLProp list

        type TableOptions =
            { IsBordered : bool
              IsStripped : bool
              IsNarrow : bool
              CustomClass : string option
              Props : IHTMLProp list }
            static member Empty =
                { IsBordered = false
                  IsStripped = false
                  IsNarrow = false
                  CustomClass = None
                  Props = [] }

    open Types

    // Styling
    let isBordered = IsBordered
    let isStripped = IsStripped
    // Spacing
    let isNarrow = IsNarrow
    // Extra
    let customClass = CustomClass
    let props = Props

    let table options children =
        let parseOptions (result : TableOptions) =
            function
            | IsBordered -> { result with IsBordered = true }
            | IsStripped -> { result with IsStripped = true }
            | IsNarrow -> { result with IsNarrow = true }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions TableOptions.Empty
        table
            [ yield classBaseList Bulma.Table.Container [ Bulma.Table.Style.IsBordered, opts.IsBordered
                                                          Bulma.Table.Style.IsStripped, opts.IsStripped
                                                          Bulma.Table.Spacing.IsNarrow, opts.IsNarrow
                                                          opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    module Row =
        // Row
        let isSelected = ClassName Bulma.Table.Row.State.IsSelected
