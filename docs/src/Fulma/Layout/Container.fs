module Layouts.Container

open Fable.Core
open Fable.Core.JsInterop
open Fable.React
open Fable.React.Props
open Fulma

let basic () =
    Container.container [ Container.IsFluid ]
        [ Content.content [ ]
            [ h1 [ ] [ str "Hello World"]
              p [ ]
                [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                      Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                      , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                      , sollicitudin vel erat vel, interdum mattis neque." ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Container

*[Bulma documentation](http://bulma.io/documentation/layout/container/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.contentFromMarkdown
                        """
### Properties

A container can have the following properties:

- `Container.IsFluid`
- `Container.IsWideScreen`
- `Container.IsFullHD`
                        """ ]
