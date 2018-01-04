namespace Fulma.Elements

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tag =

    module Classes =
        let [<Literal>] Container = "tag"

    type Option =
        | Size of ISize
        | Color of IColor
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { Size : string option
          Color : string option
          Props : IHTMLProp list
          CustomClass : string option }
        static member Empty =
            { Size = None
              Color = None
              Props = []
              CustomClass = None }

    let tag (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size IsSmall ->
                Fable.Import.Browser.console.warn("`is-small` is not a valid size for the tag element")
                result
            | Size size -> { result with Size = ofSize size |> Some }
            | Color color -> { result with Color = ofColor color |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Size; opts.Color; opts.CustomClass ]
                        [ ]
        span (classes::opts.Props)
            children
