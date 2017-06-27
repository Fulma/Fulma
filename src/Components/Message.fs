namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Message =


    let isBlack = IsBlack
    let isDark = IsDark
    let isLight = IsLight
    let isWhite = IsWhite
    let isPrimary = IsPrimary
    let isInfo = IsInfo
    let isSuccess = IsSuccess
    let isWarning = IsWarning
    let isDanger = IsDanger

    let message (color: ILevelAndColor) children =
        article [ ClassName (bulma.Message.Container ++ ofLevelAndColor color) ]
            children

    let header children =
        div [ ClassName bulma.Message.Header ]
            children

    let body children =
        div [ ClassName bulma.Message.Body ]
            children
