module Elements.Button.Types

type Model =
    { Intro : string
      ColorViewer : Viewer.Types.Model }

type Msg =
    | ColorViewer of Viewer.Types.Msg
