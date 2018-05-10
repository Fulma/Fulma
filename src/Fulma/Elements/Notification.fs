namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Notification =

    module Classes =
        let [<Literal>] Container = "notification"
        module Delete =
            let [<Literal>] Container = "delete"

    type Option =
        | Color of IColor
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Color : string option
          CustomClass : string option
          Props : IHTMLProp list
          Modifiers : string option list }
        static member Empty =
            { Color = None
              CustomClass = None
              Props = []
              Modifiers = [] }

    /// Generate <div class="notification"></div>
    let notification (options : Option list) children =
        let parseOptions (result : Options) opt =
            match opt with
            | Color color -> { result with Color = ofColor color |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes Classes.Container ( opts.CustomClass::opts.Color::opts.Modifiers ) []
        div (classes::opts.Props) children

    /// Generate <button class="delete"></button>
    let delete (options: GenericOption list) children =
        let opts = genericParse options
        button
            [ yield Helpers.classes Classes.Delete.Container ( opts.CustomClass::opts.Modifiers ) []
              yield! opts.Props ]
            children
