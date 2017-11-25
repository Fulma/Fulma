module FulmaElmish.TimePicker.State

open Elmish
open Types
open Fulma.Elmish
open TimePicker.Types
open System


let init () =
    {
        TimePickerState = { TimePicker.Types.defaultState with Format = Format.HHmm }
        CurrentTime = None
    }

let update msg model =
    match msg with
    | TimePickerChanged (newState, time) ->
        { model with TimePickerState = newState
                     CurrentTime = time }, Cmd.none
    | TimePickerCleared (newState, time) ->
         { model with TimePickerState = newState; CurrentTime = time }, Cmd.none
