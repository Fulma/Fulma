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

let toList = (fun x -> [ x ])

let docSection title docPreviews =
    div []
        ((div [ ClassName "content" ]
              [ htmlFromMarkdown title ]) :: docPreviews)

let docPreview code children =
    Card.card [ ]
        [ Card.content [ ] [ children ]
          Card.footer
            [ ]
            [ Card.Footer.item [ ]
                [ Icon.icon [ ]
                    [ i [ ClassName "fa fa-angle-up" ] [ ] ] ]
              Card.Footer.item [ ] [ str "View code" ]
              Card.Footer.item [ ]
                [ Icon.icon [ ]
                    [ i [ ClassName "fa fa-angle-up" ] [ ] ] ] ]
          Box.box' [ ] [ htmlFromMarkdown code ]
        ]

let docPage children =
    div [ ]
        [ for child in children do
            yield child
            yield hr [ ] ]
