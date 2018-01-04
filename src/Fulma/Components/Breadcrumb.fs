namespace Fulma.Components

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
        | IsCentered
        | IsRight
        // Separators
        | HasArrowSeparator
        | HasBulletSeparator
        | HasDotSeparator
        | HasSucceedsSeparator
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { Props : IHTMLProp list
          Alignment : string option
          Separator : string option
          Size : string option
          CustomClass : string option }

        static member Empty =
            { Props = []
              Alignment = None
              Separator = None
              Size = None
              CustomClass = None }

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

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Alignment; opts.Separator; opts.Size; opts.CustomClass ]
                        [ ]

        nav (classes::opts.Props)
            [ ul [ ] children ]

    module Item =

        type Option =
            | IsActive
            | Props of IHTMLProp list
            | CustomClass of string

        type internal Options =
            { Props : IHTMLProp list
              IsActive : bool
              CustomClass : string option }

            static member Empty =
                { Props = []
                  IsActive = false
                  CustomClass = None }

    let item (options: Item.Option list) children =
        let parseOptions (result: Item.Options) =
            function
            | Item.IsActive -> { result with IsActive = true }
            | Item.Props props -> { result with Props = props }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Item.Options.Empty

        li [ yield Helpers.classes "" [ opts.CustomClass ]
                        [ Classes.State.IsActive, opts.IsActive ]
             yield! opts.Props ]
            children
