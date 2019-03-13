namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props
open Browser.Types

[<RequireQualifiedAccess>]
module Menu =

    /// Generate <aside class="menu"></aside>
    let menu (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "menu").ToReactElement(aside, children)

    /// Generate <p class="menu-label"></p>
    let label (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "menu-label").ToReactElement(p, children)

    /// Generate <div class="menu-list"></div>
    let list (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOptions, "menu-list").ToReactElement(ul, children)

    module Item =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | OnClick of (MouseEvent -> unit)
            | Href of string
            | Modifiers of Modifier.IModifier list

        let private generateAnchor (options : Option list) children =
            let parseOptions (result : GenericOptions) option =
                match option with
                | IsActive state -> if state then result.AddCaseName option else result
                | OnClick cb -> DOMAttr.OnClick cb |> result.AddProp
                | Href href -> Props.Href href |> result.AddProp
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOptions).ToReactElement(a, children)

        /// Generate <li><a></a></li>
        /// You control the `a` element
        let li (options: Option list) children =
            li [ ] [ generateAnchor options children ]

        /// Generate <a></a>
        let a (options: Option list) children =
            generateAnchor options children
