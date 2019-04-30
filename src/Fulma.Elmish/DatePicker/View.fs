namespace Fulma.Elmish.DatePicker

open Fable.React
open Fable.React.Props
open Fulma
open Fable.FontAwesome
open Fulma.Extensions.Wikiki
open Types
open System

module View =
    let isCalendarDisplayed currentState =
        currentState.InputFocused && not (currentState.AutoClose && currentState.ForceClose)

    let onFocus currentState updateState =
        // If the calendar is already displayed don't dispatch a new onFocus message
        // This is needed because we register to both onClick and onFocus event
        if not (isCalendarDisplayed currentState) then
            { currentState with
                InputFocused = true
                ForceClose = false }
            |> updateState

    let onChange (config : Config<'Msg>) newDate dispatch =
        config.OnChange newDate |> dispatch

    let onDeleteClick (config : Config<'Msg>) (currentDate : DateTime option) dispatch =
        if currentDate.IsSome
        then onChange config None dispatch

    let calendar (config : Config<'Msg>) currentState updateState (currentDate : DateTime option) dispatch =
        let isCurrentMonth (date : DateTime) =
            currentState.ReferenceDate.Month = date.Month

        let isToday (dateToCompare : DateTime) =
            let d = DateTime.UtcNow
            dateToCompare.Day = d.Day && dateToCompare.Month = d.Month && dateToCompare.Year = d.Year

        let isSelected (dateToCompare : DateTime) =
            match currentDate with
            | Some date -> date.Day = dateToCompare.Day && date.Month = dateToCompare.Month && date.Year = dateToCompare.Year
            | None -> false

        let body =
            let first = DateTime(currentState.ReferenceDate.Year, currentState.ReferenceDate.Month, 1)
            let weekOffset = int first.DayOfWeek
            let firstDateCalendar = first.AddDays(float -weekOffset)
            let onClickDate date =
                fun _ ->
                    updateState { currentState with ForceClose = true }
                    onChange config (Some date) dispatch
                |> OnClick

            seq {
                for dayRank = 0 to 41 do // We have 42 dates to show
                    let date = firstDateCalendar.AddDays(float dayRank)
                    yield Calendar.Date.date
                        [ Calendar.Date.IsDisabled (not (isCurrentMonth date)) ]
                        [ Calendar.Date.item
                            [ Calendar.Date.Item.IsToday (isToday date)
                              Calendar.Date.Item.IsActive (isSelected date)
                              Calendar.Date.Item.Props [ onClickDate date ] ]
                            [ date.Day |> string |> str ] ]
            } |> Seq.toList

        let changeMonthButton offset =
            let changeMonth offset =
                  let newState =
                      { currentState with
                          ReferenceDate = currentState.ReferenceDate.AddMonths offset
                          ForceClose = false }
                  updateState newState
            let iconType =
                if offset < 0 then Fa.Solid.ChevronLeft
                else Fa.Solid.ChevronRight
            Button.button
                [ Button.IsLink
                  Button.OnClick (fun _ -> changeMonth offset) ]
                [ Icon.icon [ ] [ Fa.i [ iconType ] [ ] ] ]

        Box.box'
            [ Common.Props [ Style config.DatePickerStyle ] ]
            [ Calendar.calendar
                [ Calendar.Props [ OnMouseDown (fun ev -> ev.preventDefault()) ] ]
                [ Calendar.Nav.nav [ ]
                    [ Calendar.Nav.left [ ] [ changeMonthButton -1 ]
                      str (Date.Format.localFormat config.Local "MMMM yyyy" currentState.ReferenceDate)
                      Calendar.Nav.right [ ] [ changeMonthButton 1 ] ]

                  div [ ]
                      [ Calendar.header [ ]
                            [ Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Sunday ]
                              Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Monday ]
                              Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Tuesday ]
                              Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Wednesday ]
                              Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Thursday ]
                              Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Friday ]
                              Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Saturday ] ]
                        Calendar.body [ ] body ] ] ]


    let formatDate config currentDate =
        match currentDate with
        | None -> ""
        | Some date ->
            Date.Format.localFormat config.Local config.Local.Date.DefaultFormat date

    let input config currentState updateState currentDate =
        let dateTxt = formatDate config currentDate
        let focusEvent = (fun _ -> onFocus currentState updateState)
        Input.text
            [ Input.Props
                [ DefaultValue dateTxt
                  ReadOnly true
                  OnFocus focusEvent
                  OnClick focusEvent
                  OnBlur (fun _ ->
                      updateState { currentState with InputFocused = false }) ] ]

    let deleteButton config currentDate dispatch =
        Button.a
            [ Button.OnClick (fun _ -> onDeleteClick config currentDate dispatch) ]
            [ Icon.icon [ ] [ Fa.i [ Fa.Solid.Times ] [ ] ] ]

    let internal view<'Msg> =
        FunctionComponent.Of(fun (props: {| Config: Config<'Msg>; State: State; CurrentDate: DateTime option; Dispatch: 'Msg -> unit |}) ->
            let config = props.Config
            let state = props.State
            let currentDate = props.CurrentDate
            let dispatch = props.Dispatch

            let state = Hooks.useState state

            let input = input config state.current state.update currentDate
            let deleteButton =
                if state.current.ShowDeleteButton
                then deleteButton config currentDate dispatch |> Some
                else None
            let calendar =
                if isCalendarDisplayed state.current
                then calendar config state.current state.update currentDate dispatch |> Some
                else None

            div [ ]
                [ yield Field.body []
                    [ Field.div (if deleteButton.IsSome then [ Field.HasAddons ] else [])
                        [ yield Control.p [ Control.IsExpanded ] [ input ]
                          if deleteButton.IsSome then
                              yield Control.p [] [ deleteButton.Value ] ] ]
                  if calendar.IsSome then
                    yield calendar.Value ])

    let root config state currentDate dispatch =
        view
            {| Config = config
               State = state
               CurrentDate = currentDate
               Dispatch = dispatch |}
