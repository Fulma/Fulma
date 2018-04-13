namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Radio =

    module Classes =
        let [<Literal>] Container = "radio"

    module Input =

        type Option =
            | CustomClass of string
            | Props of IHTMLProp list
            /// Set `Name` HTMLAtrr
            | Name of string

        type internal Options =
            { CustomClass : string option
              Props : IHTMLProp list
              Name : string option }

            static member Empty =
                { CustomClass = None
                  Props = []
                  Name = None }

    /// Generate <label class="radio"></label>
    let radio (options : GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        label (classes::opts.Props) children

    /// Generate <input class="radio" />
    let input (options : Input.Option list) =
        let parseOptions (result : Input.Options) option =
            match option with
            | Input.Name name -> { result with Name = Some name }
            | Input.CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Input.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Input.Options.Empty
        let classes = Helpers.classes Classes.Container [opts.CustomClass] []
        let t = Type "radio" :> IHTMLProp
        let attrs =
            match opts.Name with
            | Some name -> classes::t::(Name name :> IHTMLProp)::opts.Props
            | None -> classes::t::opts.Props

        input attrs
