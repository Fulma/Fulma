module App.Types

open Global

type Msg =
    | MenuMsg of Menu.Types.Msg
    | FulmaExtensionsMsg of FulmaExtensions.Dispatcher.Types.Msg
    | FulmaElmishMsg of FulmaElmish.Dispatcher.Types.Msg

type Model =
    { Menu : Menu.Types.Model
      CurrentPage : Page
      FulmaExtensions : FulmaExtensions.Dispatcher.Types.Model
      FulmaElmish : FulmaElmish.Dispatcher.Types.Model }
