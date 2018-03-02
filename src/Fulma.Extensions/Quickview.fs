namespace Fulma.Extensions

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Quickview =

    module Classes =
        let [<Literal>] Container = "quickview"
        let [<Literal>] Header = "quickview-header"
        let [<Literal>] Title = "title"
        let [<Literal>] Body = "quickview-body"
        let [<Literal>] Block = "quickview-block"
        let [<Literal>] Footer = "quickview-footer"

        module State =
            let [<Literal>] IsActive = "is-active"

    type Option =
        | Props of IHTMLProp list
        /// Add `is-active` class if true
        | IsActive of bool
        | CustomClass of string

    type internal Options =
        { Props : IHTMLProp list
          IsActive : bool
          CustomClass : string option }

        static member Empty =
            { Props = []
              IsActive = false
              CustomClass = None }

    /// <header class="quickview-header"></header>
    let header (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Header [opts.CustomClass] []
        header (classes::opts.Props) children

    /// <p class="title"></p>
    let title (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Title [opts.CustomClass] []
        p (classes::opts.Props) children

    /// <div class="quickview-body"><div class="quickview-block"></div></div>
    let body (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Body [opts.CustomClass] []
        div (classes::opts.Props) [
          div [ ClassName Classes.Block ] children ]

    /// <footer class="quickview-footer"></footer>
    let footer (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Footer [opts.CustomClass] []
        footer (classes::opts.Props) children


    /// Generate <div class="quickview"></div>
    let quickview options children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | IsActive state -> { result with IsActive = state }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ ]
                        [ Classes.State.IsActive, opts.IsActive ]
        div (classes::opts.Props) children