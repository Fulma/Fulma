namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Table =
    module Types =
        type TableOption =
            | IsBordered
            | IsStripped
            | IsFullwidth
            | IsNarrow
            | IsFullWidth
            | CustomClass of string
            | Props of IHTMLProp list

        type TableOptions =
            { IsBordered : bool
              IsStripped : bool
              IsFullwidth : bool
              IsNarrow : bool
              IsFullWidth : bool
              CustomClass : string option
              Props : IHTMLProp list }
            static member Empty =
                { IsBordered = false
                  IsStripped = false
                  IsNarrow = false
                  IsFullwidth = false
                  CustomClass = None
                  Props = [] }

    open Types

    // Styling
    let inline isBordered<'T> = IsBordered
    let inline isStripped<'T> = IsStripped
    let inline isFullwidth<'T> = IsFullwidth
    // Spacing
    let inline isNarrow<'T> = IsNarrow
    // Extra
    let inline customClass x = CustomClass x
    let inline props x = Props x

    let table options children =
        let parseOptions (result : TableOptions) =
            function
            | IsBordered -> { result with IsBordered = true }
            | IsStripped -> { result with IsStripped = true }
            | IsFullwidth -> { result with IsFullwidth = true }
            | IsNarrow -> { result with IsNarrow = true }
            | IsFullWidth -> { result with IsFullWidth = true }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions TableOptions.Empty
        let class' = Helpers.classes Bulma.Table.Container [opts.CustomClass]
                        [ Bulma.Table.Style.IsBordered, opts.IsBordered
                          Bulma.Table.Style.IsStripped, opts.IsStripped
                          Bulma.Table.Style.IsFullwidth, opts.IsFullwidth
                          Bulma.Table.Spacing.IsNarrow, opts.IsNarrow ]

        table (class'::opts.Props) children

    module Row =
        // Row
        let inline isSelected<'T> = ClassName Bulma.Table.Row.State.IsSelected
