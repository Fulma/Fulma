module Fulma.Extensions.Dispatcher.Types

type Model =
    { Calendar : Fulma.Extensions.Calendar.Types.Model }

type Msg =
    | CalendarMsg of Fulma.Extensions.Calendar.Types.Msg
