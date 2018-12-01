module Elements.Box

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma


let basic () =
    div [ ClassName "block" ]
        [ Box.box' [ ]
            [ str "Lorem ipsum dolor sit amet, consectetur adipisicing elit
                   , sed do eiusmod tempor incididunt ut labore et dolore magna aliqua."] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Box

A white **box** to contain other elements .

*[Bulma documentation](http://bulma.io/documentation/elements/box/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
