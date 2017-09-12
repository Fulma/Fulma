module Components.Media.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Layouts
open Fulma.Components

let basic =
    Media.media [ ]
        [ Media.left [ ]
            [ Image.image [ Image.is64x64 ]
                [ img [ Src "https://dummyimage.com/64x64/7a7a7a/fff" ] ] ]
          Media.content [ ]
            [ Field.field_div [ ]
                [ Control.control [ ]
                    [ textarea [ ClassName "textarea"
                                 Placeholder "Add a message ..." ]
                               [ ] ] ]
              Level.level [ ]
                [ Level.left [ ]
                    [ Level.item [ ]
                        [ Button.button [ Button.isInfo ]
                            [ str "Submit" ] ] ]
                  Level.right [ ]
                    [ Level.item [ ]
                        [ str "Press Ctrl + Enter to submit" ] ] ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch)) ]
