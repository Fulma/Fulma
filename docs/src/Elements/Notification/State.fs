module Elements.Notification.State

open Elmish
open Types

let basic =
    """
```fsharp
    Notification.notification [ ]
        [ str "I am a notification" ]
```
    """

let color =
    """
```fsharp
    Notification.notification [ Notification.isSuccess ]
        [ str "I am a notification with some colors" ]
```
    """

let delete =
    """
```fsharp
    Notification.notification [ Notification.isDanger ]
        [ Notification.delete [ ] [ ]
          str "I am a notification with some colors and a delete button" ]
```
    """

let init() =
    { Intro =
        """
# Notification

*[Bulma documentation](http://bulma.io/documentation/elements/notification/)*
        """
      BasicViewer = Viewer.State.init basic
      ColorViewer = Viewer.State.init color
      DeleteViewer = Viewer.State.init delete }

open Elmish.Bulma.Elements
open Elmish.Bulma.Extra.Notification
open Fable.Helpers.React

let notificationRoot =
    Notification.notification [ Notification.isSuccess ]
        [ str "I am a global notification"]

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg

    | ColorViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.ColorViewer
        { model with ColorViewer = viewer }, Cmd.map ColorViewerMsg viewerMsg

    | DeleteViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.DeleteViewer
        { model with DeleteViewer = viewer }, Cmd.map DeleteViewerMsg viewerMsg

    | NewGlobalNotification ->
        model, Cmd.newNotification notificationRoot
