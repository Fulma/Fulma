module Menu.Types

open Fable.Import.React
open Global

type FableReactBulmaModules =
    | Elements
    | Components

type Library =
    | FableReactBulma of FableReactBulmaModules

type FableReactBulma =
    { IsElementsExpanded : bool
      IsComponentsExpanded : bool }

type Model =
    { FableReactBulma : FableReactBulma
      CurrentPage : Page }

type Msg =
    | ToggleMenu of Library
