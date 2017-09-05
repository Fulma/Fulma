namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common

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
                    let State = genericIsActiveState
                    let [<Literal>] IsToday = "is-today"

            let [<Literal>] Events = "calendar-events"

            module Event =
                let [<Literal>] Container = "calendar-event"
                let Color = levelAndColor

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

    let customClass = CustomClass
    let props = Props
    let isLarge = IsLarge

    module Event =
        let customClass = Event.CustomClass
        let props = Event.Props
        let isBlack = Event.Color IsBlack
        let isDark = Event.Color IsDark
        let isLight = Event.Color IsLight
        let isWhite = Event.Color IsWhite
        let isPrimary = Event.Color IsPrimary
        let isInfo = Event.Color IsInfo
        let isSuccess = Event.Color IsSuccess
        let isWarning = Event.Color IsWarning
        let isDanger = Event.Color IsDanger

    module Header =
        let customClass = GenericOption.CustomClass
        let props = GenericOption.Props

    module Body =
        let customClass = GenericOption.CustomClass
        let props = GenericOption.Props

    module Events =
        let customClass = GenericOption.CustomClass
        let props = GenericOption.Props

    let calendar (options : Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | IsLarge -> { result with IsLarge = true }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield classBaseList
                        Classes.Calendar.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome
                          Classes.Calendar.Size.IsLarge, opts.IsLarge ] :> IHTMLProp
              yield! opts.Props ]
            children

    let header (options: GenericOption list) children =
        let opts = genericParse options

        div
            [ yield classBaseList
                        Classes.Calendar.Header
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let body (options: GenericOption list) children =
        let opts = genericParse options

        div
            [ yield classBaseList
                        Classes.Calendar.Body
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    let events (options: GenericOption list) children =
        let opts = genericParse options

        div
            [ yield classBaseList
                        Classes.Calendar.Events
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    module Date =
        let customClass = Date.CustomClass
        let props = Date.Props
        let isDisabled = Date.IsDisabled
        let isRange = Date.Range Date.IRange.Standard
        let isRangeStart = Date.Range Date.IRange.Start
        let isRangeEnd =Date.Range Date.IRange.End

        module Item =
            let customClass = Item.CustomClass
            let props = Item.Props
            let isToday = Item.IsToday
            let isActive = Item.IsActive

        let date (options : Date.Option list) children =
            let parseOptions (result: Date.Options) opt =
                match opt with
                | Date.Props props -> { result with Props = props }
                | Date.CustomClass customClass -> { result with CustomClass = Some customClass }
                | Date.Range range -> { result with Range = Date.ofRange range |> Some }
                | Date.IsDisabled -> { result with IsDisabled = true }

            let opts = options |> List.fold parseOptions Date.Options.Empty

            div [ yield classBaseList
                            Classes.Calendar.Date.Container
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome
                              opts.Range.Value, opts.Range.IsSome
                              Classes.Calendar.Date.IsDisabled, opts.IsDisabled ] :> IHTMLProp
                  yield! opts.Props ]
                children

        let item (options : Item.Option list) children =
            let parseOptions (result: Item.Options) opt =
                match opt with
                | Item.Props props -> { result with Props = props }
                | Item.CustomClass customClass -> { result with CustomClass = Some customClass }
                | Item.IsActive -> { result with IsActive = true }
                | Item.IsToday -> { result with IsToday = true }

            let opts = options |> List.fold parseOptions Item.Options.Empty

            button [ yield classBaseList
                            Classes.Calendar.Date.Item.Container
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome
                              Classes.Calendar.Date.Item.IsToday, opts.IsToday
                              Classes.Calendar.Date.Item.State.IsActive, opts.IsActive ] :> IHTMLProp
                     yield! opts.Props ]
                children

    let event (options : Event.Option list) children =
        let parseOptions (result: Event.Options) opt =
            match opt with
            | Event.Props props -> { result with Props = props }
            | Event.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Event.Color color -> { result with Color = ofLevelAndColor color |> Some }

        let opts = options |> List.fold parseOptions Event.Options.Empty

        div [ yield classBaseList
                        Classes.Calendar.Event.Container
                        [ opts.CustomClass.Value, opts.CustomClass.IsSome
                          opts.Color.Value, opts.Color.IsSome ] :> IHTMLProp
              yield! opts.Props ]
            children

    module Nav =
        let customClass = GenericOption.CustomClass
        let props = GenericOption.Props

        module Left =
            let customClass = GenericOption.CustomClass
            let props = GenericOption.Props

        module Right =
            let customClass = GenericOption.CustomClass
            let props = GenericOption.Props

        let nav (options: GenericOption list) children =
            let opts = genericParse options

            div
                [ yield classBaseList
                            Classes.Calendar.Nav.Container
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children

        let left (options: GenericOption list) children =
            let opts = genericParse options

            div
                [ yield classBaseList
                            Classes.Calendar.Nav.Left
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children

        let right (options: GenericOption list) children =
            let opts = genericParse options

            div
                [ yield classBaseList
                            Classes.Calendar.Nav.Right
                            [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                  yield! opts.Props ]
                children
