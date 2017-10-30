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

    let inline isChild<'T> = Context IsChild
    let inline isParent<'T> = Context IsParent
    let inline isAncestor<'T> = Context IsAncestor
    let inline is1<'T> = Size Is1
    let inline is2<'T> = Size Is2
    let inline is3<'T> = Size Is3
    let inline is4<'T> = Size Is4
    let inline is5<'T> = Size Is5
    let inline is6<'T> = Size Is6
    let inline is7<'T> = Size Is7
    let inline is8<'T> = Size Is8
    let inline is9<'T> = Size Is9
    let inline is10<'T> = Size Is10
    let inline is11<'T> = Size Is11
    let inline is12<'T> = Size Is12
    let inline isVertical<'T> = IsVertical
    let inline customClass x = CustomClass x
    let inline props x = Props x

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
