namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Label =

    type Option =
        | Size of ISize
        /// Set `For` HTMLAttr
        | For of string
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    /// Generate <label class="label"></label>
    let label options children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Size size -> ofSize size |> result.AddClass
            | For htmlFor -> HtmlFor htmlFor |> result.AddProp
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "label").ToReactElement(label, children)
