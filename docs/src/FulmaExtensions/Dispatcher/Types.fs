module FulmaExtensions.Dispatcher.Types

type Model =
    { Calendar : FulmaExtensions.Calendar.Types.Model
      Tooltip : FulmaExtensions.Tooltip.Types.Model
      PageLoader : FulmaExtensions.PageLoader.Types.Model }

type Msg =
    | CalendarMsg of FulmaExtensions.Calendar.Types.Msg
    | TooltipMsg of FulmaExtensions.Tooltip.Types.Msg
    | PageLoaderMsg of FulmaExtensions.PageLoader.Types.Msg
