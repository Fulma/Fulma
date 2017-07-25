module Elements.Delete.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements

let demoInteractive =
    div [ ClassName "block" ]
        [ Delete.delete
            [ Delete.isSmall ] [ ]
          Delete.delete
            [ ] [ ]
          Delete.delete
            [ Delete.isMedium ] [ ]
          Delete.delete
            [ Delete.isLarge ] [ ] ]

let extraInteractive model dispatch =
    div [ ClassName "block" ]
        [ yield Delete.delete
                    [ Delete.onClick (fun _ -> Click |> dispatch) ] [ ]
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
