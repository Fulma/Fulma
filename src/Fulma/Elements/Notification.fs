namespace Fulma.Elements

open Fulma.Common
open Fulma.BulmaClasses
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Notification =

    module Types =

        type Option =
            | Level of ILevelAndColor
            | CustomClass of string
            | Props of IHTMLProp list

        // | AutoCloseDelay of float
        type Options =
            { Level : string option
              CustomClass : string option
              Props : IHTMLProp list }
            // AutoCloseDelay: float option
            static member Empty =
                { Level = None
                  CustomClass = None
                  Props = [] }

    open Types

    // Levels and colors
    let isBlack = Level IsBlack
    let isDark = Level IsDark
    let isLight = Level IsLight
    let isWhite = Level IsWhite
    let isPrimary = Level IsPrimary
    let isInfo = Level IsInfo
    let isSuccess = Level IsSuccess
    let isWarning = Level IsWarning
    let isDanger = Level IsDanger
    // Extra
    let props props = Props props
    let customClass = CustomClass

    module Delete =
        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

    let notification (options : Option list) children =
        let parseOptions (result : Options) opt =
            match opt with
            | Level level -> { result with Level = ofLevelAndColor level |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield (classBaseList Bulma.Notification.Container
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome
                              opts.Level.Value, opts.Level.IsSome ]) :> IHTMLProp
              yield! opts.Props ]
            children

    let delete (options: GenericOption list) children =
        let opts = genericParse options

        button
            [ yield classBaseList
                        Bulma.Notification.Delete.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
