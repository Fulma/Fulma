namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Form =
    module Control =
        module Types =
            type IHasIcon =
                | Left
                | Right

            type Option =
                | HasIcon of IHasIcon
                | IsLoading
                | Classy of string
                | Props of IHTMLProp list

            type Options =
                { HasIconLeft : string option
                  HasIconRight : string option
                  Classy : string option
                  Props : IHTMLProp list
                  IsLoading : bool }
                static member Empty =
                    { HasIconLeft = None
                      HasIconRight = None
                      Classy = None
                      Props = []
                      IsLoading = false }

            let ofHasIcon =
                function
                | Left -> bulma.Control.HasIcon.Left
                | Right -> bulma.Control.HasIcon.Right

        open Types

        // HasIcon
        let hasIconLeft = HasIcon Left
        let hasIconRight = HasIcon Right
        // State
        let isLoading = IsLoading
        // Extra
        let classy = Classy
        let props = Props

        let control options children =
            let parseOptions (result : Options) =
                function
                | HasIcon Left -> { result with HasIconLeft = bulma.Control.HasIcon.Left |> Some }
                | HasIcon Right -> { result with HasIconRight = bulma.Control.HasIcon.Right |> Some }
                | Classy classy -> { result with Classy = classy |> Some }
                | Props props -> { result with Props = props }
                | IsLoading -> { result with IsLoading = true }

            let opts = options |> List.fold parseOptions Options.Empty

            let cls = Helpers.generateClassName bulma.Control.Container [ opts.HasIconLeft
                                                                          opts.HasIconRight
                                                                          opts.Classy ]

            p
                [ yield (classBaseList cls [ bulma.Control.State.IsLoading, opts.IsLoading ]) :> IHTMLProp
                  yield! opts.Props ]
                children

    module Label =
        module Types =
            type Option =
                | Size of ISize
                | For of string
                | Classy of string
                | Props of IHTMLProp list

            type Options =
                { Size : string option
                  HtmlFor : string option
                  Classy : string option
                  Props : IHTMLProp list }
                static member Empty =
                    { Size = None
                      HtmlFor = None
                      Classy = None
                      Props = [] }

        open Types

        // Sizes
        let isSmall = Size IsSmall
        let isMedium = Size IsMedium
        let isLarge = Size IsLarge
        // Extra
        let htmlFor id = For id
        let classy = Classy
        let props = Props

        let label options children =
            let parseOptions (result : Options) =
                function
                | Size size -> { result with Size = ofSize size |> Some }
                | For htmlFor -> { result with HtmlFor = htmlFor |> Some }
                | Classy classy -> { result with Classy = classy |> Some }
                | Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions Options.Empty
            label
                [ yield ClassName(Helpers.generateClassName bulma.Label.Container [ opts.Size; opts.Classy ]) :> IHTMLProp
                  if opts.HtmlFor.IsSome then yield HtmlFor opts.HtmlFor.Value :> IHTMLProp
                  yield! opts.Props ]
                children

    module Select =
        module Types =
            type Option =
                | Size of ISize
                | Color of ILevelAndColor
                | Id of string
                | Disabled of bool
                | Value of string
                | DefaultValue of string
                | Placeholder of string
                | Props of IHTMLProp list
                | Classy of string

            type Options =
                { Size : string option
                  Color : string option
                  Id : string option
                  Disabled : bool
                  Value : string option
                  DefaultValue : string option
                  Placeholder : string option
                  Props : IHTMLProp list
                  Classy : string option }
                static member Empty =
                    { Size = None
                      Color = None
                      Id = None
                      Disabled = false
                      Value = None
                      DefaultValue = None
                      Placeholder = None
                      Props = []
                      Classy = None }

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
                | Classy of string

            type Options =
                { Size : string option
                  Type : string
                  Color : string option
                  Id : string option
                  Disabled : bool
                  Value : string option
                  DefaultValue : string option
                  Placeholder : string option
                  Props : IHTMLProp list
                  Classy : string option }

                static member Empty =
                    { Size = None
                      Type = ""
                      Color = None
                      Id = None
                      Disabled = false
                      Value = None
                      DefaultValue = None
                      Placeholder = None
                      Props = []
                      Classy = None }

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
        let typeIsText = Type Text
        let typeIsPassword = Type Password
        let typeIsDatetimeLocal = Type DatetimeLocal
        let typeIsDate = Type Date
        let typeIsMonth = Type Month
        let typeIsTime = Type Time
        let typeIsWeek = Type Week
        let typeIsNumber = Type Number
        let typeIsEmail = Type Email
        let typeIsUrl = Type Url
        let typeIsSearch = Type Search
        let typeIsTel = Type Tel
        let typeIsColor = Type IInputType.Color
        // Extra
        let id str = Id str
        let disabled value = Disabled value
        let value v = Value v
        let defaultValue v = DefaultValue v
        let placeholder str = Placeholder str
        let props props = Props props
        let classy = Classy

        let input options =
            let parseOptions (result : Options) option =
                match option with
                | Size size -> { result with Size = ofSize size |> Some }
                | Type type' -> { result with Type = ofType type' }
                | Color color -> { result with Color = ofLevelAndColor color |> Some }
                | Id id -> { result with Id = Some id }
                | Disabled disabled -> { result with Disabled = disabled }
                | Value value -> { result with Value = Some value }
                | DefaultValue defaultValue -> { result with DefaultValue = Some defaultValue }
                | Placeholder placeholder -> { result with Placeholder = Some placeholder }
                | Props props -> { result with Props = props }
                | Classy classy -> { result with Classy = classy |> Some }

            let opts = options |> List.fold parseOptions Options.Empty
            let className = Helpers.generateClassName bulma.Input.Container [ opts.Size; opts.Color; opts.Classy ]
            input
                ([ yield ClassName className :> IHTMLProp
                   yield Props.Disabled opts.Disabled :> IHTMLProp
                   yield Props.Type opts.Type :> IHTMLProp
                   if opts.Id.IsSome then yield Props.Id opts.Id.Value :> IHTMLProp
                   if opts.Value.IsSome then yield Props.Value(U2.Case1 opts.Value.Value) :> IHTMLProp

                   if opts.DefaultValue.IsSome then
                       yield Props.DefaultValue(U2.Case1 opts.DefaultValue.Value) :> IHTMLProp
                   if opts.Placeholder.IsSome then yield Props.Placeholder opts.Placeholder.Value :> IHTMLProp ]
                 @ opts.Props)

        // Alias to create input already typed
        let text options = input (Type Text :: options)
        let password options = input (Type Password :: options)
        let datetimeLocal options = input (Type DatetimeLocal :: options)
        let date options = input (Type Date :: options)
        let month options = input (Type Month :: options)
        let time options = input (Type Time :: options)
        let week options = input (Type Week :: options)
        let number options = input (Type Number :: options)
        let email options = input (Type Email :: options)
        let url options = input (Type Url :: options)
        let search options = input (Type Search :: options)
        let tel options = input (Type Tel :: options)
        let color options = input (Type IInputType.Color :: options)

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
                | Classy of string
                | Props of IHTMLProp list

            type Options =
                { HasAddons : string option
                  IsGrouped : string option
                  Layout : string option
                  Classy : string option
                  Props : IHTMLProp list }
                static member Empty =
                    { HasAddons = None
                      IsGrouped = None
                      Layout = None
                      Classy = None
                      Props = [] }

            let ofHasAddons =
                function
                | IHasAddons.Left -> bulma.Field.HasAddons.Left
                | IHasAddons.Centered -> bulma.Field.HasAddons.Left ++ bulma.Field.HasAddons.Centered
                | IHasAddons.Right -> bulma.Field.HasAddons.Left ++ bulma.Field.HasAddons.Right
                | IHasAddons.FullWidth -> bulma.Field.HasAddons.Left ++ bulma.Field.HasAddons.FullWidh

            let ofIsGrouped =
                function
                | IIsGrouped.Left -> bulma.Field.IsGrouped.Left
                | IIsGrouped.Centered -> bulma.Field.IsGrouped.Left ++ bulma.Field.IsGrouped.Centered
                | IIsGrouped.Right -> bulma.Field.IsGrouped.Left ++ bulma.Field.IsGrouped.Right

            let ofLayout = function
                | Horizontal -> bulma.Field.Layout.IsHorizontal

            type FieldLabelOption =
                | Size of ISize
                | Classy of string
                | Props of IHTMLProp list

            type FieldLabelOptions =
                { Size : string option
                  Classy : string option
                  Props : IHTMLProp list }
                static member Empty =
                    { Size = None
                      Classy = None
                      Props = [] }

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
        // Extra
        let classy = Classy
        let props = Props

        let field options children =
            let parseOptions (result : Options) =
                function
                | HasAddons hasAddons -> { result with HasAddons = ofHasAddons hasAddons |> Some }
                | IsGrouped isGrouped -> { result with IsGrouped = ofIsGrouped isGrouped |> Some }
                | Layout layout -> { result with Layout = ofLayout layout |> Some }
                | Option.Classy classy -> { result with Classy = classy |> Some }
                | Option.Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions Options.Empty
            let className =
                Helpers.generateClassName bulma.Field.Container [ opts.HasAddons; opts.IsGrouped; opts.Layout; opts.Classy ]
            div
                [ yield ClassName className :> IHTMLProp
                  yield! opts.Props ]
                children



        module Label =
            // Size
            let isSmall = Size IsSmall
            let isMedium = Size IsMedium
            let isLarge = Size IsLarge
            // Extra
            let props = Props
            let classy = Classy

        let label options children =
            let parseOptions (result : FieldLabelOptions) =
                function
                | Size size -> { result with Size = ofSize size |> Some }
                | Classy classy -> { result with Classy = classy |> Some }
                | Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions FieldLabelOptions.Empty
            div
                [ yield ClassName(Helpers.generateClassName bulma.Field.Label [ opts.Size; opts.Classy ]) :> IHTMLProp
                  yield! opts.Props ]
                children

        module Body =
            let props = GenericOption.Props
            let classy = GenericOption.Classy

        let body (options : GenericOption list) children =
            let opts = genericParse options

            div
                [ yield classBaseList
                            bulma.Field.Body
                            [ opts.Classy.Value, opts.Classy.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children
