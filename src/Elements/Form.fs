namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Form =

  module Control =

    module Types =

      type IHasIcon =
        | Left
        | Right

      type Option =
        | HasIcon of IHasIcon
        | IsLoading

      type Options =
        { hasIcon: string option
          isLoading: bool }

        static member Empty =
          { hasIcon = None
            isLoading = false }

      let ofHasIcon =
        function
        | Left -> bulma.control.hasIcon.left
        | Right -> bulma.control.hasIcon.right

    open Types

    // HasIcon
    let hasIconLeft = HasIcon Left
    let hasIconRight = HasIcon Right
    // State
    let isLoading = IsLoading

    let control options children =
      let parseOptions (result: Options) =
        function
        | HasIcon hasIcon -> { result with hasIcon = ofHasIcon hasIcon |> Some }
        | IsLoading -> { result with isLoading = true }

      let opts = options |> List.fold parseOptions Options.Empty

      p
        [ classBaseList
            (Helpers.generateClassName bulma.content.container [ opts.hasIcon ] )
            [ bulma.control.state.isLoading, opts.isLoading ] ]
        children

  module Label =

    module Types =

      type Option =
        | Size of ISize
        | For of string

      type Options =
        { size: string option
          htmlFor: string option }

        static member Empty =
          { size = None
            htmlFor = None }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    // Extra
    let htmlFor id = For id

    let label options children =
      let parseOptions (result: Options) =
        function
        | Size size -> { result with size = ofSize size |> Some }
        | For htmlFor -> { result with htmlFor = htmlFor |> Some }

      let opts = options |> List.fold parseOptions Options.Empty

      label
        [ yield ClassName (Helpers.generateClassName bulma.label.container [ opts.size ]) :> IHTMLProp
          if opts.htmlFor.IsSome then yield HtmlFor opts.htmlFor.Value :> IHTMLProp ]
        children

  module Input =

    module Types =

      type IInputType =
        | Text
        | Password
        | DatetimeLocal
        | Date
        | Month
        | Time
        | Week
        | Number
        | Email
        | Url
        | Search
        | Tel
        | Color

      type Option =
        | Size of ISize
        | Type of IInputType
        | Color of ILevelAndColor
        | Id of string
        | Disabled of bool
        | Value of string
        | DefaultValue of string
        | Placeholder of string
        | Props of IHTMLProp list

      type Options =
        { size: string option
          type': string
          color: string option
          id: string option
          disabled: bool
          value: string option
          defaultValue: string option
          placeholder: string option
          props: IHTMLProp list }

        static member Empty =
          { size = None
            type' = ""
            color = None
            id = None
            disabled = false
            value = None
            defaultValue = None
            placeholder = None
            props = [] }

      let ofType =
        function
        | Text -> "text"
        | Password -> "password"
        | DatetimeLocal -> "datetime-local"
        | Date -> "date"
        | Month -> "month"
        | Time -> "time"
        | Week -> "week"
        | Number -> "number"
        | Email -> "email"
        | Url -> "url"
        | Search -> "search"
        | Tel -> "tel"
        | IInputType.Color -> "color"

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    // Colors
    let isBlack = Color IsBlack
    let isDark = Color IsDark
    let isLight = Color IsLight
    let isWhite = Color IsWhite
    let isPrimary = Color IsPrimary
    let isInfo = Color IsInfo
    let isSuccess = Color IsSuccess
    let isWarning = Color IsWarning
    let isDanger = Color IsDanger
    // Types
    let text = Type Text
    let password = Type Password
    let datetimeLocal = Type DatetimeLocal
    let date = Type Date
    let month = Type Month
    let time = Type Time
    let week = Type Week
    let number = Type Number
    let email = Type Email
    let url = Type Url
    let search = Type Search
    let tel = Type Tel
    let color = Type IInputType.Color
    // Extra
    let id str = Id str
    let disabled value = Disabled value
    let value v = Value v
    let defaultValue v = DefaultValue v
    let placeholder str = Placeholder str
    let props props = Props props

    let input options =
      let parseOptions (result: Options) option =
        match option with
        | Size size -> { result with size = ofSize size |> Some }
        | Type type' -> { result with  type' = ofType type' }
        | Color color -> { result with color = ofLevelAndColor color |> Some }
        | Id id -> { result with id = Some id }
        | Disabled disabled -> { result with disabled = disabled }
        | Value value -> { result with value = Some value }
        | DefaultValue defaultValue -> { result with defaultValue = Some defaultValue }
        | Placeholder placeholder -> { result with placeholder = Some placeholder }
        | Props props -> { result with props = props }

      let opts = options |> List.fold parseOptions Options.Empty

      let className =
        Helpers.generateClassName
          bulma.input.container
          [ opts.size
            opts.color ]

      input
        ( [ yield ClassName className :> IHTMLProp
            yield Props.Disabled opts.disabled :> IHTMLProp
            yield Props.Type opts.type' :> IHTMLProp
            if opts.id.IsSome then yield Props.Id opts.id.Value :> IHTMLProp
            if opts.value.IsSome then yield Props.Value (U2.Case1 opts.value.Value) :> IHTMLProp
            if opts.defaultValue.IsSome then yield Props.DefaultValue (U2.Case1 opts.defaultValue.Value) :> IHTMLProp
            if opts.placeholder.IsSome then yield Props.Placeholder opts.placeholder.Value :> IHTMLProp
          ] @ opts.props)


  module Field =

    module Types =

      type IHasAddons =
        | Left
        | Centered
        | Right
        | FullWidth

      type IIsGrouped =
        | Left
        | Centered
        | Right

      type ILayout =
        | Horizontal

      type Option =
        | HasAddons of IHasAddons
        | IsGrouped of IIsGrouped
        | Layout of ILayout

      type Options =
        { hasAddons: string option
          isGrouped: string option
          layout: string option }

        static member Empty =
          { hasAddons = None
            isGrouped = None
            layout = None }

      let ofHasAddons =
        function
        | IHasAddons.Left -> bulma.field.hasAddons.left
        | IHasAddons.Centered -> bulma.field.hasAddons.left ++ bulma.field.hasAddons.centered
        | IHasAddons.Right -> bulma.field.hasAddons.left ++ bulma.field.hasAddons.right
        | IHasAddons.FullWidth -> bulma.field.hasAddons.left ++ bulma.field.hasAddons.fullWidh

      let ofIsGrouped =
        function
        | IIsGrouped.Left -> bulma.field.isGrouped.left
        | IIsGrouped.Centered -> bulma.field.isGrouped.left ++ bulma.field.isGrouped.centered
        | IIsGrouped.Right -> bulma.field.isGrouped.left ++ bulma.field.isGrouped.right

      let ofLayout =
        function
        | Horizontal -> bulma.field.layout.isHorizontal

      type FieldLabelOption =
        | Size of ISize

      type FieldLabelOptions =
        { size: string option }

        static member Empty =
          { size = None }

    open Types

    // HasAddons
    let hasAddonsLeft = HasAddons IHasAddons.Left
    let hasAddonsCentered = HasAddons IHasAddons.Centered
    let hasAddonsRight = HasAddons IHasAddons.Right
    let hasAddonsFullWidth = HasAddons IHasAddons.FullWidth
    // IsGrouped
    let isGroupedLeft = IsGrouped IIsGrouped.Left
    let isGroupedCentered = IsGrouped IIsGrouped.Centered
    let isGroupedRight = IsGrouped IIsGrouped.Right
    // Layout
    let isHorizontal = Layout Horizontal

    let field options children =
      let parseOptions (result: Options) =
        function
        | HasAddons hasAddons -> { result with hasAddons = ofHasAddons hasAddons |> Some }
        | IsGrouped isGrouped  -> { result with isGrouped = ofIsGrouped isGrouped |> Some }
        | Layout layout -> { result with layout = ofLayout layout |> Some }

      let opts = options |> List.fold parseOptions Options.Empty

      let className =
        Helpers.generateClassName
          bulma.field.container
          [ opts.hasAddons
            opts.isGrouped
            opts.layout ]

      div
        [ ClassName className ]
        children

    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge

    let label options children =
      let parseOptions (result: FieldLabelOptions) =
        function
        | Size size -> { result with size = ofSize size |> Some }

      let opts = options |> List.fold parseOptions FieldLabelOptions.Empty

      div
        [ ClassName (Helpers.generateClassName bulma.field.label [ opts.size ]) ]
        children

    let body (options: unit list) children =
      div
        [ ClassName bulma.field.body ]
        children
