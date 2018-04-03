module FulmaExtensions.PageLoader

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Elements
open Fulma.Extensions

[<Pojo>]
type PageLoaderDemoProps =
    interface end

[<Pojo>]
type PageLoaderDemoState =
    { CurrentColor : IColor
      IsActive : bool }

type PageLoaderDemo(props) =
    inherit React.Component<PageLoaderDemoProps, PageLoaderDemoState>(props)
    do base.setInitState({ CurrentColor = IsSuccess; IsActive = false })

    member this.onClick newColor =
        { this.state with
                        CurrentColor = newColor
                        IsActive = true }
        |> this.setState

        this.delayedHide ()

    member this.delayedHide _ =
        async {
            do! Async.Sleep 2000
            { this.state with IsActive = false }
            |> this.setState
        }
        |> Async.StartImmediate

    override this.render () =
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
                    [ str "Click on a button to display a loader for 3 sec" ] ]
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

let demoView () =
    PageLoader.pageLoader [ PageLoader.Color IsSuccess
                            PageLoader.IsActive true ]
        [ ]

let view =
    Render.docPage [ Render.contentFromMarkdown
                        """
# Page-loader

Display a **page-loader** to inform user that content is loading, in different colors.

*[Documentation](https://wikiki.github.io/elements/pageloader/)*

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
            <td>`yarn add bulma bulma-pageloader`</td>
        </tr>
        <tr>
            <td>Supported</td>
            <td>`yarn add bulma bulma-pageloader@0.1.0`</td>
        </tr>
    </tbody>
<table>
                        """
                     Render.docSection
                        ""
                        (Widgets.Showcase.view (fun _ -> ofType<PageLoaderDemo,_,_> (unbox null) []) (Render.getViewSource demoView))
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
