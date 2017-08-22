module Components.Tabs.Types

type Model =
    { Intro : string
      BasicViewer : Viewer.Types.Model
      AlignmentViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model
      StylesViewer : Viewer.Types.Model }

type Msg =
    | BasicViewerMsg of Viewer.Types.Msg
    | AlignmentViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
    | StylesViewerMsg of Viewer.Types.Msg
