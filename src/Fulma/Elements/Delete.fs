namespace Fulma

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Delete =

    type Option =
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string
        | OnClick of (MouseEvent -> unit)
        | Modifiers of Modifier.IModifier list

    /// Generate <a class="delete"></a>
    let delete (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            // Sizes
            | Size size -> ofSize size |> result.AddClass
            // Extra
            | OnClick cb -> DOMAttr.OnClick cb |> result.AddProp
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "delete").ToReactElement(a, children)
