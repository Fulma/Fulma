module FulmaExtensions.Tooltip.State

open Elmish
open Types

let iconCode =
    """
```fsharp
    Button.button [ Button.props [ Tooltip.dataTooltip "Top tooltip" ]
                    Button.customClass Tooltip.ClassName ]
        [ str "Top tooltip" ]
    Button.button [ Button.props [ Tooltip.dataTooltip "Left tooltip" ]
                    Button.customClass (Tooltip.ClassName ++ Tooltip.IsTooltipLeft) ]
        [ str "Left tooltip" ]
    Button.button [ Button.props [ Tooltip.dataTooltip "Right tooltip" ]
                    Button.customClass (Tooltip.ClassName ++ Tooltip.IsTooltipRight) ]
        [ str "Right tooltip" ]
    Button.button [ Button.props [ Tooltip.dataTooltip "Bottom tooltip" ]
                    Button.customClass (Tooltip.ClassName ++ Tooltip.IsTooltipBottom) ]
        [ str "Bottom tooltip" ]
```
    """

let init() =
    { Intro =
        """
# Tooltip

Display a **tooltip** attached to any kind of element, in different position.

*[Documentation](https://wikiki.github.io/bulma-extensions/tooltip)*

## Npm packages

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Version</th>
            <th>CLI</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>`yarn add bulma bulma-tooltip`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-tooltip@0.0.4`</td>
        </tr>
    </tbody>
<table>
        """
      BasicViewer = Viewer.State.init iconCode }

let update msg model =
    match msg with
    | BasicViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.BasicViewer
        { model with BasicViewer = viewer }, Cmd.map BasicViewerMsg viewerMsg
