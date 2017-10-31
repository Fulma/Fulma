namespace Fulma.Elements

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

module Form =

    [<RequireQualifiedAccess>]
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
        let inline hasIconLeft<'T> = HasIcon Left
        let inline hasIconRight<'T> = HasIcon Right
        // State
        let inline isLoading<'T> = IsLoading
        // Extra
        let inline customClass x = CustomClass x
        let inline props x = Props x

        let control element options children =
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
                [ yield Helpers.classes cls [] [Bulma.Form.Control.State.IsLoading, opts.IsLoading]
                  yield! opts.Props ]
                children

        let inline control_p x y = control p x y
        let inline control_div x y = control div x y

    [<RequireQualifiedAccess>]
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
        let inline isSmall<'T> = Size IsSmall
        let inline isMedium<'T> = Size IsMedium
        let inline isLarge<'T> = Size IsLarge
        // Extra
        let inline htmlFor id = For id
        let inline customClass x = CustomClass x
        let inline props x = Props x

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
                  if Option.isSome opts.HtmlFor then yield HtmlFor opts.HtmlFor.Value :> IHTMLProp
                  yield! opts.Props ]
                children

    [<RequireQualifiedAccess>]
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

        let inline props x = Props x
        let inline customClass x = CustomClass x
        // Colors
        let inline isBlack<'T> = Color IsBlack
        let inline isDark<'T> = Color IsDark
        let inline isLight<'T> = Color IsLight
        let inline isWhite<'T> = Color IsWhite
        let inline isPrimary<'T> = Color IsPrimary
        let inline isInfo<'T> = Color IsInfo
        let inline isSuccess<'T> = Color IsSuccess
        let inline isWarning<'T> = Color IsWarning
        let inline isDanger<'T> = Color IsDanger
        // State
        let inline isDisabled<'T> = State Disabled
        let inline isLoading<'T> = State Loading
        let inline isFocused<'T> = State Focused
        let inline isActive<'T> = State Active
        // Sizes
        let inline isSmall<'T> = Size Small
        let inline isMedium<'T> = Size Medium
        let inline isLarge<'T> = Size Large
        let inline isFullwidth<'T> = Size Fullwidth
        let inline isInline<'T> = Size Inline

        let select (options : Option list) children =
            let parseOptions (result : Options) =
                function
                | Size size -> { result with Size = ofSize size |> Some }
                | State state -> { result with State = ofState state |> Some }
                | Color color -> { result with Color = ofLevelAndColor color |> Some }
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = Some customClass }

            let opts = options |> List.fold parseOptions Options.Empty
            let class' = Helpers.classes Bulma.Form.Select.Container [opts.Size; opts.State; opts.Color; opts.CustomClass] []
            div (class'::opts.Props) children

    [<RequireQualifiedAccess>]
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
        let inline isSmall<'T> = Size IsSmall
        let inline isMedium<'T> = Size IsMedium
        let inline isLarge<'T> = Size IsLarge
        // Colors
        let inline isBlack<'T> = Color IsBlack
        let inline isDark<'T> = Color IsDark
        let inline isLight<'T> = Color IsLight
        let inline isWhite<'T> = Color IsWhite
        let inline isPrimary<'T> = Color IsPrimary
        let inline isInfo<'T> = Color IsInfo
        let inline isSuccess<'T> = Color IsSuccess
        let inline isWarning<'T> = Color IsWarning
        let inline isDanger<'T> = Color IsDanger
        // Types
        let inline typeIsText<'T> = Type Text
        let inline typeIsPassword<'T> = Type Password
        let inline typeIsDatetimeLocal<'T> = Type DatetimeLocal
        let inline typeIsDate<'T> = Type Date
        let inline typeIsMonth<'T> = Type Month
        let inline typeIsTime<'T> = Type Time
        let inline typeIsWeek<'T> = Type Week
        let inline typeIsNumber<'T> = Type Number
        let inline typeIsEmail<'T> = Type Email
        let inline typeIsUrl<'T> = Type Url
        let inline typeIsSearch<'T> = Type Search
        let inline typeIsTel<'T> = Type Tel
        let inline typeIsColor<'T> = Type IInputType.Color
        // Extra
        let inline id str = Id str
        let inline disabled value = Disabled value
        let inline value v = Value v
        let inline defaultValue v = DefaultValue v
        let inline placeholder str = Placeholder str
        let inline props props = Props props
        let inline customClass x = CustomClass x

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
                   if Option.isSome opts.Id then yield Props.Id opts.Id.Value :> IHTMLProp
                   if Option.isSome opts.Value then yield Props.Value opts.Value.Value :> IHTMLProp

                   if Option.isSome opts.DefaultValue then
                       yield Props.DefaultValue opts.DefaultValue.Value :> IHTMLProp
                   if Option.isSome opts.Placeholder then yield Props.Placeholder opts.Placeholder.Value :> IHTMLProp ]
                 @ opts.Props)

        // Alias to create input already typed
        let inline text options = input (Type Text :: options)
        let inline password options = input (Type Password :: options)
        let inline datetimeLocal options = input (Type DatetimeLocal :: options)
        let inline date options = input (Type Date :: options)
        let inline month options = input (Type Month :: options)
        let inline time options = input (Type Time :: options)
        let inline week options = input (Type Week :: options)
        let inline number options = input (Type Number :: options)
        let inline email options = input (Type Email :: options)
        let inline url options = input (Type Url :: options)
        let inline search options = input (Type Search :: options)
        let inline tel options = input (Type Tel :: options)
        let inline color options = input (Type IInputType.Color :: options)

    [<RequireQualifiedAccess>]
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
        let inline hasAddons<'T> = HasAddons IHasAddons.Left
        let inline hasAddonsCentered<'T> = HasAddons IHasAddons.Centered
        let inline hasAddonsRight<'T> = HasAddons IHasAddons.Right
        let inline hasAddonsFullWidth<'T> = HasAddons IHasAddons.FullWidth
        // IsGrouped
        let inline isGrouped<'T> = IsGrouped IIsGrouped.Left
        let inline isGroupedCentered<'T> = IsGrouped IIsGrouped.Centered
        let inline isGroupedRight<'T> = IsGrouped IIsGrouped.Right
        // Layout
        let inline isHorizontal<'T> = Layout Horizontal
        // Extra
        let inline customClass x = Types.CustomClass x
        let inline props x = Types.Props x

        let field element options children =
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

        let inline field_p x y = field p x y
        let inline field_div x y = field div x y

        module Label =
            // Size
            let inline isSmall<'T> = Size IsSmall
            let inline isMedium<'T> = Size IsMedium
            let inline isLarge<'T> = Size IsLarge
            // Extra
            let inline props x = Props x
            let inline customClass x = CustomClass x

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
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        let body (options : GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.Field.Body [opts.CustomClass] []
            div (class'::opts.Props) children

    [<RequireQualifiedAccess>]
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

        let inline props x = Props x
        let inline customClass x = CustomClass x
        let inline isBlack<'T> = Color IsBlack
        let inline isDark<'T> = Color IsDark
        let inline isLight<'T> = Color IsLight
        let inline isWhite<'T> = Color IsWhite
        let inline isPrimary<'T> = Color IsPrimary
        let inline isInfo<'T> = Color IsInfo
        let inline isSuccess<'T> = Color IsSuccess
        let inline isWarning<'T> = Color IsWarning
        let inline isDanger<'T> = Color IsDanger

        let help (options : Option list) children =
            let parseOptions (result: Options ) =
                function
                | CustomClass customClass -> { result with CustomClass = Some customClass }
                | Props props -> { result with Props = props }
                | Color color -> { result with Color = ofLevelAndColor color |> Some }

            let opts = options |> List.fold parseOptions Options.Empty
            let class' = Helpers.classes Bulma.Form.Help.Container [opts.CustomClass; opts.Color] []
            p (class'::opts.Props) children

    [<RequireQualifiedAccess>]
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
        let inline isDisabled<'T> = Disabled
        let inline isLoading<'T> = State Loading
        let inline isFocused<'T> = State Focused
        let inline isActive<'T> = State Active
        // Sizes
        let inline isSmall<'T> = Size Small
        let inline isMedium<'T> = Size Medium
        let inline isLarge<'T> = Size Large
        let inline isFullwidth<'T> = Size Fullwidth
        let inline isInline<'T> = Size Inline
        // Colors
        let inline isBlack<'T> = Color IsBlack
        let inline isDark<'T> = Color IsDark
        let inline isLight<'T> = Color IsLight
        let inline isWhite<'T> = Color IsWhite
        let inline isPrimary<'T> = Color IsPrimary
        let inline isInfo<'T> = Color IsInfo
        let inline isSuccess<'T> = Color IsSuccess
        let inline isWarning<'T> = Color IsWarning
        let inline isDanger<'T> = Color IsDanger
        // Extra
        let inline id str = Id str
        let inline value v = Value v
        let inline defaultValue v = DefaultValue v
        let inline placeholder str = Placeholder str
        let inline props props = Props props
        let inline customClass x = CustomClass x

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

            textarea [ yield Helpers.classes Bulma.Form.TextArea.Container [opts.Color; opts.CustomClass; opts.Size; opts.State] [Bulma.Form.TextArea.HasFixedSize, opts.HasFixedSize]
                       yield Props.Disabled opts.Disabled :> IHTMLProp
                       if Option.isSome opts.Id then yield Props.Id opts.Id.Value :> IHTMLProp
                       if Option.isSome opts.Value then yield Props.Value opts.Value.Value :> IHTMLProp
                       if Option.isSome opts.DefaultValue then yield Props.DefaultValue opts.DefaultValue.Value :> IHTMLProp
                       if Option.isSome opts.Placeholder then yield Props.Placeholder opts.Placeholder.Value :> IHTMLProp
                       yield! opts.Props ]
                children

    [<RequireQualifiedAccess>]
    module Checkbox =
        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

        let checkbox (options : GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.Checkbox [opts.CustomClass] []
            label (class'::opts.Props) children

        module Input =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        let input (options : GenericOption list) =
            let opts = genericParse options
            let class' = Helpers.classes "" [opts.CustomClass] []
            input (class'::(Type "checkbox" :> IHTMLProp)::opts.Props)

    [<RequireQualifiedAccess>]
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

        let inline props x = GenericOption.Props x
        let inline customClass x = GenericOption.CustomClass x

        let radio (options : GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.Radio [opts.CustomClass] []
            label (class'::opts.Props) children

        module Input =
            let inline props x = Input.Props x
            let inline customClass x = Input.CustomClass x
            let inline name x = Input.Name x

        let input (options : Input.Option list) =
            let parseOptions (result : Input.Options) option =
                match option with
                | Input.Name name -> { result with Name = Some name }
                | Input.CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | Input.Props props -> { result with Props = props }

            let opts = options |> List.fold parseOptions Input.Options.Empty
            let class' = Helpers.classes Bulma.Form.Radio [opts.CustomClass] []
            let t = Type "radio" :> IHTMLProp
            let attrs =
                match opts.Name with
                | Some name -> class'::t::(Name name :> IHTMLProp)::opts.Props
                | None -> class'::t::opts.Props

            input attrs

    [<RequireQualifiedAccess>]
    module File =

        module Types =

            type IState =
                | Focused
                | Active
                | Hovered

            let ofState =
                function
                | Focused -> Bulma.Form.File.State.IsFocused
                | Active -> Bulma.Form.File.State.IsActive
                | Hovered -> Bulma.Form.File.State.IsHovered

            type ISize =
                | Small
                | Medium
                | Large
                | Fullwidth

            let ofSize =
                function
                | Small -> Bulma.Form.File.Size.IsSmall
                | Medium -> Bulma.Form.File.Size.IsMedium
                | Large -> Bulma.Form.File.Size.IsLarge
                | Fullwidth -> Bulma.Form.File.Size.IsFullwidth

            type IAlignment =
                | Centered
                | Right

            let ofAlignment =
                function
                | Centered -> Bulma.Form.File.Alignment.IsCentered
                | Right -> Bulma.Form.File.Alignment.IsRight

            type Option =
                | CustomClass of string
                | Props of IHTMLProp list
                | State of IState
                | Size of ISize
                | Alignment of IAlignment
                | IsBoxed
                | HasName
                | Color of ILevelAndColor

            type Options =
                { CustomClass : string option
                  Props : IHTMLProp list
                  State : string option
                  Size : string option
                  Alignment : string option
                  IsBoxed : bool
                  Color : string option
                  HasName : bool}

                static member Empty =
                    { CustomClass = None
                      Props = []
                      State = None
                      Size = None
                      Alignment = None
                      IsBoxed = false
                      Color = None
                      HasName = false }

        open Types

        // State
        let inline isFocused<'T> = State Focused
        let inline isActive<'T> = State Active
        let inline isHovered<'T> = State Hovered
        // Size
        let inline isSmall<'T> = Size Small
        let inline isMedium<'T> = Size Medium
        let inline isLarge<'T> = Size Large
        let inline isFullwidth<'T> = Size Fullwidth
        // Colors
        let inline isBlack<'T> = IsBlack
        let inline isDark<'T> = IsDark
        let inline isLight<'T> = IsLight
        let inline isWhite<'T> = IsWhite
        let inline isPrimary<'T> = IsPrimary
        let inline isInfo<'T> = IsInfo
        let inline isSuccess<'T> = IsSuccess
        let inline isWarning<'T> = IsWarning
        let inline isDanger<'T> = IsDanger
        // Alignment
        let inline isRight<'T> = Alignment Right
        let inline isCentered<'T> = Alignment Centered
        // Extra
        let inline customClass x = CustomClass x
        let inline props x = Props x
        let inline isBoxed<'T> = IsBoxed
        let inline hasName<'T> = HasName

        let file (options : Option list) children =
            let parseOptions (result : Options) option =
                match option with
                | CustomClass customClass -> { result with CustomClass = customClass |> Some }
                | Props props -> { result with Props = props }
                | State state -> { result with State = ofState state |> Some }
                | Size size -> { result with Size = ofSize size |> Some }
                | Alignment alignment -> { result with Alignment = ofAlignment alignment |> Some }
                | Color color -> { result with Color = ofLevelAndColor color |> Some }
                | IsBoxed -> { result with IsBoxed = true }
                | HasName -> { result with HasName = true }

            let opts = options |> List.fold parseOptions Options.Empty
            let class' = Helpers.classes Bulma.Form.File.Container [opts.CustomClass; opts.State; opts.Size; opts.Alignment; opts.Color] [Bulma.Form.File.IsBoxed, opts.IsBoxed; Bulma.Form.File.HasName, opts.HasName]
            div (class'::opts.Props) children

        module Cta =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        module Name =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        module Icon =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        module Label =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        module Input =
            let inline props x = GenericOption.Props x
            let inline customClass x = GenericOption.CustomClass x

        let cta (options : GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.File.Cta [opts.CustomClass] []
            span (class'::opts.Props) children

        let name (options : GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.File.Name [opts.CustomClass] []
            span (class'::opts.Props) children

        let icon (options : GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.File.Icon [opts.CustomClass] []
            span (class'::opts.Props) children

        let label element (options : GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.File.Label [opts.CustomClass] []
            element (class'::opts.Props) children

        let inline label_label x y = label Fable.Helpers.React.label x y

        let inline label_span x y = label span x y

        let input (options : GenericOption list) =
            let opts = genericParse options
            let class' = Helpers.classes Bulma.Form.File.Input [opts.CustomClass] []
            input (class'::(Type "file" :> IHTMLProp)::opts.Props)
