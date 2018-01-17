namespace Fulma.Extensions

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module PageLoader =

    module Classes =
        let [<Literal>] PageLoader = "pageloader"
        let [<Literal>] IsActive = "is-active"

    type Option =
        /// Add `is-active` class if true
        | IsActive of bool
        | Color of IColor
        | Props of IHTMLProp list
        | CustomClass of string


    type internal Options =
        { IsActive : bool
          Color : string option
          Props : IHTMLProp list
          CustomClass : string option
        }
        static member Empty =
            { IsActive = false
              Color = None
              Props = []
              CustomClass = None }

    let pageLoader (options : Option list) children =

        let parseOptions (result: Options) opt =
            match opt with
            | Option.Color color -> { result with Color = ofColor color |> Some }
            | IsActive state -> { result with IsActive = state }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes Classes.PageLoader [opts.CustomClass; opts.Color] [Classes.IsActive, opts.IsActive]
        div (classes::opts.Props) children
