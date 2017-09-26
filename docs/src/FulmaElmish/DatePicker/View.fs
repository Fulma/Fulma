module FulmaElmish.DatePicker.View

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

let pickerConfig : DatePicker.Types.Config<Msg> =
    let defaultConfig = DatePicker.Types.defaultConfig DatePickerChanged

    { defaultConfig with DatePickerStyle = [ Position "absolute"
                                             MaxWidth "450px"
                                             // Fix calendar display for Ipad browsers (Safari, Chrome)
                                             // See #56: https://github.com/MangelMaxime/Fulma/issues/56#issuecomment-332186559
                                             ZIndex 10. ] }

let root model dispatch =
    let datePickerView =
        DatePicker.View.root pickerConfig model.DatePickerState model.CurrentDate dispatch

    let dateText =
        match model.CurrentDate with
        | Some date ->
            Date.Format.format date "dddd, MMMM dd, yyyy"
            |> sprintf "The selected date is: %s"
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
                                    [ datePickerView ]
                                  Column.column [ ]
                                    [ dateText ] ] ] ]
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
