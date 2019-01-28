namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Radio =

    module Input =

        type Option =
            | CustomClass of string
            | Props of IHTMLProp list
            /// Set `Name` HTMLAtrr
            | Name of string
            | Modifiers of Modifier.IModifier list

    /// Generate <label class="radio"></label>
    let radio (options : GenericOption list) children =
        GenericOptions.Parse(options, parseOption, "radio").ToReactElement(label, children)

    /// Generate <input class="radio" />
    let input (options : Input.Option list) =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Input.Name name -> Props.Name name |> result.AddProp
            | Input.Props props -> result.AddProps props
            | Input.CustomClass customClass -> result.AddClass customClass
            | Input.Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "radio", [ Type "radio" ]).ToReactElement(input)
