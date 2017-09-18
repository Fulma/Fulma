module FulmaExtensions.Divider.State

open Elmish
open Types

let normalCode =
    """
```fsharp
    div [ ClassName Bulma.Properties.Alignment.HasTextCentered ]
        [ Heading.h1 [ ] [ str "Top" ] ]
    Divider.divider [ ] [ ]
    div [ ClassName Bulma.Properties.Alignment.HasTextCentered ]
        [ Heading.h1 [ ] [ str "Middle" ] ]
    Divider.divider [ Divider.label "OR" ] [ ]
    div [ ClassName Bulma.Properties.Alignment.HasTextCentered ]
        [ Heading.h1 [ ] [ str "Bottom" ] ]
```
    """

let verticalCode =
    """
```fsharp
Columns.columns [ ]
    [ Column.column [ Column.customClass Bulma.Properties.Alignment.HasTextCentered ]
          [ Heading.h1 [ ] [str "Left"] ]
      Column.column [ ]
          [ Divider.divider [ Divider.label "OR"
                              Divider.IsVertical ] [ ] ]
      Column.column [ Column.customClass Bulma.Properties.Alignment.HasTextCentered ]
          [ Heading.h1 [ ] [ str "Right" ] ] ]
```
    """

let intro =
        """
# Divider

Display a vertical or horizontal divider to segment your design.

*[Documentation](https://wikiki.github.io/bulma-extensions/divider)*

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
            <td>`yarn add bulma bulma-divider`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-divider@0.0.1`</td>
        </tr>
    </tbody>
<table>
        """

let init() =
    { NormalViewer = Viewer.State.init normalCode
      VerticalViewer = Viewer.State.init verticalCode
      Intro = intro }

let update msg model =
    match msg with
    | NormalViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.NormalViewer
        { model with NormalViewer = viewer }, Cmd.map NormalViewerMsg viewerMsg

    | VerticalViewerMsg msg ->
        let (viewer, viewerMsg) = Viewer.State.update msg model.VerticalViewer
        { model with VerticalViewer = viewer }, Cmd.map VerticalViewerMsg viewerMsg
