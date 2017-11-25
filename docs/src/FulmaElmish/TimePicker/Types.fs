module FulmaElmish.TimePicker.Types

open Fulma.Elmish
open System

type Model =
    { TimePickerState : TimePicker.Types.State
      CurrentTime : TimeSpan option }

type Msg =
    | TimePickerChanged of TimePicker.Types.State * (TimeSpan option)
    | TimePickerCleared of TimePicker.Types.State * (TimeSpan option)
