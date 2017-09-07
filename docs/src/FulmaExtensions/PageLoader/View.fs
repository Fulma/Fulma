module FulmaExtensions.PageLoader.View

open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Types
open Fulma.Elements
open Fulma.Common
open Fulma.Grids
open Fulma.Extensions
open Fulma.Extra.FontAwesome
open Elmish.Browser
open Fable.Import.Browser

let basicInteractive (model:Model) (dispatch:Msg->unit) =
    let (isloading, color) = model.IsLoading
    if isloading then 
        window.setTimeout(  (fun _ -> dispatch IsLoadedMsg) , 3000 , [] ) |> ignore

    div [ ClassName "block" ] 
        [
            Button.button [ Button.isBlack; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsBlack))] [str "Show loader"]
            Button.button [ Button.isDanger; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsDanger))] [str "Show loader"]
            Button.button [ Button.isDark; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsDark))] [str "Show loader"]
            Button.button [ Button.isInfo; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsInfo))] [str "Show loader"]
            Button.button [ Button.isLight; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsLight))] [str "Show loader"]
            Button.button [ Button.isPrimary; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsPrimary))] [str "Show loader"]
            Button.button [ Button.isSuccess; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsSuccess))] [str "Show loader"]
            Button.button [ Button.isWarning; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsWarning))] [str "Show loader"]
            Button.button [ Button.isWhite; Button.onClick (fun _ -> dispatch (IsLoadingMsg IsWhite))] [str "Show loader"]
            
            
            PageLoader.pageLoader [ if isloading then 
                                        yield PageLoader.isActive 
                                    yield match color with
                                            | IsBlack ->  PageLoader.isBlack
                                            | IsDanger -> PageLoader.isDanger
                                            | IsDark ->   PageLoader.isDark
                                            | IsInfo ->   PageLoader.isInfo
                                            | IsLight ->  PageLoader.isLight
                                            | IsPrimary ->PageLoader.isPrimary
                                            | IsSuccess ->PageLoader.isSuccess
                                            | IsWarning ->PageLoader.isWarning
                                            | IsWhite ->  PageLoader.isWhite
                                  ]
                                  []
        ]

let root model dispatch =
    Render.docPage [    Render.contentFromMarkdown model.Intro
                        Render.docSection
                            "### Default divider"
                            (Viewer.View.root (basicInteractive model dispatch) model.Viewer (ViewerMsg >> dispatch))
                        
                    ]