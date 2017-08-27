module Elements.Image.State

open Elmish
open Types

let fixedCode =
    """
```fsharp
    Image.image [ Image.is64x64 ]
        [ img [ Src "https://dummyimage.com/64x64/7a7a7a/fff" ] ]
    br [ ]
    Image.image [ Image.is128x128 ]
        [ img [ Src "https://dummyimage.com/128x128/7a7a7a/fff" ] ]
```
    """

let responsiveCode =
    """
```fsharp
    Image.image [ Image.is2by1 ]
        [ img [ Src "https://dummyimage.com/640x320/7a7a7a/fff" ] ]
```
    """

let init() =
    { Intro =
        """
# Images

The **images** can have different sizes (fixed or ratio).

*[Bulma documentation](http://bulma.io/documentation/elements/image/)*
        """
      FixedViewer = Viewer.State.init fixedCode
      ResponsiveViewer = Viewer.State.init responsiveCode }

let update msg model =
    match msg with
    | FixedViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.FixedViewer
        { model with FixedViewer = viewer }, Cmd.map FixedViewerMsg viewerMsg

    | ResponsiveViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ResponsiveViewer
        { model with ResponsiveViewer = viewer }, Cmd.map ResponsiveViewerMsg viewerMsg
