namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Table =

  module Types =

    type TableOption =
      | IsBordered
      | IsStripped
      | IsNarrow

    type TableOptions =
      { isBordered: bool
        isStripped: bool
        isNarrow: bool }

      static member Empty =
        { isBordered = false
          isStripped = false
          isNarrow = false }

  open Types

  // Styling
  let isBordered = IsBordered
  let isStripped = IsStripped
  // Spacing
  let isNarrow = IsNarrow

  let table options children =
    let parseOptions (result: TableOptions) =
      function
      | IsBordered -> { result with isBordered = true }
      | IsStripped -> { result with isStripped = true }
      | IsNarrow -> { result with isNarrow = true }

    let opts = options |> List.fold parseOptions TableOptions.Empty

    table
      [ classBaseList
          bulma.table.container
          [ bulma.table.style.isBordered, opts.isBordered
            bulma.table.style.isStripped, opts.isStripped
            bulma.table.spacing.isNarrow, opts.isNarrow ] ]
      children

  module Row =
    // Row
    let isSelected = ClassName bulma.table.row.state.isSelected
