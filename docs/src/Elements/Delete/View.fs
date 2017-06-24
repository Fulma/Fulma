module Elements.Delete.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components.Grids

let demoInteractive =
    div [ ClassName "block" ]
        [ Delete.delete
            [ Delete.isSmall ] [ ]
          Delete.delete
            [ ] [ ]
          Delete.delete
            [ Delete.isMedium ] [ ]
          Delete.delete
            [ Delete.isLarge ] [ ] ]
let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root demoInteractive model.DemoViewer (DemoViewerMsg >> dispatch)) ]
