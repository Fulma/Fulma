module Layouts.Hero.State

open Elmish
open Types

let iconCode =
    """
```fsharp
    Hero.hero [ ]
        [ Hero.body [ ]
            [ Container.container [ Container.isFluid ]
                [ Heading.h1 [ ]
                    [ str "Header" ]
                  Heading.h2 [ Heading.isSubtitle ]
                    [ str "Subtitle" ] ] ] ]
```
    """

let centered =
    """
```fsharp
    Hero.hero [ Hero.isSuccess
                Hero.isMedium ]
        [ Hero.head [ ]
            [ Tabs.tabs [ Tabs.isBoxed
                          Tabs.isCentered ]
                [ Tabs.tab [ Tabs.Tab.isActive ]
                    [ a [ ] [ str "Fable" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Elmish" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Bulma" ] ]
                  Tabs.tab [ ]
                    [ a [ ] [ str "Hink" ] ] ] ]
          Hero.body [ ]
            [ Container.container [ Container.isFluid
                                    Container.customClass Bulma.Properties.Alignment.HasTextCentered ]
                [ Heading.h1 [ ]
                    [ str "Header" ]
                  Heading.h2 [ Heading.isSubtitle ]
                    [ str "Subtitle" ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Hero

*[Bulma documentation](http://bulma.io/documentation/layout/hero/)*
        """
      BoxViewer = Viewer.State.init iconCode
      CenteredViewer = Viewer.State.init centered }

let update msg model =
    match msg with
    | BoxViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BoxViewer
        { model with BoxViewer = viewer }, Cmd.map BoxViewerMsg viewerMsg

    | CenteredViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.CenteredViewer
        { model with CenteredViewer = viewer }, Cmd.map CenteredViewerMsg viewerMsg
