module Fulma.Elmish.DatePicker.Types

open System
open Fable.PowerPack
open Fable.Helpers.React.Props

    type State =
        { Today : DateTime option
          InputFocused : bool
          ReferenceDate : DateTime
          AutoClose : bool
          ForceClose : bool
          TitleFormat : string }

    let defaultState =
        { Today = None
          InputFocused = false
          ReferenceDate = DateTime.UtcNow
          AutoClose = false
          ForceClose = false
          TitleFormat = "" }

    type Config<'Msg> =
        { OnChange : State * (DateTime option) -> 'Msg
          Local : Date.Local.Localization
          DatePickerStyle : ICSSProp list }

    let defaultConfig onChangeMsg =
        { OnChange = onChangeMsg
          Local = Date.Local.english
          DatePickerStyle = [ Position "absolute"
                              MaxWidth "450px" ] }

    type Msg =
        | NoOp

    type Model =
        { CurrentDate : DateTime }
