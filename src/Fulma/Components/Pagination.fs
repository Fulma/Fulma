namespace Fulma.Components

open Fulma.BulmaClasses
open Fulma.Common
open Fable.Core
open Fable.Helpers.React
open Fable.Helpers.React.Props

[<RequireQualifiedAccess>]
module Pagination =

    module Types =

        type IAlignment =
            | Center
            | Right

        let ofAlignment =
            function
            | Center -> Bulma.Pagination.Alignment.Center
            | right -> Bulma.Pagination.Alignment.Right

        type Option =
            | Alignment of IAlignment
            | Size of ISize
            | CustomClass of string
            | Props of IHTMLProp list

        type Options =
            { Alignment : string option
              Size : string option
              CustomClass : string option
              Props : IHTMLProp list }

            static member Empty =
                { Alignment = None
                  Size = None
                  CustomClass = None
                  Props = [] }

        module Link =

            type Option =
                | IsCurrent
                | CustomClass of string
                | Props of IHTMLProp list

            type Options =
                { IsCurrent : bool
                  CustomClass : string option
                  Props : IHTMLProp list }

                static member Empty =
                    { IsCurrent = false
                      CustomClass = None
                      Props = [] }

    open Types

    let inline isSmall<'T> = Size IsSmall
    let inline isMedium<'T> = Size IsMedium
    let inline isLarge<'T> = Size IsLarge
    let inline isCentered<'T> = Alignment Center
    let inline isRight<'T> = Alignment Right
    let inline customClass x = CustomClass x
    let inline props x = Props x

    module Link =
        let inline isCurrent<'T> = Link.IsCurrent
        let inline customClass x = Link.CustomClass x
        let inline props x = Link.Props x

    let pagination (options: Option list) children =
        let parseOptions (result: Options) opt =
            match opt with
            | Alignment alignment -> { result with Alignment = ofAlignment alignment |> Some }
            | Size size -> { result with Size = ofSize size |> Some }
            | CustomClass customClass -> { result with CustomClass = Some customClass }
            | Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Options.Empty
        nav [ yield (ClassName (Helpers.generateClassName
                            Bulma.Pagination.Container
                            [ opts.Alignment; opts.Size ])) :> IHTMLProp
              yield! opts.Props ]
            children

    let previous (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Pagination.Previous [opts.CustomClass] []
        a (class'::opts.Props) children

    let next (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Pagination.Next [opts.CustomClass] []
        a (class'::opts.Props) children

    let link (options: Link.Option list) children =
        let parseOptions (result: Link.Options) opt =
            match opt with
            | Link.IsCurrent -> { result with IsCurrent = true }
            | Link.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Link.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Link.Options.Empty

        li [ ]
           [ a [ yield Helpers.classes Bulma.Pagination.Link [opts.CustomClass] [Bulma.Pagination.State.IsCurrent, opts.IsCurrent]
                 yield! opts.Props ]
               children ]

    let ellipsis (options: GenericOption list) =
        let opts = genericParse options

        li [ ]
           [ span [ yield Helpers.classes Bulma.Pagination.Ellipsis [opts.CustomClass] []
                    yield! opts.Props
                    yield (DangerouslySetInnerHTML { __html = "&hellip;" }) :> IHTMLProp ]
                  [ ] ]

    let list (options: GenericOption list) children =
        let opts = genericParse options
        let class' = Helpers.classes Bulma.Pagination.List [opts.CustomClass] []
        ul (class'::opts.Props) children
