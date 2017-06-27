module Render

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Elmish.Bulma.Components
open Elmish.Bulma.Elements

[<Pojo>]
type DangerousInnerHtml =
    { __html : string }

let htmlFromMarkdown str = div [ DangerouslySetInnerHTML { __html = Marked.Globals.marked.parse (str) } ] []

let contentFromMarkdown str =
    Content.content [ ]
                    [ htmlFromMarkdown str ]

let docSection title viewer =
    div [ ]
        [ yield contentFromMarkdown title
          yield viewer ]

let docPage children =
    div [ ]
        [ for child in children do
            yield child
            yield hr [ ] ]
