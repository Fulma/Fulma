namespace Fulma

open Fulma
open Fable.React
open Fable.React.Props

[<RequireQualifiedAccess>]
module Help =

    type Option =
        | CustomClass of string
        | Props of IHTMLProp list
        | Color of IColor
        | Modifiers of Modifier.IModifier list

    /// Generate <p class="help"></p>
    let help (options : Option list) children =
        let parseOptions (result : GenericOptions) option =
            match option with
            | Color color -> ofColor color |> result.AddClass
            | Props props -> result.AddProps props
            | CustomClass customClass -> result.AddClass customClass
            | Modifiers modifiers -> result.AddModifiers modifiers

        GenericOptions.Parse(options, parseOptions, "help").ToReactElement(p, children)
