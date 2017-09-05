module Components.Modal.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Elements.Form
open Fulma.Components

let content =
    Content.content [ ]
        [ h1 [ ] [str "Hello World"]
          p [ ]
            [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                  Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                  , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                  , sollicitudin vel erat vel, interdum mattis neque." ]
          h2 [ ] [str "Second level" ]
          p [ ]
            [ str "Curabitur accumsan turpis pharetra "
              strong [ ] [str "augue tincidunt" ]
              str "blandit. Quisque condimentum maximus mi
                  , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                  Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                  Donec at dignissim dui. Ut et neque nisl." ]
          ul [ ]
             [ li [ ] [str "In fermentum leo eu lectus mollis, quis dictum mi aliquet." ]
               li [ ] [str "Morbi eu nulla lobortis, lobortis est in, fringilla felis." ]
               li [ ] [str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus." ]
               li [ ] [str "Ut non enim metus."] ]
          p [ ] [str "Sed sagittis enim ac tortor maximus rutrum.
                     Nulla facilisi. Donec mattis vulputate risus in luctus.
                     Maecenas vestibulum interdum commodo." ] ]

let basicModal model dispatch =
    Modal.modal [ if model.ShowBasicModal then
                    yield Modal.isActive ]
        [ Modal.background [ Modal.Background.props [ OnClick (fun _ -> dispatch ToggleBasicModal) ] ] [ ]
          Modal.content [ ]
            [ Box.box' [ ]
                [ content ] ]
          Modal.close [ Modal.Close.isLarge
                        Modal.Close.onClick (fun _ -> dispatch ToggleBasicModal) ] [ ] ]

let basic dispatch =
    Button.button [ Button.onClick (fun _ -> dispatch ToggleBasicModal)]
        [ str "Show modal" ]

let cardModal model dispatch =
    Modal.modal [ if model.ShowCardModal then
                    yield Modal.isActive ]
        [ Modal.background [ Modal.Background.props [ OnClick (fun _ -> dispatch ToggleCardModal) ] ] [ ]
          Modal.Card.card [ ]
            [ Modal.Card.head [ ]
                [ Modal.Card.title [ ]
                    [ str "Modal title" ]
                  Delete.delete [ Delete.onClick (fun _ -> dispatch ToggleCardModal ) ] [ ] ]
              Modal.Card.body [ ]
                [ content ]
              Modal.Card.foot [ ]
                [ Button.button [ Button.isSuccess ]
                    [ str "Save changes" ]
                  Button.button [ ]
                    [ str "Cancel" ] ] ] ]

let card dispatch =
    Button.button [ Button.onClick (fun _ -> dispatch ToggleCardModal)]
        [ str "Show modal" ]

let root model dispatch =
    Render.docPage [ basicModal model dispatch
                     cardModal model dispatch
                     Render.contentFromMarkdown model.Intro
                     Render.docSection
                        "### Any content"
                        (Viewer.View.root (basic dispatch) model.BasicViewer (BasicViewerMsg >> dispatch))
                     Render.docSection
                        "### Card modal"
                        (Viewer.View.root (card dispatch) model.CardViewer (CardViewerMsg >> dispatch)) ]
