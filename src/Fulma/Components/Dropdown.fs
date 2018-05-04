namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Dropdown =

    module Classes =
        let [<Literal>] Container = "dropdown"
        let [<Literal>] Menu = "dropdown-menu"
        let [<Literal>] Content = "dropdown-content"
        let [<Literal>] Divider = "dropdown-divider"
        module State =
            let [<Literal>] IsActive = "is-active"
            let [<Literal>] IsHoverable = "is-hoverable"
            let [<Literal>] IsUp = "is-up"
        module Alignment =
            let [<Literal>] IsRight = "is-right"
        module Item =
            let [<Literal>] Container = "dropdown-item"
            module State =
                let [<Literal>] IsActive = "is-active"

    type Option =
        /// Add `is-active` class if true
        | IsActive of bool
        /// Add `is-hoverable` class
        | IsHoverable
        /// Add `is-right` class
        | IsRight
        /// Add `is-up` class
        | IsUp
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { Props : IHTMLProp list
          IsActive : bool
          IsHoverable : bool
          IsRight : bool
          IsUp : bool
          CustomClass : string option }

        static member Empty =
            { Props = []
              IsActive = false
              IsHoverable = false
              IsRight = false
              IsUp = false
              CustomClass = None }

    /// Generate <div class="dropdown"></div>
    let dropdown (options: Option list) children =
        let parseOptions (result : Options) =
            function
            | IsActive state -> { result with IsActive = state }
            | IsRight -> { result with IsRight = true }
            | IsHoverable -> { result with IsHoverable = true }
            | IsUp -> { result with IsUp = true }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            [ Classes.Alignment.IsRight, opts.IsRight
              Classes.State.IsActive, opts.IsActive
              Classes.State.IsHoverable, opts.IsHoverable
              Classes.State.IsUp, opts.IsUp ]
            |> Helpers.classes Classes.Container [opts.CustomClass]

        div (classes::opts.Props) children

    /// Generate <div class="dropdown-menu"></div>
    let menu (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Menu [opts.CustomClass] []
        div (classes::opts.Props) children

    /// Generate <div class="dropdown-content"></div>
    let content (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Content (opts.CustomClass::opts.Modifiers) []
        div (classes::opts.Props) children

    /// Generate <div class="dropdown-divider"></div>
    let divider (options: GenericOption list) =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Divider (opts.CustomClass::opts.Modifiers) []
        hr (classes::opts.Props)

    module Item =
        type Option =
            /// Add `is-active` class if true
            | IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | Modifiers of IModifier list

        type internal Options =
            { Props : IHTMLProp list
              IsActive : bool
              CustomClass : string option
              Modifiers : string option list }

            static member Empty =
                { Props = []
                  IsActive = false
                  CustomClass = None
                  Modifiers = [] }

        let internal item element (options: Option list) children =
            let parseOptions (result : Options) =
                function
                | IsActive state -> { result with IsActive = state }
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = Some customClass }
                | Modifiers modifiers -> { result with Modifiers = modifiers |> parseModifiers }

            let opts = options |> List.fold parseOptions Options.Empty
            let classes =
                [ Classes.Item.State.IsActive, opts.IsActive ]
                |> Helpers.classes Classes.Item.Container (opts.CustomClass::opts.Modifiers)

            element (classes::opts.Props) children

        /// Generate <div class="dropdown-item"></div>
        let div x y = item div x y
        /// Generate <a class="dropdown-item"></a>
        let a x y = item a x y
