namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

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
            | IsMedium -> bulma.Tag.Size.IsMedium
            | IsLarge -> bulma.Tag.Size.IsLarge

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
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
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
    let props props = Props props
    let customClass = CustomClass

    let tag (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size size -> { result with Size = ofTagSize size |> Some }
            | Color color -> { result with Color = ofLevelAndColor color |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        let className = ClassName(Helpers.generateClassName bulma.Tag.Container [ opts.Size; opts.Color; opts.CustomClass ])
        span
            (className :> IHTMLProp :: opts.Props)
            children
