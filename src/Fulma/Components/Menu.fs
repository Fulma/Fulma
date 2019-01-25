namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Menu =

    /// Generate <aside class="menu"></aside>
    let menu (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "menu").ToReactElement(aside, children)

    /// Generate <p class="menu-label"></p>
    let label (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "menu-label").ToReactElement(p, children)

    /// Generate <div class="menu-list"></div>
    let list (options: GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "menu-list").ToReactElement(ul, children)

    module Item =

        type Option =
            /// Add `is-active` class if true
            | [<CompiledName("is-active")>] IsActive of bool
            | Props of IHTMLProp list
            | CustomClass of string
            | OnClick of (React.MouseEvent -> unit)
            | Href of string
            | Modifiers of Modifier.IModifier list

        let private generateAnchor (options : Option list) children =
            let parseOption (result: GenericOptions) opt =
                match opt with
                | IsActive state -> if state then result.AddCaseName opt else result
                | OnClick cb -> DOMAttr.OnClick cb |> result.AddProp
                | Href href -> Props.Href href |> result.AddProp
                | Props props -> result.AddProps props
                | CustomClass customClass -> result.AddClass customClass
                | Modifiers modifiers -> result.AddModifiers modifiers

            GenericOptions.Parse(options, parseOption).ToReactElement(a, children)

        /// Generate <li><a></a></li>
        /// You control the `a` element
        let li (options: Option list) children =
            li [ ] [ generateAnchor options children ]

        /// Generate <a></a>
        let a (options: Option list) children =
            generateAnchor options children
