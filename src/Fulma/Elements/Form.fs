namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
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
                | CustomClass of string
                | Props of IHTMLProp list

            type Options =
                { HasIconLeft : string option
                  HasIconRight : string option
                  CustomClass : string option
                  Props : IHTMLProp list
                  IsLoading : bool }
                static member Empty =
                    { HasIconLeft = None
                      HasIconRight = None
                      CustomClass = None
                      Props = []
                      IsLoading = false }

            let ofHasIcon =
                function
                | Left -> Bulma.Form.Control.HasIcon.Left
                | Right -> Bulma.Form.Control.HasIcon.Right

        open Types

        // HasIcon
        let hasIconLeft = HasIcon Left
        let hasIconRight = HasIcon Right
        // State
        let isLoading = IsLoading
        // Extra
        let customClass = CustomClass
        let props = Props

        let internal control element options children =
            let parseOptions (result : Options) =
                function
                | HasIcon Left -> { result with HasIconLeft = Bulma.Form.Control.HasIcon.Left |> Some }
                | HasIcon Right -> { result with HasIconRight = Bulma.Form.Control.HasIcon.Right |> Some }
                | CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | Props props -> { result with Props = props }
                | IsLoading -> { result with IsLoading = true }

            let opts = options |> List.fold parseOptions Options.Empty

            let cls = Helpers.generateClassName Bulma.Form.Control.Container [ opts.HasIconLeft
                                                                               opts.HasIconRight
                                                                               opts.CustomClass ]

            element
                [ yield (classBaseList cls [ Bulma.Form.Control.State.IsLoading, opts.IsLoading ]) :> IHTMLProp
                  yield! opts.Props ]
                children

        let control_p = control p
        let control_div = control div

    module Label =
        module Types =
            type Option =
                | Size of ISize
                | For of string
                | CustomClass of string
                | Props of IHTMLProp list

            type Options =
                { Size : string option
                  HtmlFor : string option
                  CustomClass : string option
                  Props : IHTMLProp list }
                static member Empty =
                    { Size = None
                      HtmlFor = None
                      CustomClass = None
                      Props = [] }

        open Types

        // Sizes
        let isSmall = Size IsSmall
        let isMedium = Size IsMedium
        let isLarge = Size IsLarge
        // Extra
        let htmlFor id = For id
        let customClass = CustomClass
        let props = Props

        let label options children =
            let parseOptions (result : Options) =
                function
                | Size size -> { result with Size = ofSize size |> Some }
                | For htmlFor -> { result with HtmlFor = htmlFor |> Some }
                | CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions Options.Empty
            label
                [ yield ClassName(Helpers.generateClassName Bulma.Form.Label.Container [ opts.Size; opts.CustomClass ]) :> IHTMLProp
                  if opts.HtmlFor.IsSome then yield HtmlFor opts.HtmlFor.Value :> IHTMLProp
                  yield! opts.Props ]
                children

    module Select =
        module Types =
            type ISize =
                | Small
                | Medium
                | Large
                | Fullwidth
                | Inline

            let ofSize =
                function
                | Small -> Bulma.Form.Select.Size.IsSmall
                | Medium -> Bulma.Form.Select.Size.IsMedium
                | Large -> Bulma.Form.Select.Size.IsLarge
                | Fullwidth -> Bulma.Form.Select.Size.IsFullwidth
                | Inline -> Bulma.Form.Select.Size.IsInline

            type IState =
                | Loading
                | Focused
                | Active
                | Disabled

            let ofState =
                function
                | Disabled -> Bulma.Form.Select.State.IsDisabled
                | Loading -> Bulma.Form.Select.State.IsLoading
                | Focused -> Bulma.Form.Select.State.IsFocused
                | Active -> Bulma.Form.Select.State.IsActive

            type Option =
                | Size of ISize
                | State of IState
                | Color of ILevelAndColor
                | Props of IHTMLProp list
                | CustomClass of string

            type Options =
                { Size : string option
                  Color : string option
                  State : string option
                  Props : IHTMLProp list
                  CustomClass : string option }
                static member Empty =
                    { Size = None
                      Color = None
                      State = None
                      Props = []
                      CustomClass = None }

        open Types

        let props = Props
        let customClass = CustomClass
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
        // State
        let isDisabled = State Disabled
        let isLoading = State Loading
        let isFocused = State Focused
        let isActive = State Active
        // Sizes
        let isSmall = Size Small
        let isMedium = Size Medium
        let isLarge = Size Large
        let isFullwidth = Size Fullwidth
        let isInline = Size Inline

        let select (options : Option list) children =
            let parseOptions (result : Options) =
                function
                | Size size -> { result with Size = ofSize size |> Some }
                | State state -> { result with State = ofState state |> Some }
                | Color color -> { result with Color = ofLevelAndColor color |> Some }
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = Some customClass }

            let opts = options |> List.fold parseOptions Options.Empty

            div [ yield classBaseList Bulma.Form.Select.Container
                                         [ opts.Size.Value, opts.Size.IsSome
                                           opts.State.Value, opts.State.IsSome
                                           opts.Color.Value, opts.Color.IsSome
                                           opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
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
                | CustomClass of string

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
                  CustomClass : string option }

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
                      CustomClass = None }

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
        let customClass = CustomClass

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
                | CustomClass customClass -> { result with CustomClass = customClass |> Some }

            let opts = options |> List.fold parseOptions Options.Empty
            let className = Helpers.generateClassName Bulma.Form.Input.Container [ opts.Size; opts.Color; opts.CustomClass ]
            input
                ([ yield ClassName className :> IHTMLProp
                   yield Props.Disabled opts.Disabled :> IHTMLProp
                   yield Props.Type opts.Type :> IHTMLProp
                   if opts.Id.IsSome then yield Props.Id opts.Id.Value :> IHTMLProp
                   if opts.Value.IsSome then yield Props.Value opts.Value.Value :> IHTMLProp

                   if opts.DefaultValue.IsSome then
                       yield Props.DefaultValue opts.DefaultValue.Value :> IHTMLProp
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
                | CustomClass of string
                | Props of IHTMLProp list

            type Options =
                { HasAddons : string option
                  IsGrouped : string option
                  Layout : string option
                  CustomClass : string option
                  Props : IHTMLProp list }
                static member Empty =
                    { HasAddons = None
                      IsGrouped = None
                      Layout = None
                      CustomClass = None
                      Props = [] }

            let ofHasAddons =
                function
                | IHasAddons.Left -> Bulma.Form.Field.HasAddons.Left
                | IHasAddons.Centered -> Bulma.Form.Field.HasAddons.Left ++ Bulma.Form.Field.HasAddons.Centered
                | IHasAddons.Right -> Bulma.Form.Field.HasAddons.Left ++ Bulma.Form.Field.HasAddons.Right
                | IHasAddons.FullWidth -> Bulma.Form.Field.HasAddons.Left ++ Bulma.Form.Field.HasAddons.FullWidh

            let ofIsGrouped =
                function
                | IIsGrouped.Left -> Bulma.Form.Field.IsGrouped.Left
                | IIsGrouped.Centered -> Bulma.Form.Field.IsGrouped.Left ++ Bulma.Form.Field.IsGrouped.Centered
                | IIsGrouped.Right -> Bulma.Form.Field.IsGrouped.Left ++ Bulma.Form.Field.IsGrouped.Right

            let ofLayout = function
                | Horizontal -> Bulma.Form.Field.Layout.IsHorizontal

            type FieldLabelOption =
                | Size of ISize
                | CustomClass of string
                | Props of IHTMLProp list

            type FieldLabelOptions =
                { Size : string option
                  CustomClass : string option
                  Props : IHTMLProp list }
                static member Empty =
                    { Size = None
                      CustomClass = None
                      Props = [] }

        open Types

        // HasAddons
        let hasAddons = HasAddons IHasAddons.Left
        let hasAddonsCentered = HasAddons IHasAddons.Centered
        let hasAddonsRight = HasAddons IHasAddons.Right
        let hasAddonsFullWidth = HasAddons IHasAddons.FullWidth
        // IsGrouped
        let isGrouped = IsGrouped IIsGrouped.Left
        let isGroupedCentered = IsGrouped IIsGrouped.Centered
        let isGroupedRight = IsGrouped IIsGrouped.Right
        // Layout
        let isHorizontal = Layout Horizontal
        // Extra
        let customClass = CustomClass
        let props = Props

        let internal field element options children =
            let parseOptions (result : Options) =
                function
                | HasAddons hasAddons -> { result with HasAddons = ofHasAddons hasAddons |> Some }
                | IsGrouped isGrouped -> { result with IsGrouped = ofIsGrouped isGrouped |> Some }
                | Layout layout -> { result with Layout = ofLayout layout |> Some }
                | Option.CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | Option.Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions Options.Empty
            let className =
                Helpers.generateClassName Bulma.Form.Field.Container [ opts.HasAddons; opts.IsGrouped; opts.Layout; opts.CustomClass ]
            element
                [ yield ClassName className :> IHTMLProp
                  yield! opts.Props ]
                children

        let field_p = field p
        let field_div = field div

        module Label =
            // Size
            let isSmall = Size IsSmall
            let isMedium = Size IsMedium
            let isLarge = Size IsLarge
            // Extra
            let props = Props
            let customClass = CustomClass

        let label options children =
            let parseOptions (result : FieldLabelOptions) =
                function
                | Size size -> { result with Size = ofSize size |> Some }
                | CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions FieldLabelOptions.Empty
            div
                [ yield ClassName(Helpers.generateClassName Bulma.Form.Field.Label [ opts.Size; opts.CustomClass ]) :> IHTMLProp
                  yield! opts.Props ]
                children

        module Body =
            let props = GenericOption.Props
            let customClass = GenericOption.CustomClass

        let body (options : GenericOption list) children =
            let opts = genericParse options

            div
                [ yield classBaseList
                            Bulma.Form.Field.Body
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children

    module Help =

        module Types =

            type Option =
                | CustomClass of string
                | Props of IHTMLProp list
                | Color of ILevelAndColor

            type Options =
                { CustomClass : string option
                  Props : IHTMLProp list
                  Color : string option }

                static member Empty =
                    { CustomClass = None
                      Props = []
                      Color = None }

        open Types

        let props = Props
        let customClass = CustomClass
        let isBlack = Color IsBlack
        let isDark = Color IsDark
        let isLight = Color IsLight
        let isWhite = Color IsWhite
        let isPrimary = Color IsPrimary
        let isInfo = Color IsInfo
        let isSuccess = Color IsSuccess
        let isWarning = Color IsWarning
        let isDanger = Color IsDanger

        let help (options : Option list) children =
            let parseOptions (result: Options ) =
                function
                | CustomClass customClass -> { result with CustomClass = Some customClass }
                | Props props -> { result with Props = props }
                | Color color -> { result with Color = ofLevelAndColor color |> Some }

            let opts = options |> List.fold parseOptions Options.Empty

            p [ yield classBaseList Bulma.Form.Help.Container
                                    [ opts.CustomClass.Value, opts.CustomClass.IsSome
                                      opts.Color.Value, opts.Color.IsSome ] :> IHTMLProp
                yield! opts.Props ]
              children

    module Textarea =
        module Types =

            type ISize =
                | Small
                | Medium
                | Large
                | Fullwidth
                | Inline

            let ofSize =
                function
                | Small -> Bulma.Form.Select.Size.IsSmall
                | Medium -> Bulma.Form.Select.Size.IsMedium
                | Large -> Bulma.Form.Select.Size.IsLarge
                | Fullwidth -> Bulma.Form.Select.Size.IsFullwidth
                | Inline -> Bulma.Form.Select.Size.IsInline

            type IState =
                | Loading
                | Focused
                | Active

            let ofState =
                function
                | Loading -> Bulma.Form.Select.State.IsLoading
                | Focused -> Bulma.Form.Select.State.IsFocused
                | Active -> Bulma.Form.Select.State.IsActive

            type Option =
                | Size of ISize
                | State of IState
                | Color of ILevelAndColor
                | Id of string
                | Disabled
                | Value of string
                | DefaultValue of string
                | Placeholder of string
                | Props of IHTMLProp list
                | CustomClass of string
                | HasFixedSize

            type Options =
                { Size : string option
                  State : string option
                  Color : string option
                  Id : string option
                  Disabled : bool
                  HasFixedSize : bool
                  Value : string option
                  DefaultValue : string option
                  Placeholder : string option
                  Props : IHTMLProp list
                  CustomClass : string option }

                static member Empty =
                    { Size = None
                      State = None
                      Color = None
                      Id = None
                      Disabled = false
                      Value = None
                      HasFixedSize = false
                      DefaultValue = None
                      Placeholder = None
                      Props = []
                      CustomClass = None }

        open Types

        // State
        let isDisabled = Disabled
        let isLoading = State Loading
        let isFocused = State Focused
        let isActive = State Active
        // Sizes
        let isSmall = Size Small
        let isMedium = Size Medium
        let isLarge = Size Large
        let isFullwidth = Size Fullwidth
        let isInline = Size Inline
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
        // Extra
        let id str = Id str
        let value v = Value v
        let defaultValue v = DefaultValue v
        let placeholder str = Placeholder str
        let props props = Props props
        let customClass = CustomClass

        let textarea options children =
            let parseOptions (result : Options) option =
                match option with
                | Size size -> { result with Size = ofSize size |> Some }
                | State state -> { result with State = ofState state |> Some }
                | Color color -> { result with Color = ofLevelAndColor color |> Some }
                | Id id -> { result with Id = Some id }
                | Disabled -> { result with Disabled = true }
                | Value value -> { result with Value = Some value }
                | DefaultValue defaultValue -> { result with DefaultValue = Some defaultValue }
                | Placeholder placeholder -> { result with Placeholder = Some placeholder }
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | HasFixedSize -> { result with HasFixedSize = true }

            let opts = options |> List.fold parseOptions Options.Empty

            textarea [ yield classBaseList Bulma.Form.TextArea.Container
                                           [ opts.Color.Value, opts.Color.IsSome
                                             opts.CustomClass.Value, opts.CustomClass.IsSome
                                             opts.Size.Value, opts.Size.IsSome
                                             opts.State.Value, opts.State.IsSome
                                             Bulma.Form.TextArea.HasFixedSize, opts.HasFixedSize ] :> IHTMLProp
                       yield Props.Disabled opts.Disabled :> IHTMLProp
                       if opts.Id.IsSome then yield Props.Id opts.Id.Value :> IHTMLProp
                       if opts.Value.IsSome then yield Props.Value opts.Value.Value :> IHTMLProp
                       if opts.DefaultValue.IsSome then yield Props.DefaultValue opts.DefaultValue.Value :> IHTMLProp
                       if opts.Placeholder.IsSome then yield Props.Placeholder opts.Placeholder.Value :> IHTMLProp
                       yield! opts.Props ]
                children

    module Checkbox =
        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

        let checkbox (options : GenericOption list) children =
            let opts = genericParse options

            label
                [ yield classBaseList
                            Bulma.Form.Checkbox
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children

        module Input =
            let props = GenericOption.Props
            let customClass = GenericOption.CustomClass

        let input (options : GenericOption list) =
            let opts = genericParse options

            input
                [ yield classList [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield Type "checkbox" :> IHTMLProp
                  yield! opts.Props ]

    module Radio =

        module Types =

            module Input =

                type Option =
                    | CustomClass of string
                    | Props of IHTMLProp list
                    | Name of string

                type Options =
                    { CustomClass : string option
                      Props : IHTMLProp list
                      Name : string option }

                    static member Empty =
                        { CustomClass = None
                          Props = []
                          Name = None }

        open Types

        let props = GenericOption.Props
        let customClass = GenericOption.CustomClass

        let radio (options : GenericOption list) children =
            let opts = genericParse options

            label
                [ yield classBaseList
                            Bulma.Form.Radio
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children

        module Input =
            let props = Input.Props
            let customClass = Input.CustomClass
            let name = Input.Name

        let input (options : Input.Option list) =
            let parseOptions (result : Input.Options) option =
                match option with
                | Input.Name name -> { result with Name = Some name }
                | Input.CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | Input.Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions Input.Options.Empty

            input
                [ yield classList [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield Type "radio" :> IHTMLProp
                  if opts.Name.IsSome then
                    yield Name opts.Name.Value :> IHTMLProp
                  yield! opts.Props ]
