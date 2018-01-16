module Components.Message

open Fable.Helpers.React
open Fulma
open Fulma.Elements
open Fulma.Components

let loremText =
    "Donec fermentum interdum elit, in congue justo maximus congue. Mauris tincidunt ultricies lacus, vel pulvinar diam luctus et. In vel tellus vitae dolor efficitur pulvinar eu non tortor. Nunc eget augue id nisl bibendum congue vitae vitae purus. Phasellus pharetra nunc at justo dictum rutrum. Nullam diam diam, tincidunt id interdum a, rutrum ac lorem."

let basic () =
    Message.message [ ]
        [ Message.header [ ]
            [ str "Nunc finibus ligula et semper suscipit"
              Delete.delete [ ]
                [ ] ]
          Message.body [ ]
            [ str loremText ] ]

let color () =
    div [ ]
        [ Message.message [ Message.Color IsInfo ]
            [ Message.header [ ]
                [ str "Nunc finibus ligula et semper suscipit"
                  Delete.delete [ ]
                    [ ] ]
              Message.body [ ]
                [ str loremText ] ]
          Message.message [ Message.Color IsDanger ]
            [ Message.header [ ]
                [ str "Nunc finibus ligula et semper suscipit"
                  Delete.delete [ ]
                    [ ] ]
              Message.body [ ]
                [ str loremText ] ] ]

let sizes () =
    Message.message [ Message.Size IsSmall ]
        [ Message.header [ ]
            [ str "Nunc finibus ligula et semper suscipit"
              Delete.delete [ ]
                [ ] ]
          Message.body [ ]
            [ str loremText ] ]

let bodyOnly () =
    Message.message [ ]
        [ Message.body [ ]
            [ str loremText ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Message

*[Bulma documentation](http://bulma.io/documentation/components/message/)*
                        """
                     Render.docSection
                        ""
                        (Showcase.view basic (Render.getViewSource basic))
                     Render.docSection
                        "### Colors"
                        (Showcase.view color (Render.getViewSource color))
                     Render.docSection
                        "### Sizes"
                        (Showcase.view sizes (Render.getViewSource sizes))
                     Render.docSection
                        "### Body only"
                        (Showcase.view bodyOnly (Render.getViewSource bodyOnly)) ]
