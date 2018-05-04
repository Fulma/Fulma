namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Breadcrumb =

    module Classes =
        let [<Literal>] Container = "breadcrumb"
        module Alignment =
            let [<Literal>] IsCentered = "is-centered"
            let [<Literal>] IsRight = "is-right"
        module Separator =
            /// Alias for: has-arrow-separator
            let [<Literal>] Arrow = "has-arrow-separator"
            /// Alias for: has-bullet-separator
            let [<Literal>] Bullet = "has-bullet-separator"
            /// Alias for: has-dot-separator
            let [<Literal>] Dot = "has-dot-separator"
            /// Alias for: has-succeeds-separator
            let [<Literal>] Succeeds = "has-succeeds-separator"
        module State =
            let [<Literal>] IsActive = "is-active"

    type Option =
        /// Add `is-centered` class
        | IsCentered
        /// Add `is-right` class
        | IsRight
        /// Add `has-arrow-separator` class
        | HasArrowSeparator
        /// Add `has-bullet-separator` class
        | HasBulletSeparator
        /// Add `has-dot-separator` class
        | HasDotSeparator
        /// Add `has-succeeds-separator` class
        | HasSucceedsSeparator
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of IModifier list

    type internal Options =
        { Props : IHTMLProp list
          Alignment : string option
          Separator : string option
          Size : string option
          CustomClass : string option
          Modifiers : string option list }

        static member Empty =
            { Props = []
              Alignment = None
              Separator = None
              Size = None
              CustomClass = None
              Modifiers = [] }

    /// Generate <nav class="breadcumb"></nav>
    let breadcrumb options children =
        let parseOptions result =
            function
            | IsCentered -> { result with Alignment = Classes.Alignment.IsCentered |> Some }
            | IsRight -> { result with Alignment = Classes.Alignment.IsRight |> Some }
            // Separators
            | HasArrowSeparator -> { result with Separator = Classes.Separator.Arrow |> Some }
            | HasBulletSeparator -> { result with Separator = Classes.Separator.Bullet |> Some }
            | HasDotSeparator -> { result with Separator = Classes.Separator.Dot |> Some }
            | HasSucceedsSeparator -> { result with Separator = Classes.Separator.Succeeds |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        (opts.Alignment::opts.Separator::opts.Size::opts.CustomClass::opts.Modifiers)
                        [ ]

        nav (classes::opts.Props)
            [ ul [ ] children ]

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

    /// Generate <li></li>
    let item (options: Item.Option list) children =
        let parseOptions (result: Item.Options) =
            function
            | Item.IsActive state -> { result with IsActive = state }
            | Item.Props props -> { result with Props = props }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Item.Modifiers modifiers -> { result with Modifiers = modifiers |> parseModifiers }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        li [ yield Helpers.classes "" (opts.CustomClass::opts.Modifiers)
                        [ Classes.State.IsActive, opts.IsActive ]
             yield! opts.Props ]
            children
