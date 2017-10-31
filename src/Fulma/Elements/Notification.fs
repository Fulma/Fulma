namespace Fulma.Elements

open Fulma.Common
open Fulma.BulmaClasses
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
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
    let inline isBlack<'T> = Level IsBlack
    let inline isDark<'T> = Level IsDark
    let inline isLight<'T> = Level IsLight
    let inline isWhite<'T> = Level IsWhite
    let inline isPrimary<'T> = Level IsPrimary
    let inline isInfo<'T> = Level IsInfo
    let inline isSuccess<'T> = Level IsSuccess
    let inline isWarning<'T> = Level IsWarning
    let inline isDanger<'T> = Level IsDanger
    // Extra
    let inline props x = Props x
    let inline customClass x = CustomClass x

    module Delete =
        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

    let notification (options : Option list) children =
        let parseOptions (result : Options) opt =
            match opt with
            | Level level -> { result with Level = ofLevelAndColor level |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        let class' = Helpers.classes Bulma.Notification.Container [opts.CustomClass; opts.Level] []
        div (class'::opts.Props) children

    let delete (options: GenericOption list) children =
        let opts = genericParse options

        button
            [ yield Helpers.classes Bulma.Notification.Delete.Container [opts.CustomClass] []
              yield! opts.Props ]
            children
