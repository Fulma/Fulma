namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Message =

    module Types =

        type Option =
            | Props of IHTMLProp list
            | Color of ILevelAndColor
            | Size of ISize
            | CustomClass of string

        type Options =
            { Props : IHTMLProp list
              Color : string option
              Size : string option
              CustomClass : string option }

            static member Empty =
                { Props = []
                  Color = None
                  Size = None
                  CustomClass = None }

    open Types

    let inline isBlack<'T> = Color IsBlack
    let inline isDark<'T> = Color IsDark
    let inline isLight<'T> = Color IsLight
    let inline isWhite<'T> = Color IsWhite
    let inline isPrimary<'T> = Color IsPrimary
    let inline isInfo<'T> = Color IsInfo
    let inline isSuccess<'T> = Color IsSuccess
    let inline isWarning<'T> = Color IsWarning
    let inline isDanger<'T> = Color IsDanger

    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge

    let message options children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | Option.Color color -> { result with Color = ofLevelAndColor color |> Some}
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Size size -> { result with Size = ofSize size |> Some }

        let opts = options |> List.fold parseOptions Options.Empty

        article [ yield ClassName (Helpers.generateClassName Bulma.Message.Container
                                                             [ opts.Color; opts.CustomClass; opts.Size ] ) :> IHTMLProp
                  yield! opts.Props ]
            children

    let header (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Message.Header [opts.CustomClass] []
        div (class'::opts.Props) children

    let body (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Message.Body [opts.CustomClass] []
        div (class'::opts.Props) children
