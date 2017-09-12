module Layouts.Columns.State

open Elmish
open Types

let iconCode =
    """
```fsharp
    Columns.columns [ ]
        [ Column.column [ Column.Width.is6 ]
            [ Columns.columns [ ]
                [ Column.column [ ]
                    [ Notification.notification [ Notification.isSuccess ]
                        [ str "Column n°1" ] ] ]
              Columns.columns [ Columns.isGapless ]
                [ Column.column [ ]
                    [ Notification.notification [ Notification.isInfo ]
                        [ str "Column n°1.1" ] ]
                  Column.column [ ]
                    [ Notification.notification [ Notification.isWarning ]
                        [ str "Column n°1.2" ] ]
                  Column.column [ ]
                    [ Notification.notification [ Notification.isDanger ]
                        [ str "Column n°1.3" ] ] ] ]
          Column.column [ ]
            [ Columns.columns [ ]
                [ Column.column [ ]
                    [ Notification.notification [ Notification.isLight ]
                        [ str "Column n°2" ] ] ]
              Columns.columns [ Columns.isCentered ]
                [ Column.column [ Column.Width.is7 ]
                    [ Notification.notification [ Notification.isBlack ]
                        [ str "Column n°2.1" ] ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Columns

A simple way to build **responsive** columns

*[Bulma documentation](http://bulma.io/documentation/columns/basics/)*
        """
      BoxViewer = Viewer.State.init iconCode }

let update msg model =
    match msg with
    | BoxViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BoxViewer
        { model with BoxViewer = viewer }, Cmd.map BoxViewerMsg viewerMsg
