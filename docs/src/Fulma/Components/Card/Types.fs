module Components.Card.Types

type Model =
    { Intro : string
      BasicViewer : Viewer.Types.Model
      CenteredViewer : Viewer.Types.Model }

type Msg =
    | BasicViewerMsg of Viewer.Types.Msg
    | CenteredViewerMsg of Viewer.Types.Msg
