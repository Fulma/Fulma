module FulmaExtensions.PageLoader.View

open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma
open Fulma.Elements
open Fulma.Extensions


let basicInteractive (model:Model) (dispatch:Msg->unit) =
    // Here we force React to redraw this section when coming from another page
    // This prevent the visual bug effect on the page loader
    div [ Key "page-loader-force-full-redraw" ]
        [ PageLoader.pageLoader [ PageLoader.Color model.Color
                                  PageLoader.IsActive model.IsLoading ]
            [ ]
          Content.content [ ]
            [ p [ ]
                [ str "Click on a button to display a loader for 3 sec" ] ]
          div [ ClassName "block" ]
            [
                Button.button [ Button.Color IsBlack
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsBlack))] [ str "Show loader" ]
                Button.button [ Button.Color IsDanger
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsDanger))] [ str "Show loader" ]
                Button.button [ Button.Color IsDark
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsDark))] [ str "Show loader" ]
                Button.button [ Button.Color IsInfo
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsInfo))] [ str "Show loader" ]
                Button.button [ Button.Color IsLight
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsLight))] [ str "Show loader" ]
                Button.button [ Button.Color IsPrimary
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsPrimary))] [ str "Show loader" ]
                Button.button [ Button.Color IsSuccess
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsSuccess))] [ str "Show loader" ]
                Button.button [ Button.Color IsWarning
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsWarning))] [ str "Show loader" ]
                Button.button [ Button.Color IsWhite
                                Button.OnClick (fun _ -> dispatch (IsLoadingMsg IsWhite))] [ str "Show loader" ] ] ]

let root model dispatch =
    Render.docPage [    Render.contentFromMarkdown model.Intro
                        Render.docSection
                            ""
                            (Viewer.View.root (basicInteractive model dispatch) model.Viewer (ViewerMsg >> dispatch))
                        Render.contentFromMarkdown
                            """
### Properties

State:

- `PageLoader.isActive`

Color:

- `PageLoader.isBlack`
- `PageLoader.isDark`
- `PageLoader.isLight`
- `PageLoader.isWhite`
- `PageLoader.isPrimary`
- `PageLoader.isInfo`
- `PageLoader.isSuccess`
- `PageLoader.isWarning`
- `PageLoader.isDanger`
                            """
                    ]
