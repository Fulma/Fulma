namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common

[<RequireQualifiedAccess>]
module Calendar =

    module Classes =

        module Calendar =
            let [<Literal>] Container = "calendar"
            module Size =
                let [<Literal>] IsLarge = "is-large"

            module Nav =
                let [<Literal>] Container = "calendar-nav"
                let [<Literal>] Left = "calendar-nav-left"
                let [<Literal>] Right = "calendar-nav-right"

            let [<Literal>] Header = "calendar-header"
            let [<Literal>] Body = "calendar-body"

            module Date =
                let [<Literal>] Container = "calendar-date"
                let [<Literal>] IsDisabled  = "is-disabled"

                let [<Literal>] Range = "calendar-range"
                let [<Literal>] RangeStart = "range-start"
                let [<Literal>] RangeEnd = "range-end"

                module Item =
                    let [<Literal>] Container = "date-item"
                    let inline State<'T> = genericIsActiveState
                    let [<Literal>] IsToday = "is-today"

            let [<Literal>] Events = "calendar-events"

            module Event =
                let [<Literal>] Container = "calendar-event"
                let inline Color<'T> = levelAndColor

    open Fable.Helpers.React
    open Fable.Helpers.React.Props

    module Types =

        type Option =
            | CustomClass of string
            | Props of IHTMLProp list
            | IsLarge

        type Options =
            { CustomClass : string option
              Props : IHTMLProp list
              IsLarge : bool }

            static member Empty =
                { CustomClass = None
                  Props = []
                  IsLarge = false }

        module Date =

            type IRange =
                | Start
                | Standard
                | End

            type Option =
                | CustomClass of string
                | Props of IHTMLProp list
                | IsDisabled
                | Range of IRange

            let ofRange =
                function
                | Start -> Classes.Calendar.Date.Range ++ Classes.Calendar.Date.RangeStart
                | Standard -> Classes.Calendar.Date.Range
                | End -> Classes.Calendar.Date.Range ++ Classes.Calendar.Date.RangeEnd

            type Options =
                { CustomClass : string option
                  Props : IHTMLProp list
                  Range : string option
                  IsDisabled : bool }

                static member Empty =
                    { CustomClass = None
                      Props = []
                      Range = None
                      IsDisabled = false }

        module Item =

            type Option =
                | CustomClass of string
                | Props of IHTMLProp list
                | IsToday
                | IsActive

            type Options =
                { CustomClass : string option
                  Props : IHTMLProp list
                  IsToday : bool
                  IsActive : bool }

                static member Empty =
                    { CustomClass = None
                      Props = []
                      IsToday = false
                      IsActive = false }

        module Event =
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

    open Fulma.Common
    open Types

    let inline customClass x = CustomClass x
    let inline props x = Props x
    let inline isLarge<'T> = IsLarge

    module Event =
        let inline customClass x = Event.CustomClass x
        let inline props x = Event.Props x
        let inline isBlack<'T> = Event.Color IsBlack
        let inline isDark<'T> = Event.Color IsDark
        let inline isLight<'T> = Event.Color IsLight
        let inline isWhite<'T> = Event.Color IsWhite
        let inline isPrimary<'T> = Event.Color IsPrimary
        let inline isInfo<'T> = Event.Color IsInfo
        let inline isSuccess<'T> = Event.Color IsSuccess
        let inline isWarning<'T> = Event.Color IsWarning
        let inline isDanger<'T> = Event.Color IsDanger

    module Header =
        let inline customClass x = GenericOption.CustomClass x
        let inline props x = GenericOption.Props x

    module Body =
        let inline customClass x = GenericOption.CustomClass x
        let inline props x = GenericOption.Props x

    module Events =
        let inline customClass x = GenericOption.CustomClass x
        let inline props x = GenericOption.Props x

    let calendar (options : Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | IsLarge -> { result with IsLarge = true }

        let opts = options |> List.fold parseOptions Options.Empty
        let class' =
            [ Classes.Calendar.Size.IsLarge, opts.IsLarge ]
            |> Helpers.classes Classes.Calendar.Container [opts.CustomClass]

        div (class'::opts.Props) children

    let header (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Classes.Calendar.Header [opts.CustomClass] []

        div (class'::opts.Props) children

    let body (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Classes.Calendar.Body [opts.CustomClass] []

        div (class'::opts.Props) children

    let events (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Classes.Calendar.Events [opts.CustomClass] []

        div (class'::opts.Props) children

    module Date =
        let inline customClass x = Date.CustomClass x
        let inline props x = Date.Props x
        let inline isDisabled<'T> = Date.IsDisabled
        let inline isRange<'T> = Date.Range Date.IRange.Standard
        let inline isRangeStart<'T> = Date.Range Date.IRange.Start
        let inline isRangeEnd<'T> = Date.Range Date.IRange.End

        module Item =
            let inline customClass x = Item.CustomClass x
            let inline props x = Item.Props x
            let inline isToday<'T> = Item.IsToday
            let inline isActive<'T> = Item.IsActive

        let date (options : Date.Option list) children =
            let parseOptions (result: Date.Options) opt =
                match opt with
                | Date.Props props -> { result with Props = props }
                | Date.CustomClass customClass -> { result with CustomClass = Some customClass }
                | Date.Range range -> { result with Range = Date.ofRange range |> Some }
                | Date.IsDisabled -> { result with IsDisabled = true }

            let opts = options |> List.fold parseOptions Date.Options.Empty
            let class' =
                [ Classes.Calendar.Date.IsDisabled, opts.IsDisabled ]
                |> Helpers.classes Classes.Calendar.Date.Container [opts.CustomClass; opts.Range]

            div (class'::opts.Props) children

        let item (options : Item.Option list) children =
            let parseOptions (result: Item.Options) opt =
                match opt with
                | Item.Props props -> { result with Props = props }
                | Item.CustomClass customClass -> { result with CustomClass = Some customClass }
                | Item.IsActive -> { result with IsActive = true }
                | Item.IsToday -> { result with IsToday = true }

            let opts = options |> List.fold parseOptions Item.Options.Empty
            let class' =
                [ Classes.Calendar.Date.Item.IsToday, opts.IsToday
                  Classes.Calendar.Date.Item.State.IsActive, opts.IsActive ]
                |> Helpers.classes Classes.Calendar.Date.Item.Container [opts.CustomClass]

            button (class'::opts.Props) children

    let event (options : Event.Option list) children =
        let parseOptions (result: Event.Options) opt =
            match opt with
            | Event.Props props -> { result with Props = props }
            | Event.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Event.Color color -> { result with Color = ofLevelAndColor color |> Some }

        let opts = options |> List.fold parseOptions Event.Options.Empty
        let class' = Helpers.classes Classes.Calendar.Event.Container [opts.CustomClass; opts.Color] []

        div (class'::opts.Props) children

    module Nav =
        let inline customClass x = GenericOption.CustomClass x
        let inline props x = GenericOption.Props x

        module Left =
            let inline customClass x = GenericOption.CustomClass x
            let inline props x = GenericOption.Props x

        module Right =
            let inline customClass x = GenericOption.CustomClass x
            let inline props x = GenericOption.Props x

        let nav (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Classes.Calendar.Nav.Container [opts.CustomClass] []

            div (class'::opts.Props) children

        let left (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Classes.Calendar.Nav.Left [opts.CustomClass] []

            div (class'::opts.Props) children

        let right (options: GenericOption list) children =
            let opts = genericParse options
            let class' = Helpers.classes Classes.Calendar.Nav.Right [opts.CustomClass] []

            div (class'::opts.Props) children
