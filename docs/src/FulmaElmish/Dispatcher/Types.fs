module FulmaElmish.Dispatcher.Types

type Model =
    {
        DatePicker : FulmaElmish.DatePicker.Types.Model
        TimePicker : FulmaElmish.TimePicker.Types.Model
    }

type Msg =
    | DatePickerMsg of FulmaElmish.DatePicker.Types.Msg
    | TimePickerMsg of FulmaElmish.TimePicker.Types.Msg
