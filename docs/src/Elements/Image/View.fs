module Elements.Image.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fable.React.Bulma.Elements

let fixedInteractive =
    div [ ClassName "block" ]
        [ Image.image [ Image.is64x64 ]
            [ img [ Src "https://dummyimage.com/64x64/7a7a7a/fff" ] ]
          br [ ]
          Image.image [ Image.is128x128 ]
            [ img [ Src "https://dummyimage.com/128x128/7a7a7a/fff" ] ] ]

let responsiveInteractive =
    div [ ClassName "block" ]
        [ Image.image [ Image.is2by1 ]
            [ img [ Src "https://dummyimage.com/640x320/7a7a7a/fff" ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Fixed square images"
                        (Viewer.View.root fixedInteractive model.FixedViewer (FixedViewerMsg >> dispatch))
                     Render.docSection
                        "### Responsive images with ratio"
                        (Viewer.View.root responsiveInteractive model.FixedViewer (FixedViewerMsg >> dispatch)) ]
