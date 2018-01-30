module Widgets.Changelog

open Fable.Core
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fulma
open Fulma.Components
open Fulma.Elements
open Fulma.Layouts
open Fulma.Extra.FontAwesome
open Fable.PowerPack
open Fable.PowerPack.Fetch

[<Pojo>]
type ChangelogProps =
    { File : string }

type ContentState =
    | Loading
    | Fetched of string
    | Error

[<Pojo>]
type ChangelogState =
    { Content : ContentState }

type Changelog(props) =
    inherit React.Component<ChangelogProps, ChangelogState>(props)

    let rootUrl = "http://localhost:8080/changelogs/"

    do base.setInitState({ Content = Loading })

    member this.setMarkdown content =
        { this.state with Content = Fetched content }
        |> this.setState

    member this.componentDidMount () =
        promise {
            let! res = fetch (rootUrl + this.props.File) [ ]
            let! txt = res.text()
            this.setMarkdown txt
        }
        |> Promise.catch (fun _ ->
            { this.state with Content = Error }
            |> this.setState
        )
        |> Promise.start

    member this.render () =
        match this.state.Content with
        | Loading ->
            Hero.hero [ Hero.IsLarge ]
                [ Hero.body [ CustomClass "has-text-centered" ]
                    [ Content.content [ ]
                        [ Icon.faIcon [ Icon.Size IsLarge ]
                            [ //Animations work well on Spinner
                              Fa.icon Fa.I.Spinner
                              //Pulse Animation
                              Fa.pulse
                              //Icon 2x times larger
                              Fa.fa3x ]
                          br [ ]
                          br [ ]
                          p [ ] [ str "We are fetching the changelog info" ] ] ] ]
        | Error ->
            Notification.notification [ Notification.Color IsDanger ]
                [ Content.content [ Content.CustomClass "has-text-centered" ]
                        [ p [ ] [ str "An error occured, please open an issue" ] ] ]
        | Fetched txt ->
            Render.contentFromMarkdown txt

let view project version =
    com<Changelog,_,_>
        { File = project + "/" + version + ".md" }
        [ ]
