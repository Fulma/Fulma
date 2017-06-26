namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Menu =

    let menu  = aside [ ClassName bulma.Menu.Container ]

    let label menuLabel = p [ ClassName bulma.Menu.Label ] [ str menuLabel ]

    let list = ul [ ClassName bulma.Menu.List ]
