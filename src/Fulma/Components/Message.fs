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

    let isBlack = Color IsBlack
    let isDark = Color IsDark
    let isLight = Color IsLight
    let isWhite = Color IsWhite
    let isPrimary = Color IsPrimary
    let isInfo = Color IsInfo
    let isSuccess = Color IsSuccess
    let isWarning = Color IsWarning
    let isDanger = Color IsDanger

    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge

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

