namespace Fulma

open Fulma
open Fable.Import
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Input =

    module Classes =
        let [<Literal>] Container = "input"
        module State =
            let [<Literal>] IsFocused = "is-focused"
            let [<Literal>] IsActive = "is-active"
            let [<Literal>] IsHovered = "is-hovered"
            let [<Literal>] IsLoading = "is-loading"
            let [<Literal>] IsStatic = "is-static"
        module Styles =
            let [<Literal>] IsRounded = "is-rounded"
        module Size =
            let [<Literal>] IsSmall = "is-small"
            let [<Literal>] IsMedium = "is-medium"
            let [<Literal>] IsLarge = "is-large"
            let [<Literal>] IsFullwidth = "is-fullwidth"
            let [<Literal>] IsInline = "is-inline"

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
        | ColorType

    type Option =
        | Size of ISize
        /// Set `Type` HTMLAttr
        /// Don't use if the you used one of the helpers like: `Input.password`
        | Type of IInputType
        | Color of IColor
        /// Set `Id` HTMLAttr
        | Id of string
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        /// Set `IsReadOnly` HTMLAttr
        | IsReadOnly of bool
        /// Add `is-static` class if true
        | IsStatic of bool
        /// Add `is-rounded` class
        | IsRounded
        /// Set `Value` HTMLAttr
        | Value of string
        /// Set `DefaultValue` HTMLAttr
        | DefaultValue of string
        /// Set `Placeholder` HTMLAttr
        | Placeholder of string
        | OnChange of (React.FormEvent -> unit)
        | Ref of (Browser.Element->unit)
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { Size : string option
          Type : string
          Color : string option
          Id : string option
          Disabled : bool
          IsReadOnly : bool
          IsStatic : bool
          IsRounded : bool
          Value : string option
          DefaultValue : string option
          Placeholder : string option
          OnChange : (React.FormEvent -> unit) option
          Ref : (Browser.Element->unit) option
          Props : IHTMLProp list
          CustomClass : string option }

        static member Empty =
            { Size = None
              Type = ""
              Color = None
              Id = None
              Disabled = false
              IsReadOnly = false
              IsStatic = false
              IsRounded = false
              Value = None
              DefaultValue = None
              Placeholder = None
              OnChange = None
              Ref = None
              Props = []
              CustomClass = None }

    let private ofType =
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
        | IInputType.ColorType -> "color"

    /// Generate <input class="input" />
    let input options =
        let parseOptions (result : Options) option =
            match option with
            | Size size -> { result with Size = ofSize size |> Some }
            | Type type' -> { result with Type = ofType type' }
            | Color color -> { result with Color = ofColor color |> Some }
            | Id id -> { result with Id = Some id }
            | Disabled disabled -> { result with Disabled = disabled }
            | IsReadOnly state -> { result with IsReadOnly = state }
            | IsStatic state -> { result with IsStatic = state }
            | IsRounded -> { result with IsRounded = true }
            | Value value -> { result with Value = Some value }
            | DefaultValue defaultValue -> { result with DefaultValue = Some defaultValue }
            | Placeholder placeholder -> { result with Placeholder = Some placeholder }
            | Props props -> { result with Props = props }
            | OnChange cb -> { result with OnChange = cb |> Some }
            | Ref cb -> { result with Ref = cb |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Size
                          opts.Color
                          opts.CustomClass ]
                        [ Classes.State.IsStatic, opts.IsStatic
                          Classes.Styles.IsRounded, opts.IsRounded ]
        input
            ([ yield classes
               yield Props.Disabled opts.Disabled :> IHTMLProp
               yield ReadOnly opts.IsReadOnly :> IHTMLProp
               yield Props.Type opts.Type :> IHTMLProp
               if Option.isSome opts.Id then yield Props.Id opts.Id.Value :> IHTMLProp
               if Option.isSome opts.Value then yield Props.Value opts.Value.Value :> IHTMLProp
               if Option.isSome opts.DefaultValue then
                   yield Props.DefaultValue opts.DefaultValue.Value :> IHTMLProp
               if Option.isSome opts.Placeholder then yield Props.Placeholder opts.Placeholder.Value :> IHTMLProp
               if Option.isSome opts.OnChange then
                yield DOMAttr.OnChange opts.OnChange.Value :> IHTMLProp
               if Option.isSome opts.Ref then
                yield Prop.Ref opts.Ref.Value :> IHTMLProp ]
             @ opts.Props)

    /// Generate <input type="text" class="input" />
    let inline text options = input (Type Text :: options)
    /// Generate <input type="password" class="input" />
    let inline password options = input (Type Password :: options)
    /// Generate <input type="datetime-local" class="input" />
    let inline datetimeLocal options = input (Type DatetimeLocal :: options)
    /// Generate <input type="date" class="input" />
    let inline date options = input (Type Date :: options)
    /// Generate <input type="month" class="input" />
    let inline month options = input (Type Month :: options)
    /// Generate <input type="time" class="input" />
    let inline time options = input (Type Time :: options)
    /// Generate <input type="week" class="input" />
    let inline week options = input (Type Week :: options)
    /// Generate <input type="number" class="input" />
    let inline number options = input (Type Number :: options)
    /// Generate <input type="email" class="input" />
    let inline email options = input (Type Email :: options)
    /// Generate <input type="url" class="input" />
    let inline url options = input (Type Url :: options)
    /// Generate <input type="search" class="input" />
    let inline search options = input (Type Search :: options)
    /// Generate <input type="tel" class="input" />
    let inline tel options = input (Type Tel :: options)
    /// Generate <input type="color" class="input" />
    let inline color options = input (Type IInputType.ColorType :: options)
