namespace Fulma.Elmish.TimePicker

open System
open Fable.Helpers.React
open Fable.Helpers.React.Props

open Fable.PowerPack

//https://github.com/phoenixwong/vue2-timepicker/blob/master/src/vue-timepicker.vue

module Types =

    module TimePicker =

        type Option =
            | Props of IHTMLProp list
            | CustomClass of string

        type Options =
            {
                Props : IHTMLProp list
                CustomClass : string option
            }
            static member Empty =
                {
                    Props = []
                    CustomClass = None
                }

    type Format =
        | HHmm  //24 hours
        //12 hours with hours & minutes with padding (on 2 characters)
        | HHmmA
        //12 hours with hours & minutes without padding
        | Hma
        //With Seconds
        | HHmmss
        static member Default = HHmm


    type TimePeriod =
        | AM
        | PM
        with
            member x.upperCaseString() =
                match x with
                | AM -> "AM"
                | PM -> "PM"
            member x.lowerCaseString() =
                match x with
                | AM -> "am"
                | PM -> "pm"
            override x.ToString() = x.upperCaseString()

    type State =
        {
            MinuteInterval : int
            SecondInterval : int
            Format: Format
        }

    let defaultState =
        {
            MinuteInterval = 0
            SecondInterval = 0
            Format = Format.Default
        }

    type Config<'Msg> =
        {
            OnChange  : State * (TimeSpan option) -> 'Msg
            Local : Date.Local.Localization
        }

    type Msg =
        | NoOp

    type Model  = { CurrentTime : DateTime }

