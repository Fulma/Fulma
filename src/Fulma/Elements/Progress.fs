namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Progress =

    module Classes =
        let [<Literal>] Container = "progress"

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

    type internal Options =
        { Size : string option
          Color : string option
          Props : IHTMLProp list
          Max : int option
          Value : int option
          CustomClass : string option
          Modifiers : string option list }
        static member Empty =
            { Size = None
              Color = None
              Props = []
              Max = None
              Value = None
              CustomClass = None
              Modifiers = [] }

    /// Generate <progress class="progress"></progress>
    let progress options children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with Size = ofSize size |> Some }
            | Color color -> { result with Color = ofColor color |> Some }
            | Props props -> { result with Props = props }
            | Value value -> { result with Value = value |> Some }
            | Max max -> { result with Max = max |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.Size
                          ::opts.Color
                          ::opts.CustomClass
                          ::opts.Modifiers )
                        [ ]
        progress
            [ yield classes
              yield! opts.Props
              if Option.isSome opts.Value then yield HTMLAttr.Value (string opts.Value.Value) :> IHTMLProp
              if Option.isSome opts.Max then yield HTMLAttr.Max (float opts.Max.Value) :> IHTMLProp ]
            children
