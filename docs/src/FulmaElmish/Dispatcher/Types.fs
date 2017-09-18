module FulmaElmish.Dispatcher.Types

type Model =
    { DatePicker : FulmaElmish.DatePicker.Types.Model }

type Msg =
    | DatePickerMsg of FulmaElmish.DatePicker.Types.Msg
