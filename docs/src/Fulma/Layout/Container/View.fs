module Layouts.Container.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Layouts

let basic =
    Container.container [ Container.IsFluid ]
        [ Content.content [ ]
            [ h1 [ ] [str "Hello World"]
              p [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                      , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                      , sollicitudin vel erat vel, interdum mattis neque." ] ] ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        ""
                        (Viewer.View.root basic model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.contentFromMarkdown
                        """
### Properties

A container can have the following properties:

- `Container.isFluid`
- `Container.isWideScreen`
- `Container.isFullHD`
                        """ ]
