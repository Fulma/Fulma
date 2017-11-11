module FulmaElmish.TimePicker.State

open Elmish
open Types
open Fulma.Elmish
open System


let init () =
    {
        TimePickerState = { TimePicker.Types.defaultState }
        CurrentTime = None
    }

let update msg model =
    match msg with
    | TimePickerChanged (newState, time) ->
        { model with TimePickerState = newState
                     CurrentTime = time }, Cmd.none
