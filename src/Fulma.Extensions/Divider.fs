namespace Fulma.Extensions

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props

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
            
        let ofStyles style =
            match style with
            | IsVertical -> Classes.IsVertical
            | value -> failwithf "%A isn't a valid style value" value


        type Options =
            { IsVertical: bool
              Label : string option
              Props : IHTMLProp list
              CustomClass : string option
            }
            static member Empty =
                { IsVertical = false
                  Label = None
                  Props = []
                  CustomClass = None }

    open Types

    // States
    let IsVertical =  IsVertical

    // Label and Value
    let label s = Label s

    // Extra
    let props props = Props props
    let customClass = CustomClass
    
    let onChange cb = OnChange cb

    let divider (options : Option list) children =


        let parseOptions (result: Options) opt =
            match opt with
            | IsVertical -> { result with IsVertical = true }
            | Label label -> { result with Label = Some label } 
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
        

        let opts = options |> List.fold parseOptions Options.Empty

        //div [ ClassName "field" ]
        div 
            [ yield classBaseList ""
                 [ Classes.Divider, not opts.IsVertical
                   Classes.IsVertical, opts.IsVertical
                   opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
              if opts.Label.IsSome then yield !!("data-content", opts.Label.Value) :> IHTMLProp
              yield! opts.Props 
            ]
            []
