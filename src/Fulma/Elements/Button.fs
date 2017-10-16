namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
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
            | IsStatic
            | Nothing

        type Option =
            | Level of ILevelAndColor
            | Size of ISize
            | IsOutlined
            | IsInverted
            | IsLink
            | IsDisabled
            | State of IState
            | Props of IHTMLProp list
            | OnClick of (MouseEvent -> unit)
            | CustomClass of string

        let ofSize size =
            match size with
            | IsSmall -> Bulma.Button.Size.IsSmall
            | IsMedium -> Bulma.Button.Size.IsMedium
            | IsLarge -> Bulma.Button.Size.IsLarge
            | IsFullWidth -> Bulma.Button.Size.IsFullwidth
            | ISize.Nothing -> ""

        let ofStyles style =
            match style with
            | IsOutlined -> Bulma.Button.Styles.IsOutlined
            | IsInverted -> Bulma.Button.Styles.IsInverted
            | IsLink -> Bulma.Button.Styles.IsLink
            | value -> string value + " isn't a valid style value"

        let ofState state =
            match state with
            | IState.Nothing -> ""
            | IsHovered -> Bulma.Button.State.IsHovered
            | IsFocused -> Bulma.Button.State.IsFocused
            | IsActive -> Bulma.Button.State.IsActive
            | IsLoading -> Bulma.Button.State.IsLoading
            | IsStatic -> Bulma.Button.State.IsStatic

        type Options =
            { Level : string option
              Size : string option
              IsOutlined : bool
              IsInverted : bool
              IsLink : bool
              IsDisabled : bool
              State : string option
              Props : IHTMLProp list
              CustomClass : string option
              OnClick : (MouseEvent -> unit) option }
            static member Empty =
                { Level = None
                  Size = None
                  IsOutlined = false
                  IsInverted = false
                  IsLink = false
                  IsDisabled = false
                  State = None
                  Props = []
                  CustomClass = None
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
    let isStatic = State IsStatic
    let isDisabled = IsDisabled
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
    let customClass = CustomClass
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
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnClick cb -> { result with OnClick = cb |> Some }
            | IsDisabled -> { result with IsDisabled = true }

        let opts = options |> List.fold parseOptions Options.Empty

        a
            [ yield classBaseList
                (Helpers.generateClassName Bulma.Button.Container [ opts.Level; opts.Size; opts.State ])
                 [ Bulma.Button.Styles.IsOutlined, opts.IsOutlined
                   Bulma.Button.Styles.IsInverted, opts.IsInverted
                   Bulma.Button.Styles.IsLink, opts.IsLink
                   opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              if opts.IsDisabled then
                yield Disabled true :> IHTMLProp
              if opts.OnClick.IsSome then
                yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
              yield! opts.Props ]
            children
