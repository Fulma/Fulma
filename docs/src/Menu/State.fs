module Menu.State

open Elmish
open Global
open Types

let init currentPage : Model =
    { Fulma =
            { IsElementsExpanded = false
              IsComponentsExpanded = false
              IsLayoutExpanded = false }
      FulmaExtensions =
            { IsExpanded = false }
      CurrentPage = currentPage }

let update msg model =
    match msg with
    | ToggleMenu library ->
        match library with
        | Fulma ``module`` ->
            match ``module`` with
            | Elements ->
                { model with Fulma =
                                { model.Fulma with IsElementsExpanded = not model.Fulma.IsElementsExpanded } }
            | Components ->
                { model with Fulma =
                                { model.Fulma with IsComponentsExpanded = not model.Fulma.IsComponentsExpanded } }

            | Layouts ->
                { model with Fulma =
                                { model.Fulma with IsLayoutExpanded = not model.Fulma.IsLayoutExpanded } }

        | FulmaExtensions ->
            { model with FulmaExtensions =
                                { model.FulmaExtensions with IsExpanded = not model.FulmaExtensions.IsExpanded } }

        , Cmd.none
