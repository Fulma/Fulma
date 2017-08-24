namespace Elmish.Bulma.Extra

open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Elmish
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Elmish.Bulma.Elements.Notification

module Notification =

    type NotificationProgramEvent =
        { notif : React.ReactElement }

    type Notification =
        { id : int
          view : React.ReactElement }

    type Notifiable<'msg> =
        | AddNewNotification of React.ReactElement
        | UserMsg of 'msg

    type NotificationModel<'model> =
        { notifications : Notification list
          userModel : 'model }

    type Config =
        { Area : Notification list -> React.ReactElement
          AutoCloseDelay : float option }

    let defaultNotificationConfig =
        { Area = (fun notifications ->
                        div [ Style [ Position "fixed"
                                      CSSProp.Width 500
                                      Top 55
                                      Right 25
                                      ZIndex 100. ] ]
                              (List.map (fun x -> x.view) notifications))
          AutoCloseDelay = None
        }

    let internal onNotificationEvent = new Event<NotificationProgramEvent>()

    [<RequireQualifiedAccess>]
    module Cmd =
        [<Literal>]
        let NotifiedEvent = "NotifiedEvent"

        let newNotification (notif : React.ReactElement) : Cmd<_> =
            [ fun _ -> onNotificationEvent.Trigger({ notif = notif }) |> ignore ]

    [<RequireQualifiedAccess>]
    module Program =
        let toNotifiable (config: Config) (program : Program<'a, 'model, 'msg, 'view>) =
            let map (model, cmd) = model, cmd |> Cmd.map UserMsg

            let update msg model =
                match msg with
                | UserMsg userMsg ->
                    let (userModel, userCmd) = program.update userMsg model.userModel
                    { model with userModel = userModel }, userCmd |> Cmd.map UserMsg
                | AddNewNotification view ->
                    let notification =
                        { id = System.DateTime.Now.Millisecond
                          view = view }
                    { model with notifications = notification :: model.notifications }, []

            let view model dispatch =
                div [] [ config.Area model.notifications
                         program.view model.userModel (UserMsg >> dispatch) ]

            let newNotificationRecieved (dispatch : Dispatch<_ Notifiable>) =
                onNotificationEvent.Publish.Add(fun evt -> AddNewNotification evt.notif |> dispatch)

            let subs model =
                Cmd.batch [ [ newNotificationRecieved ]
                            program.subscribe model.userModel |> Cmd.map UserMsg ]

            let init args =
                let (userModel, userCmd) = program.init args
                { notifications = []
                  userModel = userModel }, Cmd.batch [ Cmd.map UserMsg userCmd ]

            { init = init
              update = update
              subscribe = subs
              onError = program.onError
              setState = fun model -> view model >> ignore
              view = view }
