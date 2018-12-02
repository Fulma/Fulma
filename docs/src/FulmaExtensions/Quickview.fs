module FulmaExtensions.Quickview

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fulma
open Fulma.Extensions

type QuickviewDemoProps =
    interface end

type QuickviewDemoState =
    { IsActive : bool }

type QuickviewDemo(props) =
    inherit React.Component<QuickviewDemoProps, QuickviewDemoState>(props)
    do base.setInitState({ IsActive = false })

    member this.show _ =
        this.setState (fun prevState _ ->
            { prevState with IsActive = true }
        )

    member this.hide _ =
        this.setState (fun prevState _ ->
            { prevState with IsActive = false }
        )

    override this.render () =
        div [ ]
            [ Quickview.quickview [ Quickview.IsActive this.state.IsActive ]
                    [ Quickview.header [ ]
                        [ Quickview.title [ ] [ str "Testing..." ]
                          Delete.delete [ Delete.OnClick this.hide ] [ ] ]
                      Quickview.body [ ]
                        [ p [ ] [ str "The body" ] ]
                      Quickview.footer [ ]
                        [ Button.button [ Button.OnClick this.hide ]
                                        [ str "Hide the quickview!" ] ] ]
              Button.button [ Button.Color IsPrimary
                              Button.OnClick this.show ]
                            [ str "Show the Quickview!" ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Quickview

Display quick view of data without leaving the current page

*[Documentation](https://wikiki.github.io/components/quickview/)*


## Npm packages

<table class="table" style="width: auto;">
    <thead>
        <tr>
            <th>Version</th>
            <th>CLI</th>
        </tr>
    </thead>
    <tbody>
        <tr>
            <td>Latest</td>
            <td>`yarn add bulma bulma-quickview`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-quickview@1.0.1`</td>
        </tr>
    </tbody>
<table>
"""
                     Render.docSection
                        ""
                        (Widgets.Showcase.view (fun _ -> ofType<QuickviewDemo,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.contentFromMarkdown
                        """
### Properties

State:

- `Quickview.IsActive true`
"""
]
