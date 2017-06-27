namespace Elmish.Bulma.Components

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Card =

    let card (props : IHTMLProp list) children =
        div [ yield ClassName bulma.Card.Container :> IHTMLProp
              yield! props ]
            children

    let header props children =
        header [ yield ClassName bulma.Card.Header.Container :> IHTMLProp
                 yield! props ]
               children

    let content props children =
        div [ yield ClassName bulma.Card.Content :> IHTMLProp
              yield! props ]
            children

    let footer props children =
        footer [ yield ClassName bulma.Card.Footer.Container :> IHTMLProp
                 yield! props ]
               children

    module Header =

        let icon props children =
            a [ yield ClassName bulma.Card.Header.Icon :> IHTMLProp
                yield! props ]
              children

        let title props children =
            p [ yield ClassName bulma.Card.Header.Title :> IHTMLProp
                yield! props ]
              children

    module Footer =

        let item props children =
            a [ yield ClassName bulma.Card.Footer.Item :> IHTMLProp
                yield! props ]
              children
