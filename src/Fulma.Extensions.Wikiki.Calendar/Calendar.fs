namespace Fulma.Extensions.Wikiki

open Fulma

[<RequireQualifiedAccess>]
module Calendar =

    open Fable.React
    open Fable.React.Props

    type Option =
        | CustomClass of string
        | Props of IHTMLProp list
        /// Add `is-large` class
        | [<CompiledName("is-large")>] IsLarge

    /// Generate <div class="calendar"></div>
    let calendar (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | IsLarge -> result.AddCaseName option

        GenericOptions.Parse(options, parseOptions, "calendar").ToReactElement(div, children)

    /// Generate <div class="calendar-header"></div>
    let header (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "calendar-header").ToReactElement(div, children)

    /// Generate <div class="calendar-body"></div>
    let body (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "calendar-body").ToReactElement(div, children)

    /// Generate <div class="calendar-events"></div>
    let events (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "calendar-events").ToReactElement(div, children)

    module Date =

        type Option =
            | CustomClass of string
            | Props of IHTMLProp list
            /// Add `is-disabled` class if true
            | [<CompiledName("is-disabled")>] IsDisabled of bool
            /// Add `calendar-range range-start` class
            | [<CompiledName("range-start")>] IsRangeStart
            /// Add `calendar-range` class
            | [<CompiledName("calendar-range")>] IsRange
            /// Add `calendar-range range-end` class
            | [<CompiledName("range-end")>] IsRangeEnd

        module Item =

            type Option =
                | CustomClass of string
                | Props of IHTMLProp list
                /// Add `is-today` class if true
                | [<CompiledName("is-today")>] IsToday of bool
                /// Add `is-active` class if true
                | [<CompiledName("is-active")>] IsActive of bool

        /// Generate <div class="calendar-date"></div>
        let date (options : Option list) children =
            let parseOptions (result: GenericOptions) option =
                match option with
                | IsRangeStart -> result.AddClass("calendar-range").AddCaseName option
                | IsRangeEnd -> result.AddClass("calendar-range").AddCaseName option
                | IsRange -> result.AddCaseName option
                | IsDisabled state -> if state then result.AddCaseName option else result
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass

            GenericOptions.Parse(options, parseOptions, "calendar-date").ToReactElement(div, children)

        /// Generate <button class="date-item"></button>
        let item (options : Item.Option list) children =
            let parseOptions (result: GenericOptions) option =
                match option with
                | Item.IsActive state -> if state then result.AddCaseName option else result
                | Item.IsToday state -> if state then result.AddCaseName option else result
                | Item.Props props -> result.AddProps props
                | Item.CustomClass customClass -> result.AddClass customClass

            GenericOptions.Parse(options, parseOptions, "date-item").ToReactElement(button, children)

    module Event =
        type Option =
            | CustomClass of string
            | Props of IHTMLProp list
            | Color of IColor

    /// Generate <div class="calendar-event"></div>
    let event (options : Event.Option list) children =
        let parseOptions (result: GenericOptions) option =
            match option with
            | Event.Color color -> ofColor color |> result.AddClass
            | Event.Props props -> result.AddProps props
            | Event.CustomClass customClass -> result.AddClass customClass

        GenericOptions.Parse(options, parseOptions, "calendar-event").ToReactElement(div, children)

    module Nav =
        /// Generate <div class="calendar-nav"></div>
        let nav (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "calendar-nav").ToReactElement(div, children)

        /// Generate <div class="calendar-nav-left"></div>
        let left (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "calendar-nav-left").ToReactElement(div, children)

        /// Generate <div class="calendar-nav-right"></div>
        let right (options: GenericOption list) children =
            GenericOptions.Parse(options, parseOptions, "calendar-nav-right").ToReactElement(div, children)
