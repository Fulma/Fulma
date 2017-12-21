module Elements.Table.Types

type Model =
    { Intro : string
      SimpleViewer : Viewer.Types.Model
      ModifierViewer : Viewer.Types.Model
      ModifierFullWidth : Viewer.Types.Model
    }

type Msg =
    | SimpleViewerMsg of Viewer.Types.Msg
    | ModifierViewerMsg of Viewer.Types.Msg
    | ModifierFullWidthMsg of Viewer.Types.Msg
