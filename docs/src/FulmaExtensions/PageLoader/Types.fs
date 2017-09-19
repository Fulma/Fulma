module FulmaExtensions.PageLoader.Types
open Fulma.Common

type Model =
    { Intro : string
      Viewer : Viewer.Types.Model
      IsLoading : bool
      Color : ILevelAndColor }

type Msg =
    | ViewerMsg of Viewer.Types.Msg
    | IsLoadingMsg of ILevelAndColor
    | FakeRequestSuccess of unit
    | FakeRequestError of exn
