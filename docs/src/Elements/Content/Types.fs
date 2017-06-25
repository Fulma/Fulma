module Elements.Content.Types

type Model =
    { Intro : string
      ContentViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model }

type Msg =
    | ContentViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
