module Fulma.Elmish.TimePicker.View

open Fulma.Elmish.TimePicker.Types
open System

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Fulma.Elements.Form
open Fulma.Extensions.Calendar.Event

let onChange (config : Config<'Msg>) state dispatch =
    config.OnChange
        state
        |> dispatch

let root (config: Config<'Msg>) (state: State) dispatch =
    form []
        [
            Field.field_div [ ]
                [
                    Control.control_div [ ]
                        [
                            Input.input [   Input.typeIsText
                                            Input.placeholder "Ex: Maxime" ]
                            Select.select [ ]
                                [ select [ ]
                                    [ option [ Value "1" ] [ str "Value n°1" ]
                                      option [ Value "2"] [ str "Value n°2" ]
                                      option [ Value "3"] [ str "Value n°3" ] ]
                                ]
                            Select.select [ ]
                                [ select [ ]
                                    [ option [ Value "1" ] [ str "Value n°1" ]
                                      option [ Value "2"] [ str "Value n°2" ]
                                      option [ Value "3"] [ str "Value n°3" ] ]
                                ]
                        ]
                ]
        ]
