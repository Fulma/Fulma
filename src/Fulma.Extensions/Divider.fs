namespace Fulma.Extensions

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
[<System.ObsoleteAttribute("Fulma.Extensions is obselete please use Fulma.Extensions.Wikiki.Divider package instead")>]
module Divider =

    module Classes =
        let [<Literal>] Divider = "is-divider"
        let [<Literal>] IsVertical = "is-divider-vertical"

    type Option =
        | IsVertical
        | Label of string
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { IsVertical: bool
          Label : string option
          Props : IHTMLProp list
          CustomClass : string option }

        static member Empty =
            { IsVertical = false
              Label = None
              Props = []
              CustomClass = None }

    let divider (options : Option list) =

        let parseOptions (result: Options) opt =
            match opt with
            | IsVertical -> { result with IsVertical = true }
            | Label label -> { result with Label = Some label }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }


        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes "" [opts.CustomClass] [Classes.Divider, not opts.IsVertical; Classes.IsVertical, opts.IsVertical]
        let attrs =
            match opts.Label with
            | Some label -> classes:: (Data("content", label) :> IHTMLProp)::opts.Props
            | None -> classes::opts.Props
        div attrs [ ]
