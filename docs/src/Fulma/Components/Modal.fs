module Components.Modal

open Fable.React
open Fable.React.Props
open Fulma
open Fable.Core
open Fable.Import

let content =
    Content.content [ ]
        [ h1 [ ]
            [ str "Hello World"]
          p [ ]
            [ str "Lorem ipsum dolor sit amet, consectetur adipiscing elit.
                  Nulla accumsan, metus ultrices eleifend gravida, nulla nunc varius lectus
                  , nec rutrum justo nibh eu lectus. Ut vulputate semper dui. Fusce erat odio
                  , sollicitudin vel erat vel, interdum mattis neque." ]
          h2 [ ]
            [ str "Second level" ]
          p [ ]
            [ str "Curabitur accumsan turpis pharetra "
              strong [ ]
                [ str "augue tincidunt" ]
              str "blandit. Quisque condimentum maximus mi
                  , sit amet commodo arcu rutrum id. Proin pretium urna vel cursus venenatis.
                  Suspendisse potenti. Etiam mattis sem rhoncus lacus dapibus facilisis.
                  Donec at dignissim dui. Ut et neque nisl." ]
          ul [ ]
             [ li [ ]
                  [ str "In fermentum leo eu lectus mollis, quis dictum mi aliquet." ]
               li [ ]
                  [ str "Morbi eu nulla lobortis, lobortis est in, fringilla felis." ]
               li [ ]
                  [ str "Aliquam nec felis in sapien venenatis viverra fermentum nec lectus." ]
               li [ ]
                  [ str "Ut non enim metus."] ]
          p [ ]
            [ str "Sed sagittis enim ac tortor maximus rutrum.
                     Nulla facilisi. Donec mattis vulputate risus in luctus.
                     Maecenas vestibulum interdum commodo." ] ]

type BasicModalProps =
    interface end

type BasicModalState =
    { IsShown : bool }

type BasicModal(props) =
    inherit Component<BasicModalProps, BasicModalState>(props)
    do base.setInitState({ IsShown = false })

    member this.toggleDisplay _ =
        this.setState (fun prevState _ ->
            { prevState with IsShown = not prevState.IsShown}
        )

    override this.render () =
        // Render the modal
        let basicModal isActive closeDisplay =
            Modal.modal [ Modal.IsActive isActive ]
                [ Modal.background [ Props [ OnClick closeDisplay ] ] [ ]
                  Modal.content [ ]
                    [ Box.box' [ ]
                        [ content ] ]
                  Modal.close [ Modal.Close.Size IsLarge
                                Modal.Close.OnClick closeDisplay ] [ ] ]
        // Control elments of the UI
        div [ ]
            [ basicModal this.state.IsShown this.toggleDisplay
              Button.button [ Button.OnClick this.toggleDisplay ]
                [ str "Show modal" ] ]

type CardModalProps =
    interface end

type CardModalState =
    { IsShown : bool }

type CardModal(props) =
    inherit Component<CardModalProps, CardModalState>(props)
    do base.setInitState({ IsShown = false })

    member this.toggleDisplay _ =
        this.setState (fun prevState _ ->
            { prevState with IsShown = not prevState.IsShown}
        )

    override this.render () =
        // Render the modal
        let cardModal isActive closeDisplay =
            Modal.modal [ Modal.IsActive isActive ]
                [ Modal.background [ Props [ OnClick closeDisplay ] ] [ ]
                  Modal.Card.card [ ]
                    [ Modal.Card.head [ ]
                        [ Modal.Card.title [ ]
                            [ str "Modal title" ]
                          Delete.delete [ Delete.OnClick closeDisplay ] [ ] ]
                      Modal.Card.body [ ]
                        [ content ]
                      Modal.Card.foot [ ]
                        [ Button.button [ Button.Color IsSuccess ]
                            [ str "Save changes" ]
                          Button.button [ ]
                            [ str "Cancel" ] ] ] ]
        // Control elments of the UI
        div [ ]
            [ cardModal this.state.IsShown this.toggleDisplay
              Button.button [ Button.OnClick this.toggleDisplay ]
                [ str "Show card modal" ] ]

let view =
    Render.docPage [ //basicModal model dispatch
                     //cardModal model dispatch
                     Render.contentFromMarkdown
                        """
# Modal

*[Bulma documentation](http://bulma.io/documentation/components/modal/)*
                        """
                     Render.docSection
                        "### Any content"
                        (Widgets.Showcase.view (fun _ -> ofType<BasicModal,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.docSection
                        "### Card modal"
                        (Widgets.Showcase.view (fun _ -> ofType<CardModal,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__)) ]
