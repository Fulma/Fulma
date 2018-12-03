namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Content =

    module Classes =
        let [<Literal>] Container = "content"
        module Ol =
            let [<Literal>] IsLowerRoman = "is-lower-roman"
            let [<Literal>] IsUpperRoman = "is-upper-roman"
            let [<Literal>] IsLowerAlpha = "is-lower-alpha"
            let [<Literal>] IsUpperAlpha = "is-upper-alpha"

    type Option =
        | Size of ISize
        | CustomClass of string
        | Props of IHTMLProp list
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Size : string option
          Props : IHTMLProp list
          CustomClass : string option
          Modifiers : string option list }

        static member Empty =
            { Size = None
              Props = []
              CustomClass = None
              Modifiers = [] }

    /// Generate <div class="content"></div>
    let content (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size size -> { result with Size = ofSize size |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOption Options.Empty
        let classes =
            Helpers.classes
                Classes.Container
                ( opts.CustomClass
                  ::opts.Size
                  ::opts.Modifiers ) [ ]
        div
            (classes::opts.Props)
            children

    module Ol =

        type Option =
            | IsLowerRoman
            | IsUpperRoman
            | IsLowerAlpha
            | IsUpperAlpha
            | CustomClass of string
            | Modifiers of Modifier.IModifier list
            | Props of IHTMLProp list

        type internal Options =
            { Style : string option
              Props : IHTMLProp list
              CustomClass : string option
              Modifiers : string option list }

            static member Empty =
                { Style = None
                  Props = []
                  CustomClass = None
                  Modifiers = [] }

        let ol (options : Option list) children =
            let parseOption (result : Options) opt =
                match opt with
                | IsLowerRoman -> { result with Style = Some Classes.Ol.IsLowerRoman }
                | IsUpperRoman -> { result with Style = Some Classes.Ol.IsUpperRoman }
                | IsLowerAlpha -> { result with Style = Some Classes.Ol.IsLowerAlpha }
                | IsUpperAlpha -> { result with Style = Some Classes.Ol.IsUpperAlpha }
                | Props props -> { result with Props = props }
                | CustomClass customClass -> { result with CustomClass = Some customClass }
                | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

            let opts = options |> List.fold parseOption Options.Empty
            let classes = Helpers.classes
                            Classes.Container
                            ( opts.Style
                              ::opts.CustomClass
                              ::opts.Modifiers )
                            [ ]

            ol (classes::opts.Props)
               children
