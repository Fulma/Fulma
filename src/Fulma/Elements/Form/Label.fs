namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Label =

    module Classes =
        let [<Literal>] Container = "label"

    type Option =
        | Size of ISize
        /// Set `For` HTMLAttr
        | For of string
        | CustomClass of string
        | Props of IHTMLProp list

    type internal Options =
        { Size : string option
          HtmlFor : string option
          CustomClass : string option
          Props : IHTMLProp list }
        static member Empty =
            { Size = None
              HtmlFor = None
              CustomClass = None
              Props = [] }

    /// Generate <label class="label"></label>
    let label options children =
        let parseOptions (result : Options) =
            function
            | Size size -> { result with Size = ofSize size |> Some }
            | For htmlFor -> { result with HtmlFor = htmlFor |> Some }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Size; opts.CustomClass ]
                        [ ]
        label
            [ yield classes
              if Option.isSome opts.HtmlFor then yield HtmlFor opts.HtmlFor.Value :> IHTMLProp
              yield! opts.Props ]
            children
