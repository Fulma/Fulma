module Render

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Elmish.Bulma.Elements

[<Pojo>]
type DangerousInnerHtml =
    { __html : string }

let htmlFromMarkdown str = div [ DangerouslySetInnerHTML { __html = Marked.Globals.marked.parse (str) } ] []

let contentFromMarkdown str =
    Content.content [ ]
                    [ htmlFromMarkdown str ]

let toList = (fun x -> [ x ])

let docSection title docPreviews =
    div []
        ((div [ ClassName "content" ]
              [ htmlFromMarkdown title ]) :: docPreviews)

let docPreview code children =
    Box.box' [ ]
             [ children ]


let docPage children =
    div [ ]
        [ for child in children do
            yield child
            yield hr [ ] ]
