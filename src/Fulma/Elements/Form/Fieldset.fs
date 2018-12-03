namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Fieldset =

    type Option =
        | CustomClass of string
        | Props of IHTMLProp list
        | Disabled of bool
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { CustomClass : string option
          Props : IHTMLProp list
          Disabled : bool
          Modifiers : string option list }

        static member Empty =
            { CustomClass = None
              Props = []
              Disabled = false
              Modifiers = [] }

    /// Generate <fieldset></fieldset>
    let fieldset (options : Option list) children =
        let parseOptions (result: Options ) =
            function
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }
            | Disabled value -> { result with Disabled = value }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes =
            Helpers.classes
                ""
                ( opts.CustomClass::opts.Modifiers )
                [ ]

        fieldset
            ( HTMLAttr.Disabled opts.Disabled :> IHTMLProp
                ::classes
                ::opts.Props )
            children
