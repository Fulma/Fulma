module Components.Media

open Fable.React
open Fable.React.Props
open Fulma

let basic () =
    Media.media [ ]
        [ Media.left [ ]
            [ Image.image [ Image.Is64x64 ]
                [ img [ Src "https://dummyimage.com/64x64/7a7a7a/fff" ] ] ]
          Media.content [ ]
            [ Field.div [ ]
                [ Control.div [ ]
                    [ textarea [ ClassName "textarea"
                                 Placeholder "Add a message ..." ]
                               [ ] ] ]
              Level.level [ ]
                [ Level.left [ ]
                    [ Level.item [ ]
                        [ Button.button [ Button.Color IsInfo ]
                            [ str "Submit" ] ] ]
                  Level.right [ ]
                    [ Level.item [ ]
                        [ str "Press Ctrl + Enter to submit" ] ] ] ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Media

*[Bulma documentation](http://bulma.io/documentation/components/media-object/)*
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view basic (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
