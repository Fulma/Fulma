module FulmaExtensions.PageLoader

open Fable.Core
open Fable.Import
open Fable.React
open Fable.React.Props
open Fulma
open Fulma.Extensions.Wikiki

type PageLoaderDemoProps =
    interface end

type PageLoaderDemoState =
    { CurrentColor : IColor
      IsActive : bool }

type PageLoaderDemo(props) =
    inherit Component<PageLoaderDemoProps, PageLoaderDemoState>(props)
    do base.setInitState({ CurrentColor = IsSuccess; IsActive = false })

    member this.onClick newColor =
        this.setState (fun prevState _ ->
            { prevState with
                        CurrentColor = newColor
                        IsActive = true }
        )

        this.delayedHide ()

    member this.delayedHide _ =
        async {
            do! Async.Sleep 2000
            this.setState (fun prevState _ ->
                { prevState with IsActive = false }
            )
        }
        |> Async.StartImmediate

    override this.render () =
        let demoView () =
            PageLoader.pageLoader [ PageLoader.Color IsSuccess
                                    PageLoader.IsActive true ]
                [ ]

        // Previous code is so we display a correct documentation
        let renderButton color =
            Button.button [ Button.Color color
                            Button.OnClick (fun _ -> this.onClick color) ]
                          [ str "Show loader" ]

        // Here we force React to redraw this section when coming from another page
        // This prevent the visual bug effect on the page loader
        div [ Key "page-loader-force-full-redraw" ]
            [ PageLoader.pageLoader [ PageLoader.Color this.state.CurrentColor
                                      PageLoader.IsActive this.state.IsActive ]
                [ ]
              Content.content [ ]
                [ p [ ]
                    [ str "Click on a button to display a loader for 2 sec" ] ]
              div [ ClassName "block" ]
                [ renderButton IsBlack
                  renderButton IsDanger
                  renderButton IsDark
                  renderButton IsInfo
                  renderButton IsLight
                  renderButton IsPrimary
                  renderButton IsSuccess
                  renderButton IsWarning
                  renderButton IsWhite ] ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Page-loader

Display a **page-loader** to inform user that content is loading, in different colors.

*[Documentation](https://wikiki.github.io/elements/pageloader/)*

### Installation

- `paket add Fulma.Extensions.Wikiki.PageLoader --project <your project>`
- Follow instructions from `dotnet femto yourProject.fsproj`
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view (fun _ -> ofType<PageLoaderDemo,_,_> (unbox null) []) (Render.includeCode __LINE__ __SOURCE_FILE__))
                     Render.contentFromMarkdown
                        """
### Properties

State:

- `PageLoader.IsActive true`

Color:

- `PageLoader.Color IsBlack`
- `PageLoader.Color IsDark`
- `PageLoader.Color IsLight`
- `PageLoader.Color IsWhite`
- `PageLoader.Color IsPrimary`
- `PageLoader.Color IsInfo`
- `PageLoader.Color IsSuccess`
- `PageLoader.Color IsWarning`
- `PageLoader.Color IsDanger`
                        """ ]
