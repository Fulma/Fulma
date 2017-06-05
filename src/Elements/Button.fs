namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Button =

  module ButtonTypes =

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

    let ofStyles style =
      match style with
      | IsOutlined -> bulma.button.styles.isOutlined
      | IsInverted -> bulma.button.styles.isInverted
      | IsLink -> bulma.button.styles.isLink
      | value -> failwithf "%A isn't a valid style value" value

    let ofState state =
      match state with
      | IState.Nothing -> ""
      | IsHovered -> bulma.button.state.isHovered
      | IsFocused -> bulma.button.state.isFocused
      | IsActive -> bulma.button.state.isActive
      | IsLoading -> bulma.button.state.isLoading

    type Options =
      { level: string
        size: string
        isOutlined: bool
        isInverted: bool
        isLink: bool
        state: string
        props: IHTMLProp list }

      static member Empty =
        { level = ""
          size = ""
          isOutlined = false
          isInverted = false
          isLink = false
          state = ""
          props = [] }

  open ButtonTypes

  // Sizes
  let isSmall = Size IsSmall
  let isMedium = Size IsMedium
  let isLarge = Size IsLarge
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

  let button (options: Option list) children =
    let rec parseOptions options result =
      match options with
      | x::xs ->
          match x with
          | Level level ->
              { result with level = ofLevel level }
          | Size size ->
              { result with size = ofSize size }
          | IsOutlined ->
              { result with isOutlined = true }
          | IsInverted ->
              { result with isInverted = true }
          | IsLink ->
              { result with isLink = true }
          | State state ->
              { result with state = ofState state }
          | Props props ->
              { result with props = props }
          |> parseOptions xs
      | [] -> result

    let opts = parseOptions options Options.Empty

    a
      ( classBaseList
          (bulma.button.container ++ opts.level ++ opts.size ++ opts.state)
          [ bulma.button.styles.isOutlined, opts.isOutlined
            bulma.button.styles.isInverted, opts.isInverted
            bulma.button.styles.isLink, opts.isLink ]
        :> IHTMLProp
      :: opts.props)
      children
