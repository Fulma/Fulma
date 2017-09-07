module FulmaExtensions.PageLoader.Types
open Fulma.Common

type Model =
    { Intro : string
      Viewer : Viewer.Types.Model
      IsLoading : bool * ILevelAndColor
      }

type Msg =
    | ViewerMsg of Viewer.Types.Msg
    | IsLoadingMsg of ILevelAndColor
    | IsLoadedMsg 
    
