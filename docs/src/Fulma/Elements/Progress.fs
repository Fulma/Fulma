module Elements.Progress

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

let colorInteractive () =
    div [ ClassName "block" ]
        [ Progress.progress
            [ Progress.Value 15
              Progress.Max 100 ] [ str "15%" ]
          Progress.progress
            [ Progress.Color IsSuccess
              Progress.Value 30
              Progress.Max 100 ] [ str "30%" ]
          Progress.progress
            [ Progress.Color IsInfo
              Progress.Value 45
              Progress.Max 100 ] [ str "45%" ]
          Progress.progress
            [ Progress.Color IsWarning
              Progress.Value 60
              Progress.Max 100 ] [ str "60%" ]
          Progress.progress
            [ Progress.Color IsPrimary
              Progress.Value 75
              Progress.Max 100 ] [ str "75%" ]
          Progress.progress
            [ Progress.Color IsDanger
              Progress.Value 90
              Progress.Max 100 ] [ str "90%" ] ]

let sizeInteractive () =
    div [ ClassName "block" ]
        [ Progress.progress
            [ Progress.Size IsSmall
              Progress.Value 15
              Progress.Max 100 ] [ str "15%" ]
          Progress.progress
            [ Progress.Value 30
              Progress.Max 100 ] [ str "30%" ]
          Progress.progress
            [ Progress.Size IsMedium
              Progress.Value 45
              Progress.Max 100 ] [ str "45%" ]
          Progress.progress
            [ Progress.Size IsLarge
              Progress.Value 60
              Progress.Max 100 ] [ str "60%" ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Progress

The **progress** element can have different colors and sizes.

*[Bulma documentation](http://bulma.io/documentation/elements/progress/)*
                        """
                     Render.docSection
                        "### Colors"
                        (Widgets.Showcase.view colorInteractive (Render.getViewSource colorInteractive))
                     Render.docSection
                        "### Sizes"
                        (Widgets.Showcase.view sizeInteractive (Render.getViewSource sizeInteractive)) ]
