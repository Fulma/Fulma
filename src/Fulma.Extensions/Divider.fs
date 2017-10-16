namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Divider =

    module Classes =
        let [<Literal>] Divider = "is-divider"
        let [<Literal>] IsVertical = "is-divider-vertical"


    module Types =
        type Option =
            | IsVertical
            | Label of string
            | Props of IHTMLProp list
            | CustomClass of string

        type Options =
            { IsVertical: bool
              Label : string option
              Props : IHTMLProp list
              CustomClass : string option }

            static member Empty =
                { IsVertical = false
                  Label = None
                  Props = []
                  CustomClass = None }

    open Types

    let IsVertical = IsVertical
    let label s = Label s
    let props props = Props props
    let customClass = CustomClass

    let divider (options : Option list) children =

        let parseOptions (result: Options) opt =
            match opt with
            | IsVertical -> { result with IsVertical = true }
            | Label label -> { result with Label = Some label }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }


        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield classList [ Classes.Divider, not opts.IsVertical
                                Classes.IsVertical, opts.IsVertical
                                opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              if opts.Label.IsSome then yield Data("content", opts.Label.Value)
              yield! opts.Props ] [ ]
