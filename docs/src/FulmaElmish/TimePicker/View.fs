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
      OnClear = TimePickerCleared }

let root model dispatch =
    let timePickerView =
        TimePicker.View.root pickerConfig model.TimePickerState model.CurrentTime dispatch

    let timeText =
        match model.CurrentTime with
        | Some time ->
            let date = new System.DateTime(time.Ticks)

            //http://fable.io/fable-powerpack/posts/date_format.html
            Fable.PowerPack.Date.Format.format date "hh:mm tt"
            |> sprintf "The selected time is: %s"
            |> str

        | None ->
            str "Please select a time"

    Render.docPage [ Render.contentFromMarkdown
                        """
# Time picker

A ready to use time picker all built with Fulma.

---
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

Here is the minimal code needed to include the time picker component into your application.

*Types.fs*
```fsharp
type Model =
    type Model =
    { TimePickerState : TimePicker.Types.State  // Carry the time picker state in your model
      CurrentTime : TimeSpan option }           // Current time selected

type Msg =
    | TimePickerChanged of TimePicker.Types.State * (TimeSpan option) // When time picker changes
    | TimePickerCleared of TimePicker.Types.State * (TimeSpan option) // Optionally define another message to map to the exposed config

```

*Update.fs*
In initialisation you can set the following available options of the time picker:
- Format: format of time displayed.
    Formats are complying with the formatting used in the [Fable.Powerpack.Date page](http://fable.io/fable-powerpack/posts/date_format.html).
    The available choices are:
    - HHmm
    - HHmmt
    - HHmmtt
    - HHmmss
    - HHmmsst
    - HHmmsstt
    - Hm
    - Hmt
    - Hmtt
    - Hms
    - Hmst
    - Hmstt

- Minute Interval: an integer between 1 and 60
- Second Interval: an integer between 1 and 60


```fsharp
let init () =
    {
        TimePickerState = { TimePicker.Types.defaultState
                                with
                                    Format = Format.HHmm
                                    MinuteInterval = 10
                                    SecondInterval = 10
                        }
        CurrentTime = None
    }

let update msg model =
    match msg with
    | TimePickerChanged (newState, time) ->
        { model with TimePickerState = newState
                     CurrentTime = time }, Cmd.none
    | TimePickerCleared (newState, time) ->
         { model with TimePickerState = newState; CurrentTime = time }, Cmd.none

```

*View.fs*
```fsharp
// Configuration passed to the components
let pickerConfig : TimePicker.Types.Config<Msg> =
    { OnChange = TimePickerChanged
      OnClear = TimePickerCleared }

let root model dispatch =
        TimePicker.View.root pickerConfig model.TimePickerState model.CurrentTime dispatch

```
                        """ ]
