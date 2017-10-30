namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Content =
    module Types =
        type Option =
            | Size of ISize
            | CustomClass of string
            | Props of IHTMLProp list

        type Options =
            { Size : string option
              Props : IHTMLProp list
              CustomClass : string option }
            static member Empty =
                { Size = None
                  Props = []
                  CustomClass = None }

    open Types

    // Sizes
    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
    // Extra
    let inline props x = Props x
    let inline customClass x = CustomClass x

    let content (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size size -> { result with Size = ofSize size |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOption Options.Empty
        div
            [ yield Helpers.classes Bulma.Content.Container [opts.CustomClass; opts.Size] []
              yield! opts.Props ]
            children
