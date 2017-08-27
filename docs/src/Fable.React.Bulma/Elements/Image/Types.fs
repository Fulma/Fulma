module Elements.Image.Types

type Model =
    { Intro : string
      FixedViewer : Viewer.Types.Model
      ResponsiveViewer : Viewer.Types.Model }

type Msg =
    | FixedViewerMsg of Viewer.Types.Msg
    | ResponsiveViewerMsg of Viewer.Types.Msg
