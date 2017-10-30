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

        type IAnchorOption =
            interface end

        type IBtnOption =
            interface end

        type IInputOption =
            interface end

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
            interface IAnchorOption
            interface IBtnOption
            interface IInputOption

        type AnchorOnlyOption =
            | Href of string
            interface IAnchorOption

        type InputOnlyOption =
            | Type of string
            | Value of string
            interface IInputOption

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

        type AnchorOptions =
            { GenericOption : Options
              Href : string option }

            static member Empty =
                { GenericOption = Options.Empty
                  Href = None }

        type InputOptions =
            { GenericOption : Options
              Value : string option
              Type : string option }

            static member Empty =
                { GenericOption = Options.Empty
                  Type = None
                  Value = None }


        let parseGenericOptions (result: Options) opt =
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

    open Types

    // Sizes
    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
    let inline isFullWidth<'T> = Size IsFullWidth
    // States
    let inline isHovered<'T> = State IsHovered
    let inline isFocused<'T> = State IsFocused
    let inline isActive<'T> = State IsActive
    let inline isLoading<'T> = State IsLoading
    let inline isStatic<'T> = State IsStatic
    let inline isDisabled<'T> = IsDisabled
    // Styles
    let inline isOutlined<'T> = IsOutlined
    let inline isInverted<'T> = IsInverted
    let inline isLink<'T> = IsLink
    // Levels and colors
    let inline isBlack<'T> = Level IsBlack
    let inline isDark<'T> = Level IsDark
    let inline isLight<'T> = Level IsLight
    let inline isWhite<'T> = Level IsWhite
    let inline isPrimary<'T> = Level IsPrimary
    let inline isInfo<'T> = Level IsInfo
    let inline isSuccess<'T> = Level IsSuccess
    let inline isWarning<'T> = Level IsWarning
    let inline isDanger<'T> = Level IsDanger
    // Extra
    let inline props x = Props x
    let inline customClass x = CustomClass x
    let inline onClick cb = OnClick cb

    // Anchor only
    let inline href x = AnchorOnlyOption.Href x

    // Input only
    let inline typeIsSubmit<'T> = InputOnlyOption.Type "reset"
    let inline typeIsReset<'T> = InputOnlyOption.Type "submit"
    let inline value x = InputOnlyOption.Value x

    let genericPropsGenerator opts =
        [ yield Helpers.classes Bulma.Button.Container [opts.Level; opts.Size; opts.State; opts.CustomClass] [Bulma.Button.Styles.IsOutlined, opts.IsOutlined; Bulma.Button.Styles.IsInverted, opts.IsInverted; Bulma.Button.Styles.IsLink, opts.IsLink]
          if opts.IsDisabled then
            yield Disabled true :> IHTMLProp
          if Option.isSome opts.OnClick then
            yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
          yield! opts.Props ]

    let button_a (options : 'T list when 'T :> IAnchorOption) children =
        let parseOptions (result: AnchorOptions) (opt : IAnchorOption) =
            match opt with
            | :? Option as genericOption -> { result with GenericOption = parseGenericOptions result.GenericOption genericOption }
            | :? AnchorOnlyOption as anchorOption ->
                match anchorOption with
                | AnchorOnlyOption.Href href -> { result with Href = Some href }
            | invalidType ->
                Fable.Import.JS.console.warn ("Invalid option type given for the anchor button: " + string invalidType)
                result

        let anchorOpts = options |> List.fold parseOptions AnchorOptions.Empty

        a
            [ if Option.isSome anchorOpts.Href then
                yield HTMLAttr.Href anchorOpts.Href.Value :> IHTMLProp
              yield! genericPropsGenerator anchorOpts.GenericOption ]
            children

    let button_btn (options : Option list) children =
        let opts = options |> List.fold parseGenericOptions Options.Empty

        button
            (genericPropsGenerator opts)
            children

    let button_input (options : 'T list when 'T :> IInputOption) =
        let parseOptions (result: InputOptions) (opt : IInputOption) =
            match opt with
            | :? Option as genericOption -> { result with GenericOption = parseGenericOptions result.GenericOption genericOption }
            | :? InputOnlyOption as anchorOption ->
                match anchorOption with
                | InputOnlyOption.Type typeValue -> { result with Type = Some typeValue }
                | InputOnlyOption.Value value -> { result with Value = Some value }
            | invalidType ->
                Fable.Import.JS.console.warn ("Invalid option type given for the input button: " + string invalidType)
                result

        let inputOpts = options |> List.fold parseOptions InputOptions.Empty

        input
            [ if Option.isSome inputOpts.Type then
                yield HTMLAttr.Type inputOpts.Type.Value :> IHTMLProp
              if Option.isSome inputOpts.Value then
                yield HTMLAttr.Value inputOpts.Value.Value :> IHTMLProp
              yield! genericPropsGenerator inputOpts.GenericOption ]
