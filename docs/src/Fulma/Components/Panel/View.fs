module Components.Panel.View

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
    Columns.columns [ ]
        [ Column.column [ Column.Offset.is3
                          Column.Width.is6 ]
            [ Panel.panel [ ]
                [ Panel.heading [ ] [ str "Repositories"]
                  Panel.block [ ]
                    [ Control.control [ Control.hasIconLeft ]
                        [ Input.input [ Input.isSmall
                                        Input.typeIsText
                                        Input.placeholder "Search" ]
                          Icon.icon [ Icon.isSmall
                                      Icon.isLeft ]
                                    [ i [ ClassName "fa fa-search" ] [ ] ] ] ]
                  Panel.tabs [ ]
                    [ Panel.tab [ ] [ str "All" ]
                      Panel.tab [ Panel.Tab.isActive ] [ str "Fable" ]
                      Panel.tab [ ] [ str "Elmish" ]
                      Panel.tab [ ] [ str "Bulma" ] ]
                  Panel.block [ Panel.Block.isActive ]
                    [ Panel.icon [ ] [ i [ ClassName "fa fa-book" ] [ ] ]
                      str "Bulma" ]
                  Panel.block [ ]
                    [ Panel.icon [ ] [ i [ ClassName "fa fa-code-fork" ] [ ] ]
                      str "Fable" ]
                  Panel.checkbox [ ]
                    [ input [ Type "checkbox" ]
                      str "I am a checkbox" ]
                  Panel.block [ ]
                    [ Button.button [ Button.isPrimary
                                      Button.isOutlined
                                      Button.isFullWidth ]
                                    [ str "Reset" ] ] ] ] ]


let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.PanelViewer (PanelViewerMsg >> dispatch)) ]
