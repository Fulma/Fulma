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

    module Item =
        type Option =
            /// Add `is-active` class if true
            | IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | OnClick of (React.MouseEvent -> unit)
            | Modifiers of Modifier.IModifier list

        type internal Options =
            {   Props : IHTMLProp list
                IsActive : bool
                CustomClass : string option
                OnClick : (React.MouseEvent -> unit) option
                Modifiers : string option list }
            static member Empty =
                { Props = []
                  IsActive = false
                  CustomClass = None
                  OnClick = None
                  Modifiers = [] }

    /// Generate <aside class="menu"></aside>
    let menu (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container (opts.CustomClass::opts.Modifiers) []
        aside (classes::opts.Props) children

    /// Generate <p class="menu-label"></p>
    let label (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Label (opts.CustomClass::opts.Modifiers) []
        p (classes::opts.Props) children

    /// Generate <div class="menu-list"></div>
    let list (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.List (opts.CustomClass::opts.Modifiers) []
        ul (classes::opts.Props) children

    /// Generate <li><a></a></li>
    let item (options: Item.Option list) children =
        let parseOptions (result: Item.Options) =
            function
            | Item.IsActive state -> { result with IsActive = state }
            | Item.Props props -> { result with Props = props }
            | Item.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Item.OnClick cb -> { result with OnClick = cb |> Some }
            | Item.Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Item.Options.Empty
        let classes =
            [Classes.State.IsActive, opts.IsActive]
            |> Helpers.classes Classes.List (opts.CustomClass::opts.Modifiers)
        let attrs =
            match opts.OnClick with
            | Some handler -> classes::(upcast DOMAttr.OnClick handler)::opts.Props
            | None -> classes::opts.Props

        li [ ] [ a attrs children ]
