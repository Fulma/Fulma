namespace Fulma.Layouts

open Fulma
open Fulma.BulmaClasses
open Fulma
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Hero =

    module Classes =
        let [<Literal>] Container = "hero"
        let [<Literal>] Head = "hero-head"
        let [<Literal>] Body = "hero-body"
        let [<Literal>] Foot = "hero-foot"
        module Video =
            let [<Literal>] Container = "hero-video"
            let [<Literal>] IsTransparent = "is-transparent"
        module Buttons =
            let [<Literal>] Container = "hero-buttons"
        module Style =
            let [<Literal>] IsBold = "is-bold"
        module Size =
            let [<Literal>] IsMedium = "is-medium"
            let [<Literal>] IsLarge = "is-large"
            let [<Literal>] IsHalfHeight = "is-halfheight"
            let [<Literal>] IsFullHeight = "is-fullheight"

    type Option =
        | IsBold
        | IsMedium
        | IsLarge
        | IsHalfHeight
        | IsFullHeight
        | Color of IColor
        | CustomClass of string
        | Props of IHTMLProp list

    type internal Options =
        { Props : IHTMLProp list
          IsBold : bool
          Size : string option
          Color : string option
          CustomClass : string option }

        static member Empty =
            { Props = []
              IsBold = false
              Size = None
              Color = None
              CustomClass = None }

    let hero (options : Option list) children =
        let parseOptions (result: Options ) opt =
            match opt with
            | Props props -> { result with Props = props }
            | IsMedium -> { result with Size = Classes.Size.IsMedium |> Some }
            | IsLarge -> { result with Size = Classes.Size.IsLarge |> Some }
            | IsHalfHeight -> { result with Size = Classes.Size.IsHalfHeight |> Some }
            | IsFullHeight -> { result with Size = Classes.Size.IsFullHeight |> Some }
            | Color color -> { result with Color = ofColor color |> Some }
            | IsBold -> { result with IsBold = true }
            | CustomClass customClass -> { result with CustomClass = Some customClass }

        let opts = options |> List.fold parseOptions Options.Empty
        let classes = Helpers.classes Classes.Container
                        [opts.Color; opts.Size; opts.CustomClass]
                        [Classes.Style.IsBold, opts.IsBold]
        section (classes::opts.Props) children

    let head (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Head [opts.CustomClass] []
        div (classes::opts.Props) children

    let body (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Body [opts.CustomClass] []
        div (classes::opts.Props) children

    let foot (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Foot [opts.CustomClass] []
        div (classes::opts.Props) children

    let video (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Video.Container [opts.CustomClass] []
        div (classes::opts.Props) children

    let buttons (options: GenericOption list) children =
        let opts = genericParse options
        let classes = Helpers.classes Classes.Buttons.Container [opts.CustomClass] []
        div (classes::opts.Props) children
