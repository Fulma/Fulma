namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props
open Browser.Types

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
        /// Don't use if you used one of the helpers like: `Input.password`
        | Type of IInputType
        | Color of IColor
        /// Set `Id` HTMLAttr
        | Id of string
        /// Add `disabled` HTMLAttr if true
        | Disabled of bool
        /// Set `IsReadOnly` HTMLAttr
        | IsReadOnly of bool
        /// Add `is-static` class if true
        | [<CompiledName("is-static")>] IsStatic of bool
        /// Add `is-rounded` class
        | [<CompiledName("is-rounded")>] IsRounded
        /// Set `Value` HTMLAttr
        | Value of string
        | Key of string
        /// Set `DefaultValue` HTMLAttr
        | DefaultValue of string
        /// `Ref` callback that sets the value of an input textbox after DOM element is created.
        | ValueOrDefault of string
        /// Set `Placeholder` HTMLAttr
        | Placeholder of string
        | OnChange of (Event -> unit)
        | Ref of (Element->unit)
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    let private ofType (typ : IInputType) =
        match typ with
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

    open Fable.Core.JsInterop

    /// Generate <input class="input" />
    let input (options : Option list) =
        let parseOptions (result : GenericOptions) option =
            match option with
            | IsStatic state -> if state then result.AddCaseName option else result
            | IsRounded -> result.AddCaseName option
            | Size size -> ofSize size |> result.AddClass
            | Color color -> ofColor color |> result.AddClass
            | Type type' -> Props.Type (ofType type') |> result.AddProp
            | Id id -> Props.Id id |> result.AddProp
            | Disabled disabled -> Props.Disabled disabled |> result.AddProp
            | IsReadOnly state -> Props.ReadOnly state |> result.AddProp
            | Value value -> Props.Value value |> result.AddProp
            | DefaultValue defaultValue -> Props.DefaultValue defaultValue |> result.AddProp
            | ValueOrDefault valueOrDefault ->
                Props.Ref <| (fun e ->
                    if e |> isNull |> not
                        && !!e?value <> valueOrDefault then
                        e?value <- valueOrDefault
                ) |> result.AddProp
            | Placeholder placeholder -> Props.Placeholder placeholder |> result.AddProp
            | OnChange cb -> Props.OnChange cb |> result.AddProp
            | Ref ref -> Props.Ref ref |> result.AddProp
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers
            | Key k -> Props.Prop.Key k |> result.AddProp

        GenericOptions.Parse(options, parseOptions, "input").ToReactElement(input)

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
