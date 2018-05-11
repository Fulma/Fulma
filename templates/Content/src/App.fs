module App.View

open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.FontAwesome

type Model =
    { Value : string }

type Msg =
    | ChangeValue of string

let init _ = { Value = "" }, Cmd.none

let private update msg model =
    match msg with
    | ChangeValue newValue ->
        { model with Value = newValue }, Cmd.none

let private view model dispatch =
    Hero.hero [ Hero.IsFullHeight ]
        [ Hero.body [ ]
            [ Container.container [ ]
                [ Columns.columns [ Columns.CustomClass "has-text-centered" ]
                    [ Column.column [ Column.Width(Screen.All, Column.IsOneThird)
                                      Column.Offset(Screen.All, Column.IsOneThird) ]
                        [ Image.image [ Image.Is128x128
                                        Image.Props [ Style [ Margin "auto"] ] ]
                            [ img [ Src "assets/fulma_logo.svg" ] ]
                          Field.div [ ]
                            [ Label.label [ ]
                                [ str "Enter your name" ]
                              Control.div [ ]
                                [ Input.text [ Input.OnChange (fun ev -> dispatch (ChangeValue ev.Value))
                                               Input.Value model.Value
                                               Input.Props [ AutoFocus true ] ] ] ]
                          Content.content [ ]
                            [ str "Hello, "
                              str model.Value
                              str " "
                              Icon.faIcon [ ]
                                [ Fa.icon Fa.I.SmileO ] ] ] ] ] ] ]

open Elmish.React
open Elmish.Debug
open Elmish.HMR

Program.mkProgram init update view
//-:cnd:noEmit
#if DEBUG
|> Program.withHMR
#endif
//+:cnd:noEmit
|> Program.withReactUnoptimized "elmish-app"
//-:cnd:noEmit
#if DEBUG
|> Program.withDebugger
#endif
//+:cnd:noEmit
|> Program.run
