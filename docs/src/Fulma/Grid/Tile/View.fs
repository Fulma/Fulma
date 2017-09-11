module Grid.Tile.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Grids


let iconInteractive =
    div [ ClassName "block" ]
        [ Box.box' [ ]
            [ str "Lorem ipsum dolor sit amet, consectetur adipisicing elit
                   , sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.BoxViewer (BoxViewerMsg >> dispatch)) ]
