namespace Fulma.Elmish.DatePicker

open System
open Fable.PowerPack

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
          Local : Date.Local.Localization }

    type Msg =
        | NoOp

    type Model =
        { CurrentDate : DateTime }
