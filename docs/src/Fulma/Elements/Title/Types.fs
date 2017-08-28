module Elements.Title.Types

type Model =
    { Intro : string
      TypeViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model }

type Msg =
    | TypeViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
