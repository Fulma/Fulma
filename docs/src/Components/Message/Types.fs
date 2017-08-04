module Components.Message.Types

type Model =
    { Intro : string
      BasicViewer : Viewer.Types.Model
      ColorViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model
      BodyOnlyViewer : Viewer.Types.Model }

type Msg =
    | BasicViewerMsg of Viewer.Types.Msg
    | ColorViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
    | BodyOnlyViewerMsg of Viewer.Types.Msg
