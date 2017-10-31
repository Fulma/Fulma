namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
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
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
    let inline isHalfHeight<'T> = Size IsHalfHeight
    let inline isFullHeight<'T> = Size IsFullHeight
    // Style
    let inline isBold<'T> = IsBold
    // Colors
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
        let class' = Helpers.classes Bulma.Hero.Container
                        [opts.Color; opts.Size; opts.CustomClass]
                        [Bulma.Hero.Style.IsBold, opts.IsBold]
        section (class'::opts.Props) children

    module Head =
        let inline props x = GenericOption.Props x
        let customClass cls = GenericOption.CustomClass cls

    module Body =
        let inline props x = GenericOption.Props x
        let customClass cls = GenericOption.CustomClass cls

    module Foot =
        let inline props x = GenericOption.Props x
        let customClass cls = GenericOption.CustomClass cls

    module Video =
        let inline props x = GenericOption.Props x
        let customClass cls = GenericOption.CustomClass cls

    module Buttons =
        let inline props x = GenericOption.Props x
        let customClass cls = GenericOption.CustomClass cls

    let head (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Hero.Head [opts.CustomClass] []
        div (class'::opts.Props) children

    let body (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Hero.Body [opts.CustomClass] []
        div (class'::opts.Props) children

    let foot (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Hero.Foot [opts.CustomClass] []
        div (class'::opts.Props) children

    let video (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Hero.Video.Container [opts.CustomClass] []
        div (class'::opts.Props) children

    let buttons (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Hero.Buttons.Container [opts.CustomClass] []
        div (class'::opts.Props) children
