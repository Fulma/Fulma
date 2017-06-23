module Viewer.State

open Elmish
open Types

let init code : Model =
    { IsExpanded = false
      Code = code }

let update msg model =
    match msg with
    | Expand ->
        { model with IsExpanded = true }, Cmd.none
    | Collapse ->
        { model with IsExpanded = false }, Cmd.none
