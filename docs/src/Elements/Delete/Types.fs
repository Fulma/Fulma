module Elements.Delete.Types

type Model =
    { Intro : string
      DemoViewer : Viewer.Types.Model }

type Msg =
    | DemoViewerMsg of Viewer.Types.Msg
