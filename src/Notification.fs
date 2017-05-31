namespace Elmish.Bulma

open Elmish
open Elmish.Bulma.Modifiers
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Notification =

  type NotificationProgramEvent = { notif: React.ReactElement }

  type Notification =
    { id: int
      view: React.ReactElement }

  type Notifiable<'msg> =
    | AddNewNotification of React.ReactElement
    | UserMsg of 'msg

  type NotificationModel<'model> =
    { notifications : Notification list
      userModel: 'model }

  type Option =
    | Level of Level
    | Closable
    // | AutoCloseDelay of float

  type Options =
    { level: Level
      hasDeleteButton: bool }
      // AutoCloseDelay: float option

    static member Empty =
      { level = NoLevel
        hasDeleteButton = false }

  let notification (options: Option list) (properties: IHTMLProp list)children =
    let rec parseOptions options result =
      match options with
      | x::xs ->
          match x with
          | Level level ->
              { result with level = level }
          | Closable ->
              { result with hasDeleteButton = true }
          |> parseOptions xs
      | [] -> result

    let opts = parseOptions options Options.Empty

    let closeArea =
      [ if opts.hasDeleteButton then
          yield button
                  [ ClassName "delete" ]
                  [ ]
      ]

    let className = ClassName ("notification " + !!opts.level)

    div
      ((className :> IHTMLProp) :: properties)
      ( closeArea @ children )

  let defaultNotificationArea notifications =
    div
      [ Style
          [ Position "fixed"
            CSSProp.Width (U2.Case1 500)
            Top 55
            Right 25
            ZIndex 100. ] ]
      (List.map (fun x -> x.view) notifications)

  let internal onNotificationEvent = new Event<NotificationProgramEvent>()

  [<RequireQualifiedAccess>]
  module Cmd =
    let [<Literal>] NotifiedEvent = "NotifiedEvent"

    let newNotification (notif: React.ReactElement) : Cmd<_> =
      [ fun _ ->
          onNotificationEvent.Trigger({ notif = notif })
          |> ignore ]

  [<RequireQualifiedAccess>]
  module Program =

    let toNotifiable notificationArea (program : Program<'a,'model,'msg,'view>)  =
      let map (model, cmd) =
          model, cmd |> Cmd.map UserMsg

      let update msg model =
        match msg with
        | UserMsg userMsg ->
            let (userModel, userCmd) = program.update userMsg model.userModel
            { model with
                userModel = userModel}, userCmd |> Cmd.map UserMsg
        | AddNewNotification view ->
            let notification =
              { id = System.DateTime.Now.Millisecond
                view = view }
            { model with
                notifications = notification :: model.notifications }, []

      let view model dispatch =
        div
          [ ]
          [ notificationArea model.notifications
            program.view model.userModel (UserMsg >> dispatch) ]

      let newNotificationRecieved (dispatch:Dispatch<_ Notifiable>) =
        onNotificationEvent.Publish.Add(fun evt ->
          AddNewNotification evt.notif |> dispatch
        )

      let subs model =
        Cmd.batch
          [ [ newNotificationRecieved ]
            program.subscribe model.userModel |> Cmd.map UserMsg ]

      let init args =
        let (userModel, userCmd) = program.init args
        { notifications = []
          userModel = userModel}
          , Cmd.batch [ Cmd.map UserMsg userCmd ]

      { init = init
        update = update
        subscribe = subs
        onError = program.onError
        setState = fun model -> view model >> ignore
        view = view }
