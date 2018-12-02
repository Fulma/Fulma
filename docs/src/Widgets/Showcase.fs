module Widgets.Showcase

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma

module CopyButton =

    open Fable.Core.JsInterop

    type Props =
        | Value of string

    let inline copyButtton (props: Props list) : React.ReactElement =
        ofImport "default" "./../../js/CopyButton.js" (keyValueList CaseRules.LowerFirst props) []

type ShowcaseProps =
    { Preview : unit -> React.ReactElement
      SourceCode : string }

type ShowcaseState =
    { IsExpanded : bool }

type Showcase(props) =
    inherit React.Component<ShowcaseProps, ShowcaseState>(props)
    do base.setInitState({ IsExpanded = false })

    member this.toggleArea _ =
        this.setState(fun prevState _ ->
            { prevState with IsExpanded = not prevState.IsExpanded}
        )

    override this.render () =
        let footerItemIcon  =
            let footerIconClass =
                match this.state.IsExpanded with
                | true -> ClassName "fa fa-angle-up"
                | false -> ClassName "fa fa-angle-down"

            Card.Footer.a [ ]
                    [ Icon.icon [ ]
                        [ i [ footerIconClass ] [ ] ] ]

        let footerItemText =
            match this.state.IsExpanded with
            | true -> Card.Footer.a [ ] [ str "Hide code" ]
            | false -> Card.Footer.a [ ] [ str "View code" ]

        Card.card [ ]
            [ yield Card.content [ ] [ this.props.Preview () ]
              yield Card.footer
                [ Common.Props [ OnClick this.toggleArea ] ]
                [ footerItemIcon
                  footerItemText
                  footerItemIcon ]
              if this.state.IsExpanded then
                yield Box.box' [ Props [ Style [ Position "relative"
                                                 BorderRadius "0"
                                                 MaxHeight "400px"
                                                 Overflow "auto" ] ] ]
                    [ CopyButton.copyButtton [ CopyButton.Value this.props.SourceCode ]
                      Render.renderFSharpCode this.props.SourceCode ]
            ]

let inline view preview sourceCode =
    ofType<Showcase,_,_>
        { Preview = preview
          SourceCode = sourceCode }
        [ ]
