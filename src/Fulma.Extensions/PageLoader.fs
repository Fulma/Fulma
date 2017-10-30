namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module PageLoader =

    module Classes =
        let [<Literal>] PageLoader = "pageloader"
        let [<Literal>] IsActive = "is-active"



    module Types =
        type Option =
            | IsActive
            | Color of ILevelAndColor
            | Props of IHTMLProp list
            | CustomClass of string


        type Options =
            { IsActive : bool
              Color : string option
              Props : IHTMLProp list
              CustomClass : string option
            }
            static member Empty =
                { IsActive = false
                  Color = None
                  Props = []
                  CustomClass = None }

    open Types


    let inline isActive<'T> = IsActive
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
    let inline customClass x = CustomClass x

    let pageLoader (options : Option list) children =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Color color -> { result with Color = ofLevelAndColor color |> Some }
            | IsActive -> { result with IsActive = true }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty
        let className = Helpers.generateClassName Classes.PageLoader  [ opts.Color]
        let class' = Helpers.classes className [opts.CustomClass] [Classes.IsActive, opts.IsActive]
        div (class'::opts.Props) children
