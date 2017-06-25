module Elements.Title.State

open Elmish
open Types

let typeCode =
    """
```fsharp
    Heading.h1 [ Heading.isTitle ]
        [ str "Title" ]
    Heading.h2 [ Heading.isSubtitle ]
        [ str "Subtitle" ]
```
    """

let sizeCode =
    """
```fsharp
Heading.h1 [ Heading.isTitle ]
    [ str "Title 1" ]
Heading.h2 [ Heading.isTitle ]
    [ str "Title 2" ]
Heading.h3 [ Heading.isTitle ]
    [ str "Title 3" ]
Heading.h4 [ Heading.isTitle ]
    [ str "Title 3" ]
Heading.h5 [ Heading.isTitle ]
    [ str "Title 5" ]
Heading.h6 [ Heading.isTitle ]
    [ str "Title 6" ]
Heading.h1 [ Heading.isSubtitle ]
    [ str "Subtitle 1" ]
Heading.h2 [ Heading.isSubtitle ]
    [ str "Subtitle 2" ]
Heading.h3 [ Heading.isSubtitle ]
    [ str "Subtitle 3" ]
Heading.h4 [ Heading.isSubtitle ]
    [ str "Subtitle 4" ]
Heading.h5 [ Heading.isSubtitle ]
    [ str "Subtitle 5" ]
Heading.h6 [ Heading.isSubtitle ]
    [ str "Subtitle 6" ]
```
    """

let init() =
    { Intro =
        """
# Title

*[Bulma documentation](http://bulma.io/documentation/elements/title/)*
        """
      TypeViewer = Viewer.State.init typeCode
      SizeViewer = Viewer.State.init sizeCode }

let update msg model =
    match msg with
    | TypeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.TypeViewer
        { model with TypeViewer = viewer }, Cmd.map TypeViewerMsg viewerMsg

    | SizeViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.SizeViewer
        { model with SizeViewer = viewer }, Cmd.map SizeViewerMsg viewerMsg
