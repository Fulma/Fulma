module FulmaExtensions.Checkradio.Types

type Model =
    { Intro : string
      InlineBlockViewer : Viewer.Types.Model
      ColorViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model
      CircleViewer : Viewer.Types.Model
      StateViewer : Viewer.Types.Model
      EventViewer : Viewer.Types.Model
      IsChecked : bool
    }

type Msg =
    | InlineBlockViewerMsg of Viewer.Types.Msg
    | ColorViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
    | CircleViewerMsg of Viewer.Types.Msg
    | StateViewerMsg of Viewer.Types.Msg
    | EventViewerMsg of Viewer.Types.Msg
    | Change of bool 

