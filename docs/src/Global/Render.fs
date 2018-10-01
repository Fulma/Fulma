[<RequireQualifiedAccess>]
module Render

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Fulma

type DangerousInnerHtml =
    { __html : string }

let htmlFromMarkdown str = div [ DangerouslySetInnerHTML { __html = Marked.Globals.marked.parse (str) } ] []

let contentFromMarkdown str =
    Content.content [ ]
                    [ htmlFromMarkdown str ]

let renderFSharpCode code =
    contentFromMarkdown ("```fsharp\n" + code + "\n```")

let docSection title viewer =
    div [ ]
        [ yield contentFromMarkdown title
          yield viewer ]

let docPage children =
    div [ ]
        [ for child in children do
            yield child
            yield hr [ ] ]

let getViewSource (view: unit->React.ReactElement) = "TODO update"
