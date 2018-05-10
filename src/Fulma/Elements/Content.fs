namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Content =

    module Classes =
        let [<Literal>] Container = "content"

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
