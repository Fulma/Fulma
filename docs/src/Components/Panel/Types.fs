module Components.Panel.Types

type Model =
    { Intro : string
      PanelViewer : Viewer.Types.Model }

type Msg =
    | PanelViewerMsg of Viewer.Types.Msg
