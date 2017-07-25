module Components.Breadcrumb.Types

type Model =
    { Intro : string
      BasicViewer : Viewer.Types.Model
      AlignmentCenterViewer : Viewer.Types.Model
      IconViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model
      SeparatorViewer : Viewer.Types.Model }

type Msg =
    | BasicViewerMsg of Viewer.Types.Msg
    | AlignmentCenterViewerMsg of Viewer.Types.Msg
    | IconViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
    | SeparatorViewerMsg of Viewer.Types.Msg
