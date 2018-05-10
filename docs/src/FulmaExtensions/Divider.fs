module FulmaExtensions.Divider

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Extensions

let basicInteractive () =
    div [ ]
        [ div [ ClassName TextAlignment.Classes.HasTextCentered ]
              [ Heading.h1 [ ] [ str "Top" ] ]
          Divider.divider [ ]
          div [ ClassName TextAlignment.Classes.HasTextCentered ]
              [ Heading.h1 [ ] [ str "Middle" ] ]
          Divider.divider [ Divider.Label "OR" ]
          div [ ClassName TextAlignment.Classes.HasTextCentered ]
              [ Heading.h1 [ ] [ str "Bottom" ] ] ]

let verticalInteractive () =
     Columns.columns [ ]
        [ Column.column [ Column.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ]  ]
              [ Heading.h1 [ ] [str "Left"] ]
          Column.column [ ]
              [ Divider.divider [ Divider.Label "OR"
                                  Divider.IsVertical ] ]
          Column.column [ Column.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ]  ]
              [ Heading.h1 [ ] [ str "Right" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Divider

Display a vertical or horizontal divider to segment your design.

*[Documentation](https://wikiki.github.io/layout/divider/)*

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
            <td>`yarn add bulma bulma-divider@0.1.0`</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                         "### Default divider"
                         (Widgets.Showcase.view basicInteractive (Render.getViewSource basicInteractive))
                     Render.docSection
                         "### Vertical divider"
                         (Widgets.Showcase.view verticalInteractive (Render.getViewSource verticalInteractive)) ]
