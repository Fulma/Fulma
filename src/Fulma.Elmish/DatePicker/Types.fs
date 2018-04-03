namespace Fulma.Elmish.DatePicker

open System
open Fable.PowerPack
open Fable.Helpers.React.Props

module Types =

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
          DatePickerStyle : CSSProp list }

    let defaultConfig onChangeMsg =
        { OnChange = onChangeMsg
          Local = Date.Local.englishUK
          DatePickerStyle = [ Position "absolute"
                              MaxWidth "450px" ] }

    type Msg =
        | NoOp

    type Model =
        { CurrentDate : DateTime }
