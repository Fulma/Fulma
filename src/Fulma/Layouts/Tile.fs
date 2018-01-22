namespace Fulma.Layouts

open Fulma
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Tile =

    module Classes =
        let [<Literal>] Container = "tile"
        let [<Literal>] IsAncestor = "is-ancestor"
        let [<Literal>] IsChild = "is-child"
        let [<Literal>] IsParent = "is-parent"
        let [<Literal>] IsVertical = "is-vertical"

        module Size =
            let [<Literal>] Is1 = "is-1"
            let [<Literal>] Is2 = "is-2"
            let [<Literal>] Is3 = "is-3"
            let [<Literal>] Is4 = "is-4"
            let [<Literal>] Is5 = "is-5"
            let [<Literal>] Is6 = "is-6"
            let [<Literal>] Is7 = "is-7"
            let [<Literal>] Is8 = "is-8"
            let [<Literal>] Is9 = "is-9"
            let [<Literal>] Is10 = "is-10"
            let [<Literal>] Is11 = "is-11"
            let [<Literal>] Is12 = "is-12"

    type ISize =
        | Is1
        | Is2
        | Is3
        | Is4
        | Is5
        | Is6
        | Is7
        | Is8
        | Is9
        | Is10
        | Is11
        | Is12

    let ofSize =
        function
        | Is1 -> Classes.Size.Is1
        | Is2 -> Classes.Size.Is2
        | Is3 -> Classes.Size.Is3
        | Is4 -> Classes.Size.Is4
        | Is5 -> Classes.Size.Is5
        | Is6 -> Classes.Size.Is6
        | Is7 -> Classes.Size.Is7
        | Is8 -> Classes.Size.Is8
        | Is9 -> Classes.Size.Is9
        | Is10 -> Classes.Size.Is10
        | Is11 -> Classes.Size.Is11
        | Is12 -> Classes.Size.Is12

    type Option =
        | Size of ISize
        | CustomClass of string
        | Props of IHTMLProp list
        /// Add `is-child` class
        | IsChild
        /// Add `is-ancestor` class
        | IsAncestor
        /// Add `is-parent` class
        | IsParent
        /// Add `is-vertical` class
        | IsVertical

    type internal Options =
        { Size : string option
          IsVertical : bool
          CustomClass : string option
          Props : IHTMLProp list
          Context : string option }

        static member Empty =
            { Size = None
              IsVertical = false
              CustomClass = None
              Props = []
              Context = None }

    /// Generate <div class="title"></div>
    let tile (options: Option list) children =
        let parseOptions (result: Options) =
            function
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | Size size -> { result with Size = ofSize size |> Some }
            | IsChild -> { result with Context = Classes.IsChild |> Some }
            | IsAncestor -> { result with Context = Classes.IsAncestor |> Some }
            | IsParent -> { result with Context = Classes.IsParent |> Some }
            | IsVertical -> { result with IsVertical = true }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield Helpers.classes
                        Classes.Container
                        [opts.CustomClass; opts.Context; opts.Size]
                        [Classes.IsVertical, opts.IsVertical]
              yield! opts.Props ]
            children

    /// Generate <div class="title is-parent"></div>
    let parent (options: Option list) children =
        tile (IsParent :: options) children

    /// Generate <div class="title is-child"></div>
    let child (options: Option list) children =
        tile (IsChild :: options) children

    /// Generate <div class="title is-ancestor"></div>
    let ancestor (options: Option list) children =
        tile (IsAncestor :: options) children
