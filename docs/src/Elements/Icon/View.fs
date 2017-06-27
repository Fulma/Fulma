module Elements.Icon.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components.Grids


let iconInteractive =
    div [ ClassName "block" ]
        [ Icon.icon [ Icon.isSmall ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon [ ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon [ Icon.isMedium ]
            [ i [ ClassName "fa fa-home" ] [ ] ]
          Icon.icon [ Icon.isLarge ]
            [ i [ ClassName "fa fa-home" ] [ ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root iconInteractive model.IconViewer (IconViewerMsg >> dispatch)) ]
