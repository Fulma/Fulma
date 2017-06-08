namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Progress =
    module Types =
        type Option =
            | Size of ISize
            | Color of ILevelAndColor
            | Props of IHTMLProp list

        type Options =
            { size : string option
              color : string option
              props : IHTMLProp list }
            static member Empty =
                { size = None
                  color = None
                  props = [] }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    // Levels and colors
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

    let progress options children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with size = ofSize size |> Some }
            | Color color -> { result with color = ofLevelAndColor color |> Some }
            | Props props -> { result with props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        progress
            (ClassName(Helpers.generateClassName bulma.progress.container [ opts.size; opts.color ]) :> IHTMLProp
             :: opts.props) children
