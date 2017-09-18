namespace Fulma.Elmish.DatePicker

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma.BulmaClasses
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Extra.FontAwesome
open Fulma.Extensions
open Fable.PowerPack
open Types
open System

module View =

    let onFocus (config : Config<'Msg>) state currentDate dispatch =
        config.OnChange
            ({ state with InputFocused = true
                          ForceClose = false }, currentDate)
            |> dispatch


    let onChange (config : Config<'Msg>) state currentDate dispatch =
        config.OnChange
            (state, currentDate)
            |> dispatch

    let calendar (config : Config<'Msg>) state (currentDate : DateTime option) dispatch =
        let isCurrentMonth (date : DateTime) =
            state.ReferenceDate.Month  = date.Month

        let isToday (dateToCompare : DateTime) =
            let d = DateTime.UtcNow
            dateToCompare.Day = d.Day && dateToCompare.Month = d.Month && dateToCompare.Year = d.Year

        let isSelected (dateToCompare : DateTime) =
            match currentDate with
            | Some date -> date.Day = dateToCompare.Day && date.Month = dateToCompare.Month && date.Year = dateToCompare.Year
            | None -> false

        let body =
            let first = DateTime(state.ReferenceDate.Year, state.ReferenceDate.Month, 1)
            let weekOffset = int first.DayOfWeek
            let firstDateCalendar = first.AddDays(float -weekOffset)

            seq {
                for dayRank = 0 to 34 do // We have 35 dates to show
                    let date = firstDateCalendar.AddDays(float dayRank)
                    yield Calendar.Date.date [
                                if not (isCurrentMonth date) then
                                    yield Calendar.Date.isDisabled ]
                                [ Calendar.Date.item [
                                      if isToday date then
                                        yield Calendar.Date.Item.isToday
                                      if isSelected date then
                                        yield Calendar.Date.Item.isActive
                                      yield Calendar.Date.Item.props [ OnClick (fun _ -> let newState = { state with ForceClose = true }
                                                                                         onChange config newState (Some date) dispatch) ] ]
                                    [ str (date.Day.ToString()) ] ]
            } |> Seq.toList

        Box.box' [ Box.props [ Style [ Position "absolute"
                                       MaxWidth "450px" ] ] ]
                 [ Calendar.calendar [ Calendar.props [ OnMouseDown (fun ev -> ev.preventDefault()) ]
                                                   ]
                                     [ Calendar.Nav.nav [ ]
                                         [ Calendar.Nav.left [ ]
                                             [ Button.button [ Button.isLink
                                                               Button.onClick (fun _ -> let newState = { state with ReferenceDate = state.ReferenceDate.AddMonths(-1)
                                                                                                                    ForceClose = false }
                                                                                        onChange config newState currentDate dispatch) ]
                                                             [ Icon.faIcon [ ] (Fa.Custom "fa-chevron-left") ] ]
                                           str (Date.Format.localFormat config.Local state.ReferenceDate "MMMM yyyy")
                                           Calendar.Nav.right [ ]
                                             [ Button.button [ Button.isLink
                                                               Button.onClick (fun _ -> let newState = { state with ReferenceDate = state.ReferenceDate.AddMonths(1)
                                                                                                                    ForceClose = false }
                                                                                        onChange config newState currentDate dispatch) ]
                                                             [ Icon.faIcon [ ] (Fa.Custom "fa-chevron-right") ] ] ]
                                       div [ ]
                                           [ Calendar.header [ ]
                                                 [ Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Sunday ]
                                                   Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Monday ]
                                                   Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Tuesday ]
                                                   Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Wednesday ]
                                                   Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Thursday ]
                                                   Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Friday ]
                                                   Calendar.Date.date [ ] [ str config.Local.Date.AbbreviatedDays.Saturday ] ]
                                             Calendar.body [ ]
                                                 body ] ] ]


    let root<'Msg> (config: Config<'Msg>) (state: State) (currentDate: DateTime option) dispatch =
        let dateTxt =
            match currentDate with
            | Some date ->
                Date.Format.localFormat Date.Local.french date "dd/MM/yyyy"
            | None -> ""
        div [ ]
            [ yield Input.input [ Input.typeIsText
                                  Input.props [ Value dateTxt
                                                OnFocus (fun _ -> onFocus config state currentDate dispatch)
                                                // TODO: Implement something to trigger onChange only if the value actually change
                                                OnBlur (fun _ -> let newState = { state with InputFocused = false }
                                                                 onChange config newState currentDate dispatch) ] ]
              if state.InputFocused && not (state.AutoClose && state.ForceClose) then
                yield calendar config state currentDate dispatch ]
