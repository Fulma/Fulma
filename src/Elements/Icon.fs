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
            | Classy of string
            | Props of IHTMLProp list

        type Options =
            { Size : string option
              Position : string option
              Classy : string option
              Props : IHTMLProp list }
            static member Empty =
                { Size = None
                  Position = None
                  Classy = None
                  Props = [] }

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
    // Extra
    let props = Props
    let classy = Classy

    let icon options children =
        let parseOptions (result : Options) option =
            match option with
            | Size size -> { result with Size = ofSize size |> Some }
            | Position position -> { result with Position = ofPosition position |> Some }
            | Classy classy -> { result with Classy = classy |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        span
            [ yield ClassName (Helpers.generateClassName
                                        bulma.Icon.Container
                                        [ opts.Size; opts.Position; opts.Classy ]) :> IHTMLProp
              yield! opts.Props ]
            children
