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

    let isSmall = Size IsSmall
    let isMedium = Size IsMedium
    let isLarge = Size IsLarge
    let isCentered = Alignment Center
    let isRight = Alignment Right
    let customClass = CustomClass
    let props = Props

    module Link =
        let isCurrent = Link.IsCurrent
        let customClass = Link.CustomClass
        let props = Link.Props

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

        a [ yield classBaseList Bulma.Pagination.Previous
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
            children

    let next (options: GenericOption list) children =
        let opts = genericParse options

        a [ yield classBaseList Bulma.Pagination.Next
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
            yield! opts.Props ]
            children

    let link (options: Link.Option list) children =
        let parseOptions (result: Link.Options) opt =
            match opt with
            | Link.IsCurrent -> { result with IsCurrent = true }
            | Link.CustomClass customClass -> { result with CustomClass = Some customClass }
            | Link.Props props -> { result with Props = props }

        let opts = options |> List.fold parseOptions Link.Options.Empty

        li [ ]
           [ a [ yield classBaseList Bulma.Pagination.Link
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome
                                    Bulma.Pagination.State.IsCurrent, opts.IsCurrent ] :> IHTMLProp
                 yield! opts.Props ]
               children ]

    let ellipsis (options: GenericOption list) =
        let opts = genericParse options

        li [ ]
           [ span [ yield classBaseList Bulma.Pagination.Ellipsis
                                  [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
                    yield! opts.Props
                    yield (DangerouslySetInnerHTML { __html = "&hellip;" }) :> IHTMLProp ]
                  [ ] ]

    let list (options: GenericOption list) children =
        let opts = genericParse options

        ul [ yield classBaseList Bulma.Pagination.List
                                 [ opts.CustomClass.Value, opts.CustomClass.IsSome ] :> IHTMLProp
             yield! opts.Props ]
            children
