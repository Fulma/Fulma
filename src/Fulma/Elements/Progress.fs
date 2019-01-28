namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Progress =

    type Option =
        | Size of ISize
        | Color of IColor
        | Props of IHTMLProp list
        /// Set `Value` HTMLAttr
        | Value of int
        /// Set `Max` HTMLAttr
        | Max of int
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    /// Generate <progress class="progress"></progress>
    let progress options children =
        let parseOption (result : GenericOptions) =
            function
            | Value value -> HTMLAttr.Value (float value) |> result.AddProp
            | Max max -> HTMLAttr.Max (float max) |> result.AddProp
            | Size size -> ofSize size |> result.AddClass
            | Color color -> ofColor color |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOption, "progress").ToReactElement(progress, children)
