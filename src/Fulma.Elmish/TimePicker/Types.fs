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
        | HHmm
        static member Default = HHmm

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
            OnChange  : State * (DateTime option) -> 'Msg
            Local : Date.Local.Localization
        }

    type Msg =
        | NoOp

    type Model  = { CurrentTime : DateTime  }

