module FulmaExtensions.PageLoader.Types
open Fulma

type Model =
    { Intro : string
      Viewer : Viewer.Types.Model
      IsLoading : bool
      Color : IColor }

type Msg =
    | ViewerMsg of Viewer.Types.Msg
    | IsLoadingMsg of IColor
    | FakeRequestSuccess of unit
    | FakeRequestError of exn
