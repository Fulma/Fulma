namespace Elmish.Bulma.Elements

open Elmish
open Elmish.Bulma.BulmaClasses
open Elmish.Bulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

module Delete =
    module Types =
        type Option =
            | Size of ISize
            | Props of IHTMLProp list
            | Classy of string
            | OnClick of (React.MouseEvent -> unit)

        type Options =
            { Size : string option
              Props : IHTMLProp list
              Classy : string option
              OnClick : (React.MouseEvent -> unit) option }
            static member Empty =
                { Size = None
                  Props = []
                  Classy = None
                  OnClick = None }

    open Types

    // Sizes
    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    // Extra props
    let props props = Props props
    let classy = Classy
    let onClick cb = OnClick cb

    let delete (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size size -> { result with Size = ofSize size |> Some }
            | Props props -> { result with Props = props }
            | Classy classy -> { result with Classy = Some classy }
            | OnClick cb -> { result with OnClick = cb |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        a [ yield ClassName (Helpers.generateClassName
                                bulma.Delete.Container [ opts.Size; opts.Classy ]) :> IHTMLProp
            yield! opts.Props
            if opts.OnClick.IsSome then
                yield DOMAttr.OnClick opts.OnClick.Value :> IHTMLProp ]
            children
