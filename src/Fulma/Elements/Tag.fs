namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tag =
    module Types =
        type ITagSize =
            | IsMedium
            | IsLarge

        type Option =
            | Size of ITagSize
            | Color of ILevelAndColor
            | Props of IHTMLProp list
            | CustomClass of string

        let ofTagSize size =
            match size with
            | IsMedium -> Bulma.Tag.Size.IsMedium
            | IsLarge -> Bulma.Tag.Size.IsLarge

        type Options =
            { Size : string option
              Color : string option
              Props : IHTMLProp list
              CustomClass : string option }
            static member Empty =
                { Size = None
                  Color = None
                  Props = []
                  CustomClass = None }

    open Types

    // Size
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
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
    let inline props x = Props x
    let inline customClass x = CustomClass x

    let tag (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size size -> { result with Size = ofTagSize size |> Some }
            | Color color -> { result with Color = ofLevelAndColor color |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        let className = ClassName(Helpers.generateClassName Bulma.Tag.Container [ opts.Size; opts.Color; opts.CustomClass ])
        span
            (className :> IHTMLProp :: opts.Props)
            children
