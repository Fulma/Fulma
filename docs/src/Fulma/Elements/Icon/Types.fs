module Elements.Icon.Types

type Model =
    { Intro                 : string
      IconViewer            : Viewer.Types.Model
      ConvenienceViewer     : Viewer.Types.Model
      BorderPulledViewer    : Viewer.Types.Model
      RotationFlipViewer    : Viewer.Types.Model
      AnimationViewer       : Viewer.Types.Model
      IconListViewer        : Viewer.Types.Model
      StackedIconViewer     : Viewer.Types.Model
      ComposeButtonViewer   : Viewer.Types.Model
    }

type Msg =
    | IconViewerMsg             of Viewer.Types.Msg
    | ConvenienceViewerMsg      of Viewer.Types.Msg
    | BorderPulledViewerMsg     of Viewer.Types.Msg
    | RotationFlipViewerMsg     of Viewer.Types.Msg
    | AnimationViewerMsg        of Viewer.Types.Msg
    | IconListViewerMsg         of Viewer.Types.Msg
    | StackedIconViewerMsg      of Viewer.Types.Msg
    | ComposeButtonViewerMsg    of Viewer.Types.Msg
