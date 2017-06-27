namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Icon =
    module Types =
        type IPosition =
            | Left
            | Right

        type Option =
            | Size of ISize
            | Position of IPosition

        type Options =
            { Size : string option
              Position : string option }
            static member Empty =
                { Size = None
                  Position = None }

        let ofPosition =
            function
            | Left -> bulma.Icon.Position.Left
            | Right -> bulma.Icon.Position.Right

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    // Position
    let isLeft = Position Left
    let isRight = Position Right

    let icon options children =
        let parseOptions (result : Options) option =
            match option with
            | Size size -> { result with Size = ofSize size |> Some }
            | Position position -> { result with Position = ofPosition position |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        span
            [ ClassName(Helpers.generateClassName bulma.Icon.Container [ opts.Size; opts.Position ]) ]
            children
