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

let (|ValidInterval|_|) =
        function
        | i when i < 60 && i >= 1 -> Some i
        | _ -> None

let validateInterval listName =
    function
    | ValidInterval i   -> Interval i
    | n                 ->
        log <| sprintf "[Time Picker] The value %d for %s-interval is invalid.\nIt must be between 1 and 60. Defaulted value: 1" n listName
        Interval 1


//Helpers to format hour from Fable.Powerpack.Date:
//https://github.com/fable-compiler/fable-powerpack/blob/master/src/Date/Format.fs
let inline padWithN n c = (fun (x: string) -> x.PadLeft(n, c)) << string
let internal padWith = padWithN 2

let formatOptionTxt =
    function
    | HHmm  | HHmmt | HHmmtt | HHmmss   | HHmmsst   | HHmmsstt  -> padWith '0'
    | Hm    | Hmt   | Hmtt   | Hms      | Hmst      | Hmstt     -> string

let formatPeriodTxt =
    Option.defaultValue AM  >> (fun p -> p.ToString() )

let formatTimeTxt format (time: TimeSpan) =
    let date = new System.DateTime(time.Ticks)
    match format with
    //Format Hour with Fable Powerpack:
    //http://fable.io/fable-powerpack/posts/date_format.html
    | HHmm      -> Format.format date "HH:mm"
    | HHmmt     -> Format.format date "hh:mm t"
    | HHmmtt    -> Format.format date "hh:mm tt"
    | HHmmss    -> Format.format date "HH:mm:ss"
    | HHmmsst   -> Format.format date "hh:mm:ss t"
    | HHmmsstt  -> Format.format date "hh:mm:ss tt"
    | Hm        -> Format.format date "H:m"
    | Hmt       -> Format.format date "h:m t"
    | Hmtt      -> Format.format date "h:m tt"
    | Hms       -> Format.format date "H:m:s"
    | Hmst      -> Format.format date "h:m:s t"
    | Hmstt     -> Format.format date "h:m:s tt"

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
        let buttonStyle =
            Style [
                     Border "none"
                     Position "absolute"
                     Overflow "hidden"
                     Outline "none"
                     FlexFlow "column nowrap"
                     Display "flex"
                     Top 0
                     Right 0
                     Bottom 0
                     BackgroundColor "Transparent" ]

        Button.button [
            Button.props [
                OnClick (fun _ -> onClear config state dispatch )
                buttonStyle
            ]
            ] [
                Icon.faIcon [
                    Icon.isSmall
                    Icon.isRight
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
        | HHmm | HHmmt  | HHmmtt    | HHmmss    | HHmmsst   | HHmmsstt  -> "HH"
        | Hm   | Hmt    | Hmtt      | Hms       | Hmst      | Hmstt     -> "H" )

let minuteHintOption =
    hintOption (
        function
        | HHmm | HHmmt  | HHmmtt    | HHmmss    | HHmmsst   | HHmmsstt  -> "mm"
        | Hm   | Hmt    | Hmtt      | Hms       | Hmst      | Hmstt     -> "m")

let secondHintOption =
    hintOption (
        function
        | HHmmss | HHmmsst | HHmmsstt -> "ss"
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
        [ str (formatOptionTxt state.Format value) ]

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
            | HHmm | HHmmss | Hm | Hms ->
                [ for i in 0..23 -> hourOption config state currentTime i dispatch ]
            | HHmmsst | HHmmsstt | HHmmtt | HHmmt | Hmtt | Hmt | Hmstt | Hmst ->
                [ for i in 0..11 -> hourOption config state currentTime i dispatch ]
    hint::hourOptions

let minuteRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch  =
        let hint = minuteHintOption state
        let minuteOptions =
            let (Interval interval) = validateInterval "minute" state.MinuteInterval

            [ for i in 0 .. interval .. 59 -> minuteOption config state currentTime i dispatch ]

        hint::minuteOptions

let secondRangeOptions
    (config: Config<'Msg>)
    (state: State)
    (currentTime: TimeSpan option)
    dispatch  =
        let hint = secondHintOption state
        let secondOptions =
            let (Interval interval) = validateInterval "second" state.SecondInterval

            [ for i in 0 .. interval .. 59 -> secondOption config state currentTime i dispatch ]

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
        ] [ str <| formatPeriodTxt (Some p) ])

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
        Level.item [ Level.Item.hasTextCentered ]
            [ Select.select [ ]
                [ select [] options ]
            ]

    match state.Format with
    | Hm    | HHmm                              -> [ hourOptions; minuteOptions ] |> List.map toLevelItem
    | Hms   | HHmmss                            -> [ hourOptions; minuteOptions; secondOptions ] |> List.map toLevelItem
    | HHmmt | HHmmtt    | Hmt     | Hmtt        -> [ hourOptions; minuteOptions; periodOptions ] |> List.map toLevelItem
    | Hmst  | Hmstt     | HHmmsst | HHmmsstt    -> [ hourOptions; minuteOptions; secondOptions; periodOptions ] |> List.map toLevelItem

let timePickerWidth =
    function
    | Hm    | HHmm                              -> Style [ Width "12em" ]
    | Hms   | HHmmss                            -> Style [ Width "18em" ]
    | HHmmt | HHmmtt    | Hmt     | Hmtt        -> Style [ Width "18em" ]
    | Hmst  | Hmstt     | HHmmsst | HHmmsstt    -> Style [ Width "24em" ]


let root (config: Config<'Msg>) (state: State) (currentTime: TimeSpan option) dispatch =
    let timeTxt =
        let zeroTime = TimeSpan(0,0,0,0)
        let time = Option.defaultValue zeroTime currentTime
        formatTimeTxt  state.Format time

    Dropdown.dropdown [
            if state.ShowDropdown then yield Dropdown.isActive
             ]
        [ div [ Style [ ] ]
            [
                Control.control_div [ ]
                    [

                      yield Input.input [
                                Input.defaultValue timeTxt
                                Input.props [
                                        ReadOnly true
                                        OnClick (fun _ ->
                                                       let newState = { state with ShowDropdown = not (state.ShowDropdown) }
                                                       onChange config currentTime newState dispatch)
                                        timePickerWidth state.Format ]
                            ]

                      if currentTime.IsSome && not state.ShowDropdown then
                            yield clearIcon config state currentTime dispatch
                    ]
            ]
          Dropdown.menu [ Props [ Style [
                                    Top "2.2em"
                                    Position "absolute" ] ] ]
            [   Dropdown.content [ Props [ timePickerWidth state.Format ] ]
                    [
                        Level.level[ ]
                                [ yield! levelItems config state currentTime dispatch ]
                    ]
            ]
        ]
