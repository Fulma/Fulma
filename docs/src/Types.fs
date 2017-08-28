module App.Types

open Global

type Msg =
    | MenuMsg of Menu.Types.Msg
    | FulmaMsg of Fulma.Dispatcher.Types.Msg
    | FulmaExtensionsMsg of Fulma.Extensions.Dispatcher.Types.Msg


type Model =
    { Menu : Menu.Types.Model
      CurrentPage : Page
      Home : Home.Types.Model
      Fulma : Fulma.Dispatcher.Types.Model
      FulmaExtensions : Fulma.Extensions.Dispatcher.Types.Model }
