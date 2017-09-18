module FulmaElmish.DatePicker.Types

open Fulma.Elmish
open System

type Model =
    { DatePickerState : DatePicker.Types.State
      CurrentDate : DateTime option }

type Msg =
    | DatePickerChanged of DatePicker.Types.State * (DateTime option)
