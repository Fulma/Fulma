module FulmaElmish.TimePicker.Types

open Fulma.Elmish
open System

type Model =
    { TimePickerState : TimePicker.Types.State
      CurrentTime : DateTime option }

type Msg =
    | TimePickerChanged of TimePicker.Types.State * (DateTime option)
