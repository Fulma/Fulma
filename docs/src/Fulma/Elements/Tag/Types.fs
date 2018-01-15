module Elements.Tag.Types

type Model =
    { Intro : string
      ColorViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model
      NestedDeleteViewer : Viewer.Types.Model
      ListViewer : Viewer.Types.Model }

type Msg =
    | ColorViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
    | NestedDeleteViewerMsg of Viewer.Types.Msg
    | ListViewerMsg of Viewer.Types.Msg
