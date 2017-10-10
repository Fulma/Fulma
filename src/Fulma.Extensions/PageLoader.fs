namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

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


    let isActive = IsActive
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
    let customClass = CustomClass

    let pageLoader (options : Option list) children =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Color color -> { result with Color = ofLevelAndColor color |> Some }
            | IsActive -> { result with IsActive = true }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield classBaseList
                    (Helpers.generateClassName Classes.PageLoader  [ opts.Color])
                    [ opts.CustomClass.Value, opts.CustomClass.IsSome
                      Classes.IsActive , opts.IsActive ] :> IHTMLProp
              yield! opts.Props ]
            children
