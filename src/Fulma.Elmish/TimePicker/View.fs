module Fulma.Elmish.TimePicker.View

open Fulma.Elmish.TimePicker.Types
open System
open Fulma.Components
open Fulma.Elements
open Fulma.Common
open Fulma.Extra.FontAwesome

open Fable.Helpers.React
open Fable.Helpers.React.Props

open Fable.PowerPack.Date

open Fulma.Elements.Form
open Fulma.Layouts
open Fable.Helpers.React.Props
open Fable.Helpers.React.Props
open Fable.Import.JS
open Fable.AST.Babel
open Fulma.Elements.Button

let log (input: string) = Fable.Import.Browser.console.log( input )

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
    let date = new System.DateTime(time.Ticks)
    match format with
    //Format Hour with Fable Powerpack:
    //http://fable.io/fable-powerpack/posts/date_format.html
    | HHmm   -> Format.format date "HH:mm"
    | Hma    -> Format.format date "h:m t"
    | HHmmA  -> Format.format date "hh:mm tt"
    | HHmmss -> Format.format date "HH:mm:ss"

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

let hintOption
    buildHintText
    (state: State) =
    let hintText = buildHintText state.Format
    option [ (Disabled true) :> IHTMLProp ] [ str hintText ]

let hourHintOption =
    hintOption (
        function
        | HHmm | HHmmss | HHmmA-> "HH"
        | Hma -> "H" )

let minuteHintOption =
    hintOption (
        function
        | HHmm | HHmmss | HHmmA-> "mm"
        | Hma -> "m" )

let secondHintOption =
    hintOption (
        function
        | HHmmss -> "ss"
        | _ -> "ss" )

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
    let hint = hourHintOption state
    let hourOptions =
        match state.Format with
          | HHmm | HHmmss ->
            [ for i in 0..23 -> hourOption config state currentTime i dispatch ]
          | HHmmA | Hma ->
            [ for i in 0..11 -> hourOption config state currentTime i dispatch ]
    hint::hourOptions

let minuteRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch  =
        let hint = minuteHintOption state
        let minuteOptions =
            if state.MinuteInterval > 0 then
                [ for i in 0 .. state.MinuteInterval .. 59 -> minuteOption config state currentTime i dispatch ]
            else
                [ for i in 0..59 -> minuteOption config state currentTime i dispatch ]
        hint::minuteOptions

let secondRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch  =
        let hint = secondHintOption state
        let secondOptions =
            if state.SecondInterval > 0 then
                [ for i in 0 .. state.SecondInterval .. 59 -> secondOption config state currentTime i dispatch ]
            else
                [ for i in 0..59 -> secondOption config state currentTime i dispatch ]
        hint::secondOptions

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
            OnClick (fun _ ->
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
            [ Select.select [
                    Select.props [ ]
            ]
                [ select [ ]
                            options ] ]

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
            if state.ShowDropdown then yield Dropdown.isActive
            yield Dropdown.props [
                    Style [ CSSProp.Width "500px" ]
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
                                        OnClick (fun _ ->
                                                       let newState = { state with ShowDropdown = not (state.ShowDropdown) }
                                                       onChange config currentTime newState dispatch)
                                        Style [ CSSProp.Width "10em" ] ]
                            ]
                          ]
                          if currentTime.IsSome && not state.ShowDropdown then
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
