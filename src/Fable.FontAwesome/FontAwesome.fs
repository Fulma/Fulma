namespace Fable.FontAwesome

open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props

module internal Helpers =

    let classes std (options : string option list) (booleans: (string * bool) list) =
        let std = (std, options) ||> List.fold (fun complete opt ->
            match opt with Some name -> complete + " " + name | None -> complete)
        (std, booleans) ||> List.fold (fun complete (name, flag) ->
            if flag then complete + " " + name else complete)
        |> ClassName :> IHTMLProp

[<RequireQualifiedAccess>]
module Fa =

    module Classes =
        module Size =
            let [<Literal>] FaExtraSmall = "fa-xs"
            let [<Literal>] FaSmall = "fa-sm"
            let [<Literal>] FaLarge = "fa-lg"
            let [<Literal>] Fa2x = "fa-2x"
            let [<Literal>] Fa3x = "fa-3x"
            let [<Literal>] Fa4x = "fa-4x"
            let [<Literal>] Fa5x = "fa-5x"
            let [<Literal>] Fa6x = "fa-6x"
            let [<Literal>] Fa7x = "fa-7x"
            let [<Literal>] Fa8x = "fa-8x"
            let [<Literal>] Fa9x = "fa-9x"
            let [<Literal>] Fa10 = "fa-10x"

        module Style =
            let [<Literal>] FixedWidth = "fa-fw"
            let [<Literal>] IsLi = "fa-li"
            let [<Literal>] Border = "fa-border"
            let [<Literal>] Inverse = "fa-inverse"

        module Rotations =
            let [<Literal>] Rotate90 = "fa-rotate-90"
            let [<Literal>] Rotate180 = "fa-rotate-180"
            let [<Literal>] Rotate270 = "fa-rotate-270"

        module Flips =
            let [<Literal>] Horizontal = "fa-flip-horizontal"
            let [<Literal>] Vertical = "fa-flip-vertical"

        module Animations =
            let [<Literal>] Spin = "fa-spin"
            let [<Literal>] Pulse = "fa-pulse"

        module Pull =
            let [<Literal>] Right = "fa-pull-right"
            let [<Literal>] Left = "fa-pull-left"

        module Stack =

            let [<Literal>] Container = "fa-stack"

            module Size =
                let [<Literal>] Fa1x = "fa-stack-1x"
                let [<Literal>] Fa2x = "fa-stack-2x"

    type ISize =
        | FaExtraSmall
        | FaSmall
        | FaLarge
        | Fa2x
        | Fa3x
        | Fa4x
        | Fa5x
        | Fa6x
        | Fa7x
        | Fa8x
        | Fa9x
        | Fa10

    type IconOption =
        | Size of ISize
        | Border
        | PullLeft
        | PullRight
        | Inverse
        | Rotate90
        | Rotate180
        | Rotate270
        | FlipHorizontal
        | FlipVertical
        | IsLi
        | Icon of string
        | Spin
        | Pulse
        | Props of IHTMLProp list
        | CustomClass of string
        | FixedWidth
        | Stack1x
        | Stack2x

    let internal ofSize (size : ISize) =
        match size with
        | FaExtraSmall -> Classes.Size.FaExtraSmall
        | FaSmall -> Classes.Size.FaSmall
        | FaLarge -> Classes.Size.FaLarge
        | Fa2x -> Classes.Size.Fa2x
        | Fa3x -> Classes.Size.Fa3x
        | Fa4x -> Classes.Size.Fa4x
        | Fa5x -> Classes.Size.Fa5x
        | Fa6x -> Classes.Size.Fa6x
        | Fa7x -> Classes.Size.Fa7x
        | Fa8x -> Classes.Size.Fa8x
        | Fa9x -> Classes.Size.Fa9x
        | Fa10 -> Classes.Size.Fa10

    type IconOptions =
        { Icon : string option
          Size : string option
          Border : string option
          Pull : string option
          HaveSpin : bool
          HavePulse : bool
          Rotation : string option
          Flip : string option
          IsInverse : bool
          Props : IHTMLProp list
          FixedWidth : bool
          IsLi : bool
          StackSize : string option
          CustomClass : string option }

        static member Empty =
            { Icon = None
              Size = None
              Border = None
              Pull = None
              HaveSpin = false
              HavePulse = false
              Rotation = None
              Flip = None
              IsInverse = false
              Props = [ ]
              FixedWidth = false
              IsLi = false
              StackSize = None
              CustomClass = None }

    let toIconOptions (faOptions: IconOption list) =
        let parseOptions (result: IconOptions) (option: IconOption) =
            match option with
            | Size s ->
                { result with Size = ofSize s |> Some }
            | Border ->
                { result with Border = Some Classes.Style.Border }
            | PullLeft ->
                { result with Pull = Some Classes.Pull.Left }
            | PullRight ->
                { result with Pull = Some Classes.Pull.Right }
            | Inverse ->
                { result with IsInverse = true }
            | Icon faIcon ->
                { result with Icon = faIcon |> Some }
            | Rotate90 ->
                { result with Rotation = Classes.Rotations.Rotate90 |> Some }
            | Rotate180 ->
                { result with Rotation = Classes.Rotations.Rotate180 |> Some }
            | Rotate270 ->
                { result with Rotation = Classes.Rotations.Rotate270 |> Some }
            | FlipHorizontal ->
                { result with Rotation = Classes.Flips.Horizontal |> Some }
            | FlipVertical ->
                { result with Rotation = Classes.Flips.Vertical |> Some }
            | Spin ->
                { result with HaveSpin = true }
            | Pulse ->
                { result with HavePulse = true }
            | Props props ->
                { result with Props = props }
            | FixedWidth ->
                { result with FixedWidth = true }
            | IsLi ->
                { result with IsLi = true }
            | CustomClass customClass ->
                { result with CustomClass = Some customClass }
            | Stack1x ->
                { result with StackSize = Some Classes.Stack.Size.Fa1x }
            | Stack2x ->
                { result with StackSize = Some Classes.Stack.Size.Fa2x }

        faOptions |> List.fold parseOptions IconOptions.Empty

    /// Logic used to display one icon alone or as one item in an unordered list:
    let internal displayIcon baseElement baseClass (opts: IconOptions) children  =
        let classes =
            Helpers.classes baseClass
                [ opts.Icon
                  opts.Size
                  opts.Border
                  opts.Pull
                  opts.Rotation
                  opts.Flip
                  opts.CustomClass
                  opts.StackSize ]
                [ Classes.Style.FixedWidth, opts.FixedWidth
                  Classes.Style.IsLi, opts.IsLi
                  Classes.Animations.Pulse, opts.HavePulse
                  Classes.Animations.Spin, opts.HaveSpin
                  Classes.Style.Inverse, opts.IsInverse ]

        baseElement (classes::opts.Props)
          children

    let ul props children =
        ul [ ClassName "fa-ul" ]
            children

    let ol props children =
        ol [ ClassName "fa-ul" ]
            children

    let i (faOptions: IconOption list) children =
        let opts = toIconOptions faOptions
        displayIcon i "" opts children

    let span (faOptions: IconOption list) children =
        let opts = toIconOptions faOptions
        displayIcon span "" opts children

    module Stack =
        type Option =
            | Size of ISize
            | CustomClass of string
            | Props of IHTMLProp list

        type internal Options =
            { Size : string option
              Props : IHTMLProp list
              CustomClass : string option }

            static member Empty =
                { Size = None
                  Props = [ ]
                  CustomClass = None }


    let stack options children =
        let parseOption (result : Stack.Options) opt =
            match opt with
            | Stack.Size size ->
                { result with Size = ofSize size |> Some }
            | Stack.CustomClass customClass ->
                { result with CustomClass = Some customClass }
            | Stack.Props props ->
                { result with Props = props }

        let opts = options |> List.fold parseOption Stack.Options.Empty
        let classes = Helpers.classes
                        Classes.Stack.Container
                        ( opts.Size
                            :: opts.CustomClass
                            :: [] )
                        [ ]

        Fable.Helpers.React.span (classes::opts.Props)
            children
