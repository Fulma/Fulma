module FulmaExtensions.Quickview

open Fable.Core
open Fable.Import
open Fable.React
open Fulma
open Fulma.Extensions.Wikiki

type QuickviewDemoProps =
    interface end

type QuickviewDemoState =
    { IsActive : bool }

type QuickviewDemo(props) =
    inherit Component<QuickviewDemoProps, QuickviewDemoState>(props)
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

### Installation

- `paket add Fulma.Extensions.Wikiki.Quickview --project <your project>`
- Follow instructions from `dotnet femto yourProject.fsproj`
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
