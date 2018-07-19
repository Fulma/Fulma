namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Menu =

    module Classes =
        let [<Literal>] Container = "menu"
        let [<Literal>] Label = "menu-label"
        let [<Literal>] List = "menu-list"
        module State =
            let [<Literal>] IsActive = "is-active"

    /// Generate <aside class="menu"></aside>
    let menu (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container ( opts.CustomClass::opts.Modifiers ) []
        aside (classes::opts.Props) children

    /// Generate <p class="menu-label"></p>
    let label (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Label ( opts.CustomClass::opts.Modifiers ) []
        p (classes::opts.Props) children

    /// Generate <div class="menu-list"></div>
    let list (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.List ( opts.CustomClass::opts.Modifiers ) []
        ul (classes::opts.Props) children

    module Item =

        type Option =
            /// Add `is-active` class if true
            | IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | OnClick of (React.MouseEvent -> unit)
            | Href of string
            | Modifiers of Modifier.IModifier list

        type internal Options =
            { Props : IHTMLProp list
              IsActive : bool
              CustomClass : string option
              OnClick : (React.MouseEvent -> unit) option
              Href : string option
              Modifiers : string option list }
            static member Empty =
                { Props = []
                  IsActive = false
                  CustomClass = None
                  OnClick = None
                  Href = None
                  Modifiers = [] }

        let private itemAttrs (options : Option list) =
            let parseOptions (result: Options) =
                function
                | IsActive state -> { result with IsActive = state }
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = Some customClass }
                | OnClick cb -> { result with OnClick = cb |> Some }
                | Href href -> { result with Href = Some href }
                | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

            let opts = options |> List.fold parseOptions Options.Empty
            let classes =
                [Classes.State.IsActive, opts.IsActive]
                |> Helpers.classes "" ( opts.CustomClass::opts.Modifiers )
            let attrs =
                [ if Option.isSome opts.OnClick then
                    yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp
                  if Option.isSome opts.Href then
                    yield Props.Href opts.Href.Value :> IHTMLProp
                  yield! opts.Props ]
            (classes::attrs)

        /// Generate <li><a></a></li>
        /// You control the `a` element
        let li (options: Option list) children =
            let attrs = itemAttrs options
            li [ ] [ a attrs children ]

        /// Generate <a></a>
        let a (options: Option list) children =
            let attrs = itemAttrs options
            a attrs children
