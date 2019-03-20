namespace Fulma.Extensions

open Fulma

[<RequireQualifiedAccess>]
[<System.ObsoleteAttribute("Fulma.Extensions is obselete please use Fulma.Extensions.Wikiki.Calendar package instead")>]
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
                    module State =
                        let [<Literal>] IsActive = "is-active"
                    let [<Literal>] IsToday = "is-today"

            let [<Literal>] Events = "calendar-events"

            module Event =
                let [<Literal>] Container = "calendar-event"

    open Fable.React
    open Fable.React.Props

    type Option =
        | CustomClass of string
        | Props of IHTMLProp list
        | IsLarge

    type internal Options =
        { CustomClass : string option
          Props : IHTMLProp list
          IsLarge : bool }

        static member Empty =
            { CustomClass = None
              Props = []
              IsLarge = false }

    let calendar (options : Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | IsLarge -> { result with IsLarge = true }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            [ Classes.Calendar.Size.IsLarge, opts.IsLarge ]
            |> Helpers.classes Classes.Calendar.Container [opts.CustomClass]

        div (classes::opts.Props) children

    let header (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Calendar.Header [opts.CustomClass] []

        div (classes::opts.Props) children

    let body (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Calendar.Body [opts.CustomClass] []

        div (classes::opts.Props) children

    let events (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Calendar.Events [opts.CustomClass] []

        div (classes::opts.Props) children

    module Date =

        type Option =
            | CustomClass of string
            | Props of IHTMLProp list
            /// Add `is-disabled` class if true
            | Disabled of bool
            | IsRangeStart
            | IsRange
            | IsRangeEnd

        type internal Options =
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
                /// Add `is-active` class if true
                | IsActive of bool

            type internal Options =
                { CustomClass : string option
                  Props : IHTMLProp list
                  IsToday : bool
                  IsActive : bool }

                static member Empty =
                    { CustomClass = None
                      Props = []
                      IsToday = false
                      IsActive = false }


        let date (options : Option list) children =
            let parseOptions (result: Options) opt =
                match opt with
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = Some customClass }
                | IsRangeStart -> { result with Range = Classes.Calendar.Date.Range + " " + Classes.Calendar.Date.RangeStart |> Some }
                | IsRange -> { result with Range = Classes.Calendar.Date.Range |> Some }
                | IsRangeEnd -> { result with Range = Classes.Calendar.Date.Range + " " + Classes.Calendar.Date.RangeEnd |> Some }
                | Disabled state -> { result with IsDisabled = state }

            let opts = options |> List.fold parseOptions Options.Empty
            let classes =
                [ Classes.Calendar.Date.IsDisabled, opts.IsDisabled ]
                |> Helpers.classes Classes.Calendar.Date.Container [opts.CustomClass; opts.Range]

            div (classes::opts.Props) children

        let item (options : Item.Option list) children =
            let parseOptions (result: Item.Options) opt =
                match opt with
                | Item.Props props -> { result with Props = props }
                | Item.CustomClass customClass -> { result with CustomClass = Some customClass }
                | Item.IsActive state -> { result with IsActive = state }
                | Item.IsToday -> { result with IsToday = true }

            let opts = options |> List.fold parseOptions Item.Options.Empty
            let classes =
                [ Classes.Calendar.Date.Item.IsToday, opts.IsToday
                  Classes.Calendar.Date.Item.State.IsActive, opts.IsActive ]
                |> Helpers.classes Classes.Calendar.Date.Item.Container [opts.CustomClass]

            button (classes::opts.Props) children

    module Event =
        type Option =
            | CustomClass of string
            | Props of IHTMLProp list
            | Color of IColor

        type internal Options =
            { CustomClass : string option
              Props : IHTMLProp list
              Color : string option }

            static member Empty =
                { CustomClass = None
                  Props = []
                  Color = None }

    let event (options : Event.Option list) children =
        let parseOptions (result: Event.Options) opt =
            match opt with
            | Event.Props props -> { result with Props = props }
            | Event.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Event.Color color -> { result with Color = ofColor color |> Some }

        let opts = options |> List.fold parseOptions Event.Options.Empty
        let classes = Helpers.classes Classes.Calendar.Event.Container [opts.CustomClass; opts.Color] []

        div (classes::opts.Props) children

    module Nav =
        let nav (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Calendar.Nav.Container [opts.CustomClass] []

            div (classes::opts.Props) children

        let left (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Calendar.Nav.Left [opts.CustomClass] []

            div (classes::opts.Props) children

        let right (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Calendar.Nav.Right [opts.CustomClass] []

            div (classes::opts.Props) children
