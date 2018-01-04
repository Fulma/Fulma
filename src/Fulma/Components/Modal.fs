namespace Fulma.Components

open Fulma
open Fable.Import.React
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Modal =

    module Classes =
        let [<Literal>] Container = "modal"
        let [<Literal>] Background = "modal-background"
        let [<Literal>] Content = "modal-content"
        module State =
            let [<Literal>] IsActive = "is-active"

        module Close =
            let [<Literal>] Container = "modal-close"

        module Card =
            let [<Literal>] Container = "modal-card"
            let [<Literal>] Head = "modal-card-head"
            let [<Literal>] Foot = "modal-card-foot"
            let [<Literal>] Title = "modal-card-title"
            let [<Literal>] Body = "modal-card-body"

    type Option =
        | Props of IHTMLProp list
        | Active of bool
        | CustomClass of string

    type internal Options =
        { Props : IHTMLProp list
          IsActive : bool
          CustomClass : string option }

        static member Empty =
            { Props = []
              IsActive = false
              CustomClass = None }

    module Close =
        type Option =
            | Props of IHTMLProp list
            | Size of ISize
            | CustomClass of string
            | OnClick of (MouseEvent -> unit)

        type internal Options =
            { Props : IHTMLProp list
              Size : string option
              CustomClass : string option
              OnClick : (MouseEvent -> unit) option }

            static member Empty =
                { Props = []
                  Size = None
                  CustomClass = None
                  OnClick = None }

    let modal options children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Active state -> { result with IsActive = state }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ ]
                        [ Classes.State.IsActive, opts.IsActive ]
        div (classes::opts.Props)
            children

    let close (options : Close.Option list) children =
        let parseOptions (result: Close.Options ) opt =
            match opt with
            | Close.Props props -> { result with Props = props }
            | Close.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Close.Size IsSmall
            | Close.Size IsMedium ->
                Fable.Import.Browser.console.warn("`is-small` and `is-medium` are not valid sizes for 'modal close'")
                result
            | Close.Size size -> { result with Size = ofSize size |> Some }
            | Close.OnClick cb -> { result with OnClick = Some cb }

        let opts = options |> List.fold parseOptions Close.Options.Empty
        let classes = Helpers.classes Classes.Close.Container [opts.Size] []
        let opts =
            match opts.OnClick with
            | Some v -> classes::(DOMAttr.OnClick v :> IHTMLProp)::opts.Props
            | None -> classes::opts.Props

        button opts children

    let background (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Background [opts.CustomClass] []
        div (classes::opts.Props) children

    let content (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Content [opts.CustomClass] []
        div (classes::opts.Props) children

    module Card =

        let card (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Container [opts.CustomClass] []
            div (classes::opts.Props) children

        let head (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Head [opts.CustomClass] []
            header (classes::opts.Props) children

        let foot (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Foot [opts.CustomClass] []
            footer (classes::opts.Props) children

        let title (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Title [opts.CustomClass] []
            div (classes::opts.Props) children

        let body (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Body [opts.CustomClass] []
            section (classes::opts.Props) children
