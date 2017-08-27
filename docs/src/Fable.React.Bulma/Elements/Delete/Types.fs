module Elements.Delete.Types

type Model =
    { Intro : string
      DemoViewer : Viewer.Types.Model
      ExtraViewer : Viewer.Types.Model
      Clicked : bool }

type Msg =
    | DemoViewerMsg of Viewer.Types.Msg
    | ExtraViewerMsg of Viewer.Types.Msg
    | Click
