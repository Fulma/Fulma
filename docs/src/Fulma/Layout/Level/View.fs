module Layouts.Level.View

open Fable.Helpers.React
open Types
open Fulma
open Fulma.Layouts
open Fulma.Elements.Form
open Fulma.Elements

let iconInteractive =
    Level.level [ ]
        [ Level.left [ ]
            [ Level.item [ ]
                [ Heading.h5 [ Heading.IsSubtitle ]
                    [ strong [ ] [ str "123"]
                      str " posts" ] ]
              Level.item [ ]
                [ Field.field [ Field.HasAddons ]
                    [ Control.control [ ]
                        [ Input.text [ Input.Placeholder "Find a post" ] ]
                      Control.control [ ]
                        [ Button.button [ ]
                            [ str "Search" ] ] ] ] ]
          Level.right [ ]
            [ Level.item [ ]
                [ a [ ] [ str "All" ] ]
              Level.item [ ]
                [ a [ ] [ str "Published" ] ]
              Level.item [ ]
                [ a [ ] [ str "Drafts" ] ]
              Level.item [ ]
                [ a [ ] [ str "Deleted" ] ]
              Level.item [ ]
                [ Button.button [ Button.Color IsSuccess ] [ str "New" ] ] ] ]

let centered =
    Level.level [ ]
        [ Level.item [ Level.Item.HasTextCentered ]
            [ div [ ]
                [ Level.heading [ ] [ str "Stars" ]
                  Level.title [ ] [ str "1,010" ] ] ]
          Level.item [ Level.Item.HasTextCentered ]
            [ div [ ]
                [ Level.heading [ ] [ str "Forks" ]
                  Level.title [ ] [ str "127" ] ] ]
          Level.item [ Level.Item.HasTextCentered ]
            [ div [ ]
                [ Level.heading [ ] [ str "Watchers" ]
                  Level.title [ ] [ str "66" ] ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root iconInteractive model.BoxViewer (BoxViewerMsg >> dispatch))
                     Render.docSection
                        "### Centered level"
                        (Viewer.View.root centered model.CenteredViewer (CenteredViewerMsg >> dispatch)) ]
