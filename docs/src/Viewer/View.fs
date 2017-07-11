module Viewer.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Elmish.Bulma.Elements
open Elmish.Bulma.Components

let root interactiveView model dispatch =
    let eventToTrigger =
        match model.IsExpanded with
        | true -> Collapse
        | false -> Expand

    let footerItemIcon  =
        let footerIconClass =
            match model.IsExpanded with
            | true -> ClassName "fa fa-angle-up"
            | false -> ClassName "fa fa-angle-down"

        Card.Footer.item [ ]
                [ Icon.icon [ ]
                    [ i [ footerIconClass ] [ ] ] ]

    let footerItemText =
        match model.IsExpanded with
        | true -> Card.Footer.item [ ] [ str "Hide code" ]
        | false -> Card.Footer.item [ ] [ str "View code" ]

    Card.card [ ]
        [ yield Card.content [ ] [ interactiveView ]
          yield Card.footer
            [ Card.Footer.props [ OnClick (fun _ -> eventToTrigger |> dispatch) ] ]
            [ footerItemIcon
              footerItemText
              footerItemIcon ]
          if model.IsExpanded then
            yield Box.box' [ ] [ Render.contentFromMarkdown model.Code ]
        ]
