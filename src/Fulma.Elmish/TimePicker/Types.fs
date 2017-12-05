namespace Fulma.Elmish.TimePicker

open System
open Fable.Helpers.React
open Fable.Helpers.React.Props

open Fable.PowerPack

//Heavily inspired by: https://github.com/phoenixwong/vue2-timepicker/blob/master/src/vue-timepicker.vue

module Types =

    type Format =
        | HHmm      //24 hours with hous & minutes
        | HHmmt     //12 hours and AM/PM period one character with hours & minutes
        | HHmmtt
        | HHmmss    //24 hours with hous & minutes & seconds
        | HHmmsst
        | HHmmsstt
        | Hm
        | Hmt
        | Hmtt
        | Hms
        | Hmst
        | Hmstt
        static member Default = HHmm


    type TimePeriod =
        | AM
        | PM
        with
            override x.ToString() =
                match x with
                | AM -> "AM"
                | PM -> "PM"

    type Interval = Interval of int

    type State =
        {
            MinuteInterval : int
            SecondInterval : int
            Format: Format
            ShowDropdown : bool
        }

    let defaultState =
        {
            MinuteInterval = 1
            SecondInterval = 1
            Format = Format.Default
            ShowDropdown = false
        }

    type Config<'Msg> =
        {
            OnChange    : State * (TimeSpan option) -> 'Msg
            OnClear     : State * (TimeSpan option) -> 'Msg
        }

    type Msg =
        | NoOp

    type Model  = { CurrentTime : DateTime }

