namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Progress =
    module Types =
        type Option =
            | Size of ISize
            | Color of ILevelAndColor
            | Props of IHTMLProp list
            | Value of int
            | Max of int
            | CustomClass of string

        type Options =
            { Size : string option
              Color : string option
              Props : IHTMLProp list
              Max : int option
              Value : int option
              CustomClass : string option }
            static member Empty =
                { Size = None
                  Color = None
                  Props = []
                  Max = None
                  Value = None
                  CustomClass = None }

    open Types

    // Sizes
    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
    // Levels and colors
    let inline isBlack<'T> = Color IsBlack
    let inline isDark<'T> = Color IsDark
    let inline isLight<'T> = Color IsLight
    let inline isWhite<'T> = Color IsWhite
    let inline isPrimary<'T> = Color IsPrimary
    let inline isInfo<'T> = Color IsInfo
    let inline isSuccess<'T> = Color IsSuccess
    let inline isWarning<'T> = Color IsWarning
    let inline isDanger<'T> = Color IsDanger
    // Extra
    let inline props x = Props x
    let inline value v = Value v
    let inline max m = Max m
    let inline customClass x = CustomClass x

    let progress options children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with Size = ofSize size |> Some }
            | Color color -> { result with Color = ofLevelAndColor color |> Some }
            | Props props -> { result with Props = props }
            | Value value -> { result with Value = value |> Some }
            | Max max -> { result with Max = max |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        progress
            [ yield ClassName (Helpers.generateClassName Bulma.Progress.Container [ opts.Size; opts.Color; opts.CustomClass ]) :> IHTMLProp
              yield! opts.Props
              if Option.isSome opts.Value then yield HTMLAttr.Value (string opts.Value.Value) :> IHTMLProp
              if Option.isSome opts.Max then yield HTMLAttr.Max (float opts.Max.Value) :> IHTMLProp ]
            children
