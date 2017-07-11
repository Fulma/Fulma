namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Message =

    module Types =

        type Option =
            | Props of IHTMLProp list
            | Color of ILevelAndColor
            | CustomClass of string

        type Options =
            { Props : IHTMLProp list
              Color : string option
              CustomClass : string option }

            static member Empty =
                { Props = []
                  Color = None
                  CustomClass = None }

    open Types

    let isBlack = IsBlack
    let isDark = IsDark
    let isLight = IsLight
    let isWhite = IsWhite
    let isPrimary = IsPrimary
    let isInfo = IsInfo
    let isSuccess = IsSuccess
    let isWarning = IsWarning
    let isDanger = IsDanger

    let message options children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | Option.Color color -> { result with Color = ofLevelAndColor color |> Some}
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty

        article [ yield ClassName (Helpers.generateClassName bulma.Message.Container
                                                             [ opts.Color; opts.CustomClass ] ) :> IHTMLProp
                  yield! opts.Props ]
            children

    let header (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList bulma.Message.Header
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let body (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList bulma.Message.Body
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
