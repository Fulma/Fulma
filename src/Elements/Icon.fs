namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Icon =

  module Types =

    type IPosition =
      | Left
      | Right

    type Option =
      | Size of ISize
      | Position of IPosition

    type Options =
      { size: string option
        position: string option }

      static member Empty =
        { size = None
          position = None }

    let ofPosition =
      function
      | Left -> bulma.icon.position.left
      | Right -> bulma.icon.position.right

  open Types

  // Sizes
  let isSmall = Size IsSmall
  let isMedium = Size IsMedium
  let isLarge = Size IsLarge
  // Position
  let isLeft = Position Left
  let isRight = Position Right

  let icon options children =
    let parseOptions (result: Options) option =
      match option with
      | Size size -> { result with size = ofSize size |> Some }
      | Position position -> { result with position = ofPosition position |> Some }

    let opts = options |> List.fold parseOptions Options.Empty

    span
      [ ClassName (Helpers.generateClassName bulma.icon.container [ opts.size; opts.position ]) ]
      children
