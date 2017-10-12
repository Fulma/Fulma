module Components.Panel.State

open Elmish
open Types

let iconCode =
    """
```fsharp
  Panel.panel [ ]
    [ Panel.heading [ ] [ str "Repositories"]
      Panel.block [ ]
        [ Control.control_div [ Control.hasIconLeft ]
            [ Input.input [ Input.isSmall
                            Input.typeIsText
                            Input.placeholder "Search" ]
              Icon.icon [ Icon.isSmall
                          Icon.isLeft ]
                        [ i [ ClassName "fa fa-search" ] [ ] ] ] ]
      Panel.tabs [ ]
        [ Panel.tab [ ] [ str "All" ]
          Panel.tab [ Panel.Tab.isActive ] [ str "Fable" ]
          Panel.tab [ ] [ str "Elmish" ]
          Panel.tab [ ] [ str "Bulma" ] ]
      Panel.block [ Panel.Block.isActive ]
        [ Panel.icon [ ] [ i [ ClassName "fa fa-book" ] [ ] ]
          str "Bulma" ]
      Panel.block [ ]
        [ Panel.icon [ ] [ i [ ClassName "fa fa-code-fork" ] [ ] ]
          str "Fable" ]
      Panel.checkbox [ ]
        [ input [ Type "checkbox" ]
          str "I am a checkbox" ]
      Panel.block [ ]
        [ Button.button [ Button.isPrimary
                          Button.isOutlined
                          Button.isFullWidth ]
                        [ str "Reset" ] ] ]
```
    """

let init() =
    { Intro =
        """
# Panel

A composable **panel**, for compact controls

*[Bulma documentation](http://bulma.io/documentation/components/panel/)*
        """
      PanelViewer = Viewer.State.init iconCode }

let update msg model =
    match msg with
    | PanelViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.PanelViewer
        { model with PanelViewer = viewer }, Cmd.map PanelViewerMsg viewerMsg
