module Fulma.Elmish.TimePicker.View

open Fulma.Elmish.TimePicker.Types
open System


let onChange (config : Config<'Msg>) state dispatch =
    config.OnChange
        state
        |> dispatch

let root (config: Config<'Msg>) (state: State) dispatch =
    ()
