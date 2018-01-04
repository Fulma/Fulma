namespace Fulma.Elements

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
        | Value of int
        | Max of int
        | CustomClass of string

    type internal Options =
        { Size : string option
          Color : string option
          Props : IHTMLProp list
          Max : int option
          Value : int option
          CustomClass : string option }
        static member Empty =
            { Size = None
              Color = None
              Props = []
              Max = None
              Value = None
              CustomClass = None }

    let progress options children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with Size = ofSize size |> Some }
            | Color color -> { result with Color = ofColor color |> Some }
            | Props props -> { result with Props = props }
            | Value value -> { result with Value = value |> Some }
            | Max max -> { result with Max = max |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Size; opts.Color; opts.CustomClass ]
                        [ ]
        progress
            [ yield classes
              yield! opts.Props
              if Option.isSome opts.Value then yield HTMLAttr.Value (string opts.Value.Value) :> IHTMLProp
              if Option.isSome opts.Max then yield HTMLAttr.Max (float opts.Max.Value) :> IHTMLProp ]
            children
