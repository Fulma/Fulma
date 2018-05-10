namespace Fulma

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
        /// Add `is-active` class if true
        | IsActive of bool
        | CustomClass of string
        | Modifiers of Modifier.IModifier list

    type internal Options =
        { Props : IHTMLProp list
          IsActive : bool
          CustomClass : string option
          Modifiers : string option list }

        static member Empty =
            { Props = []
              IsActive = false
              CustomClass = None
              Modifiers = [] }

    module Close =
        type Option =
            | Props of IHTMLProp list
            | Size of ISize
            | CustomClass of string
            | OnClick of (MouseEvent -> unit)
            | Modifiers of Modifier.IModifier list

        type internal Options =
            { Props : IHTMLProp list
              Size : string option
              CustomClass : string option
              OnClick : (MouseEvent -> unit) option
              Modifiers : string option list }

            static member Empty =
                { Props = []
                  Size = None
                  CustomClass = None
                  OnClick = None
                  Modifiers = [] }

    /// Generate <div class="modal"></div>
    let modal options children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | IsActive state -> { result with IsActive = state }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        ( opts.CustomClass::opts.Modifiers )
                        [ Classes.State.IsActive, opts.IsActive ]
        div (classes::opts.Props)
            children

    /// Generate <button class="modal-close"></button>
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
            | Close.Modifiers modifiers -> { result with Modifiers = modifiers |> Modifier.parseModifiers }

        let opts = options |> List.fold parseOptions Close.Options.Empty
        let classes = Helpers.classes Classes.Close.Container ( opts.Size::opts.CustomClass::opts.Modifiers ) []
        let opts =
            match opts.OnClick with
            | Some v -> classes::(DOMAttr.OnClick v :> IHTMLProp)::opts.Props
            | None -> classes::opts.Props

        button opts children

    /// Generate <div class="modal-background"></div>
    let background (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Background ( opts.CustomClass::opts.Modifiers ) []
        div (classes::opts.Props) children

    /// Generate <div class="modal-content"></div>
    let content (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Content ( opts.CustomClass::opts.Modifiers ) []
        div (classes::opts.Props) children

    module Card =

        /// Generate <div class="modal-card"></div>
        let card (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Container ( opts.CustomClass::opts.Modifiers ) []
            div (classes::opts.Props) children

        /// Generate <div class="modal-card-head"></div>
        let head (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Head ( opts.CustomClass::opts.Modifiers ) []
            header (classes::opts.Props) children

        /// Generate <div class="modal-card-foot"></div>
        let foot (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Foot ( opts.CustomClass::opts.Modifiers ) []
            footer (classes::opts.Props) children

        /// Generate <div class="modal-card-title"></div>
        let title (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Title ( opts.CustomClass::opts.Modifiers ) []
            div (classes::opts.Props) children

        /// Generate <div class="modal-card-body"></div>
        let body (options: GenericOption list) children =
            let opts = genericParse options
            let classes = Helpers.classes Classes.Card.Body ( opts.CustomClass::opts.Modifiers ) []
            section (classes::opts.Props) children
