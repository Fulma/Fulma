module Elements.Icon.Types

type Model =
    { Intro : string
      IconViewer : Viewer.Types.Model }

type Msg =
    | IconViewerMsg of Viewer.Types.Msg
