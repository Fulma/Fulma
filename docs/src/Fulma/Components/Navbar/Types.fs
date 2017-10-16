module Components.Navbar.Types

type Model =
    { Intro : string
      BasicViewer : Viewer.Types.Model
      ColorViewer : Viewer.Types.Model }

type Msg =
    | BasicViewerMsg of Viewer.Types.Msg
    | ColorViewerMsg of Viewer.Types.Msg
