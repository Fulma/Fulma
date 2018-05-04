namespace Fulma

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Media =

    module Classes =
        let [<Literal>] Container = "media"
        let [<Literal>] Left = "media-left"
        let [<Literal>] Right = "media-right"
        let [<Literal>] Content = "media-content"
        module Size =
            let [<Literal>] IsLarge = "is-large"

    type Option =
        | Size of ISize
        | Props of IHTMLProp list
        | CustomClass of string
        | Modifiers of IModifier list

    type internal Options =
        { Size : string option
          Props : IHTMLProp list
          CustomClass : string option
          Modifiers : string option list }
        static member Empty =
            { Size = None
              Props = []
              CustomClass = None
              Modifiers = [] }

    /// Generate <article class="media"></article>
    let media (options: Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size IsSmall
            | Size IsMedium ->
                Fable.Import.Browser.console.warn("`is-small` and `is-medium` are not valid sizes for the media component")
                result
            | Size size -> { result with Size = ofSize size |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Modifiers modifiers -> { result with Modifiers = modifiers |> parseModifiers }

        let opts = options |> List.fold parseOption Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        (opts.Size::opts.CustomClass::opts.Modifiers)
                        [ ]
        article (classes::opts.Props) children

    /// Generate <div class="media-left"></div>
    let left (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Left (opts.CustomClass::opts.Modifiers) []
        figure (classes::opts.Props) children

    /// Generate <div class="media-right"></div>
    let right (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Right (opts.CustomClass::opts.Modifiers) []
        div (classes::opts.Props) children

    /// Generate <div class="media-content"></div>
    let content (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Content (opts.CustomClass::opts.Modifiers) []
        div (classes::opts.Props) children
