module FulmaElmish.DatePicker

open Fable.Core
open Fable.Import
open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Elmish
open System

type DatePickerDemoProps =
    interface end

type DatePickerDemoState =
    { CurrentDate : DateTime option }

type DatePickerDemo(props) =
    inherit Component<DatePickerDemoProps, DatePickerDemoState>(props)

    let pickerConfig : DatePicker.Types.Config<DateTime option > =
        let defaultConfig = DatePicker.Types.defaultConfig id

        { defaultConfig with DatePickerStyle = [ Position PositionOptions.Absolute
                                                 MaxWidth "450px"
                                                 // Fix calendar display for Ipad browsers (Safari, Chrome)
                                                 // See #56: https://github.com/MangelMaxime/Fulma/issues/56#issuecomment-332186559
                                                 ZIndex 10. ] }
    let initialPickerState =
        { DatePicker.Types.defaultState with
            AutoClose = true
            ShowDeleteButton = true }

    do base.setInitState { CurrentDate = None }

    member this.datePickerChanged newDate =
        this.setState (fun prevState _ -> { prevState with CurrentDate = newDate })

    override this.render () =

        let datePickerView =
            DatePicker.View.root pickerConfig initialPickerState this.state.CurrentDate this.datePickerChanged

        let dateText =
            match this.state.CurrentDate with
            | Some date ->
                Date.Format.localFormat pickerConfig.Local "dddd, MMMM dd, yyyy" date
                |> sprintf "The selected date is: %s"
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
```fsharp
type Model =
    { CurrentDate : DateTime option } // Current date selected

type Msg =
    // Message dispatch when a new date is selected
    | DateChanged of DateTime option
```

*Update.fs*
```fsharp
let init() =
    { CurrentDate = None }

let update msg model =
    match msg with
    | DateChanged dateOption ->
        // Store the selected date
        { model with CurrentDate = dateOption }, Cmd.none

```

*View.fs*
```fsharp
// Configuration passed to the components
let pickerConfig : DatePicker.Types.Config<Msg> =
    DatePicker.Types.defaultConfig DateChanged

let initialPickerState : DatePicker.Types.State =
    DatePicker.Types.defaultState

let root model dispatch =
    DatePicker.View.root pickerConfig initialPickerState model.CurrentDate dispatch
```

## Config option

Here is the different options you can set in the Config element:

- `OnChange : DateTime option -> 'Msg`: Message to dispatch when a new date is selected
- `Local : Date.Local.Localization`: Local used to generated the calendar
- `DatePickerStyle : ICSSProp list`: Inline style used to display the calendar box
                        """ ]
