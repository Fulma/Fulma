module FulmaElmish.TimePicker.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Extensions
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Elmish
open Fulma.Layouts
open Fulma.Components
open Fable.PowerPack

let pickerConfig : TimePicker.Types.Config<Msg> =
    { OnChange = TimePickerChanged
      Local = Date.Local.french }

let root model dispatch =
    let timePickerView =
        TimePicker.View.root pickerConfig model.TimePickerState model.CurrentTime dispatch

    let timeText =
        match model.CurrentTime with
        | Some time ->
            let date = new System.DateTime(time.Ticks)

            Fable.PowerPack.Date.Format.format date "hhm:mm tt"
            |> sprintf "The selected time is: %s"
            |> str

        | None ->
            str "Please select a date"

    Render.docPage [ Render.contentFromMarkdown
                        """
# Date picker

A ready to use date picker.

This component is based on [Fulma.Extensions.Calendar](#fulma-extensions/calendar).

---

**Important**, for now this components works best when using [preact](https://preactjs.com/) instead of [react](https://facebook.github.io/react/)

**Preact**, is really easy to switch over. See the [migration guide](https://preactjs.com/guide/switching-to-preact).

This special requirement is due to how react manage input `value` and `defaultValue` (aka *Uncontrolled components*)
                        """
                     Card.card [ ]
                        [ Card.content [ ]
                            [ Columns.columns [ Columns.isVCentered ]
                                [ Column.column [ ]
                                    [ timePickerView ]
                                  Column.column [ ]
                                    [ timeText ] ] ] ]
                     Render.contentFromMarkdown
                        """
Here is the minimal code needed to include the datepicker components into your application.

*Types.fs*
```fsharp
type Model =
    { DatePickerState : DatePicker.Types.State // Store the state of the date picker into your model
      CurrentDate : DateTime option } // Current date selected

type Msg =
    // Message dispatch when a new date is selected
    | DatePickerChanged of DatePicker.Types.State * (DateTime option)
```

*Update.fs*
```fsharp
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
```fsharp
// Configuration passed to the components
let pickerConfig : DatePicker.Types.Config<Msg> =
    { OnChange = DatePickerChanged // Message to dispatch when a new date is selected
      Local = Date.Local.french } // Local used to generated the calendar

let root model dispatch =
    DatePicker.View.root pickerConfig model.DatePickerState model.CurrentDate dispatch
```
                        """ ]
