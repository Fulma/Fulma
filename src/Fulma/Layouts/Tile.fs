namespace Fulma.Layouts

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Core.JsInterop
open Fable.Helpers.React
open Fable.Helpers.React.Props
open Fable.Import

[<RequireQualifiedAccess>]
module Tile =

    module Types =

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
            | Is1 -> Bulma.Grid.Tile.Size.Is1
            | Is2 -> Bulma.Grid.Tile.Size.Is2
            | Is3 -> Bulma.Grid.Tile.Size.Is3
            | Is4 -> Bulma.Grid.Tile.Size.Is4
            | Is5 -> Bulma.Grid.Tile.Size.Is5
            | Is6 -> Bulma.Grid.Tile.Size.Is6
            | Is7 -> Bulma.Grid.Tile.Size.Is7
            | Is8 -> Bulma.Grid.Tile.Size.Is8
            | Is9 -> Bulma.Grid.Tile.Size.Is9
            | Is10 -> Bulma.Grid.Tile.Size.Is10
            | Is11 -> Bulma.Grid.Tile.Size.Is11
            | Is12 -> Bulma.Grid.Tile.Size.Is12

        type IContext =
            | IsChild
            | IsAncestor
            | IsParent

        let ofContext =
            function
            | IsChild -> Bulma.Grid.Tile.IsChild
            | IsAncestor -> Bulma.Grid.Tile.IsAncestor
            | IsParent -> Bulma.Grid.Tile.IsParent

        type Option =
            | Size of ISize
            | CustomClass of string
            | Props of IHTMLProp list
            | Context of IContext
            | IsVertical

        type Options =
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

    open Types

    let isChild = Context IsChild
    let isParent = Context IsParent
    let isAncestor = Context IsAncestor
    let is1 = Size Is1
    let is2 = Size Is2
    let is3 = Size Is3
    let is4 = Size Is4
    let is5 = Size Is5
    let is6 = Size Is6
    let is7 = Size Is7
    let is8 = Size Is8
    let is9 = Size Is9
    let is10 = Size Is10
    let is11 = Size Is11
    let is12 = Size Is12
    let isVertical = IsVertical
    let customClass = CustomClass
    let props = Props

    let tile (options: Option list) children =
        let parseOptions (result: Options) =
            function
            | CustomClass customClass -> { result with CustomClass = customClass |> Some }
            | Props props -> { result with Props = props }
            | Size size -> { result with Size = ofSize size |> Some }
            | Context context -> { result with Context = ofContext context |> Some }
            | IsVertical -> { result with IsVertical = true }

        let opts = options |> List.fold parseOptions Options.Empty

        div [ yield Helpers.classes
                        Bulma.Grid.Tile.Container
                        [opts.CustomClass; opts.Context; opts.Size]
                        [Bulma.Grid.Tile.IsVertical, opts.IsVertical]
              yield! opts.Props ]
            children

    let parent (options: Option list) children =
        tile (isParent :: options) children

    let child (options: Option list) children =
        tile (isChild :: options) children

    let ancestor (options: Option list) children =
        tile (isAncestor :: options) children
