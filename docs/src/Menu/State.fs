module Menu.State

open Elmish
open Global
open Types

let init currentPage : Model =
    { FableReactBulma =
            { IsElementsExpanded = false
              IsComponentsExpanded = false }
      CurrentPage = currentPage }

let update msg model =
    match msg with
    | ToggleMenu library ->
        match library with
        | FableReactBulma ``module`` ->
            match ``module`` with
            | Elements ->
                { model with FableReactBulma =
                                { model.FableReactBulma with IsElementsExpanded = not model.FableReactBulma.IsElementsExpanded } }
            | Components ->
                { model with FableReactBulma =
                                { model.FableReactBulma with IsComponentsExpanded = not model.FableReactBulma.IsComponentsExpanded } }
        , Cmd.none
