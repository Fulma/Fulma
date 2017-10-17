module Elements.Button.Types

type Model =
    { Intro : string
      ColorViewer : Viewer.Types.Model
      DemoHelpersViewer : Viewer.Types.Model
      SizeViewer : Viewer.Types.Model
      OutlinedViewer : Viewer.Types.Model
      MixedStyleViewer : Viewer.Types.Model
      StateViewer : Viewer.Types.Model
      ExtraViewer : Viewer.Types.Model
      ClickCount : int
      StaticViewer : Viewer.Types.Model
      DisabledViewer : Viewer.Types.Model
      IconsViewer : Viewer.Types.Model }

type Msg =
    | ColorViewerMsg of Viewer.Types.Msg
    | DemoHelpersViewerMsg of Viewer.Types.Msg
    | SizeViewerMsg of Viewer.Types.Msg
    | OutlinedViewerMsg of Viewer.Types.Msg
    | MixedStyleViewerMsg of Viewer.Types.Msg
    | StateViewerMsg of Viewer.Types.Msg
    | ExtraViewerMsg of Viewer.Types.Msg
    | Click
    | StaticViewerMsg of Viewer.Types.Msg
    | DisabledViewerMsg of Viewer.Types.Msg
    | IconsViewerMsg of Viewer.Types.Msg
