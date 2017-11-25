module Fulma.Elmish.TimePicker.View

open Fulma.Elmish.TimePicker.Types
open System
open Fulma.Components
open Fulma.Elements
open Fulma.Common
open Fulma.Extra.FontAwesome

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Fulma.Elements.Form
open Fulma.Layouts
open Fable.Helpers.React.Props
open Fable.Helpers.React.Props
open Fable.Import.JS
open Fable.AST.Babel
open Fulma.Elements.Button

//Helpers to format hour from Fable.Powerpack.Date:
//https://github.com/fable-compiler/fable-powerpack/blob/master/src/Date/Format.fs
let inline padWithN n c = (fun (x: string) -> x.PadLeft(n, c)) << string
let internal padWith = padWithN 2

let formatStr =
    function
    | HHmm | HHmmss | HHmmA -> padWith '0'
    | Hma  -> string

let formatPeriod =
    function
    | Hma   -> Option.defaultValue AM  >> (fun p -> p.lowerCaseString() )
    | HHmmA -> Option.defaultValue AM >> (fun p -> p.upperCaseString() )
    | _     -> Option.defaultValue AM >> (fun p -> p.upperCaseString() )

let formatTimeTxt format (time: TimeSpan) (period: TimePeriod option) =
    match format with
    | HHmm ->
        sprintf "%s:%s"
        <| formatStr HHmm time.Hours
        <| formatStr HHmm time.Minutes

    | Hma ->
        sprintf "%s:%s %s"
        <| formatStr Hma time.Hours
        <| formatStr Hma time.Minutes
        <| formatPeriod Hma period

    | HHmmA ->
        sprintf "%s:%s %s"
        <| formatStr HHmmA time.Hours
        <| formatStr HHmmA time.Minutes
        <| formatPeriod HHmmA period

    | HHmmss ->
        sprintf "%s:%s:%s"
        <| formatStr HHmmss time.Hours
        <| formatStr HHmmss time.Minutes
        <| formatStr HHmmss time.Seconds

let onChange (config : Config<'Msg>) currentTime state dispatch =
    config.OnChange
        (state, currentTime)
        |> dispatch

let onClear (config: Config<'Msg>) state dispatch =
    config.OnClear
        (state, None)
        |> dispatch

let clearIcon
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch   =
        Button.button [
            Button.props [ OnClick (fun _ -> onClear config state dispatch ) ]
        ] [
            Icon.faIcon [
                Icon.isRight
                Icon.isSmall
            ] Fa.Times
        ]

let selectOption
    updateTime
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    (value: int)
    dispatch   =

    option [
        if currentTime = None && value = 0 then yield (Selected true) :> IHTMLProp
        yield Value (string value) :> IHTMLProp
        yield OnClick(fun _ ->
                    let time = updateTime currentTime value
                    onChange config (Some time) state dispatch) :> IHTMLProp
    ]
        [ str (formatStr state.Format value) ]

let hourOption (config: Config<'Msg>) =
    selectOption (fun (time: TimeSpan option) h ->

                        match time with
                        | Some t ->
                            let hours = t.Hours
                            t.Add <| TimeSpan(h - hours, 0, 0)
                        | None   -> TimeSpan(h, 0, 0) ) config

let minuteOption (config: Config<'Msg>) =
    selectOption (fun (time: TimeSpan option) m ->
                        match time with
                        | Some t ->
                            let minutes = t.Minutes
                            t.Add <| TimeSpan(0, m - minutes, 0)
                        | None   -> TimeSpan(0, m, 0) ) config

let secondOption (config: Config<'Msg>) =
    selectOption (fun (time: TimeSpan option) s ->
                        match time with
                        | Some t ->
                            let seconds = t.Seconds
                            t.Add <| TimeSpan(0, 0, s - seconds)
                        | None   -> TimeSpan(0, 0, s) ) config

let hourRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch =
    match state.Format with
      | HHmm | HHmmss ->
        [ for i in 0..23 -> hourOption config state currentTime i dispatch ]
      | HHmmA | Hma ->
        [ for i in 0..11 -> hourOption config state currentTime i dispatch ]

let minuteRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch  =
        if state.MinuteInterval <> 0 then
            [ for i in 0 .. state.MinuteInterval .. 59 -> minuteOption config state currentTime i dispatch ]
        else
            [ for i in 0..59 -> minuteOption config state currentTime i dispatch ]

let secondRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch  =
        if state.SecondInterval <> 0 then
            [ for i in 0 .. state.SecondInterval .. 59 -> secondOption config state currentTime i dispatch ]
        else
            [ for i in 0..59 -> secondOption config state currentTime i dispatch ]

let getTimePeriod (time:TimeSpan) =
        if time.Hours > 12 then PM else AM

let updatePeriod period (currentTime: TimeSpan option)  =
    match currentTime with
    | Some time ->
        let currentPeriod = getTimePeriod time
        match currentPeriod, period with
        | AM, PM -> time.Add <| TimeSpan(12,0,0)
        | PM, AM -> time.Add <| TimeSpan(-12,0,0)
        | AM, AM -> time
        | PM, PM -> time
    | None ->
        match period with
        | AM -> TimeSpan(0,0,0)
        | PM -> TimeSpan(24,0,0)

let periodRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch =
    [ AM; PM ]
    |> List.map (fun p ->
        option [
            Value <| p.ToString()
            OnClick(fun _ ->
                let time = updatePeriod p currentTime
                onChange config (Some time) state dispatch)
        ] [ str <| formatPeriod state.Format (Some p) ])

let levelItems
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch =
    let hourOptions = hourRangeOptions config state currentTime dispatch
    let minuteOptions = minuteRangeOptions config state currentTime dispatch
    let secondOptions = secondRangeOptions config state currentTime dispatch
    let periodOptions = periodRangeOptions config state currentTime dispatch
    let toLevelItem options =
        Level.item [ ]
            [ Select.select []
                [ select [ ] options ] ]

    match state.Format with
    | HHmm      ->
        [ hourOptions; minuteOptions ] |> List.map toLevelItem
    | HHmmss    ->
        [ hourOptions; minuteOptions; secondOptions ] |> List.map toLevelItem
    | HHmmA | Hma ->
        [ hourOptions; minuteOptions; periodOptions ] |> List.map toLevelItem

let root (config: Config<'Msg>) (state: State) (currentTime: TimeSpan option) dispatch =
    let timeTxt =
        let period  = Option.map getTimePeriod currentTime
        let zeroTime = TimeSpan(0,0,0,0)
        let time = Option.defaultValue zeroTime currentTime
        formatTimeTxt  state.Format time period

    Dropdown.dropdown [
            Dropdown.isHoverable
            Dropdown.props [ Style [ CSSProp.Width "500px" ]
                            ]
             ]
        [ div [ Style [ CSSProp.MaxWidth "10em" ] ]
            [
                Level.level[ ]
                    [ Level.left [ ]
                        [ yield Level.item [] [
                            Input.input [
                                Input.defaultValue timeTxt
                                Input.props [
                                        ReadOnly true
                                        Style [
                                            CSSProp.Width "10em"
                                            CSSProp.Height "2.2em"
                                            CSSProp.Padding "0.3em"
                                            CSSProp.FontSize "1em"
                                        ] ]
                            ]
                          ]
                          if currentTime.IsSome then
                            yield Level.item [] [ clearIcon config state currentTime dispatch ]
                        ]
                    ]
            ]
          Dropdown.menu [ Props [ Style [ CSSProp.Padding "0" ] ] ]
            [   Dropdown.content [ ]
                    [
                        Level.level[ ]
                            [ Level.left [ ]
                                [ yield! levelItems config state currentTime dispatch ]
                            ]
                    ]
            ]
        ]
