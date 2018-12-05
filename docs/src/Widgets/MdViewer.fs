module Widgets.MdViewer

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fulma
open Fable.FontAwesome
open Fable.PowerPack
open Fable.PowerPack.Fetch

type ChangelogProps =
    { File : string }

type ContentState =
    | Loading
    | Fetched of string
    | Error

type ChangelogState =
    { Content : ContentState }

type Changelog(props) =
    inherit React.Component<ChangelogProps, ChangelogState>(props)

    #if DEBUG
    let rootUrl = "http://localhost:8080/"
    #else
    let rootUrl = "https://raw.githubusercontent.com/MangelMaxime/Fulma/master/docs/public/"
    #endif

    do base.setInitState({ Content = Loading })

    member this.setMarkdown content =
        this.setState (fun prevState _ ->
            { prevState with Content = Fetched content }
        )

    override this.componentDidMount () =
        promise {
            let! res = fetch (rootUrl + this.props.File) [ ]
            let! txt = res.text()
            this.setMarkdown txt
        }
        |> Promise.catch (fun _ ->
            this.setState (fun prevState _ ->
                { prevState with Content = Error }
            )
        )
        |> Promise.start

    override this.render () =
        match this.state.Content with
        | Loading ->
            Hero.hero [ Hero.IsLarge ]
                [ Hero.body [ CustomClass "has-text-centered" ]
                    [ Content.content [ ]
                        [ Icon.icon [ Icon.Size IsLarge ]
                            [ Fa.i [ //Animations work well on Spinner
                                     Fa.Solid.Spinner
                                     //Pulse Animation
                                     Fa.Pulse
                                     //Icon 3x times larger
                                     Fa.Size Fa.Fa3x ]
                                [ ] ]
                          br [ ]
                          br [ ]
                          p [ ] [ str "We are fetching the changelog info" ] ] ] ]
        | Error ->
            Notification.notification [ Notification.Color IsDanger ]
                [ Content.content [ Content.CustomClass "has-text-centered" ]
                        [ p [ ] [ str "An error occured, please open an issue" ] ] ]
        | Fetched txt ->
            Render.contentFromMarkdown txt

let view file =
    ofType<Changelog,_,_>
        { File = file }
        [ ]
