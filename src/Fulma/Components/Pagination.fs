namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Pagination =

    module Classes =
        let [<Literal>] Container = "pagination"
        let [<Literal>] Previous = "pagination-previous"
        let [<Literal>] Next = "pagination-next"
        let [<Literal>] Link = "pagination-link"
        let [<Literal>] Ellipsis = "pagination-ellipsis"
        let [<Literal>] List = "pagination-list"
        module Alignment =
            let [<Literal>] Center = "is-centered"
            let [<Literal>] Right = "is-right"
        module State =
            let [<Literal>] IsCurrent = "is-current"
        module Styles =
            let [<Literal>] IsRounded = "is-rounded"

    type Option =
        /// Add `is-centered` class
        | IsCentered
        /// Add `is-right` class
        | IsRight
        /// Add `is-rounded` class
        | IsRounded
        | Size of ISize
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Alignment : string option
          Size : string option
          IsRounded : bool
          CustomClass : string option
          Props : IHTMLProp list
          Modifiers : string option list }

        static member Empty =
            { Alignment = None
              Size = None
              IsRounded = false
              CustomClass = None
              Props = []
              Modifiers = [] }

    module Link =

        type Option =
            /// Add `current` class if true
            | Current of bool
            | CustomClass of string
            | Props of IHTMLProp list
            | Modifiers of Modifier.IModifier list

        type internal Options =
            { IsCurrent : bool
              CustomClass : string option
              Props : IHTMLProp list
              Modifiers : string option list }

            static member Empty =
                { IsCurrent = false
                  CustomClass = None
                  Props = []
                  Modifiers = [] }

    /// Generate <nav class="pagination"></nav>
    let pagination (options: Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | IsCentered -> { result with Alignment = Classes.Alignment.Center |> Some }
            | IsRight -> { result with Alignment = Classes.Alignment.Right |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsRounded -> { result with IsRounded = true }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        (opts.Alignment::opts.Size::opts.CustomClass::opts.Modifiers)
                        [ Classes.Styles.IsRounded, opts.IsRounded ]

        nav (classes::opts.Props)
            children

    /// Generate <a class="pagination-previous"></a>
    let previous (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Previous (opts.CustomClass::opts.Modifiers) []
        a (classes::opts.Props) children

    /// Generate <a class="pagination-next"></a>
    let next (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Next (opts.CustomClass::opts.Modifiers) []
        a (classes::opts.Props) children

    /// Generate <li><a class="pagination-link"></a></li>
    let link (options: Link.Option list) children =
        let parseOptions (result: Link.Options) opt =
            match opt with
            | Link.Current state -> { result with IsCurrent = state }
            | Link.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Link.Props props -> { result with Props = props }
            | Link.Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Link.Options.Empty

        li [ ]
           [ a [ yield Helpers.classes Classes.Link [opts.CustomClass] [Classes.State.IsCurrent, opts.IsCurrent]
                 yield! opts.Props ]
               children ]

    /// Generate <li><a class="pagination-ellipsis">&hellip;</a></li>
    let ellipsis (options: GenericOption list) =
        let opts = genericParse options

        li [ ]
           [ span [ yield Helpers.classes Classes.Ellipsis (opts.CustomClass::opts.Modifiers) []
                    yield! opts.Props
                    yield (DangerouslySetInnerHTML { __html = "&hellip;" }) :> IHTMLProp ]
                  [ ] ]

    /// Generate <ul class="pagination-list"></ul>
    let list (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.List (opts.CustomClass::opts.Modifiers) []
        ul (classes::opts.Props) children
