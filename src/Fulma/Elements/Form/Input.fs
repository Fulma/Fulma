namespace Fulma.Elements.Form

open Fulma
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
        | Type of IInputType
        | Color of IColor
        | Id of string
        | Disabled of bool
        | IsReadOnly of bool
        | IsStatic
        | Value of string
        | DefaultValue of string
        | Placeholder of string
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
              IsReadOnly = false
              IsStatic = false
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
        | IInputType.ColorType -> "color"

    let input options =
        let parseOptions (result : Options) option =
            match option with
            | Size size -> { result with Size = ofSize size |> Some }
            | Type type' -> { result with Type = ofType type' }
            | Color color -> { result with Color = ofColor color |> Some }
            | Id id -> { result with Id = Some id }
            | Disabled disabled -> { result with Disabled = disabled }
            | IsReadOnly state -> { result with IsReadOnly = state }
            | IsStatic -> { result with IsStatic = true }
            | Value value -> { result with Value = Some value }
            | DefaultValue defaultValue -> { result with DefaultValue = Some defaultValue }
            | Placeholder placeholder -> { result with Placeholder = Some placeholder }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Size
                          opts.Color
                          opts.CustomClass ]
                        [ Classes.State.IsStatic, opts.IsStatic ]
        input
            ([ yield classes
               yield Props.Disabled opts.Disabled :> IHTMLProp
               yield ReadOnly opts.IsReadOnly :> IHTMLProp
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
    let inline color options = input (Type IInputType.ColorType :: options)
