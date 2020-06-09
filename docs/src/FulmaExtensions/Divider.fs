module FulmaExtensions.Divider

open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Extensions.Wikiki

let basicInteractive () =
    div [ ]
        [ Text.div [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
              [ Heading.h1 [ ]
                    [ str "Top" ] ]
          Divider.divider [ ]
          Text.div [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
              [ Heading.h1 [ ]
                    [ str "Middle" ] ]
          Divider.divider [ Divider.Label "OR" ]
          Text.div [ Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
              [ Heading.h1 [ ]
                    [ str "Bottom" ] ] ]

let verticalInteractive () =
     Columns.columns [ ]
        [ Column.column [ Column.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
              [ Heading.h1 [ ]
                    [ str "Left"] ]
          Column.column [ ]
              [ Divider.divider [ Divider.Label "OR"
                                  Divider.IsVertical ] ]
          Column.column [ Column.Modifiers [ Modifier.TextAlignment (Screen.All, TextAlignment.Centered) ] ]
              [ Heading.h1 [ ]
                    [ str "Right" ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Divider

Display a vertical or horizontal divider to segment your design.

*[Documentation](https://wikiki.github.io/layout/divider/)*

### Installation

- `paket add Fulma.Extensions.Wikiki.Divider --project <your project>`
- Follow instructions from `dotnet femto yourProject.fsproj` - [Femto documentation](https://github.com/Zaid-Ajaj/Femto/)
                        """
                     Render.docSection
                         "### Default divider"
                         (Widgets.Showcase.view basicInteractive (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                         "### Vertical divider"
                         (Widgets.Showcase.view verticalInteractive (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
