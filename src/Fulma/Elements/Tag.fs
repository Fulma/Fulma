namespace Fulma.Elements

open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Tag =

    module Classes =
        let [<Literal>] Container = "tag"
        let [<Literal>] IsDelete = "is-delete"
        module List =
            let [<Literal>] Container = "tags"
            let [<Literal>] HasAddons = "has-addons"
            let [<Literal>] IsCentered = "is-centered"
            let [<Literal>] IsRight = "is-right"

    type Option =
        | Size of ISize
        | Color of IColor
        /// Add `is-delete` class
        | IsDelete
        | Props of IHTMLProp list
        | CustomClass of string

    type internal Options =
        { Size : string option
          Color : string option
          IsDelete : bool
          Props : IHTMLProp list
          CustomClass : string option }
        static member Empty =
            { Size = None
              Color = None
              IsDelete = false
              Props = []
              CustomClass = None }

    /// Generate <span class="tag"></span>
    let tag (options : Option list) children =
        let parseOption (result : Options) opt =
            match opt with
            | Size IsSmall ->
                Fable.Import.Browser.console.warn("`is-small` is not a valid size for the tag element")
                result
            | Size size -> { result with Size = ofSize size |> Some }
            | IsDelete -> { result with IsDelete = true }
            | Color color -> { result with Color = ofColor color |> Some }
            | Props props -> { result with Props = props }
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }

        let opts = options |> List.fold parseOption Options.Empty
        let classes = Helpers.classes
                        Classes.Container
                        [ opts.Size; opts.Color; opts.CustomClass ]
                        [ Classes.IsDelete, opts.IsDelete ]
        span (classes::opts.Props)
            children

    /// Generate <span class="tag is-delete"></span>
    let delete options children = tag (IsDelete::options) children

    module List =

        type Option =
            /// Add `has-addons` class
            | HasAddons
            /// Add `is-centered` class
            | IsCentered
            /// Add `is-right` class
            | IsRight
            | Props of IHTMLProp list
            | CustomClass of string

        type internal Options =
            { HasAddons : bool
              IsCentered : bool
              IsRight : bool
              Props : IHTMLProp list
              CustomClass : string option }

            static member Empty =
                { HasAddons = false
                  IsCentered = false
                  IsRight = false
                  Props = [ ]
                  CustomClass = None }

    /// Generate <div class="tags"></div>
    let list (options : List.Option list) children =
        let parseOption (result : List.Options) opt =
            match opt with
            | List.HasAddons -> { result with HasAddons = true }
            | List.IsCentered -> { result with IsCentered = true }
            | List.IsRight -> { result with IsRight = true }
            | List.Props props -> { result with Props = props }
            | List.CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOption List.Options.Empty
        let classes = Helpers.classes
                        Classes.List.Container
                        [ opts.CustomClass ]
                        [ Classes.List.HasAddons, opts.HasAddons
                          Classes.List.IsCentered, opts.IsCentered
                          Classes.List.IsRight, opts.IsRight ]

        div (classes::opts.Props) children
