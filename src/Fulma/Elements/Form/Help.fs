namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Help =

    module Classes =
        let [<Literal>] Container = "help"

    type Option =
        | CustomClass of string
        | Props of IHTMLProp list
        | Color of IColor
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { CustomClass : string option
          Props : IHTMLProp list
          Color : string option
          Modifiers : string option list }

        static member Empty =
            { CustomClass = None
              Props = []
              Color = None
              Modifiers = [] }

    /// Generate <p class="help"></p>
    let help (options : Option list) children =
        let parseOptions (result: Options ) =
            function
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }
            | Color color -> { result with Color = ofColor color |> Some }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            Helpers.classes
                Classes.Container
                ( opts.CustomClass
                  ::opts.Color
                  ::opts.Modifiers )
                [ ]

        p (classes::opts.Props) children
