module Components.Modal.State

open Elmish
open Types

let basic =
    """
```fsharp
    Modal.modal [ if model.ShowBasicModal then
                    yield Modal.isActive ]
        [ Modal.background [ Modal.Background.props [ OnClick (fun _ -> dispatch ToggleBasicModal) ] ] [ ]
          Modal.content [ ]
            [ Box.box' [ ]
                [ content ] ]
          Modal.close [ Modal.Close.isLarge
                        Modal.Close.onClick (fun _ -> dispatch ToggleBasicModal) ] [ ] ]
```
    """

let card =
    """
```fsharp
    Modal.modal [ if model.ShowCardModal then
                    yield Modal.isActive ]
        [ Modal.background [ Modal.Background.props [ OnClick (fun _ -> dispatch ToggleCardModal) ] ] [ ]
          Modal.Card.card [ ]
            [ Modal.Card.head [ ]
                [ Modal.Card.title [ ]
                    [ str "Modal title" ]
                  Delete.delete [ Delete.onClick (fun _ -> dispatch ToggleCardModal ) ] [ ] ]
              Modal.Card.body [ ]
                [ content ]
              Modal.Card.foot [ ]
                [ Button.button_div [ Button.isSuccess ]
                    [ str "Save changes" ]
                  Button.button_div [ ]
                    [ str "Cancel" ] ] ] ]
```
    """

let init() =
    { Intro =
        """
# Modal

*[Bulma documentation](http://bulma.io/documentation/components/modal/)*
        """
      BasicViewer = Viewer.State.init basic
      CardViewer = Viewer.State.init card
      ShowBasicModal = false
      ShowCardModal = false }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg

    | CardViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.CardViewer
        { model with CardViewer = viewer }, Cmd.map CardViewerMsg viewerMsg

    | ToggleBasicModal ->
        { model with ShowBasicModal = not model.ShowBasicModal }, Cmd.none

    | ToggleCardModal ->
        { model with ShowCardModal = not model.ShowCardModal }, Cmd.none
