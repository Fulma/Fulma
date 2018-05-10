namespace Fulma

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Delete =

    module Classes =
        let [<Literal>] Container = "delete"

    type Option =
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string
        | OnClick of (MouseEvent -> unit)
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Size : string option
          Props : IHTMLProp list
          CustomClass : string option
          OnClick : (MouseEvent -> unit) option
          Modifiers : string option list }
        static member Empty =
            { Size = None
              Props = []
              CustomClass = None
              OnClick = None
              Modifiers = [] }

    /// Generate <a class="delete"></a>
    let delete (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            // Sizes
            | Size size -> { result with Size = ofSize size |> Some }
            // Extra
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | OnClick cb -> { result with OnClick = cb |> Some }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOption Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.Size
                          ::opts.CustomClass
                          ::opts.Modifiers )
                        [ ]
        a [ yield classes
            yield! opts.Props
            if Option.isSome opts.OnClick then
                yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp ]
            children
