module Elements.Delete.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Elements

let demoInteractive =
    div [ ClassName "block" ]
        [ Delete.delete
            [ Delete.Size IsSmall ] [ ]
          Delete.delete
            [ ] [ ]
          Delete.delete
            [ Delete.Size IsMedium ] [ ]
          Delete.delete
            [ Delete.Size IsLarge ] [ ] ]

let extraInteractive model dispatch =
    div [ ClassName "block" ]
        [ yield Delete.delete
                    [ Delete.OnClick (fun _ -> Click |> dispatch) ] [ ]
          if model.Clicked then
            yield br []
            yield str "You clicked the delete button" ]

let root model dispatch =
    Render.docPage [ Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Sizes"
                        (Viewer.View.root demoInteractive model.DemoViewer (DemoViewerMsg >> dispatch))
                     Render.docSection
                        """
### Extra

You can also attach any props to delete elements. Try clicking on the next button.
                        """
                        (Viewer.View.root (extraInteractive model dispatch) model.ExtraViewer (ExtraViewerMsg >> dispatch)) ]
