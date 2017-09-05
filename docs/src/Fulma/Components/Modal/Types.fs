module Components.Modal.Types

type Model =
    { Intro : string
      BasicViewer : Viewer.Types.Model
      CardViewer : Viewer.Types.Model
      ShowBasicModal : bool
      ShowCardModal : bool }

type Msg =
    | BasicViewerMsg of Viewer.Types.Msg
    | CardViewerMsg of Viewer.Types.Msg
    | ToggleBasicModal
    | ToggleCardModal
