namespace Fulma.Layout

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Hero =

    module Types =

        type ISize =
            | IsMedium
            | IsLarge
            | IsHalfHeight
            | IsFullHeight

        type Option =
            | Props of IHTMLProp list
            | IsBold
            | Size of ISize
            | Color of ILevelAndColor
            | CustomClass of string

        let ofSize =
            function
            | IsMedium -> Bulma.Hero.Size.IsMedium
            | IsLarge -> Bulma.Hero.Size.IsLarge
            | IsHalfHeight -> Bulma.Hero.Size.IsHalfHeight
            | IsFullHeight -> Bulma.Hero.Size.IsFullHeight

        type Options =
            { Props : IHTMLProp list
              IsBold : bool
              Size : string option
              Color : string option
              CustomClass : string option }

            static member Empty =
                { Props = []
                  IsBold = false
                  Size = None
                  Color = None
                  CustomClass = None }

    open Types

    // Sizes
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    let isHalfHeight = Size IsHalfHeight
    let isFullHeight = Size IsFullHeight
    // Style
    let isBold = IsBold
    // Colors
    let isBlack = Color IsBlack
    let isDark = Color IsDark
    let isLight = Color IsLight
    let isWhite = Color IsWhite
    let isPrimary = Color IsPrimary
    let isInfo = Color IsInfo
    let isSuccess = Color IsSuccess
    let isWarning = Color IsWarning
    let isDanger = Color IsDanger
    // Extra
    let props props = Props props
    let customClass cls = CustomClass cls

    let hero (options : Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | Size size -> { result with Size = ofSize size |> Some }
            | Color color -> { result with Color = ofLevelAndColor color |> Some }
            | IsBold -> { result with IsBold = true }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty

        section [ yield classBaseList
                        Bulma.Hero.Container
                        [ Bulma.Hero.Style.IsBold, opts.IsBold
                          opts.Color.Value , opts.Color.IsSome
                          opts.Size.Value, opts.Size.IsSome
                          opts.CustomClass.Value, opts.CustomClass.IsSome
                         ] :> IHTMLProp
                  yield! opts.Props ]
            children

    module Head =
        let props props = GenericOption.Props props
        let customClass cls = GenericOption.CustomClass cls

    module Body =
        let props props = GenericOption.Props props
        let customClass cls = GenericOption.CustomClass cls

    module Foot =
        let props props = GenericOption.Props props
        let customClass cls = GenericOption.CustomClass cls

    module Video =
        let props props = GenericOption.Props props
        let customClass cls = GenericOption.CustomClass cls

    module Buttons =
        let props props = GenericOption.Props props
        let customClass cls = GenericOption.CustomClass cls

    let head (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        Bulma.Hero.Head
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let body (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        Bulma.Hero.Body
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let foot (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        Bulma.Hero.Foot
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let video (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        Bulma.Hero.Video.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let buttons (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        Bulma.Hero.Buttons.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
