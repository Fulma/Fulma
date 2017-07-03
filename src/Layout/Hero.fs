namespace Elmish.Bulma.Layout

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
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
            | Classy of string

        let ofSize =
            function
            | IsMedium -> bulma.Hero.Size.IsMedium
            | IsLarge -> bulma.Hero.Size.IsLarge
            | IsHalfHeight -> bulma.Hero.Size.IsHalfHeight
            | IsFullHeight -> bulma.Hero.Size.IsFullHeight

        type Options =
            { Props : IHTMLProp list
              IsBold : bool
              Size : string option
              Color : string option
              Classy : string option }

            static member Empty =
                { Props = []
                  IsBold = false
                  Size = None
                  Color = None
                  Classy = None }

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
    let classy cls = Classy cls

    let hero (options : Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | Size size -> { result with Size = ofSize size |> Some }
            | Color color -> { result with Color = ofLevelAndColor color |> Some }
            | IsBold -> { result with IsBold = true }
            | Classy classy -> { result with Classy = Some classy }

        let opts = options |> List.fold parseOptions Options.Empty

        section [ yield classBaseList
                        bulma.Hero.Container
                        [ bulma.Hero.Style.IsBold, opts.IsBold
                          opts.Color.Value , opts.Color.IsSome
                          opts.Size.Value, opts.Size.IsSome
                          opts.Classy.Value, opts.Classy.IsSome
                         ] :> IHTMLProp
                  yield! opts.Props ]
            children

    module Head =
        let props props = GenericOption.Props props
        let classy cls = GenericOption.Classy cls

    module Body =
        let props props = GenericOption.Props props
        let classy cls = GenericOption.Classy cls

    module Foot =
        let props props = GenericOption.Props props
        let classy cls = GenericOption.Classy cls

    module Video =
        let props props = GenericOption.Props props
        let classy cls = GenericOption.Classy cls

    module Buttons =
        let props props = GenericOption.Props props
        let classy cls = GenericOption.Classy cls

    let head (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        bulma.Hero.Head
                        [ opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let body (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        bulma.Hero.Body
                        [ opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let foot (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        bulma.Hero.Foot
                        [ opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let video (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        bulma.Hero.Video.Container
                        [ opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let buttons (options: GenericOption list) children =
        let opts = genericParse options

        div [ yield classBaseList
                        bulma.Hero.Buttons.Container
                        [ opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children
