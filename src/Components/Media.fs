namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Media =

    let media props children =
        article [ yield ClassName bulma.Media.Container :> IHTMLProp
                  yield! props ]
            children

    let left props children =
        figure [ yield ClassName bulma.Media.Left :> IHTMLProp
                 yield! props ]
            children

    let right props children =
        div [ yield ClassName bulma.Media.Right :> IHTMLProp
              yield! props ]
            children

    let content props children =
        div [ yield ClassName bulma.Media.Content :> IHTMLProp
              yield! props ]
            children
