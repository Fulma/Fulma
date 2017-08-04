module Components.Message.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Elements.Form
open Elmish.Bulma.Components

let loremText =
    "Donec fermentum interdum elit, in congue justo maximus congue. Mauris tincidunt ultricies lacus, vel pulvinar diam luctus et. In vel tellus vitae dolor efficitur pulvinar eu non tortor. Nunc eget augue id nisl bibendum congue vitae vitae purus. Phasellus pharetra nunc at justo dictum rutrum. Nullam diam diam, tincidunt id interdum a, rutrum ac lorem."

let basic =
    Message.message [ ]
        [ Message.header [ ]
            [ str "Nunc finibus ligula et semper suscipit"
              Delete.delete [ ]
                [ ] ]
          Message.body [ ]
            [ str loremText ] ]

let color =
    div [ ]
        [ Message.message [ Message.isInfo ]
            [ Message.header [ ]
                [ str "Nunc finibus ligula et semper suscipit"
                  Delete.delete [ ]
                    [ ] ]
              Message.body [ ]
                [ str loremText ] ]
          Message.message [ Message.isDanger ]
            [ Message.header [ ]
                [ str "Nunc finibus ligula et semper suscipit"
                  Delete.delete [ ]
                    [ ] ]
              Message.body [ ]
                [ str loremText ] ] ]

let sizes =
    Message.message [ Message.isSmall ]
        [ Message.header [ ]
            [ str "Nunc finibus ligula et semper suscipit"
              Delete.delete [ ]
                [ ] ]
          Message.body [ ]
            [ str loremText ] ]

let bodyOnly =
    Message.message [ ]
        [ Message.body [ ]
            [ str loremText ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.docSection
                        "### Colors"
                        (Viewer.View.root color model.ColorViewer (ColorViewerMsg >> dispatch))
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root sizes model.SizeViewer (SizeViewerMsg >> dispatch))
                     Render.docSection
                        "### Body only"
                        (Viewer.View.root bodyOnly model.BodyOnlyViewer (BodyOnlyViewerMsg >> dispatch)) ]
