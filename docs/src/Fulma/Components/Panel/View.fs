module Components.Panel.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Elements
open Fulma.Components
open Fulma.Layouts
open Fulma.Elements.Form

let iconInteractive =
    Columns.columns [ ]
        [ Column.column [ Column.Offset (Column.All, Column.Is3)
                          Column.Width (Column.All, Column.Is6) ]
            [ Panel.panel [ ]
                [ Panel.heading [ ] [ str "Repositories"]
                  Panel.block [ ]
                    [ Control.control [ Control.HasIconLeft ]
                        [ Input.text [ Input.Size IsSmall
                                       Input.Placeholder "Search" ]
                          Icon.icon [ Icon.Size IsSmall
                                      Icon.IsLeft ]
                                    [ i [ ClassName "fa fa-search" ] [ ] ] ] ]
                  Panel.tabs [ ]
                    [ Panel.tab [ ] [ str "All" ]
                      Panel.tab [ Panel.Tab.Active true ] [ str "Fable" ]
                      Panel.tab [ ] [ str "Elmish" ]
                      Panel.tab [ ] [ str "Bulma" ] ]
                  Panel.block [ Panel.Block.Active true ]
                    [ Panel.icon [ ] [ i [ ClassName "fa fa-book" ] [ ] ]
                      str "Bulma" ]
                  Panel.block [ ]
                    [ Panel.icon [ ] [ i [ ClassName "fa fa-code-fork" ] [ ] ]
                      str "Fable" ]
                  Panel.checkbox [ ]
                    [ input [ Type "checkbox" ]
                      str "I am a checkbox" ]
                  Panel.block [ ]
                    [ Button.button [ Button.Color IsPrimary
                                      Button.IsOutlined
                                      Button.IsFullwidth ]
                                    [ str "Reset" ] ] ] ] ]


let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.PanelViewer (PanelViewerMsg >> dispatch)) ]
