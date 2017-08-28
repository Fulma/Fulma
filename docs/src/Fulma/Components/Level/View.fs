module Components.Level.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Components
open Fulma.Grids
open Fulma.Elements.Form


let iconInteractive =
    Level.level [ ]
        [ Level.left [ ]
            [ Level.item [ ]
                [ Heading.h5 [ Heading.isSubtitle ]
                    [ strong [ ] [ str "123"]
                      str " posts" ] ]
              Level.item [ ]
                [ Field.field [ Field.hasAddonsLeft ]
                    [ Control.control [ ]
                        [ Input.input [ Input.typeIsText
                                        Input.placeholder "Find a post" ] ]
                      Control.control [ ]
                        [ Button.button [ ]
                            [ str "Search" ] ] ] ] ]
          Level.right [ ]
            [ Level.item [ ]
                [ a [ ] [ str "All" ] ]
              Level.item [ ]
                [ a [ ] [ str "Published" ] ]
              Level.item [ ]
                [ a [ ] [ str "Drafts" ] ]
              Level.item [ ]
                [ a [ ] [ str "Deleted" ] ]
              Level.item [ ]
                [ Button.button [ Button.isSuccess ] [ str "New" ] ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.BoxViewer (BoxViewerMsg >> dispatch)) ]
