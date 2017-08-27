module Elements.Progress.Types

type Model =
    { Intro : string
      ColorViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model
      Clicked : bool }

type Msg =
    | ColorViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
    | Click
