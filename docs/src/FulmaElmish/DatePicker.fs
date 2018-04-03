module FulmaElmish.DatePicker

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma.Components
open Fulma.Elmish
open Fulma.Layouts
open Fable.PowerPack
open System

[<Pojo>]
type DatePickerDemoProps =
    interface end

[<Pojo>]
type DatePickerDemoState =
    { DatePickerState : DatePicker.Types.State
      CurrentDate : DateTime option }

type DatePickerDemo(props) =
    inherit React.Component<DatePickerDemoProps, DatePickerDemoState>(props)

    let pickerConfig : DatePicker.Types.Config<DatePicker.Types.State * DateTime option > =
        let defaultConfig = DatePicker.Types.defaultConfig id

        { defaultConfig with DatePickerStyle = [ Position "absolute"
                                                 MaxWidth "450px"
                                                 // Fix calendar display for Ipad browsers (Safari, Chrome)
                                                 // See #56: https://github.com/MangelMaxime/Fulma/issues/56#issuecomment-332186559
                                                 ZIndex 10. ] }

    do base.setInitState({ DatePickerState = { DatePicker.Types.defaultState with AutoClose = true }
                           CurrentDate = None })

    member this.datePickerChanged (newState, newDate) =
        { this.state with DatePickerState = newState
                          CurrentDate = newDate }
        |> this.setState

    override this.render () =
        let datePickerView =
                DatePicker.View.root pickerConfig this.state.DatePickerState this.state.CurrentDate this.datePickerChanged

        let dateText =
            match this.state.CurrentDate with
            | Some date ->
                Date.Format.localFormat pickerConfig.Local "dddd, MMMM dd, yyyy" date
                |> (fun dateStr -> "The selected date is: " + dateStr)
                |> str

            | None ->
                str "Please select a date"

        Card.card [ ]
            [ Card.content [ ]
                [ Columns.columns [ Columns.IsVCentered ]
                    [ Column.column [ ]
                        [ datePickerView ]
                      Column.column [ ]
                    [ dateText ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Date picker

A ready to use date picker.

This component is based on [Fulma.Extensions.Calendar](#fulma-extensions/calendar).
                        """
                     (ofType<DatePickerDemo,_,_> (unbox null) [])
                     Render.contentFromMarkdown
                        """
Here is the minimal code needed to include the datepicker components into your application.

*Types.fs*
```fs
type Model =
    { DatePickerState : DatePicker.Types.State // Store the state of the date picker into your model
      CurrentDate : DateTime option } // Current date selected

type Msg =
    // Message dispatch when a new date is selected
    | DatePickerChanged of DatePicker.Types.State * (DateTime option)
```

*Update.fs*
```fs
let init() =
    { DatePickerState = { DatePicker.Types.defaultState with AutoClose = true }
      CurrentDate = None }

let update msg model =
    match msg with
    | DatePickerChanged (newState, date) ->
        // Store the new state and the selected date
        { model with DatePickerState = newState
                     CurrentDate = date }, Cmd.none

```

*View.fs*
```fs
// Configuration passed to the components
let pickerConfig : DatePicker.Types.Config<Msg> =
    DatePicker.Types.defaultConfig DatePickerChanged

let root model dispatch =
    DatePicker.View.root pickerConfig model.DatePickerState model.CurrentDate dispatch
```

## Config option

Here is the different options you can set in the Config element:

- `OnChange : State * (DateTime option) -> 'Msg`: Message to dispatch when a new date is selected
- `Local : Date.Local.Localization`: Local used to generated the calendar
- `DatePickerStyle : ICSSProp list`: Inline style used to display the calendar box
                        """ ]
