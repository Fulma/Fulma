module FulmaExtensions.Divider.Types

type Model =
    { Intro : string
      NormalViewer : Viewer.Types.Model
      VerticalViewer : Viewer.Types.Model
    }

type Msg =
    | NormalViewerMsg of Viewer.Types.Msg
    | VerticalViewerMsg of Viewer.Types.Msg
    
