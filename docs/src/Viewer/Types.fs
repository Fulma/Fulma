module Viewer.Types

open Fable.Import.React

type Model =
    { IsExpanded : bool
      Code : string }

type Msg =
    | Expand
    | Collapse
