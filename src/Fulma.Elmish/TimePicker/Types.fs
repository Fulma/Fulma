namespace Fulma.Elmish

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma.BulmaClasses
open System

//https://github.com/phoenixwong/vue2-timepicker/blob/master/src/vue-timepicker.vue

module TimePicker =

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

        type Config<'Msg> =
            {
                OnChange  : State * (DateTime option) -> 'Msg
            }

        type Msg =
            | NoOp

        type Model  = { CurrentTime : DateTime  }

