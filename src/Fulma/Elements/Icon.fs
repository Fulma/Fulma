namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
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
            | CustomClass of string
            | Props of IHTMLProp list

        type Options =
            { Size : string option
              Position : string option
              CustomClass : string option
              Props : IHTMLProp list }
            static member Empty =
                { Size = None
                  Position = None
                  CustomClass = None
                  Props = [] }

        let ofPosition =
            function
            | Left -> Bulma.Icon.Position.Left
            | Right -> Bulma.Icon.Position.Right

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
    let customClass = CustomClass

    let icon options children =
        let parseOptions (result : Options) option =
            match option with
            | Size size -> { result with Size = ofSize size |> Some }
            | Position position -> { result with Position = ofPosition position |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        span
            [ yield ClassName (Helpers.generateClassName
                                        Bulma.Icon.Container
                                        [ opts.Size; opts.Position; opts.CustomClass ]) :> IHTMLProp
              yield! opts.Props ]
            children
