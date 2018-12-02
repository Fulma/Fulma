[<RequireQualifiedAccess>]
module Render

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import
open Fulma
open Fable.Core.JsInterop

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
    // We sue `Key` to force react to make a delete action when switching from one page to another
    // I cehcked and react do not delete the whole page when we modify a stateful component so that fine for
    // If needed, we can convert this function to a stateful component
    div [ Key (System.Guid.NewGuid().ToString())
          Id (System.Guid.NewGuid().ToString())  ]
        [ for child in children do
            yield child
            yield hr [ ] ]

let inline includeCode<'a> (line : string) (file : string) : string =
    importAll ("!!custom-loader?line=" + line + "!./" + file)
