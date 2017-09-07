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
            | IsActive of bool
            | Level of ILevelAndColor
            | Props of IHTMLProp list
            | CustomClass of string
            
       
        type Options =
            { IsActive : bool
              Level : string option
              Props : IHTMLProp list
              CustomClass : string option
            }
            static member Empty =
                { IsActive = false
                  Level = None
                  Props = []
                  CustomClass = None }

    open Types


    let isActive = IsActive true

    
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
    
    let pageLoader (options : Option list) children =


        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | IsActive isActive -> { result with IsActive = isActive}
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
        

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield classBaseList 
                    (Helpers.generateClassName Classes.PageLoader  [ opts.Level])
                    [ 
                      opts.CustomClass.Value, opts.CustomClass.IsSome 
                      Classes.IsActive , opts.IsActive
                    ] :> IHTMLProp
              yield! opts.Props ]
            []
