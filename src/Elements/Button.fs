namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Button =
    module Types =
        type ISize =
            | IsSmall
            | IsMedium
            | IsLarge
            | IsFullWidth
            | Nothing

        type IState =
            | IsHovered
            | IsFocused
            | IsActive
            | IsLoading
            | Nothing

        type Option =
            | Level of ILevelAndColor
            | Size of ISize
            | IsOutlined
            | IsInverted
            | IsLink
            | State of IState
            | Props of IHTMLProp list
            | OnClick of (React.MouseEvent -> unit)
            | Classy of string

        let ofSize size =
            match size with
            | IsSmall -> bulma.Button.Size.IsSmall
            | IsMedium -> bulma.Button.Size.IsMedium
            | IsLarge -> bulma.Button.Size.IsLarge
            | IsFullWidth -> bulma.Button.Size.IsFullwidth
            | ISize.Nothing -> ""

        let ofStyles style =
            match style with
            | IsOutlined -> bulma.Button.Styles.IsOutlined
            | IsInverted -> bulma.Button.Styles.IsInverted
            | IsLink -> bulma.Button.Styles.IsLink
            | value -> failwithf "%A isn't a valid style value" value

        let ofState state =
            match state with
            | IState.Nothing -> ""
            | IsHovered -> bulma.Button.State.IsHovered
            | IsFocused -> bulma.Button.State.IsFocused
            | IsActive -> bulma.Button.State.IsActive
            | IsLoading -> bulma.Button.State.IsLoading

        type Options =
            { Level : string option
              Size : string option
              IsOutlined : bool
              IsInverted : bool
              IsLink : bool
              State : string option
              Props : IHTMLProp list
              Classy : string option
              OnClick : (React.MouseEvent -> unit) option }
            static member Empty =
                { Level = None
                  Size = None
                  IsOutlined = false
                  IsInverted = false
                  IsLink = false
                  State = None
                  Props = []
                  Classy = None
                  OnClick = None }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    let isFullWidth = Size IsFullWidth
    // States
    let isHovered = State IsHovered
    let isFocused = State IsFocused
    let isActive = State IsActive
    let isLoading = State IsLoading
    // Styles
    let isOutlined = IsOutlined
    let isInverted = IsInverted
    let isLink = IsLink
    // Levels and colors
    let isBlack = Level IsBlack
    let isDark = Level IsDark
    let isLight = Level IsLight
    let isWhite = Level IsWhite
    let isPrimary = Level IsPrimary
    let isInfo = Level IsInfo
    let isSuccess = Level IsSuccess
    let isWarning = Level IsWarning
    let isDanger = Level IsDanger
    // Extra
    let props props = Props props
    let onClick cb = OnClick cb

    let button (options : Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | Option.Level level -> { result with Level = ofLevelAndColor level |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsOutlined -> { result with IsOutlined = true }
            | IsInverted -> { result with IsInverted = true }
            | IsLink -> { result with IsLink = true }
            | State state -> { result with State = ofState state |> Some }
            | Props props -> { result with Props = props }
            | Classy classy -> { result with Classy = Some classy }
            | OnClick cb -> { result with OnClick = cb |> Some }

        let opts = options |> List.fold parseOptions Options.Empty

        a
            [ yield classBaseList
                (Helpers.generateClassName bulma.Button.Container [ opts.Level; opts.Size; opts.State ])
                 [ bulma.Button.Styles.IsOutlined, opts.IsOutlined
                   bulma.Button.Styles.IsInverted, opts.IsInverted
                   bulma.Button.Styles.IsLink, opts.IsLink
                   opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
              if opts.OnClick.IsSome then
                yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
              yield! opts.Props ]
            children
