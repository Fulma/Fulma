module FulmaElmish.DatePicker.State

open Elmish
open Types
open Fulma.Elmish
open System


let init () =
    { DatePickerState = { DatePicker.Types.defaultState with AutoClose = true }
      CurrentDate = None }

let update msg model =
    match msg with
    | DatePickerChanged (newState, date) ->
        { model with DatePickerState = newState
                     CurrentDate = date }, Cmd.none
