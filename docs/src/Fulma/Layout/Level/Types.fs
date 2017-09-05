module Layouts.Level.Types

type Model =
    { Intro : string
      BoxViewer : Viewer.Types.Model
      CenteredViewer : Viewer.Types.Model }

type Msg =
    | BoxViewerMsg of Viewer.Types.Msg
    | CenteredViewerMsg of Viewer.Types.Msg
